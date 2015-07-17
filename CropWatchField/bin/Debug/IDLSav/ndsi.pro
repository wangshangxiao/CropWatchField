pro NDSI,FilenameCCD,FilenameIRS,OutputPath,Message=Message
  ;TEST
;  FilenameCCD='D:\DWQ\learn_idl\NDSI_IN\ccd\1_hongxing_wgs20140303.tif'
;  FilenameIRS='D:\DWQ\learn_idl\NDSI_IN\irs\1_hongxing_wgs_20140303.tif'
;  OutputPath='D:\DWQ\learn_idl\NDSI_OUT\'
  COMPILE_OPT idl2            ;该语句的功能则相当于同时使用COMPILE_OPT DEFINE32 和STRICTARR
  ;即编译规则中添加IDL整型数据位32位和数组元素的使用必须用中括号。
  ENVI,/RESTORE_BASE_SAVE_FILES        ;启动一个新的IDL编译器
  ENVI_BATCH_INIT     ;ENVI_BATCH_INIT是初始化ENVI的二次开发模式
  ;A=DIALOG_MESSAGE(FilenameCCD[0])
   if strmid(OutputPath,strlen(OutputPath)-1,1) ne '\' then begin
    OutputPath = OutputPath+'\'
  endif
  test_file = file_test(OutputPath,/directory)
  if test_file eq 0 then begin
    file_mkdir,OutputPath
  endif
  N_FilenameCCD=N_ELEMENTS(FilenameCCD)
  N_FilenameIRS=N_ELEMENTS(FilenameIRS)
  for i=0,N_FilenameCCD-1 do begin
    outfile=OutputPath+file_basename(FilenameCCD[i],'.tif')
    ENVI_OPEN_FILE,FilenameCCD[i],r_fid=fid1
    ENVI_OPEN_FILE,FilenameIRS[i],r_fid=fid2
    ENVI_FILE_QUERY,fid1,ns=ns,nl=nl,dims=dims,nb=nb          ;查看图像信息，fid是图像的地址，nl、ns表示图像行列号，nb表示波段
    fids=[fid1,fid2]                  ;fid1表示FilenameCCD的地址，
    pos=[1,1]                     ;[1,1]表示FilenameCCD的第二波段和FilenameIRS的第二波段，[2,3]表示FilenameCCD的第三波段和FilenameIRS的第四波段
    exp='float((b1-b2)/(b1+b2))'            ;波段间的运算
    envi_doit,'math_doit',dims=dims,exp=exp,fid=fids,pos=pos,$          ;调用envi函数“math_doit”做波段间的运算exp
      out_name=outfile,r_fid=temp_fid1
    ENVI_FILE_QUERY,temp_fid1,ns=ns,nl=nl,dims=dims,pos=INDGEN(nb)       ;上一步得到的是hdr格式的文件，本步查看图像信息，下一步输出tif格式的图像，INDGEN(nb)表示输出所有波段
    ;这里也可以用INDGEN(1)输出一个波段
    outfileName=outfile+'_ndsi.tif'
    ENVI_OUTPUT_TO_EXTERNAL_FORMAT,dims=dims,fid=temp_fid1,OUT_NAME=outfileName,pos=INDGEN(1),/tiff
    
  ;     data1 = read_tiff(FilenameCCD[i],geotiff=geotiff)
  ;     data2 = read_tiff(FilenameIRS[j],geotiff=geotiff)
  ;     if data1_band eq 2 && data2_band eq 2 then begin
  ;     filename=file_basename(image1)+'_ndsi.tif
  ;     write_tiff,outfilename,outdata,geotiff=geotiff,/float
    
  endfor
  ENVI_BATCH_EXIT
end

