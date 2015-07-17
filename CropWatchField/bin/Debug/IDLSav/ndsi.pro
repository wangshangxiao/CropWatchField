pro NDSI,FilenameCCD,FilenameIRS,OutputPath,Message=Message
  ;TEST
;  FilenameCCD='D:\DWQ\learn_idl\NDSI_IN\ccd\1_hongxing_wgs20140303.tif'
;  FilenameIRS='D:\DWQ\learn_idl\NDSI_IN\irs\1_hongxing_wgs_20140303.tif'
;  OutputPath='D:\DWQ\learn_idl\NDSI_OUT\'
  COMPILE_OPT idl2            ;�����Ĺ������൱��ͬʱʹ��COMPILE_OPT DEFINE32 ��STRICTARR
  ;��������������IDL��������λ32λ������Ԫ�ص�ʹ�ñ����������š�
  ENVI,/RESTORE_BASE_SAVE_FILES        ;����һ���µ�IDL������
  ENVI_BATCH_INIT     ;ENVI_BATCH_INIT�ǳ�ʼ��ENVI�Ķ��ο���ģʽ
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
    ENVI_FILE_QUERY,fid1,ns=ns,nl=nl,dims=dims,nb=nb          ;�鿴ͼ����Ϣ��fid��ͼ��ĵ�ַ��nl��ns��ʾͼ�����кţ�nb��ʾ����
    fids=[fid1,fid2]                  ;fid1��ʾFilenameCCD�ĵ�ַ��
    pos=[1,1]                     ;[1,1]��ʾFilenameCCD�ĵڶ����κ�FilenameIRS�ĵڶ����Σ�[2,3]��ʾFilenameCCD�ĵ������κ�FilenameIRS�ĵ��Ĳ���
    exp='float((b1-b2)/(b1+b2))'            ;���μ������
    envi_doit,'math_doit',dims=dims,exp=exp,fid=fids,pos=pos,$          ;����envi������math_doit�������μ������exp
      out_name=outfile,r_fid=temp_fid1
    ENVI_FILE_QUERY,temp_fid1,ns=ns,nl=nl,dims=dims,pos=INDGEN(nb)       ;��һ���õ�����hdr��ʽ���ļ��������鿴ͼ����Ϣ����һ�����tif��ʽ��ͼ��INDGEN(nb)��ʾ������в���
    ;����Ҳ������INDGEN(1)���һ������
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

