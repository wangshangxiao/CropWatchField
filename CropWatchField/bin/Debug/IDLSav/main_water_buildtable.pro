    pro main_water_buildtable,watertableoutpath=watertableoutpath,Message=Message
    compile_opt idl2
;    Result = DIALOG_MESSAGE(watertableoutpath)
    ;ʵ�ֹ��ܣ���������ˮ�ֺ����Ĳ��ұ�
    ;print,systime()
    ;�������ұ��Լ��Ҫ25����
    ;outwaterfindtablepath������Ĳ��ұ�Ĵ洢·��
    ;ʹ��Cw Cm ALA Hspot Ns�޹������������
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
    
    ;�͹۲���
    ;    Cab=fltarr(20)+20           ;[20,60]����Ϊ  2
    ;    for k=0,18 do begin
    ;    Cab(k+1)=Cab(k)+2
    ;    endfor
    
    Cw=fltarr(20)+0.005        ;[0.005,0.045]����Ϊ0.002
    for k=0,18 do begin
      Cw[k+1]=Cw[k]+0.002
    endfor
    
    Cm=fltarr(10)+0.002        ;[0.002,0.01]����Ϊ0.0008
    for k=0,8 do begin
      Cm[k+1]=Cm[k]+0.0008
    endfor
    ;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;    ALA=fltarr(10)+30          ;[30,80]����Ϊ5
;    for k=0,8 do begin
;      ALA[k+1]=ALA[k]+5
;    endfor
    ;  ;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
    ;    Lai=fltarr(10)+1           ;[1,7]����Ϊ0.6
    ;    for k=0,8 do begin
    ;    Lai(k+1)=Lai(k)+0.6
    ;    endfor
    ;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;        Hspot=fltarr(10)           ;[0,1]����Ϊ0.1
;        for k=0,8 do begin
;        Hspot[k+1]=Hspot[k]+0.1
;        endfor
;    
;        Ns=fltarr(5)+1            ;[1,2]����Ϊ0.2
;        for k=0,3 do begin
;        Ns[k+1]=Ns[k]+0.2
;        endfor
    ;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
    ;    Psoil=fltarr(20)+0.05      ;[0.05,0.25]����Ϊ0.01
    ;    for k=0,18 do begin
    ;    Psoil(k+1)=Psoil(k)+0.01
    ;    endfor
    
    
    
    ;̫���춥�� tts   �۲��춥��tto
    ;diffuse/direct radiation
    
    
    ;ENVI������
    ENVI,/restore_base_save_files
    ENVI_BATCH_INIT
    ;��ʼ��������
    ENVI_REPORT_INIT, '�������ұ��С�',title="������",base=base ,/INTERRUPT
    ENVI_REPORT_INC, base,n_elements(Cw)
    OPENW,table,watertableoutpath+'\'+'IRSwatertable.txt',/GET_LUN       ;������ұ�
        
    for w = 0,n_elements(Cw)-1 do begin
      for m = 0,n_elements(Cm)-1 do begin
        for n =0,n_elements(Ns)-1 do begin
          for a =0,n_elements(ALA)-1 do begin
            for hs=0,n_elements(hspot)-1 do begin
            
              PRO4SAIL5B,Cab,Car,Cbrown,Cw[w],Cm[m],Ns[n],ALA[a],lai,hspot[hs],tts,tto,psi,$
                psoil,skyl,resh,resv
              HJIRS_response=GET_HJ_IRS_response()
              band1 = total(resv[300:720]*HJIRS_response[1,0:420])/total(HJIRS_response[1,*])
              band2 = total(resv[1080:1410]*HJIRS_response[2,425:755])/total(HJIRS_response[2,*])
              ;then the look up table will be built
              IRSref0 = [Cw[w],ALA[a],hspot[hs],Cm[m],Ns[n],band1,band2]
              IRSref = strjoin(string(IRSref0,format='(2108f10.6)'));2108�����ʽ�����ظ�������Ĭ��Ϊ1�Σ�10�����ַ���ȣ�6��ʾ����ֵ�������뵽6λ�ľ��ȡ�
              ;str = transpose(string(lut,format='(2108f10.6)'))
              ;strjoin��ʾ�ַ��������ӣ�string��ʾ��ʽ��������ַ�������
              ;print,string(lut,format='(2108f10.6)')
              ;OPENW���ļ������ڶ�д;/GET_LUN,����������һ���Ϸ����߼��豸�ţ�100-128�������������
              ;/APPEND:��ԭ���ݵĺ�����׷�ӵ���ʽ�����ļ�д������
              ;PRINTF,LUN,transpose(str)
              PRINTF,table,IRSref    ;format='(10(f," "),f)';��ʽ�е����ֱ�ʾΪ������һ
            endfor
          endfor
        endfor
      endfor
      ENVI_REPORT_STAT,base, w+1, float(n_elements(Cw)), CANCEL=cancelvar
      ;�ж��Ƿ���ȡ��
        IF cancelVar EQ 1 THEN BEGIN
        ; tmp = DIALOG_MESSAGE('�����ȡ��'+'%'+STRING(Tn),/info)
        ENVI_REPORT_INIT, base=base, /finish
        ENVI_BATCH_EXIT
        return
      ENDIF
    endfor
    FREE_LUN,table
    ENVI_REPORT_INIT, base=base, /finish    
    ;  print,systime()
;    ENVI_BATCH_EXIT
    Message=''
    end
    PRO test_main_water_buildtable
    watertableoutpath='D:\10_test'
    main_water_buildtable,watertableoutpath=watertableoutpath,Message=Message
    END
