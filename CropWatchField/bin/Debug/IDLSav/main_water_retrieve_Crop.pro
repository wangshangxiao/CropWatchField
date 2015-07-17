  PRO main_water_retrieve_Crop,watertableinpath=watertableinpath,CropType=CropType,$
      inputFiles=inputFiles,waterimageoutpath=waterimageoutpath,$
      Image_crop_inputpath=Image_crop_inputpath,Message=Message
    ;ʵ�ֹ��ܣ����ò��ұ���������ˮ����,��Cw ALA Hspot Cm Ns�������������
    ;waterfindtablepath:�Ѿ������õĲ��ұ������
    ;inputfiles:��������ɸ�Ӱ���ļ���Ӱ��Ҫ�󣺾���Ԥ�������ξ��������䶨�ꡢ�����������ü�����Ļ�����IRS���ݵ�����
    ;ouputwaterpath�����Ҷ���غ����ֲ�ͼ�Ĵ��·��
    compile_opt idl2
    ENVI,/RESTORE_BASE_SAVE_FILES
    ENVI_BATCH_INIT 
    print,systime()
    ;��ȡ���ұ������
    Lines=file_lines(watertableinpath)
    ;��ȡ���ұ������
    StringArray = strarr(Lines);
    OPENR, lun, watertableinpath, /GET_LUN
    READF, lun, StringArray
    FREE_LUN, lun
    StringArray0=strsplit(StringArray[0], ' ', /EXTRACT)
    col_lines=N_elements(StringArray0)
    ;--------------------------------------
    Simref= fltarr(col_lines,Lines)
    OPENR,table,watertableinpath,/get_lun
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
      ;data Ϊint[4,1726,874]��Ϊ4��  1726��  874��
      Nir_IRS = reform(data[0,*,*]);/10000.0
      SW_IRS = reform(data[1,*,*]);/10000.0
      ;��ȡĳ���ε�������
      dims = size(dataCrop,/dimensions)
      result = fltarr(dims[0],dims[1])
      Nir_IRS_Index=Nir_IRS[index_Crop]
      SW_IRS_Index=SW_IRS[index_Crop]
      result_Index=result[index_Crop]
      ;�ڲ�������------------------------------
      ENVI,/restore_base_save_files
      ENVI_BATCH_INIT
      ;��ʼ��������
      ENVI_REPORT_INIT, '���ݴ�����_�ڲ���', $
        title="�ӽ�����", base=base_iner ,/INTERRUPT
      ENVI_REPORT_INC , base_iner, N_index_Crop
      ;------------------------------------
      for i=0,N_index_Crop-1 do begin
          ;����������������������ʱ��
          if Nir_IRS_Index[i] LE 0 OR Nir_IRS_Index[i] GE 1 then continue
          if SW_IRS_Index[i] LE 0 OR SW_IRS_Index[i] GE 1 then continue
          cost=sqrt(((Nir_IRS_Index[i]-Simref[5,*])^2+(SW_IRS_Index[i]-Simref[6,*])^2)/2.0);���ۺ���
          order=sort(cost)                                                                      ;�����ۺ�������������
;          result[i,j]=total(Simref[0,order[0:1999]])/2000.0                                     ;��ǰ20%�����ݵ�ƽ��ֵ��Ϊ�����
          result_Index[i]=total(Simref[0,order[0:9]])/10.0    
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
     write_tiff,waterimageoutpath,result,geotiff = geotiff,/float
    endfor
    ENVI_REPORT_INIT, base=base, /finish
    ENVI_BATCH_EXIT
    Message=''
  end
  
  pro test_main_water_retrieve_Crop
    watertableinpath='D:\02_HongXing\05_software\Estimation_ch_water\testdata\IRSwatertable.txt'
    inputFiles='D:\02_HongXing\05_software\Estimation_ch_water\testdata\hj1b-irs-452-56-20110826-l20000595422_repro_Cut.tif'
    Image_crop_inputpath='D:\02_HongXing\05_software\Estimation_ch_water\testdata\hongxing_2013_Geo_GIS.tif'
    waterimageoutpath='D:\02_HongXing\05_software\Estimation_ch_water\testdata\test_water.tif'
    CropType='Soybean'
    main_water_retrieve_Crop,watertableinpath=watertableinpath,CropType=CropType,$
      inputFiles=inputFiles,waterimageoutpath=waterimageoutpath,$
      Image_crop_inputpath=Image_crop_inputpath,Message=Message
    print,systime()
  end