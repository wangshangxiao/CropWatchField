pro threshold_method,FilenameNDSI,OutPutPath,Message=Message
;test
;FilenameNDSI='D:\DWQ\learn_idl\test\1_hongxing_wgs20140303_ndsi.tif'
;OutPutPath='D:\DWQ\learn_idl\threshold_new\'


  COMPILE_OPT idl2
  
  ENVI,/RESTORE_BASE_SAVE_FILES
  ENVI_BATCH_INIT
;  dir='D:\DWQ\learn_idl\NDSI_OUT\'
;  OutPutPath='D:\DWQ\learn_idl\threshold\'
  if strmid(OutPutPath,strlen(OutPutPath)-1,1) ne '\' then begin
    OutPutPath = OutPutPath+'\'
  endif
  test_file = file_test(OutPutPath,/directory)
  if test_file eq 0 then begin
    file_mkdir,OutPutPath
  endif
  
  N_FilenameNDSI=N_ELEMENTS(FilenameNDSI)
   for i=0,N_FilenameNDSI-1 do begin
    outfile=OutPutPath+file_basename(FilenameNDSI[i],'.tif')
    ENVI_OPEN_FILE,FilenameNDSI[i],r_fid=fid
    ENVI_FILE_QUERY,fid,ns=ns,nl=nl,nb=nb,dims=dims      ;主要是得到图像的行列数和波段数
    map_info=envi_get_map_info(fid=fid)
 ;   FilenameNDSI=file_basename(FilenameNDSI[i],'.tif')
;    outFilenameNDSI=OutPutPath+FilenameNDSI+'_threshold'
    data=read_tiff(FilenameNDSI[i],geotiff=geotiff)              ;得到图像的地理信息，data表示像元值
    outdata=fltarr(ns,nl)             ;建立一个和原图像行列数一样的全空的数组，用来存储输出的图像
    for i_nl=0,nl-1 do begin               ;此行和下一行是逐行逐列按像元运算
      for i_ns=0,ns-1 do begin
        if data[i_ns,i_nl] ge 0 then begin
          if data[i_ns,i_nl] le 0.57 then begin
            outdata[i_ns,i_nl]=0
          endif else if data[i_ns,i_nl] gt 0.57 && data[i_ns,i_nl] le 0.72 then begin
            outdata[i_ns,i_nl]=1
          endif else if data[i_ns,i_nl] gt 0.72 && data[i_ns,i_nl] le 1 then begin
            outdata[i_ns,i_nl]=2
          endif
        endif
      endfor
    endfor
    openw,lun,outfile,/get_lun             ;创建一个可以读写的新文件
    for i_nl=0,nl-1 do begin
      writeu,lun,outdata[*,i_nl]              ;writeu函数可以产生ENVI格式的文件，二进制文件
    endfor
      FREE_LUN,lun
      ENVI_SETUP_HEAD,fname=outfile,ns=ns,nl=nl,nb=1,$
        DATA_TYPE=4,offset=0,INTERLEAVE=1,MAP_INFO=map_info, /write, /open     ;使用该函数写某个已存入磁盘的影像数据的envi头文件
      ENVI_OPEN_FILE,outfile,r_fid=outFid
      ENVI_FILE_QUERY,outFid,ns=ns,nl=nl,nb=1,dims=dims
      ENVI_OUTPUT_TO_EXTERNAL_FORMAT,fid=outFid,dims=dims,pos=INDGEN(1),$                     ;影像数据输出为特定格式“.tif”
        out_name=outfile+'_threshold.tif',/TIFF
   
  endfor
END