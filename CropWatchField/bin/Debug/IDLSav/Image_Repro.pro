PRO Image_Repro,inputFiles=inputFiles,Image_Refer=Image_Refer,OutputDir=OutputDir,Message=Message
  ;���ܣ���Ӱ����ͶӰΪ�ο�Ӱ���ͶӰ
  ;���룺����ͶӰ��Ӱ����ļ���,�ο�Ӱ��
  ;��������Ӱ���ļ���
  ;����
;  result1=dialog_message(inputFiles,/information)
  COMPILE_OPT idl2
  ENVI,/RESTORE_BASE_SAVE_FILES
  ENVI_BATCH_INIT 
   ;������Ǹ�Ŀ¼����·�������\
   IF strmid(OutputDir,strlen(OutputDir)-1,1) NE '\' THEN BEGIN
    OutputDir = OutputDir+'\'
  ENDIF
  ;����Ƿ�������������ļ��У���������ڣ������ļ���
  test_file = file_test(OutputDir,/directory)
  IF test_file eq 0 then begin
    file_mkdir,OutputDir
  ENDIF 
  N_inputFiles=N_ELEMENTS(inputFiles);��ȡ����Ӱ���ļ��ĸ��� 
  Image_BaseName=FILE_BASENAME(inputFiles,'.tif',/FOLD_CASE)   
  ImageTempOut_Name=OutputDir+Image_BaseName+'_Temp.tif'
  ImageOut_Name=OutputDir+Image_BaseName+'_Repro.tif'
  ;��ȡ�ο�Ӱ�����Ϣ
  ENVI_OPEN_FILE,Image_Refer,r_fid=Refer_fid
  ENVI_FILE_QUERY,Refer_fid,ns=Refer_ns,nl=Refer_nl,dims=Refer_dims
  ImageRefer_PRJ=ENVI_GET_PROJECTION(fid=Refer_fid)
  Map_info_Refer=ENVI_GET_MAP_INFO(fid=Refer_fid)    
  FOR i=0,N_inputFiles-1 DO BEGIN
    ENVI_OPEN_FILE,inputFiles[i],r_fid=Image_fid
    ENVI_FILE_QUERY,Image_fid,ns=Image_ns,nl=Image_nl,dims=Image_dims,nb=Image_nb
    Map_info_Image=ENVI_GET_MAP_INFO(fid=Image_fid)
    ;��ȡ����Ӱ���ͶӰ��Ϣ
    ImageInput_PRJ=ENVI_GET_PROJECTION(fid=Image_fid)
    if ImageInput_PRJ.PE_COORD_SYS_STR EQ ImageRefer_PRJ.PE_COORD_SYS_STR then begin
      Message='����ͶӰһ�£�����Ҫ������ͶӰ��'
      ;Message1=dialog_message(Message,/information)
      RETURN
    ENDIF    
    Map_info_Refer=ENVI_GET_MAP_INFO(fid=Refer_fid)
    Map_info_Image=ENVI_GET_MAP_INFO(fid=Image_fid)
    ;��ͶӰ
    ENVI_CONVERT_FILE_MAP_PROJECTION, fid=Image_fid, r_fid=ImageTempOut_Fid, $
      O_PIXEL_SIZE=Map_info_Refer.PS[0:1],$
      pos=LINDGEN(Image_nb),dims=Image_dims,$
      o_proj=ImageRefer_PRJ,WARP_METHOD=3,out_name=ImageTempOut_Name[i]
    ;���Ϊtiff����ɾ����ʱ�ļ�
    ENVI_OPEN_FILE,ImageTempOut_Name[i],r_fid=ImageTempOut_Fid,/no_realize
    ENVI_FILE_QUERY,ImageTempOut_Fid,dims=ImageTempOut_dims,nb=ImageTempOut_nb
    ENVI_OUTPUT_TO_EXTERNAL_FORMAT,fid=ImageTempOut_Fid,dims=ImageTempOut_dims,pos=INDGEN(Image_nb),$
      out_name=ImageOut_Name[i],/TIFF
    ENVI_FILE_MNG, id=ImageTempOut_Fid, /REMOVE, /DELETE    
  ENDFOR
  Message=''
;  ENVI_BATCH_EXIT
END
PRO Test_Image_Repro
;  inputFiles=['D:\10_test\fusion\0816\20110816_prediction_ESTARFM_13.tif','D:\10_test\fusion\0816\20110816_prediction_estarfm_13_subset.tif']
  inputFiles='D:\02_HongXing\04_system\HX_TestData\Pretreat\Project\IN\Reference\hj1a-ccd1-447-56-20101005-l20000403561_latlon.tif'
  Image_Refer='D:\02_HongXing\04_system\HX_TestData\Pretreat\Project\IN\Image\hj1b-ccd1-449-56-20130826-l20001042636_subset.tif'
  OutputDir='D:\'
  Image_Repro,inputFiles=inputFiles,Image_Refer=Image_Refer,OutputDir=OutputDir,Message=Message
END