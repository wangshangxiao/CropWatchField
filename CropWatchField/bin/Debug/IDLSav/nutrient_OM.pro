;说明：
;HJFilenames----hj星文件名
;OberFilename----观测文件
;OutputPath----输出路径
;Histogram----观测文件是否符合正态分布

pro Nutrient_OM,HJFilenames,ObserFilename,OutputPath,sHistogram,Message=Message
  ;test
;    HJFilenames = 'D:\02_HongXing\04_system\HX_TestData\Nutrient\direct_Inversion\IN\hj1a-ccd2-447-56-20110826-l20000600736_hx_geo_repro_subset.tif'
;    ObserFilename = 'D:\02_HongXing\04_system\HX_TestData\Nutrient\direct_Inversion\IN\om.txt'
;    OutputPath = 'D:\02_HongXing\04_system\HX_TestData\Nutrient\direct_Inversion\OUT\'
;    sHistogram = 'true'

  compile_opt idl2
  ENVI,/RESTORE_BASE_SAVE_FILES
  ENVI_BATCH_INIT
  
;  result0=dialog_message('dddd',/information)
  ;检测输出路径
  if strmid(OutputPath,strlen(OutputPath)-1,1) ne '\' then begin
    OutputPath = OutputPath+'\'
  endif
  test_file = file_test(OutputPath,/directory)
  if test_file eq 0 then begin
    file_mkdir,OutputPath
  endif
  ;读入观测数据
  lines = file_lines(ObserFilename)
  ;=dialog_message(string(lines))
  ObserData = fltarr(lines)
  openr,lun,ObserFilename,/get_lun
  readf,lun,ObserData
  free_lun,lun
  ;r=dialog_message((HJFilenames[0]))
  ;文件数
  NFiles = n_elements(HJFilenames)
  ;批处理
  ENVI_REPORT_INIT,'批处理中...',$
    title='土壤有机质估算',base=base,/interrupt
  ENVI_REPORT_INC,BASE,1
  
  FOR i=0,NFiles-1 do begin
    HJData = read_tiff(HJFilenames[i],geotiff=geotiff)
    result = QUERY_TIFF(HJFilenames[i],ImgInfo)
    ns = imginfo.DIMENSIONS[0]
    nl = imginfo.DIMENSIONS[1]
    ;利用模型计算有机质含量
    OMData = 6+122.5*HJData[0,*,*]-107.1*HJData[2,*,*]
    ;直方图匹配计算转换函数
    NHis = 255
    index=where((OMData gt 0 and OMData lt 6) or (OMData gt 6 and OMData lt 60))
    index3=where((OMData lt 0) or (OMData eq 6 ) or (OMData ge 60))
    TempOMData=OMData[index]
    
    TF=HistogramMatch(TempOMData,ObserData,NHis,sHistogram)
    ;根据转换函数求新的有机质含量
    index2 = where(OMData eq 6)
    MinOmData = min(TempOMData)
    MaxOmData = max(TempOMData)
    OMData_NHis = (OMData-MinOmData)*NHis/(MaxOmData-MinOmData)
    OMData_TF=TF[fix(OMData_NHis)]
    OMData_NHis2 = OMData_TF*(MaxOmData-MinOmData)/255.0+MinOmData
    ;拉伸
    MINOMData_NHis2=MIN(OMData_NHis2)
    MAXOMData_NHis2=MAX(OMData_NHis2)
    MINObserData=MIN(ObserData)
    MAXObserData=MAX(ObserData)
    OMData_Stretch=(OMData_NHis2-MINOMData_NHis2)*(MAXObserData-MINObserData)/(MAXOMData_NHis2-MINOMData_NHis2)+MINObserData
    OMData_Stretch[index3] = -1
    
    ;Debug
    ;    window,4,title='原始直方图'
    ;    hist1=histogram(TempOMData)
    ;    plot,hist1
    ;    window,5,title='参考直方图'
    ;    hist2=histogram(ObserData)
    ;    plot,hist2
    ;    window,6,title='匹配直方图-未拉伸'
    ;    hist3=histogram(OMData_NHis2)
    ;    plot,hist3
    ;    window,7,title='匹配直方图-拉伸'
    ;    hist4=histogram(OMData_Stretch)
    ;    plot,hist4
    
    OutFilename = OutputPath+strmid(file_Basename(HJFilenames[i]),0,strlen(file_basename(HJFilenames[i]))-4)+'_OM.tif'
    write_tiff,OutFilename,OMData_Stretch,geotiff=geotiff,/float
    ENVI_REPORT_STAT,BASE,(i+1)*1.0/(NFiles)*100,100
  endfor
  ENVI_REPORT_INIT,BASE=BASE,/FINISH
