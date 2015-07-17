  Pro SprwheatMD,CCDImageInputpath=CCDImageInputpath,IRSImageInputpath=IRSImageInputpath,$
      Sprwheatoutpath=Sprwheatoutpath,Image_crop_inputpath=Image_crop_inputpath,Message=Message
    compile_opt idl2
    ;result1=dialog_message(CCDImageInputpath,/information)
    ;距离成熟期越近日期的影像计算结果越好
    ;读取影像数据
    ;读取作物分布图，其中1代表玉米2代表大豆3小麦4其他和大麦
    ;读取输入CCD和IRS影像的个数
    N_CCDinputFiles=N_ELEMENTS(CCDImageInputpath)
    N_IRSinputFiles=N_ELEMENTS(IRSImageInputpath)
    if N_CCDinputFiles NE N_IRSinputFiles then begin
      Message='两幅影像个数不同，请重新选择！'
      Return
    endif
    for n_CCD=0,N_CCDinputFiles-1 do begin
      dataCrop = read_tiff(Image_crop_inputpath,geotiff = geotiff)
      dataCCD = read_tiff(CCDImageInputpath[n_CCD],geotiff = geotiff)
      dataIRS = read_tiff(IRSImageInputpath[n_CCD],geotiff = geotiff)
      ;判断两幅影像的行列数是否一致
      dimsCCD=size(dataCCD,/DIMENSIONS)
      dimsIRS=size(dataIRS,/DIMENSIONS)
      if dimsCCD[1] NE dimsIRS[1] || dimsCCD[2] NE dimsIRS[2] then begin
        Message='两幅影像行列数不同，请重新裁剪！'
        Return
      endif
      ;读取影像文件名
      CCDfilename=FILE_BASENAME(CCDImageInputpath,'.tif',/FOLD_CASE)
      IRSfilename=FILE_BASENAME(IRSImageInputpath,'.tif',/FOLD_CASE)
      ;提取影像获取时间
      CCDfilenames=strsplit(CCDfilename,'-',/EXTRACT,/REGEX)
      IRSfilenames=strsplit(IRSfilename,'-',/EXTRACT,/REGEX)
      CCDTime=CCDfilenames[4]
      IRSTime=IRSfilenames[4]
      CCDTimelength=strlen(CCDTime)
      IRSTimelength=strlen(IRSTime)     
      if CCDTimelength NE 8 || IRSTimelength NE 8 || $
        CCDTime LT 10000000 || CCDTime GT 90000000 || IRSTime LT 10000000 || IRSTime GT 90000000 then begin
        Message='获取影像日期错误！'
        Return
      endif
      ;提取年月日
      CCDYear=Strmid(CCDTime,0,4)
      CCDMonth=Strmid(CCDTime,4,2)
      CCDDay=Strmid(CCDTime,6,2)
      IRSYear=Strmid(IRSTime,0,4)
      IRSMonth=Strmid(IRSTime,4,2)
      IRSDay=Strmid(IRSTime,6,2)
      ;比较影像获取时间
      RCCDTime=JULDAY(CCDMonth,CCDDay,CCDYear)
      RIRSTime=JULDAY(IRSMonth,IRSDay,IRSYear)
      if RCCDTime GE RIRSTime then begin
        ImageTime=RCCDTime
        ;CCD的值是1表示所取时间是按照CCD影像的值来计算的
        CCD=1
        Starttime=CCDTime
      endif else begin
        ImageTime=RIRSTime
        CCD=0
        Starttime=IRSTime
      endelse     
      ;CCD数据的band3和band4
      redCCD = reform(dataCCD[2,*,*]);/10000.0<1>0
      nirCCD = reform(dataCCD[3,*,*]);/10000.0<1>0
      dims=size(dataCrop,/DIMENSIONS)
      NDVI=fltarr(dims)
      NDWI=fltarr(dims)
      ;IRS数据的band1和band2
      nirIRS = reform(dataIRS[0,*,*]);/10000.0<1>0
      mirIRS = reform(dataIRS[1,*,*]);/10000.0<1>0
      ;即取作物分布图中的春小麦
      index_soybean=where(dataCrop EQ 3)  
      NDVI[index_soybean] = (nirCCD[index_soybean]-redCCD[index_soybean])/$
        (nirCCD[index_soybean]+redCCD[index_soybean]+0.00000001)
      NDWI[index_soybean] = (nirIRS[index_soybean]-mirIRS[index_soybean])/$
        (nirIRS[index_soybean]+mirIRS[index_soybean]+0.00000001)
      SprwheatMDate=4.243+33.89*NDVI+7.52*NDWI
      index5=where(SprwheatMDate EQ 4.243)
      SprwheatMDate[index5]=0
      SprwheatMDate=reform(SprwheatMDate,[dims])
      write_tiff,Sprwheatoutpath,SprwheatMDate,geotiff = geotiff,/float
    endfor
    Message=''  
  end
  
  pro Test_SprwheatMD
    Image_crop_inputpath='D:\02_HongXing\2_vector\01_hongxing_2013\hongxing_2013_Geo_GIS.tif'
    CCDImageInputpath='D:\10_test\fusion\test\hj1b-ccd2-446-56-20110816-l20000595422_albers105_sub_geo_sub_repro_Cut.tif'
    IRSImageInputpath='D:\10_test\fusion\test\hj1b-irs-452-56-20110826-l20000595422_repro_Cut.tif'
    Sprwheatoutpath='D:\10_test\fusion\test\test.tif'
    SprwheatMD,CCDImageInputpath=CCDImageInputpath,IRSImageInputpath=IRSImageInputpath,$
      Sprwheatoutpath=Sprwheatoutpath,Image_crop_inputpath=Image_crop_inputpath,Message=Message
      
  End