;˵����
;YieldFilenames----�����ļ���
;CropClassifyFilenames----���������ļ���
;       1-����
;       2-��
;       3-С��
;OutputPath----���·��
;HisPara1----���
;HisPara2----�ٷ��� ͨ���涨�ٷ�����ȷ����һ���������Сֵ
pro Nutrient_Percent,YieldFilenames,CropClassifyFilenames,OutputPath,HisPara1,HisPara2,Message=Message
  ;test
;  YieldFilenames = 'D:\test\'+['ss_harvest_2010_yield.tif']
;  CropClassifyFilenames = 'D:\test\'+['2010crop-tif_sub.tif']
;  OutputPath = 'd:\rrrr\'
;  HisPara1 = 20
;  HisPara2 = '95'
  
  compile_opt idl2
  ENVI,/RESTORE_BASE_SAVE_FILES
  ENVI_BATCH_INIT
  ;�ַ�to��ֵ
  HisPara1 = fix(HisPara1)
  HisPara2 = float(HisPara2)/100.0
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
  ;r=dialog_message((YieldFilenames[0])+(CropClassifyFilenames[0])+string(NFiles))
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
  MaizeMean = Mean(Maize)
  N_Maize=n_elements(Maize)
  Maizemin = min(Maize)
  Maizemax = max(Maize)
  for i=1,fix(Maizemax) do begin
    index=where(Maize gt MaizeMean-i and Maize lt MaizeMean+i,count)
    p=count*1.0/N_Maize
    if p gt HisPara2 then begin
      NormMaizeMax = MaizeMean+i
      NormMaizeMin = MaizeMean-i
      break
    endif
  endfor
  HMaize = Histogram((Maize), Binsize=HisPara1, Min=Maizemin, Max=Maizemax)
  N_HMaize=n_elements(HMaize)
  X_Maize=Maizemin+indgen(N_HMaize)*HisPara1
  str='Mean='+strtrim(string(MaizeMean),2)+' Min='+strtrim(string(NormMaizeMin),2)+$
    ' Max='+strtrim(string(NormMaizeMax),2)+' P='+strtrim(string(fix(HisPara2*100)),2)+'%'
  aM=barplot(X_Maize,HMaize,WINDOW_TITLE='����ֱ��ͼ����һ������',TITLE=STR,buffer=1)
  OutFilename = OutputPath+'Percent_Maize.jpg'
  aM.save,OutFilename
  ENVI_REPORT_STAT,BASE,30,100
  ;��
  SoybeanMean = Mean(Soybean)
  N_Soybean=n_elements(Soybean)
  Soybeanmin = min(Soybean)
  Soybeanmax = max(Soybean)
  for i=1,fix(Soybeanmax) do begin
    index=where(Soybean gt SoybeanMean-i and Soybean lt SoybeanMean+i,count)
    p=count*1.0/N_Soybean
    if p gt HisPara2 then begin
      NormSoybeanMax = SoybeanMean+i
      NormSoybeanMin = SoybeanMean-i
      break
    endif
  endfor
  HSoybean = Histogram((Soybean), Binsize=HisPara1, Min=Soybeanmin, Max=Soybeanmax)
  N_HSoybean=n_elements(HSoybean)
  X_Soybean=Soybeanmin+indgen(N_HSoybean)*HisPara1
  str='Mean='+strtrim(string(SoybeanMean),2)+' Min='+strtrim(string(NormSoybeanMin),2)+$
    ' Max='+strtrim(string(NormSoybeanMax),2)+' P='+strtrim(string(fix(HisPara2*100)),2)+'%'
  aS=barplot(X_Soybean,HSoybean,WINDOW_TITLE='��ֱ��ͼ����һ������',TITLE=STR,buffer=1)
  OutFilename = OutputPath+'Percent_Soybean.jpg'
  aS.save,OutFilename
  ENVI_REPORT_STAT,BASE,60,100
  ;С��
  WheatMean = Mean(Wheat)
  N_Wheat=n_elements(Wheat)
  Wheatmin = min(Wheat)
  Wheatmax = max(Wheat)
  for i=1,fix(Wheatmax) do begin
    index=where(Wheat gt WheatMean-i and Wheat lt WheatMean+i,count)
    p=count*1.0/N_Wheat
    if p gt HisPara2 then begin
      NormWheatMax = WheatMean+i
      NormWheatMin = WheatMean-i
      break
    endif
  endfor
  HWheat = Histogram((Wheat), Binsize=HisPara1, Min=Wheatmin, Max=Wheatmax)
  N_HWheat=n_elements(HWheat)
  X_Wheat=Wheatmin+indgen(N_HWheat)*HisPara1
  str='Mean='+strtrim(string(WheatMean),2)+' Min='+strtrim(string(NormWheatMin),2)+$
    ' Max='+strtrim(string(NormWheatMax),2)+' P='+strtrim(string(fix(HisPara2*100)),2)+'%'
  aW=barplot(X_Wheat,HWheat,WINDOW_TITLE='С��ֱ��ͼ����һ������',TITLE=STR,buffer=1)
  OutFilename = OutputPath+'Percent_Wheat.jpg'
  aW.save,OutFilename
  AW.CLOSE
  As.close
  Am.close
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
    OutYieldFilename = OutputPath+strmid(file_Basename(YieldFilenames[i]),0,strlen(file_basename(YieldFilenames[i]))-4)+'_Normal.tif'
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
  envi_batch_exit
end