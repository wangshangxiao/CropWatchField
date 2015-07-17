  pro main_ch_buildtable,inputtype=inputtype,chtableoutpath=chtableoutpath,Message=Message
    compile_opt idl2
    ;�������õ�
;    Result1 = DIALOG_MESSAGE(chtableoutpath)
    ;ʵ�ֹ��ܣ���������Ҷ���غ����Ĳ��ұ�
    ;inputtype��ʾ����Ļ������������ͣ�����CCDA1��CCDA2��CCDB1��CCDB2
    ;chtableoutpathָ����Ĳ��ұ��·��
    ;�������ұ��ʱ���Լ��25����
    ;print,systime()
    ;EXAMPLE INPUT VALUES
    ;INPUTS OF PROSECT
    Cab    =38d             ;chlorophyll content (g.cm-2) (20-80 possible for Ohia)   [20,60]����Ϊ  2
    Car    =8.0d            ;carotenoid content (g.cm-2)  (5-18 possible for Ohia)
    Cbrown =0.000d          ;brown pigment content (arbitrary units) - wood/shade?
    Cw     =0.015d          ;EWT (cm) - Equivalent water thickness                    [0.005,0.045]����Ϊ0.002
    Cm     =0.005d          ;LMA (g.cm-2) - leaf mass per unit leaf area (0.05-0.2 possible for Ohia)  [0.002,0.01]����Ϊ0.0004
    ;PROSPECT
    ;INPUTS OF SAIL
    ALA    =35.0d           ;average leaf angle      [30,80]����Ϊ2.5
    Lai    =2d              ;leaf area index         [1,7]����Ϊ0.3
    Hspot  =0.01d           ;hot spot                [0,1]����Ϊ0.05
    Ns     =1.5d                                    ;[1,2]����Ϊ0.05
    ;����Ϊ�ڲ�������������
    psoil  = 0.2d            ;soil coefficient�������׷�����        [0.05,0.25]����Ϊ0.01
    tts    =40.41242d        ;solar zenith angle  ̫���춥��
    tto    =23.3773d         ;observer zenith angle  �۲��춥��
    psi    =233.547d         ;azimuth  ��Է�λ��
    skyl   =10.0d            ;diffuse/direct radiation�������ܼ��ȸߡ��չ�ǿ��ʱ,Skyl��ԼΪ10% ,��������, Skyl�ɸ���90%
    
    ;  PRO4SAIL5B,Cab,Car,Cbrown,Cw,Cm,Ns,ALA,lai,hspot,tts,tto,psi,$
    ;  psoil,skyl,resh,resv
    ;  Basicpara=[Cab,Cw,Cm,ALA,Lai,Hspot,Ns,psoil,reform(resv)];��Ż����Ĳο�����
    ;  Basicpara0=Basicpara(8:2108,*)
    ;�͹۲���
    Cab=fltarr(20)+30           ;[20,60]����Ϊ  2   [30,50]����Ϊ  2
    for k=0,18 do begin
      Cab[k+1]=Cab[k]+1
    endfor
    
    ;    Cw=fltarr(20)+0.005        ;[0.005,0.045]����Ϊ0.002
    ;    for k=0,18 do begin
    ;    Cw[k+1]=Cw[k]+0.002
    ;    endfor
    
    ;    Cm=fltarr(20)+0.002        ;[0.002,0.01]����Ϊ0.0004
    ;    for k=0,18 do begin
    ;    Cm[k+1]=Cm[k]+0.0004
    ;    endfor
    ;---------------------------------------------------------------
        ALA=fltarr(10)+30          ;[30,80]����Ϊ5
        for k=0,8 do begin
        ALA[k+1]=ALA[k]+5
        endfor
    ;;
    ;    Lai=fltarr(10)+1           ;[1,7]����Ϊ0.6
    ;    for k=0,8 do begin
    ;    Lai[k+1]=Lai[k]+0.6
    ;    endfor
    ;
    ;    Hspot=fltarr(10)           ;[0,1]����Ϊ0.1
    ;    for k=0,8 do begin
    ;    Hspot[k+1]=Hspot[k]+0.1
    ;    endfor
    ;
        Ns=fltarr(5)+1            ;[1,2]����Ϊ0.2
        for k=0,3 do begin
        Ns[k+1]=Ns[k]+0.2
        endfor
    ;-----------------------------------------------------------
    ;    Psoil=fltarr(20)+0.05      ;[0.05,0.25]����Ϊ0.01
    ;    for k=0,18 do begin
    ;    Psoil[k+1]=Psoil[k]+0.01
    ;    endfor
    
    OPENW,table,chtableoutpath+'\'+inputtype+'chtable.txt',/GET_LUN
    ;̫���춥�� tts   �۲��춥��tto
    ;diffuse/direct radiation
    ;ENVI������
    ENVI,/restore_base_save_files
    ENVI_BATCH_INIT
    ;��ʼ��������
    ENVI_REPORT_INIT, '�������ұ��С�', $
      title="������", $
      base=base ,/INTERRUPT
    ENVI_REPORT_INC, base,n_elements(Cab)
    
    for ab=0,n_elements(Cab)-1 do begin
      for n =0,n_elements(Ns)-1 do begin
        for a =0,n_elements(ALA)-1 do begin
          for i=0,n_elements(LAI)-1 do begin
            for hs=0,n_elements(hspot)-1 do begin
            
              ;��ʼ�������ұ�
              PRO4SAIL5B,Cab[ab],Car,Cbrown,Cw,Cm,Ns[n],ALA[a],lai[i],hspot[hs],tts,tto,psi,$
                psoil,skyl,resh,resv
              ;��ϵ���������EQ  =  ;LT < ;GT >;NE ������;LE <=;GE >=
              HJ_respsose  = GET_HJ_CCD_response()  ; HJ�Ǵ������Ĺ�����Ӧ����              ������A  ccd1 ccd2 ��B ccd1  ccd2
              ;ѡ�񻷾���CCD��������:�ֱ��л�����A��CCD1��CCD2�ͻ�����B��CCD1��CCD2
              CASE (inputtype) of
                'HJCCDA1':BEGIN
                blue=total(resv*HJ_respsose[1,*])/total(HJ_respsose[1,*])
                green=total(resv*HJ_respsose[2,*])/total(HJ_respsose[2,*])
                red=total(resv*HJ_respsose[3,*])/total(HJ_respsose[3,*])
                nir=total(resv*HJ_respsose[4,*])/total(HJ_respsose[4,*])
              END
              'HJCCDA2':BEGIN
              blue=total(resv*HJ_respsose[5,*])/total(HJ_respsose[5,*])
              green=total(resv*HJ_respsose[6,*])/total(HJ_respsose[6,*])
              red=total(resv*HJ_respsose[7,*])/total(HJ_respsose[7,*])
              nir=total(resv*HJ_respsose[8,*])/total(HJ_respsose[8,*])
            END
            'HJCCDB1':BEGIN
            blue=total(resv*HJ_respsose[9,*])/total(HJ_respsose[9,*])
            green=total(resv*HJ_respsose[10,*])/total(HJ_respsose[10,*])
            red=total(resv*HJ_respsose[11,*])/total(HJ_respsose[11,*])
            nir=total(resv*HJ_respsose[12,*])/total(HJ_respsose[12,*])
          END
          'HJCCDB2':BEGIN
          blue=total(resv*HJ_respsose[13,*])/total(HJ_respsose[13,*])
          green=total(resv*HJ_respsose[14,*])/total(HJ_respsose[14,*])
          red=total(resv*HJ_respsose[15,*])/total(HJ_respsose[15,*])
          nir=total(resv*HJ_respsose[16,*])/total(HJ_respsose[16,*])
        END
      ENDCASE
      ;using the red and nir band for estimating the LAI
      ;then the look up table will be built
      ;ccdref0 = [Ns[n],Lai[i],Cab[ab],Cm[m],Cw[w],ALA[a],psoil[ps],blue,green,red,nir]
      ccdref0 = [Cab[ab],ALA[a],Lai[i],hspot[hs],Ns[n],green,red]
      ;Reform()��������ʹ������Ԫ�ظ������޸ĵ�ǰ���£��ı������ά��������������Ķ�̬ʹ��
      ccdref = strjoin(string(ccdref0,format='(2108f10.6)'));2108�����ʽ�����ظ�������Ĭ��Ϊ1�Σ�10�����ַ���ȣ�6��ʾ����ֵ�������뵽6λ�ľ��ȡ�
      PRINTF,table,ccdref    ;format='(10(f," "),f)';��ʽ�е����ֱ�ʾΪ������һ
    endfor
  endfor
endfor
endfor
ENVI_REPORT_STAT,base, ab+1, float(n_elements(Cab)), CANCEL=cancelvar
;�ж��Ƿ���ȡ��
IF cancelVar EQ 1 THEN BEGIN
  ; tmp = DIALOG_MESSAGE('�����ȡ��'+'%'+STRING(Tn),/info)
  ENVI_REPORT_INIT, base=base, /finish
  return
  ENVI_BATCH_EXIT
ENDIF
endfor
FREE_LUN,table
ENVI_REPORT_INIT, base=base, /finish
;����������
;ENVI_BATCH_EXIT
;print,systime()
Message=''
end
 pro test_main_ch_buildtable
    inputtype='HJCCDA1'
    chtableoutpath='D:\10_test'
    main_ch_buildtable,inputtype=inputtype,chtableoutpath=chtableoutpath,Message=Message
  end