;  envi_batch_exit
  Message = ''
end

function HistogramMatch, OriImage, RefImage,NHis,sHistogram
  BinSize = 1
  
  OriImage = reform(OriImage)
  RefImage = reform(RefImage)
  ;Calculate the histogram of the input AdjustImage.
  rmin = min(RefImage)
  rmax = max(RefImage)
  ;将参考数据映射到0-NHis
  rImage = fix((RefImage-rmin)*NHis/(rmax-rmin))
  rn_his = NHis
  
  if sHistogram eq 'false' then begin
    match_histogram = Histogram((rImage), Min=0, Max=NHis, Binsize=BinSize)
    rhist = match_histogram
  endif else begin
    omatch_histogram = Histogram((rImage), Min=0, Max=NHis, Binsize=BinSize)
    X = 0+indgen(NHis+1)*Binsize*1.
    match_histogram = GAUSSFIT(X, omatch_histogram, coeff, NTERMS=4);高斯拟合
    rhist = match_histogram
  endelse
  
  omin = min(OriImage)
  omax = max(OriImage)
  ;将原始数据映射到0-NHis
  oimage = fix((OriImage-omin)*NHis/(omax-omin))
  on_his = NHis
  h = Histogram((oImage), Min=0, Max=NHis,Binsize=BinSize)
  
  totalPixels = Float(N_Elements(oImage))
  totalHistogramPixels = Float(Total(match_histogram))
  if totalPixels ne totalHistogramPixels then begin
    factor = totalPixels / totalHistogramPixels
  endif else begin
    factor = 1.0
  endelse
  match_histogram = match_histogram * factor
  
  ;Find a mapping from the input pixels to the transformation function s.
  s = FltArr(on_his)
  for k=0,on_his-1 do begin
    s[k] = Total(h(0:k) / TotalPixels)
  endfor
  
  ;Find a mapping from input histogram to the transformation function v.
  v = FltArr(rn_his)
  for q=0,rn_his-1 do begin
    v[q] = Total(match_histogram(0:q) / Total(match_histogram))
  endfor
  
  ;Find probablitly density function z from v and s.
  z = fltArr(on_his)
  for j=0,on_his-1 do begin
    i = Where(v LT s[j], count)
    if count GT 0 then begin
      z[j] = (Reverse(i))[0]
    endif else begin
      z[j]=0
    endelse
  endfor
  
  ;;;;;;;;;;;拉伸
  ;  temp = z[oImage]
  ;  mintemp = min(temp)
  ;  maxtemp = max(temp)
  ;  ;对参考的直方图进行高斯拟合
  ;  yfit = GAUSSFIT(indgen(nhis+1), rhist, coeff, NTERMS=3)
  ;  ;  rmin = coeff[1]-3*coeff[2]
  ;  ;  rmax = coeff[1]+3*coeff[2]
  ;  ;根据百分比求拉伸的最小值和最大值
  ;  n_rimage=n_elements(rimage)
  ;  for i=coeff[1],nhis do begin
  ;    index=where(rimage gt coeff[1] and rimage lt i,count)
  ;    p=2*count*1.0/n_rimage
  ;    if p gt 0.9/2.0 then begin
  ;      rmax = i
  ;      break
  ;    endif
  ;  endfor
  ;  for i=coeff[1],0,-1 do begin
  ;    index=where(rimage gt i and rimage lt coeff[1],count)
  ;    p=2*count*1.0/n_rimage
  ;    if p gt 0.9/2.0 then begin
  ;      rmin = i
  ;      break
  ;    endif
  ;  endfor
  ;  ;按参考直方图进行拉伸
  ;  temp2 = (temp-mintemp)*(rmax-rmin)/(maxtemp-mintemp)+rmin
  ;  y = fltarr(on_his)
  ;  for j=0,on_his-1 do begin
  ;    i = where(oImage eq j,count)
  ;    if count gt 0 then begin
  ;      y[j] = temp2[i[0]]
  ;    endif else begin
  ;      y[j] = 0
  ;    endelse
  ;  endfor
  ;  ;Debug
  ;  window,1,title='原始直方图'
  ;  plot,h
  ;  window,2,title='参考直方图'
  ;  plot,rhist
  ;  window,3,title='匹配直方图-未拉伸'
  ;  temp=z[oImage]
  ;  h3 = Histogram((temp), Min=0, Max=NHis,Binsize=BinSize)
  ;  plot,h3
  ;  window,4,title='匹配直方图-拉伸'
  ;  temp4 = y[oImage]
  ;  h4 = Histogram((temp4), Min=0, Max=NHis,Binsize=BinSize)
  ;  plot,h4
  
  Return, z
end