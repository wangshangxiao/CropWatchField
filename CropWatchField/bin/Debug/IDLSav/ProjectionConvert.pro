PRO TestProject
  inputFile='D:\02_HongXing\04_system\HX_TestData\Pretreat\Project\IN\Image\hj1b-ccd1-449-56-20130826-l20001042636_subset.tif'
  ReferFile='D:\02_HongXing\04_system\HX_TestData\Pretreat\Project\IN\Reference\hj1b-irs-452-56-20110826-l20000595422_repro_Cut.tif'
  outFile='D:\123.tif'
  ProjectionConvert,inputFile,ReferFile,outFile,TIFF=TIFF,Message=Message
END

PRO ProjectionConvert,inputFile,ReferFile,outFile,TIFF=TIFF,Message=Message
  ;功能将inputFile的坐标系转换成ReferFile的坐标系,outFile为输出文件
  COMPILE_OPT idl2
  ;    inputFile='D:\20090831.tif'
  ;    ReferFile='D:\项目\cropwatch\data\cropland_0.25degree_1%_1bit.tif'
  ;    outFile='E:\20090831.tif'
  ;    TIFF=1
  ENVI,/RESTORE_BASE_SAVE_FILES
  ENVI_BATCH_INIT,LOG_FILE="C:\envi_Preprocessing.Log"
  ENVI_OPEN_FILE,inputFile[0],R_FID=fid
  IF fid EQ -1 THEN BEGIN
    Message='无效的影像文件:'+inputFile[0]
    RETURN
  ENDIF
  ENVI_OPEN_FILE,ReferFile,R_FID=referfid
  IF referfid EQ -1 THEN BEGIN
    Message='无效的影像文件:'+ReferFile
    RETURN
  ENDIF
  
  outDIR=FILE_DIRNAME(outFile,/MARK_DIRECTORY)
  CATCH,error
  IF error NE 0 THEN GOTO,next
  FILE_MKDIR,outDIR
  next:
  CATCH,/CANCEL
  ;构建输出文件名称
  FileMainName=FILE_BASENAME(outFile,'.tif',/FOLD_CASE)
  IF KEYWORD_SET(TIFF) THEN BEGIN
    outTempFile=outDIR+FileMainName+'NewProjTemp'
    outFile=outDIR+FileMainName+'.tif'
  ENDIF ELSE BEGIN
    outTempFile=outDIR+FileMainName
  ENDELSE
  ;判断文件坐标是否为目标坐标
  outProj=ENVI_GET_PROJECTION(FID=referfid)
  ENVI_FILE_QUERY,fid,dims=dims,nb=nb
  ENVI_CONVERT_FILE_MAP_PROJECTION, fid=fid, r_fid=TempFid, $
    pos=LINDGEN(nb),dims=dims,o_proj=outProj,WARP_METHOD=3,out_name=outTempFile
  IF TempFid EQ -1 THEN BEGIN
    ENVI_BATCH_EXIT
    Message=STRARR(FILE_LINES("C:\envi_Preprocessing.Log"))
    OPENR,lun,"C:\envi_Preprocessing.Log",/GET_LUN
    READF,lun,Message
    FREE_LUN,lun
    Message=STRJOIN(Message,STRING(10b))
    RETURN
  ENDIF
  IF KEYWORD_SET(TIFF) THEN BEGIN
    ENVI_FILE_QUERY,TempFid,nb=nb,DATA_TYPE=out_dt,dims=dims
    ENVI_OUTPUT_TO_EXTERNAL_FORMAT, DIMS=dims $
      , FID=TempFid, OUT_NAME=outFile,POS=INDGEN(nb), /TIFF
    ENVI_FILE_MNG, id=TempFid,/DELETE,/REMOVE
  ENDIF
  ENVI_BATCH_EXIT
  Message=''
END