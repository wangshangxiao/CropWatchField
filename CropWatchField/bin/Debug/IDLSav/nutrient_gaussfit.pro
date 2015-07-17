;˵����
;YieldFilenames----�����ļ���
;CropClassifyFilenames----���������ļ���
;       1-����
;       2-��
;       3-С��
;OutputPath----���·��
;HisPara1----���
;HisPara2----���ٱ��ķ���
pro Nutrient_GaussFit,YieldFilenames,CropClassifyFilenames,OutputPath,HisPara1,HisPara2,Message=Message
  ;test
  ;    YieldFilenames = 'd:\test\'+['ss_harvest_2010_yield.tif','ss_harvest_2010_yield-2.tif']
  ;    CropClassifyFilenames = 'd:\test\'+['2010crop-tif_sub.tif','2010crop-tif_sub.tif']
  ;    OutputPath = 'd:\'
  ;    HisPara1 = 20
  ;    HisPara2 = 2

  compile_opt idl2
  ENVI,/RESTORE_BASE_SAVE_FILES
  ENVI_BATCH_INIT
  ;r=dialog_message((YieldFilenames[0])+(CropClassifyFilenames[0]))
  ;�ַ�to��ֵ
  HisPara1 = fix(HisPara1)
  HisPara2 = fix(HisPara2)
  ;������·��
  if strmid(OutputPath,strlen(OutputPath)-1,1) ne '\' then begin
    OutputPath = OutputPath+'\'
  endif
  test_file = file_test(OutputPath,/directory)
  if test_file eq 0 then begin
    file_mkdir,OutputPath
  endif
  ;�ļ���
  NFiles = n_elements(YieldFilenames)
  ;��ø����������
  Maize = []
  Wheat = []
  Soybean = []
  
  FOR i=0,NFiles-1 do begin
    CropClassifyData = read_tiff(CropClassifyFilenames[i])
    YieldData = read_tiff(YieldFilenames[i])
    result = QUERY_TIFF(YieldFilenames[i],ImgInfo)
    ns = imginfo.DIMENSIONS[0]
    nl = imginfo.DIMENSIONS[1]
    YieldTemp = YieldData;reform(YieldData,1,ns*nl)
    CropClassifyTemp = CropClassifyData;reform(CropClassifyData,1,ns*nl)
    
    ;����
    MaizeIndex = where(CropClassifyTemp EQ 1 and YieldTemp gt 0)
    MaizeTemp = YieldTemp[MaizeIndex]
    Maize = [Maize,MaizeTemp]
    ;��
    SoybeanIndex = where(CropClassifyTemp EQ 2 and YieldTemp gt 0)
    SoybeanTemp = YieldTemp[SoybeanIndex]
    Soybean = [Soybean,SoybeanTemp]
    ;С��
    WheatIndex = where(CropClassifyTemp EQ 3 and YieldTemp gt 0)
    WheatTemp = YieldTemp[WheatIndex]
    Wheat = [Wheat,WheatTemp]
  endfor
  
  ;�����һ������
  ENVI_REPORT_INIT,'�����һ������ ...',$
    title='�����һ������',base=base,/interrupt
    
  ;����
  Maizemin = min(Maize)
  Maizemax = max(Maize)
  HMaize = Histogram((Maize), Binsize=HisPara1, Min=Maizemin, Max=Maizemax)
  N_HMaize=n_elements(HMaize)
  X_Maize=Maizemin+indgen(N_HMaize)*HisPara1
  yfit = GAUSSFIT(X_Maize, HMaize, coeff, NTERMS=3);��˹���
  NormMaizeMin = coeff[1]-HisPara2*coeff[2]
  NormMaizeMax = coeff[1]+HisPara2*coeff[2]
  MuMinusSigma=coeff[1]-HisPara2*coeff[2]
  MuPlusSigma=coeff[1]+HisPara2*coeff[2]
  index = where(Maize ge MuMinusSigma and Maize le MuPlusSigma,CountMaize)
  N_Maize=N_ELEMENTS(Maize)
  Percent = CountMaize*1.0/N_Maize*100
  str='mu='+strtrim(string(coeff[1]),2)+' sigma='+strtrim(string(coeff[2]),2)+$
    ' [mu-'+strtrim(string(HisPara2),2)+'sigma,'+'mu+'+strtrim(string(HisPara2),2)+'sigma]'+' '+$
    strtrim(string(Percent),2)+'%'
  aM=barplot(X_Maize,HMaize,WINDOW_TITLE='����ֱ��ͼ����˹���',TITLE=STR,buffer=1)
  ;a.FONT_STYLE='isolatin1'
  bM=plot(X_Maize,yfit,LINESTYLE='dash', THICK=2,/CURRENT,AXIS_STYLE=0)
  bM.COLOR='red'
  OutFilename = OutputPath+'Gauss_Maize.jpg'
  bM.save,OutFilename
  ENVI_REPORT_STAT,BASE,30,100
  ;��
  Soybeanmin = min(Soybean)
  Soybeanmax = max(Soybean)
  HSoybean = Histogram((Soybean), Binsize=HisPara1, Min=Soybeanmin, Max=Soybeanmax)
  N_HSoybean=n_elements(HSoybean)
  X_Soybean=Soybeanmin+indgen(N_HSoybean)*HisPara1
  yfit = GAUSSFIT(X_Soybean, HSoybean, coeff, NTERMS=3);��˹���
  NormSoybeanMin = coeff[1]-HisPara2*coeff[2]
  NormSoybeanMax = coeff[1]+HisPara2*coeff[2]
  MuMinusSigma=coeff[1]-HisPara2*coeff[2]
  MuPlusSigma=coeff[1]+HisPara2*coeff[2]
  index = where(Soybean ge MuMinusSigma and Soybean le MuPlusSigma,CountSoybean)
  N_Soybean=N_ELEMENTS(Soybean)
  Percent = CountSoybean*1.0/N_Soybean*100
  str='mu='+strtrim(string(coeff[1]),2)+' sigma='+strtrim(string(coeff[2]),2)+$
    ' [mu-'+strtrim(string(HisPara2),2)+'sigma,'+'mu+'+strtrim(string(HisPara2),2)+'sigma]'+' '+$
    strtrim(string(Percent),2)+'%'
  aS=barplot(X_Soybean,HSoybean,WINDOW_TITLE='��ֱ��ͼ����˹���',TITLE=STR,buffer=1)
  ;a.FONT_STYLE='isolatin1'
  bS=plot(X_Soybean,yfit,LINESTYLE='dash', THICK=2,/CURRENT,AXIS_STYLE=0)
  bS.COLOR='red'
  OutFilename = OutputPath+'Gauss_Soybean.jpg'
  bS.save,OutFilename
  ENVI_REPORT_STAT,BASE,60,100
  ;С��
  Wheatmin = min(Wheat)
  Wheatmax = max(Wheat)
  HWheat = Histogram((Wheat), Binsize=HisPara1, Min=Wheatmin, Max=Wheatmax)
  N_HWheat=n_elements(HWheat)
  X_Wheat=Wheatmin+indgen(N_HWheat)*HisPara1
  yfit = GAUSSFIT(X_Wheat, HWheat, coeff, NTERMS=3);��˹���
  NormWheatMin = coeff[1]-HisPara2*coeff[2]
  NormWheatMax = coeff[1]+HisPara2*coeff[2]
  MuMinusSigma=coeff[1]-HisPara2*coeff[2]
  MuPlusSigma=coeff[1]+HisPara2*coeff[2]
  index = where(Wheat ge MuMinusSigma and Wheat le MuPlusSigma,CountWheat)
  N_Wheat=N_ELEMENTS(Wheat)
  Percent = CountWheat*1.0/N_Wheat*100
  str='mu='+strtrim(string(coeff[1]),2)+' sigma='+strtrim(string(coeff[2]),2)+$
    ' [mu-'+strtrim(string(HisPara2),2)+'sigma,'+'mu+'+strtrim(string(HisPara2),2)+'sigma]'+' '+$
    strtrim(string(Percent),2)+'%'
  ;device,set_font='isolatin1'
  aW=barplot(X_Wheat,HWheat,WINDOW_TITLE='С��ֱ��ͼ����˹���',TITLE=STR,buffer=1)
  ;  aW.FONT_STYLE='����'
  bW=plot(X_Wheat,yfit,LINESTYLE='dash', THICK=2,/CURRENT,AXIS_STYLE=0)
  bW.COLOR='red'
  OutFilename = OutputPath+'Gauss_Wheat.jpg'
  bW.save,OutFilename
  bW.CLOSE
  bs.close
  bm.close
  ENVI_REPORT_STAT,BASE,100,100
  ENVI_REPORT_INIT,BASE=BASE,/FINISH
  ;;;;;;;;;��һ��
  ;������
  ENVI_REPORT_INIT,'��������...',$
    title='������һ��',base=base2,/interrupt
  ENVI_REPORT_INC,BASE2,1
  
  NormData=fltarr(ns,nl,NFiles)
  FOR i=0,NFiles-1 do begin
    CropClassifyData = read_tiff(CropClassifyFilenames[i])
    YieldData = read_tiff(YieldFilenames[i],geotiff=geotiff)
    result = QUERY_TIFF(YieldFilenames[i],ImgInfo)
    ns = imginfo.DIMENSIONS[0]
    nl = imginfo.DIMENSIONS[1]
    
    
    OutData = YieldData
    
    ;����
    index=where(YieldData le NormMaizeMax and YieldData ge NormMaizeMin and CropClassifyData EQ 1 and YieldData gt 0)
    OutData[index]=(YieldData[index]-NormMaizeMin)/(NormMaizeMax-NormMaizeMin)
    index=where(YieldData lt NormMaizeMin and CropClassifyData EQ 1 and YieldData gt 0)
    OutData[index]=0
    index=where(YieldData gt NormMaizeMax and CropClassifyData EQ 1 and YieldData gt 0)
    OutData[index]=1
    index=where(YieldData le 0  and CropClassifyData EQ 1)
    OutData[index] = -1
    ;��
    index=where(YieldData le NormSoybeanMax and YieldData ge NormSoybeanMin and CropClassifyData EQ 2 and YieldData gt 0)
    OutData[index]=(YieldData[index]-NormSoybeanMin)/(NormSoybeanMax-NormSoybeanMin)
    index=where(YieldData lt NormSoybeanMin and CropClassifyData EQ 2 and YieldData gt 0)
    OutData[index]=0
    index=where(YieldData gt NormSoybeanMax and CropClassifyData EQ 2 and YieldData gt 0)
    OutData[index]=1
    index=where(YieldData le 0  and CropClassifyData EQ 2)
    OutData[index] = -1
    ;С��
    index=where(YieldData le NormWheatMax and YieldData ge NormWheatMin and CropClassifyData EQ 3 and YieldData gt 0)
    OutData[index]=(YieldData[index]-NormWheatMin)/(NormWheatMax-NormWheatMin)
    index=where(YieldData lt NormWheatMin and CropClassifyData EQ 3 and YieldData gt 0)
    OutData[index]=0
    index=where(YieldData gt NormWheatMax and CropClassifyData EQ 3 and YieldData gt 0)
    OutData[index]=1
    index=where(YieldData le 0  and CropClassifyData EQ 3)
    OutData[index] = -1
    ;
    index=where(CropClassifyData ne 3 and CropClassifyData ne 2 and CropClassifyData ne 1)
    OutData[index] = -1
    ;
    NormData[*,*,i]=OutData
    ;����ļ�
    OutYieldFilename = OutputPath+file_basename(strmid(YieldFilenames[i],0,strlen(YieldFilenames[i])-4)+'_Normal.tif')
    write_tiff,OutYieldFilename,OutData,geotiff=geotiff,/float
    ENVI_REPORT_STAT,BASE2,(i+1)*1.0/(NFiles)*100,100
  endfor
  ;�������ֵ
  MaxNormData = fltarr(ns,nl)
  for i_ns=0,ns-1 do begin
    for i_nl=0,nl-1 do begin
      MaxNormData[i_ns,i_nl] = MAX(NormData[i_ns,i_nl])
    endfor
  endfor
  OutMaxNormYieldFilename = OutputPath+'MaxNormYield.tif'
  write_tiff,OutMaxNormYieldFilename,MaxNormData,geotiff=geotiff,/float
  ENVI_REPORT_INIT,BASE=BASE2,/FINISH
;  envi_batch_exit
 Message=''
end