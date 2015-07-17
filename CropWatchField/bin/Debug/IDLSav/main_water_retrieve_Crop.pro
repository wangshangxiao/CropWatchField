  PRO main_water_retrieve_Crop,watertableinpath=watertableinpath,CropType=CropType,$
      inputFiles=inputFiles,waterimageoutpath=waterimageoutpath,$
      Image_crop_inputpath=Image_crop_inputpath,Message=Message
    ;实现功能：利用查找表方法来反演水含量,用Cw ALA Hspot Cm Ns五个参数来反演
    ;waterfindtablepath:已经建立好的查找表的输入
    ;inputfiles:输入的若干个影像文件，影像要求：经过预处理（几何纠正、辐射定标、大气纠正、裁剪）后的环境星IRS数据的输入
    ;ouputwaterpath：输出叶绿素含量分布图的存放路径
    compile_opt idl2
    ENVI,/RESTORE_BASE_SAVE_FILES
    ENVI_BATCH_INIT 
    print,systime()
    ;读取查找表的行数
    Lines=file_lines(watertableinpath)
    ;读取查找表的列数
    StringArray = strarr(Lines);
    OPENR, lun, watertableinpath, /GET_LUN
    READF, lun, StringArray
    FREE_LUN, lun
    StringArray0=strsplit(StringArray[0], ' ', /EXTRACT)
    col_lines=N_elements(StringArray0)
    ;--------------------------------------
    Simref= fltarr(col_lines,Lines)
    OPENR,table,watertableinpath,/get_lun
    readf,table,Simref
    free_lun,table
    ;读取农作物参考影像
    dataCrop = read_tiff(Image_crop_inputpath,geotiff = geotiff)
    Case (CropType) of
      ;maize玉米
      'Maize' : begin
        Crop_Type=1
      End
      'Soybean' : begin
        Crop_Type=2
      End
      'Wheat' : begin
        Crop_Type=3
      End
      'Other' : begin
        Crop_Type=4
      End
    EndCase
    ;读取tiff影像的个数
    N_inputFiles=N_ELEMENTS(inputFiles);读取输入影像文件的个数
      ;检查影像是否符合条件
    ENVI_OPEN_FILE,Image_crop_inputpath,r_fid=Refer_fid
    ENVI_FILE_QUERY,Refer_fid,ns=Refer_ns,nl=Refer_nl,dims=Refer_dims
    ImageRefer_PRJ=ENVI_GET_PROJECTION(fid=Refer_fid)
    Map_info_Refer=ENVI_GET_MAP_INFO(fid=Refer_fid)    
   FOR j=0,N_inputFiles-1 DO BEGIN
     ;获取影像的投影信息,其中：fid代表file的ID，ns表示列数，nl表示行数，dims表示行列号
     ENVI_OPEN_FILE,inputFiles[j],r_fid=Image_fid
     ENVI_FILE_QUERY,Image_fid,ns=Image_ns,nl=Image_nl,dims=Image_dims,nb=Image_nb
     ;获取输入文件影像信息
     Map_info_Image=ENVI_GET_MAP_INFO(fid=Image_fid)
     ;读取影像的投影信息
     ImageInput_PRJ=ENVI_GET_PROJECTION(fid=Image_fid)
     ;读取影像的像素大小
     if Map_info_Image.PS[0] NE Map_info_Refer.PS[0] || Map_info_Image.PS[1] $
       NE Map_info_Refer.PS[1] then begin
       Message='与参考影像的像素值不同，请进行重采样！  '
       RETURN
     ENDIF
     if Map_info_Image.PS[0] NE Map_info_Image.PS[1] then begin
       Message='请重采样为方形像素！  '
       RETURN
     ENDIF
     if ImageInput_PRJ.NAME NE ImageRefer_PRJ.NAME then begin
       Message='两者投影不一致,请进行重投影！  '
       RETURN
     ENDIF
   ENDFOR
    ;读取农作物的索引
    index_Crop=where(dataCrop EQ Crop_Type)
    N_index_Crop=N_elements(index_Crop)
    ;ENVI外部进度条------------------------
    ENVI,/restore_base_save_files
    ENVI_BATCH_INIT
    ;初始化进度条
    ENVI_REPORT_INIT, '数据处理中…', $
      title="总进度条", $
      base=base ,/INTERRUPT
    ENVI_REPORT_INC, base,N_inputFiles
    ;--------------------------------
    for n=0,N_inputFiles-1 do begin
      data = read_tiff(inputFiles[n],geotiff = geotiff)
      ;data 为int[4,1726,874]意为4列  1726行  874层
      Nir_IRS = reform(data[0,*,*]);/10000.0
      SW_IRS = reform(data[1,*,*]);/10000.0
      ;读取某波段的行列数
      dims = size(dataCrop,/dimensions)
      result = fltarr(dims[0],dims[1])
      Nir_IRS_Index=Nir_IRS[index_Crop]
      SW_IRS_Index=SW_IRS[index_Crop]
      result_Index=result[index_Crop]
      ;内部进度条------------------------------
      ENVI,/restore_base_save_files
      ENVI_BATCH_INIT
      ;初始化进度条
      ENVI_REPORT_INIT, '数据处理中_内部…', $
        title="子进度条", base=base_iner ,/INTERRUPT
      ENVI_REPORT_INC , base_iner, N_index_Crop
      ;------------------------------------
      for i=0,N_index_Crop-1 do begin
          ;增加限制条件，较少运行时间
          if Nir_IRS_Index[i] LE 0 OR Nir_IRS_Index[i] GE 1 then continue
          if SW_IRS_Index[i] LE 0 OR SW_IRS_Index[i] GE 1 then continue
          cost=sqrt(((Nir_IRS_Index[i]-Simref[5,*])^2+(SW_IRS_Index[i]-Simref[6,*])^2)/2.0);代价函数
          order=sort(cost)                                                                      ;将代价函数计算结果排序
