  PRO main_ch_retrieve,chtableinpath=chtableinpath,inputFiles=inputFiles,chimageoutpath=chimageoutpath,Message=Message
  compile_opt idl2
;  Result = DIALOG_MESSAGE(chimageoutpath)
  ;实现功能：利用已经建立好的查找表来反演叶绿素的含量
  ;chtableinpath:已经建立好的查找表的输入
  ;inputfiles:输入的若干个影像文件，影像要求：经过预处理（几何纠正、辐射定标、大气纠正、裁剪）后的环境星CCD数据的输入
  ;chimageoutpath：输出叶绿素含量分布图的存放路径
  ;用Cab ALA Lai Hspot Ns五个参数来反演
;  print,systime()
  ;读取模拟的反射率数据
  Simref= fltarr(7,file_lines(chtableinpath))  ;7表示数组有几列
  OPENR,table,chtableinpath,/get_lun
  readf,table,Simref
  free_lun,table
  ;读取tiff影像
  N_inputFiles=N_ELEMENTS(inputFiles);读取输入影像文件的个数
  
   ;ENVI进度条
  ENVI,/restore_base_save_files
  ENVI_BATCH_INIT
  ;初始化进度条
  ENVI_REPORT_INIT, '数据处理中…', $
  title="进度条", $
  base=base ,/INTERRUPT
  ENVI_REPORT_INC, base,N_inputFiles
  
  
  for n=0,N_inputFiles-1 do begin
    data = read_tiff(inputFiles[n],geotiff = geotiff)
    ;data 为int[4,1726,874]意为4列  1726行  874层
    blue = reform(data[0,*,*])/10000.0<1>0
    green = reform(data[1,*,*])/10000.0<1>0
    red = reform(data[2,*,*])/10000.0<1>0
    nir = reform(data[3,*,*])/10000.0<1>0
    NDVI=(nir-red)/(nir+red+0.00000001)
    dims = size(blue,/dimensions)
    result = fltarr(dims[0],dims[1])
    for i=0,dims[0]-1 do begin
      for j=0,dims[1]-1 do begin
         if Blue[i,j] GE 1 OR Green[i,j] GE 1 OR Red[i,j] GE 1 OR nir[i,j] GE 1 then continue
         if Blue[i,j] LE 0 OR Green[i,j] LE 0 OR Red[i,j] LE 0 OR nir[i,j] LE 0 then continue  
         if NDVI[i,j] EQ 0 then continue 
         cost=sqrt(((Green[i,j]-Simref[5,*])^2+(Red[i,j]-Simref[6,*])^2)/2.0)                  ;代价函数
         order=sort(cost);                                                                     ;将代价函数计算结果排序
         result[i,j]=total(Simref[0,order[0:1999]])/2000.0                                     ;将前20%的数据的平均值作为最后结果
      endfor
    endfor
    ENVI_REPORT_STAT,base, n, float(N_inputFiles), CANCEL=cancelvar
        ;判断是否点击取消
        IF cancelVar EQ 1 THEN BEGIN
         ; tmp = DIALOG_MESSAGE('点击了取消'+'%'+STRING(Tn),/info)
          ENVI_REPORT_INIT, base=base, /finish
          return
          ENVI_BATCH_EXIT
          ENDIF
          
    write_tiff,chimageoutpath,result,geotiff = geotiff,/float
  ;  print,systime()
  endfor
  ENVI_REPORT_INIT, base=base, /finish
  Message=''
  end

;  pro test_main_ch_retrieve
;  chtableinpath='D:\xujin\test\CCDA1chtable.txt'
;  inputFiles='D:\xujin\Inversion pro\XJdata\CCD_7_tiff\hj1a-ccd2-447-56-20110826-l20000600736_hx_geo_ref_crop.tif'
;  chimageoutpath='D:\xujin\test'
;  main_ch_retrieve,chtableinpath=chtableinpath,inputFiles=inputFiles,chimageoutpath=chimageoutpath,Message=Message
;  end