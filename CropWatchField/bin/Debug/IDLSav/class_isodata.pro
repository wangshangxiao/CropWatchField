;非监督分类
pro CLASS_ISODATA,inputfile,outputDir,$
        
    ;ISO算法参数
    ITERATIONS = ITERATIONS, $ ;最大迭代次数
    NUM_CLASSES = NUM_CLASSES , $    ;最大分类数
    CHANGE_THRESH = CHANGE_THRESH, $  ;变化阈值
    MIN_CLASSES = MIN_CLASSES, $   ;最小分类数
    Message=Message
  
;  inputfile='D:\IRSA_WU\hunan_sub\basedata\20130713.tif'
;  outputDir='C:\Users\lizy\Desktop\test'
;  ITERATIONS=10
;  MIN_CLASSES=10
;  NUM_CLASSES=15
;  CHANGE_THRESH=.05
  
    
  COMPILE_OPT idl2
  envi, /restore_base_save_files  
  envi_batch_init, log_file='batch.txt' 
  CATCH, Error_status
  errorshow = 'Sorry to see the error,'+ $
    ' please send the error Information to "dongyq@esrichina-bj.cn"'
    
  IF Error_status NE 0 THEN BEGIN
;    tmp = DIALOG_MESSAGE(errorshow+STRING(13b)+$
;      !ERROR_STATE.MSG,/error,title = '错误提示!')
      
      Message=ERROR_STATE.MSG
      envi_batch_exit
    return
  ENDIF
  
  ;;IF ~KEYWORD_SET(CHANGE_THRESH) THEN CHANGE_THRESH = .05
      ;;IF ~KEYWORD_SET(NUM_CLASSES) THEN NUM_CLASSES = 10
      ;;IF ~KEYWORD_SET(ITERATIONS) THEN ITERATIONS = 1
      IF ~KEYWORD_SET(ISO_MERGE_DIST) THEN ISO_MERGE_DIST = 1
      IF ~KEYWORD_SET(ISO_MERGE_PAIRS) THEN ISO_MERGE_PAIRS = 2
      IF ~KEYWORD_SET(ISO_MIN_PIXELS) THEN ISO_MIN_PIXELS = 1
      IF ~KEYWORD_SET(ISO_SPLIT_SMULT) THEN ISO_SPLIT_SMULT = 1
      IF ~KEYWORD_SET(ISO_SPLIT_STD) THEN ISO_SPLIT_STD = 1
      ;;IF ~KEYWORD_SET(MIN_CLASSES) THEN MIN_CLASSES = 5
  
  ;输入数据预处理
  ENVI_OPEN_FILE, inputfile, r_fid=fid
  IF (fid EQ -1) THEN BEGIN
    Message='输入文件无效'
    envi_batch_exit
    RETURN
  ENDIF
  ;获取文件信息
  ENVI_FILE_QUERY, fid, dims=dims, nb=nb
  pos  = LINDGEN(nb)
  
  file_name=FILE_BASENAME(InputFile)
  fields=strsplit(file_name,'.',COUNT=count,/EXTRACT)
  out_name = outputDir+'\'+fields[0]+'iso.tif'
  out_bname= 'IsoData'
;  out_bname = 'IsoData'+outputfile
  
  ENVI_DOIT, 'class_doit', fid=fid, pos=pos, dims=dims, $
    out_bname=out_bname, out_name=out_name, method=4, $
    r_fid=r_fid, $
    NUM_CLASSES = NUM_CLASSES, $
    ITERATIONS = ITERATIONS, $
    in_memory=0, $
    CHANGE_THRESH = CHANGE_THRESH, $
    ISO_MERGE_DIST = ISO_MERGE_DIST, $
    ISO_MERGE_PAIRS = ISO_MERGE_PAIRS, $
    ISO_MIN_PIXELS = ISO_MIN_PIXELS, $
    ISO_SPLIT_SMULT = ISO_SPLIT_SMULT, $
    ISO_SPLIT_STD = ISO_SPLIT_STD, $
    MIN_CLASSES = MIN_CLASSES
  outPutFile=outputDir+'\'+fields[0]+'_iso.tif'
   envitotiff,out_name,outPutFile
   envi_batch_exit
   Message=''
   ;envi_file_mng,id=fid,/REMOVE
END

pro envitotiff,InputFile,outPutFile
    ENVI_OPEN_FILE,InputFile,R_FID=fid
    ENVI_FILE_QUERY,fid,nb=nb,DIMS=dims
    ENVI_OUTPUT_TO_EXTERNAL_FORMAT,dims=dims,fid=fid,pos=INDGEN(nb),out_name=outPutFile,TIFF=1
    ENVI_FILE_MNG, id=fid, /REMOVE, /DELETE
end