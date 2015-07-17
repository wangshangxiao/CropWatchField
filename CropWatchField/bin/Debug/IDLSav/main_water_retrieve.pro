  PRO main_water_retrieve,watertableinpath=watertableinpath,inputFiles=inputFiles,waterimageoutpath=waterimageoutpath,Message=Message
;  Result1 = DIALOG_MESSAGE(waterimageoutpath)
  ;ʵ�ֹ��ܣ����ò��ұ���������ˮ����,��Cw ALA Hspot Cm Ns�������������
  ;waterfindtablepath:�Ѿ������õĲ��ұ������
  ;inputfiles:��������ɸ�Ӱ���ļ���Ӱ��Ҫ�󣺾���Ԥ�������ξ��������䶨�ꡢ�����������ü�����Ļ�����IRS���ݵ�����
  ;ouputwaterpath�����Ҷ���غ����ֲ�ͼ�Ĵ��·��
  ;print,systime()
  ;��ȡģ��ķ���������
  Simref= fltarr(7,file_lines(watertableinpath))        ;7��ʾ�����м���
  OPENR,table,watertableinpath,/get_lun
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
  band1 = reform(data[0,*,*])/10000.0
  band2 = reform(data[1,*,*])/10000.0
  dims = size(band1,/dimensions)
  result = fltarr(dims[0],dims[1])
  for i=0,dims[0]-1 do begin
    for j=0,dims[1]-1 do begin
      if band1[i,j] GE 1 OR band2[i,j] GE 1  then continue
      if band1[i,j] LE 0 OR band1[i,j] LE 0  then continue  ;����������������������ʱ��
      cost=sqrt(((band1[i,j]-Simref[5,*])^2+(band2[i,j]-Simref[6,*])^2)/2.0);���ۺ���
      order=sort(cost)                                                                      ;�����ۺ�������������
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
  
  write_tiff,waterimageoutpath,result,geotiff = geotiff,/float
  endfor
  ENVI_REPORT_INIT, base=base, /finish
;  print,systime()
   Message=''
  end

;  pro test_main_water_retrieve
;  watertableinpath='D:\xujin\test\IRSwatertable.txt'
;  inputFiles='D:\xujin\Inversion pro\XJdata\IRS_7_tiff\hj1b-irs-452-56-20110829-l20000602167_all_subset_1_geo_ref_resize_crop.tif'
;  waterimageoutpath='D:\xujin\test'
;  main_water_retrieve,watertableinpath=watertableinpath,inputFiles=inputFiles,waterimageoutpath=waterimageoutpath,Message=Message
;  end