;          result[i,j]=total(Simref[0,order[0:1999]])/2000.0                                     ;将前20%的数据的平均值作为最后结果
          result_Index[i]=total(Simref[0,order[0:9]])/10.0    
       ;判断子进度条是否点击取消--------
       ENVI_REPORT_STAT, base_iner, i, float(N_index_Crop), CANCEL=cancelvar_iner
        IF cancelvar_iner EQ 1 THEN BEGIN
          ;tmp = DIALOG_MESSAGE('点击了取消'+'%'+STRING(Tn),/info)
          ENVI_REPORT_INIT, base=base_iner, /finish
          Break
          ENVI_BATCH_EXIT
        ENDIF
        ;判断总进度条是否点击取消
        ENVI_REPORT_STAT,base, n, float(N_inputFiles), CANCEL=cancelvar
        IF cancelVar EQ 1 THEN BEGIN
          ;tmp = DIALOG_MESSAGE('点击了取消'+'%'+STRING(Tn),/info)
          ENVI_REPORT_INIT, base=base, /finish
          Break
          ENVI_BATCH_EXIT
        ENDIF
      ;内部进度条结束--------------------------------
      endfor
      ENVI_REPORT_INIT, base=base_iner, /finish
      ENVI_BATCH_EXIT
      result[index_Crop]=result_Index
     write_tiff,waterimageoutpath,result,geotiff = geotiff,/float
    endfor
    ENVI_REPORT_INIT, base=base, /finish
    ENVI_BATCH_EXIT
    Message=''
  end
  
  pro test_main_water_retrieve_Crop
    watertableinpath='D:\02_HongXing\05_software\Estimation_ch_water\testdata\IRSwatertable.txt'
    inputFiles='D:\02_HongXing\05_software\Estimation_ch_water\testdata\hj1b-irs-452-56-20110826-l20000595422_repro_Cut.tif'
    Image_crop_inputpath='D:\02_HongXing\05_software\Estimation_ch_water\testdata\hongxing_2013_Geo_GIS.tif'
    waterimageoutpath='D:\02_HongXing\05_software\Estimation_ch_water\testdata\test_water.tif'
    CropType='Soybean'
    main_water_retrieve_Crop,watertableinpath=watertableinpath,CropType=CropType,$
      inputFiles=inputFiles,waterimageoutpath=waterimageoutpath,$
      Image_crop_inputpath=Image_crop_inputpath,Message=Message
    print,systime()
  end