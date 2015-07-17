  PRO main_water_retrieve,watertableinpath=watertableinpath,inputFiles=inputFiles,waterimageoutpath=waterimageoutpath,Message=Message
;  Result1 = DIALOG_MESSAGE(waterimageoutpath)
  ;实现功能：利用查找表方法来反演水含量,用Cw ALA Hspot Cm Ns五个参数来反演
  ;waterfindtablepath:已经建立好的查找表的输入
  ;inputfiles:输入的若干个影像文件，影像要求：经过预处理（几何纠正、辐射定标、大气纠正、裁剪）后的环境星IRS数据的输入
  ;ouputwaterpath：输出叶绿素含量分布图的存放路径
  ;print,systime()
  ;读取模拟的反射率数据
  Simref= fltarr(7,file_lines(watertableinpath))        ;7表示数组有几列
  OPENR,table,watertableinpath,/get_lun
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
  band1 = reform(data[0,*,*])/10000.0
  band2 = reform(data[1,*,*])/10000.0
  dims = size(band1,/dimensions)
  result = fltarr(dims[0],dims[1])
  for i=0,dims[0]-1 do begin
    for j=0,dims[1]-1 do begin
      if band1[i,j] GE 1 OR band2[i,j] GE 1  then continue
      if band1[i,j] LE 0 OR band1[i,j] LE 0  then continue  ;增加限制条件，较少运行时间
      cost=sqrt(((band1[i,j]-Simref[5,*])^2+(band2[i,j]-Simref[6,*])^2)/2.0);代价函数
      order=sort(cost)                                                                      ;将代价函数计算结果排序
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
  
  write_tiff,waterimageoutpath,result,geotiff = geotiff,/float
  endfor
  ENVI_REPORT_INIT, base=base, /finish
;  print,systime()
   Message=''
  end

;  pro test_main_water_retrieve
;  watertableinpath='D:\xujin\test\IRSwatertable.txt'
;  inputFiles='D:\xujin\Inversion pro\XJdata\IRS_7_tiff\hj1b-irs-452-56-20110829-l20000602167_all_subset_1_geo_ref_resize_crop.tif'
;  waterimageoutpath='D:\xujin\test'
;  main_water_retrieve,watertableinpath=watertableinpath,inputFiles=inputFiles,waterimageoutpath=waterimageoutpath,Message=Message
;  end