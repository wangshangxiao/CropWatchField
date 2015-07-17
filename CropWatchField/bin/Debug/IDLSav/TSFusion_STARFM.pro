pro TSFusion_STARFM,Fx,F0,C0,C1,WIN_SIZE,Message=Message
  ;函数描述：
  ;STARFM 融合法
  ;简化公式:
  ;L2=convol((M2-M1+L1)/ABS(L1-M1)/ABS(M1-M2),1/Dijk)/convol(1./ABS(L1-M1)/ABS(M1-M2),1/Dijk)
  ;
  ;参数说明：
  ;fx-所预测的t1时期高空间分辨率影像
  ;f0-t0时期的高空间分辨率影像
  ;c0-t0时期的低空间分辨率影像
  ;c1-t1时期低空间分辨率影像
  ;win_size-窗口大小
  ;Message-返回的消息
;  win_size='3'
;  Fx = 'D:\share\Hongxingtest\yxz\TestData\out\predictiontest1.tif'
;  F0 = 'D:\share\Hongxingtest\yxz\TestData\spatialtime\T0spatial\ndvi_l5121031_03120090620sub_sub.tif'
;  C0 = 'D:\share\Hongxingtest\yxz\TestData\spatialtime\T0time\a2009177.250m_16_days_ndvi_processed_sub_pro_sub.tif'
;  C1 = 'D:\share\Hongxingtest\yxz\TestData\spatialtime\T1\a2009209.250m_16_days_ndvi_processed_sub_pro_sub.tif'
  
  Fx = file_dirname(Fx)+'\'+file_basename(Fx,'.tif')
  win_size=fix(win_size)
  COMPILE_OPT IDL2
  ENVI,/RESTORE_BASE_SAVE_FILES
  ENVI_BATCH_INIT
  ;打开F0
  ENVI_OPEN_FILE,F0,r_fid=f0_fid
  if (f0_fid eq -1) then begin
    Message = '打开t0时期高空间分辨率影像错误！'
    envi_batch_exit
  endif
  ;得到FO影像参数
  envi_file_query,f0_fid,ns=f0_ns,nl=f0_nl,dims=f0_dims,nb=f0_nb,data_type=f0_type
  f0_mapinfo=ENVI_GET_MAP_INFO(fid=f0_fid)
  
  ;打开C0
  ENVI_OPEN_FILE,C0,r_fid=C0_fid
  if (C0_fid eq -1) then begin
    Message = '打开t0时期高时间分辨率影像错误！'
    envi_batch_exit
  endif
  ;得到C0影像参数
  envi_file_query,C0_fid,ns=C0_ns,nl=C0_nl,dims=C0_dims,nb=C0_nb,data_type=c0_type
  C0_mapinfo=ENVI_GET_MAP_INFO(fid=C0_fid)
  
  ;打开C1
  ENVI_OPEN_FILE,C1,r_fid=C1_fid
  if (C1_fid eq -1) then begin
    Message = '打开t1时期高时间分辨率影像错误！'
    envi_batch_exit
  endif
  ;得到C0影像参数
  envi_file_query,C1_fid,ns=C1_ns,nl=C1_nl,dims=C1_dims,nb=C1_nb,data_type=c1_type
  C1_mapinfo=ENVI_GET_MAP_INFO(fid=C1_fid)
  
  ;打开预测影像文件
  OPENW,lun,Fx,/GET_LUN
  ;块大小
  block=200<f0_nl
  win_radius=win_size/2
  ;初始化进度条
  ENVI_REPORT_INIT,'数据处理中...',title="时空融合",base=base,/interrupt
  ENVI_REPORT_INC,BASE,1
  FOR line=win_radius,f0_nl-win_radius-1,block DO BEGIN
    block_line=((line+block+win_radius-1<(f0_nl-1))-line+win_radius+1)
    C0DATA=make_array(f0_ns,block_line,F0_nb,type=c0_type)
    C1DATA=make_array(f0_ns,block_line,type=c1_type)
    F0DATA=make_array(f0_ns,block_line,type=f0_type)
    FxDATA=make_array(f0_ns,block_line,type=f0_type)
    FOR i_nb=0,F0_nb-1 DO BEGIN
      tempdata = ENVI_GET_DATA(DIMS=[-1L,0,f0_ns-1,line-win_radius,(line+block-1+win_radius)<(f0_nl-1)],FID=C0_fid,POS=i_nb)
      C0DATA[*,*,i_nb] = tempdata
    ENDFOR
    FOR i_nb=0,F0_nb-1 DO BEGIN
      tempdata = ENVI_GET_DATA(DIMS=[-1L,0,f0_ns-1,line-win_radius,(line+block-1+win_radius)<(f0_nl-1)],FID=C1_fid,POS=i_nb)
      C1DATA[*,*,i_nb] = tempdata
    ENDFOR
    FOR i_nb=0,F0_nb-1 DO BEGIN
      tempdata = ENVI_GET_DATA(DIMS=[-1L,0,f0_ns-1,line-win_radius,(line+block-1+win_radius)<(f0_nl-1)],FID=F0_fid,POS=i_nb)
      F0DATA[*,*,i_nb] = tempdata
    ENDFOR
    ;;;;;;;;;Starfm;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
    ;卷积核
    kernel=dblarr(win_size,win_size)
    for i=0,win_size-1 do begin
      for j=0,win_size-1 do begin
        KERNEL[i,j]=1./((sqrt((j-win_radius)^2+(i-win_radius)^2))+1.0)
      endfor
    endfor
    ;逐像素处理
    for i=win_radius, f0_ns-1-win_radius do begin
      ;计算进度
      p = ((line-win_radius)*(f0_ns-2.*win_radius)+(i*block_line-2.*win_radius))/((f0_nl-2*win_radius)*(f0_ns-2*win_radius))*100
      ENVI_REPORT_STAT,BASE,p,100.,cancel=cancelvar
      for j=win_radius, block_line-1-win_radius do begin
        ;;;Choose candidates according to spectral difference
        Candidate=intarr(win_size,win_size)
        Candidate[*,*]=1
        S=abs(F0DATA[i-win_radius:i+win_radius,j-win_radius:j+win_radius]-C0DATA[i-win_radius:i+win_radius,j-win_radius:j+win_radius])
        T=abs(C1DATA[i-win_radius:i+win_radius,j-win_radius:j+win_radius]-C0DATA[i-win_radius:i+win_radius,j-win_radius:j+win_radius])
        Candidate=(S Le ABS(F0DATA[i,j]-C0DATA[i,j]))*(T Le ABS(C1DATA[i,j]-C0DATA[i,j]))*Candidate
        ;numerator
        Temp1=1./(S*T)*(C1DATA[i-win_radius:i+win_radius,j-win_radius:j+win_radius]-C0DATA[i-win_radius:i+win_radius,j-win_radius:j+win_radius]+$
          F0DATA[i-win_radius:i+win_radius,j-win_radius:j+win_radius])*Candidate
        numerator=convol(Temp1,kernel)
        ;denominator
        Temp2=1./(S*T)*Candidate
        denominator=convol(Temp2,kernel)
        if F0DATA[I,J]-C0DATA[I,J] eq 0 then begin
          Fxdata[i,j]=fix(C1DATA[I,J])
        endif else IF F0DATA[I,J]-C0DATA[I,J] eq 0 THEN begin
          Fxdata[i,j]=fix(F0DATA[I,J])
        endif else begin
          Fxdata[i,j]=floor(numerator[win_radius,win_radius]/denominator[win_radius,win_radius]+0.00000001)
        endelse
      endfor
    endfor
    ;写块
    if line eq win_radius then begin
      FOR i_block_line=0,block_line-1-win_radius DO BEGIN
        WRITEU,lun,Fxdata[*,i_block_line]
      ENDFOR
    endif else if line+block ge f0_nl-win_radius-1 then begin
      FOR i_block_line=win_radius,block_line-1 DO BEGIN
        WRITEU,lun,Fxdata[*,i_block_line]
      ENDFOR
    endif else begin
      FOR i_block_line=win_radius,block_line-1-win_radius DO BEGIN
        WRITEU,lun,Fxdata[*,i_block_line]
      ENDFOR
    endelse
  ENDFOR
  FREE_LUN,lun
  ;输出文件
  ENVI_SETUP_HEAD,fname=Fx,ns=f0_ns,nl=f0_nl,nb=f0_nb,$
    DATA_TYPE=2,offset=0,INTERLEAVE=1,MAP_INFO=f0_mapinfo, /write, /open
  ENVI_OPEN_FILE,fx,r_fid=Out_fid
  ENVI_OUTPUT_TO_EXTERNAL_FORMAT, DIMS=f0_dims, $
    FID=Out_fid, OUT_NAME=Fx+'.tif',POS=LINDGEN(f0_nb), /TIFF
  ENVI_FILE_MNG,ID=Out_fid,/DELETE,/REMOVE
  Message = ''
  ENVI_REPORT_INIT,base=base,/finish
  ENVI_BATCH_EXIT
end