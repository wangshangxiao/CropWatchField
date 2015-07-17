  PRO main_ch_retrieve_Crop,chtableinpath=chtableinpath,inputFiles=inputFiles,$
      CropType=CropType,chimageoutpath=chimageoutpath,$
      Image_crop_inputpath=Image_crop_inputpath,Message=Message
    ;Result1 = DIALOG_MESSAGE(chimageoutpath)
    ;ʵ�ֹ��ܣ������Ѿ������õĲ��ұ�������Ҷ���صĺ���
    ;chtableinpath:�Ѿ������õĲ��ұ������
    ;inputfiles:��������ɸ�Ӱ���ļ���Ӱ��Ҫ�󣺾���Ԥ�������ξ��������䶨�ꡢ�����������ü�����Ļ�����CCD���ݵ�����
    ;chimageoutpath�����Ҷ���غ����ֲ�ͼ�Ĵ��·��
    ;��ȡ����ֲ�ͼ������1��������2�����3С��4�����ʹ���
    ;��Cab ALA Lai Hspot Ns�������������
    compile_opt idl2
    ENVI,/RESTORE_BASE_SAVE_FILES
    ENVI_BATCH_INIT 
    print,systime()
    ;-------------------------------
    ;��ȡ���ұ������
    Lines=file_lines(chtableinpath)
    ;��ȡ���ұ������
    StringArray = strarr(Lines);
    OPENR,lun,chtableinpath, /GET_LUN
    READF,lun,StringArray
    FREE_LUN, lun
    StringArray0=strsplit(StringArray[0], ' ', /EXTRACT)
    col_lines=N_elements(StringArray0)
    ;-------------------------------
    ;��ȡ���ұ�
    Simref= fltarr(col_lines,file_lines(chtableinpath))  ;7��ʾ�����м���
    OPENR,table,chtableinpath,/get_lun
    readf,table,Simref
    free_lun,table
    ;��ȡũ����ο�Ӱ��
    dataCrop = read_tiff(Image_crop_inputpath,geotiff = geotiff)
    Case (CropType) of
      ;maize����
      'Maize' : begin
        Crop_Type=1
      End
      'Soybean' : begin
        Crop_Type=2
      End
      'Wheat' : begin
        Crop_Type=3
      End
      'Other' : begin
        Crop_Type=4
      End
    EndCase
    ;��ȡtiffӰ��ĸ���
    N_inputFiles=N_ELEMENTS(inputFiles);��ȡ����Ӱ���ļ��ĸ���
    ;���Ӱ���Ƿ��������
    ENVI_OPEN_FILE,Image_crop_inputpath,r_fid=Refer_fid
    ENVI_FILE_QUERY,Refer_fid,ns=Refer_ns,nl=Refer_nl,dims=Refer_dims
    ImageRefer_PRJ=ENVI_GET_PROJECTION(fid=Refer_fid)
    Map_info_Refer=ENVI_GET_MAP_INFO(fid=Refer_fid)    
   FOR j=0,N_inputFiles-1 DO BEGIN
     ;��ȡӰ���ͶӰ��Ϣ,���У�fid����file��ID��ns��ʾ������nl��ʾ������dims��ʾ���к�
     ENVI_OPEN_FILE,inputFiles[j],r_fid=Image_fid
     ENVI_FILE_QUERY,Image_fid,ns=Image_ns,nl=Image_nl,dims=Image_dims,nb=Image_nb
     ;��ȡ�����ļ�Ӱ����Ϣ
     Map_info_Image=ENVI_GET_MAP_INFO(fid=Image_fid)
     ;��ȡӰ���ͶӰ��Ϣ
     ImageInput_PRJ=ENVI_GET_PROJECTION(fid=Image_fid)
     ;��ȡӰ������ش�С
     if Map_info_Image.PS[0] NE Map_info_Refer.PS[0] || Map_info_Image.PS[1] $
       NE Map_info_Refer.PS[1] then begin
       Message='��ο�Ӱ�������ֵ��ͬ��������ز�����  '
       RETURN
     ENDIF
     if Map_info_Image.PS[0] NE Map_info_Image.PS[1] then begin
       Message='���ز���Ϊ�������أ�  '
       RETURN
     ENDIF
     if ImageInput_PRJ.NAME NE ImageRefer_PRJ.NAME then begin
       Message='����ͶӰ��һ��,�������ͶӰ��  '
       RETURN
     ENDIF
   ENDFOR
    ;��ȡũ���������
    index_Crop=where(dataCrop EQ Crop_Type)
    N_index_Crop=N_elements(index_Crop)
    ;ENVI�ⲿ������------------------------
    ENVI,/restore_base_save_files
    ENVI_BATCH_INIT
    ;��ʼ��������
    ENVI_REPORT_INIT, '���ݴ����С�', $
      title="�ܽ�����", $
      base=base ,/INTERRUPT
    ENVI_REPORT_INC, base,N_inputFiles
    ;--------------------------------
    for n=0,N_inputFiles-1 do begin
      data = read_tiff(inputFiles[n],geotiff = geotiff)
      ;�˴�reform��������ֱ�ӽ���ά������ת��Ϊ��ά������
      blue = reform(data[0,*,*]);/10000.0<1>0
      green = reform(data[1,*,*]);/10000.0<1>0
      red = reform(data[2,*,*]);/10000.0<1>0
      nir = reform(data[3,*,*]);/10000.0<1>0
      ;��ȡ������
      dims = size(dataCrop,/dimensions)
      result = fltarr(dims[0],dims[1])
      NDVI=fltarr(dims)
      Blue_Index=Blue[index_Crop]
      Green_Index=Green[index_Crop]
      Red_Index=Red[index_Crop]
      nir_Index=nir[index_Crop]
      result_Index=result[index_Crop]
      NDVI[index_Crop]=(nir[index_Crop]-red[index_Crop])/ $
        (nir[index_Crop]+red[index_Crop]+0.00000001)
      NDVI_Index=NDVI[index_Crop]
      ;�ڲ�������------------------------------
      ENVI,/restore_base_save_files
      ENVI_BATCH_INIT
      ;��ʼ��������
      ENVI_REPORT_INIT, '���ݴ�����_�ڲ���', $
        title="�ӽ�����", base=base_iner ,/INTERRUPT
      ENVI_REPORT_INC , base_iner, N_index_Crop
      ;-------------------------------------
      for i=0,N_index_Crop-1 do begin
        if Blue_Index[i] GE 1 OR Green_Index[i] GE 1 OR $
          Red_Index[i] GE 1 OR nir_Index[i] GE 1 then continue
        if Blue_Index[i] LE 0 OR Green_Index[i] LE 0 OR $
          Red_Index[i] LE 0 OR nir_Index[i] LE 0 then continue
        if NDVI_Index[i] LE 0 OR NDVI_Index[i] GE 1 then continue
        ;���ۺ����������̲�����첨�����Ϲ�����ۺ���
        cost=sqrt(((Green_Index[i]-Simref[5,*])^2+ $
          (Red_Index[i]-Simref[6,*])^2)/2.0)
        ;�����ۺ�������������
        order=sort(cost);
        ;��ǰ20%�����ݵ�ƽ��ֵ��Ϊ�����
        ;result[i,j]=total(Simref[0,order[0:1999]])/2000.0
        result_Index[i]=total(Simref[0,order[0:499]])/500.0
        abcde=0000000000000000
        ;�ж��ӽ������Ƿ���ȡ��--------
       ENVI_REPORT_STAT, base_iner, i, float(N_index_Crop), CANCEL=cancelvar_iner
        IF cancelvar_iner EQ 1 THEN BEGIN
          ;tmp = DIALOG_MESSAGE('�����ȡ��'+'%'+STRING(Tn),/info)
          ENVI_REPORT_INIT, base=base_iner, /finish
          Break
          ENVI_BATCH_EXIT
        ENDIF
        ;�ж��ܽ������Ƿ���ȡ��
        ENVI_REPORT_STAT,base, n, float(N_inputFiles), CANCEL=cancelvar
        IF cancelVar EQ 1 THEN BEGIN
          ;tmp = DIALOG_MESSAGE('�����ȡ��'+'%'+STRING(Tn),/info)
          ENVI_REPORT_INIT, base=base, /finish
          Break
          ENVI_BATCH_EXIT
        ENDIF
      ;�ڲ�����������--------------------------------
      endfor
      ENVI_REPORT_INIT, base=base_iner, /finish
      ENVI_BATCH_EXIT
      result[index_Crop]=result_Index
      write_tiff,chimageoutpath,result,geotiff = geotiff,/float
      ;---------------   
    endfor
    ENVI_REPORT_INIT, base=base, /finish
    ENVI_BATCH_EXIT
    Message=''
  END
  
  pro test_main_ch_retrieve_Crop
    chtableinpath='D:\02_HongXing\05_software\Estimation_ch_water\testdata\HJCCDA1chtable.txt'
    inputFiles='D:\02_HongXing\05_software\Estimation_ch_water\testdata\hj1b-ccd2-446-56-20110816-l20000595422_albers105_sub_geo_sub_repro_Cut.tif'
    Image_crop_inputpath='D:\02_HongXing\05_software\Estimation_ch_water\testdata\hongxing_2013_Geo_GIS.tif'
    chimageoutpath='D:\02_HongXing\05_software\Estimation_ch_water\testdata\test.tif'
    CropType='Soybean'
    main_ch_retrieve_Crop,chtableinpath=chtableinpath,inputFiles=inputFiles,CropType=CropType,$
      chimageoutpath=chimageoutpath,Image_crop_inputpath=Image_crop_inputpath,Message=Message
    print,systime()
  end