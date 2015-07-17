;说明：
;YieldFilenames----归一化产量文件名
;OutputPath----输出路径

pro Nutrient_N,YieldFilenames,OutputPath,Message=Message
  ;test
;  YieldFilenames='D:\rrrr\MaxNormYield.tif'  
;  outputpath='D:\rrrr\'
  
  compile_opt idl2
  ENVI,/RESTORE_BASE_SAVE_FILES
  ENVI_BATCH_INIT
  ;检测输出路径
  if strmid(OutputPath,strlen(OutputPath)-1,1) ne '\' then begin
    OutputPath = OutputPath+'\'
  endif
  test_file = file_test(OutputPath,/directory)
  if test_file eq 0 then begin
    file_mkdir,OutputPath
  endif
  ;r=dialog_message((YieldFilenames[0]))
  ;文件数
  NFiles = n_elements(YieldFilenames)
  ;批处理
  ENVI_REPORT_INIT,"批处理中...",$
    title="土壤速效氮估算",base=base,/interrupt
  ENVI_REPORT_INC,BASE,1
  FOR i=0,NFiles-1 do begin
    YieldData = read_tiff(YieldFilenames[i])
    result = QUERY_TIFF(YieldFilenames[i],ImgInfo)
    ns = imginfo.DIMENSIONS[0]
    nl = imginfo.DIMENSIONS[1]
    ;;;;;;;;;;;根据最新的研究成果修改下式
    index = where(YieldData le 0)
    NData = 297.35*YieldData^0.2505
    NData[index] = -1
    ;;;;;;;;;;;;;;;
    OutFilename = OutputPath+strmid(file_Basename(YieldFilenames[i]),0,strlen(file_basename(YieldFilenames[i]))-4)+'_N.tif'
    write_tiff,OutFilename,NData,geotiff=geotiff,/float
    ENVI_REPORT_STAT,BASE,(i+1)*1.0/(NFiles)*100,100
  endfor
  ENVI_REPORT_INIT,BASE=BASE,/FINISH
  envi_batch_exit
  Message = ''
end