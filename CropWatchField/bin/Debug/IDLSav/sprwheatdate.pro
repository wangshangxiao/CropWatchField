  Pro SprwheatDate,CCDImageInputpath=CCDImageInputpath,IRSImageInputpath=IRSImageInputpath,Sprwheatoutpath=Sprwheatoutpath,Message=Message
  compile_opt idl2
  ;距离成熟期越近日期的影像计算结果越好
  ;读取影像数据
  dataCCD = read_tiff(CCDImageInputpath,geotiff = geotiff)
  dataIRS = read_tiff(IRSImageInputpath,geotiff = geotiff)
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
    CCD=1
    Starttime=CCDTime
   endif else begin
    ImageTime=RIRSTime
    CCD=0
    Starttime=IRSTime
  endelse

  ;CCD数据的band3和band4
   redCCD = reform(dataCCD[2,*,*])/10000.0<1>0
   nirCCD = reform(dataCCD[3,*,*])/10000.0<1>0
  ;IRS数据的band1和band2
   nirIRS = reform(dataIRS[0,*,*])/10000.0<1>0
   mirIRS = reform(dataIRS[1,*,*])/10000.0<1>0
   index1=where(redCCD EQ 1)
   index2=where(nirCCD EQ 1)
   index3=where(nirIRS EQ 1)
   index4=where(mirIRS EQ 1)
   redCCD[index1]=0
   nirCCD[index2]=0
   nirIRS[index3]=0
   mirIRS[index4]=0
   NDVI = (nirCCD-redCCD)/(nirCCD+redCCD+0.00000001)
   NDWI = (nirIRS-mirIRS)/(nirIRS+mirIRS+0.00000001)
   SprwheatMD=4.243+33.89*NDVI+7.52*NDWI
   index5=where(SprwheatMD EQ 4.243)
   SprwheatMD[index5]=0
   SprwheatMD=long(SprwheatMD*10)
   SprwheatMD=FLOAT(SprwheatMD)/10
;   write_tiff,Sprwheatoutpath+'\'+'距离春小麦'+Starttime+'成熟期天数预测.tif',SprwheatMD,geotiff = geotiff,/float
   write_tiff,Sprwheatoutpath,SprwheatMD,geotiff = geotiff,/float
   Message=''
   end
  
  pro Test_SprwheatDate
  CCDImageInputpath='D:\3_HongXing\DATA\0_RSDATA\DTFDATA\CCD_7_tiff\hj1a-ccd2-447-56-20110826-l20000600736_hx_geo_ref_crop.tif'
  IRSImageInputpath='D:\3_HongXing\DATA\0_RSDATA\DTFDATA\IRS_7_tiff\hj1b-irs-452-56-20110829-l20000602167_all_subset_1_geo_ref_resize_crop.tif'
  Soybeanoutpath='D:\7_test'
  SprwheatDate,CCDImageInputpath=CCDImageInputpath,IRSImageInputpath=IRSImageInputpath,Sprwheatoutpath=Sprwheatoutpath,Message=Message

  End