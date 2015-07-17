  PRO main_ch_retrieve,chtableinpath=chtableinpath,inputFiles=inputFiles,chimageoutpath=chimageoutpath,Message=Message
  compile_opt idl2
;  Result = DIALOG_MESSAGE(chimageoutpath)
  ;ʵ�ֹ��ܣ������Ѿ������õĲ��ұ�������Ҷ���صĺ���
  ;chtableinpath:�Ѿ������õĲ��ұ������
  ;inputfiles:��������ɸ�Ӱ���ļ���Ӱ��Ҫ�󣺾���Ԥ�������ξ��������䶨�ꡢ�����������ü�����Ļ�����CCD���ݵ�����
  ;chimageoutpath�����Ҷ���غ����ֲ�ͼ�Ĵ��·��
  ;��Cab ALA Lai Hspot Ns�������������
;  print,systime()
  ;��ȡģ��ķ���������
  Simref= fltarr(7,file_lines(chtableinpath))  ;7��ʾ�����м���
  OPENR,table,chtableinpath,/get_lun
  readf,table,Simref
  free_lun,table
  ;��ȡtiffӰ��
  N_inputFiles=N_ELEMENTS(inputFiles);��ȡ����Ӱ���ļ��ĸ���
  
   ;ENVI������
  ENVI,/restore_base_save_files
  ENVI_BATCH_INIT
  ;��ʼ��������
  ENVI_REPORT_INIT, '���ݴ����С�', $
  title="������", $
  base=base ,/INTERRUPT
  ENVI_REPORT_INC, base,N_inputFiles
  
  
  for n=0,N_inputFiles-1 do begin
    data = read_tiff(inputFiles[n],geotiff = geotiff)
    ;data Ϊint[4,1726,874]��Ϊ4��  1726��  874��
    blue = reform(data[0,*,*])/10000.0<1>0
    green = reform(data[1,*,*])/10000.0<1>0
    red = reform(data[2,*,*])/10000.0<1>0
    nir = reform(data[3,*,*])/10000.0<1>0
    NDVI=(nir-red)/(nir+red+0.00000001)
    dims = size(blue,/dimensions)
    result = fltarr(dims[0],dims[1])
    for i=0,dims[0]-1 do begin
      for j=0,dims[1]-1 do begin
         if Blue[i,j] GE 1 OR Green[i,j] GE 1 OR Red[i,j] GE 1 OR nir[i,j] GE 1 then continue
         if Blue[i,j] LE 0 OR Green[i,j] LE 0 OR Red[i,j] LE 0 OR nir[i,j] LE 0 then continue  
         if NDVI[i,j] EQ 0 then continue 
         cost=sqrt(((Green[i,j]-Simref[5,*])^2+(Red[i,j]-Simref[6,*])^2)/2.0)                  ;���ۺ���
         order=sort(cost);                                                                     ;�����ۺ�������������
         result[i,j]=total(Simref[0,order[0:1999]])/2000.0                                     ;��ǰ20%�����ݵ�ƽ��ֵ��Ϊ�����
      endfor
    endfor
    ENVI_REPORT_STAT,base, n, float(N_inputFiles), CANCEL=cancelvar
        ;�ж��Ƿ���ȡ��
        IF cancelVar EQ 1 THEN BEGIN
         ; tmp = DIALOG_MESSAGE('�����ȡ��'+'%'+STRING(Tn),/info)
          ENVI_REPORT_INIT, base=base, /finish
          return
          ENVI_BATCH_EXIT
          ENDIF
          
    write_tiff,chimageoutpath,result,geotiff = geotiff,/float
  ;  print,systime()
  endfor
  ENVI_REPORT_INIT, base=base, /finish
  Message=''
  end

;  pro test_main_ch_retrieve
;  chtableinpath='D:\xujin\test\CCDA1chtable.txt'
;  inputFiles='D:\xujin\Inversion pro\XJdata\CCD_7_tiff\hj1a-ccd2-447-56-20110826-l20000600736_hx_geo_ref_crop.tif'
;  chimageoutpath='D:\xujin\test'
;  main_ch_retrieve,chtableinpath=chtableinpath,inputFiles=inputFiles,chimageoutpath=chimageoutpath,Message=Message
;  end