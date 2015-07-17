  pro main_ch_buildtable,inputtype=inputtype,chtableoutpath=chtableoutpath,Message=Message
    compile_opt idl2
    ;调程序用的
;    Result1 = DIALOG_MESSAGE(chtableoutpath)
    ;实现功能：建立反演叶绿素含量的查找表
    ;inputtype表示输入的环境星数据类型，包括CCDA1，CCDA2，CCDB1，CCDB2
    ;chtableoutpath指输出的查找表的路径
    ;建立查找表的时间大约是25分钟
    ;print,systime()
    ;EXAMPLE INPUT VALUES
    ;INPUTS OF PROSECT
    Cab    =38d             ;chlorophyll content (g.cm-2) (20-80 possible for Ohia)   [20,60]步长为  2
    Car    =8.0d            ;carotenoid content (g.cm-2)  (5-18 possible for Ohia)
    Cbrown =0.000d          ;brown pigment content (arbitrary units) - wood/shade?
    Cw     =0.015d          ;EWT (cm) - Equivalent water thickness                    [0.005,0.045]步长为0.002
    Cm     =0.005d          ;LMA (g.cm-2) - leaf mass per unit leaf area (0.05-0.2 possible for Ohia)  [0.002,0.01]步长为0.0004
    ;PROSPECT
    ;INPUTS OF SAIL
    ALA    =35.0d           ;average leaf angle      [30,80]步长为2.5
    Lai    =2d              ;leaf area index         [1,7]步长为0.3
    Hspot  =0.01d           ;hot spot                [0,1]步长为0.05
    Ns     =1.5d                                    ;[1,2]步长为0.05
    ;以上为冠层生理生化参数
    psoil  = 0.2d            ;soil coefficient土壤光谱反射率        [0.05,0.25]步长为0.01
    tts    =40.41242d        ;solar zenith angle  太阳天顶角
    tto    =23.3773d         ;observer zenith angle  观测天顶角
    psi    =233.547d         ;azimuth  相对方位角
    skyl   =10.0d            ;diffuse/direct radiation当大气能见度高、日光强烈时,Skyl大约为10% ,而在阴天, Skyl可高于90%
    
    ;  PRO4SAIL5B,Cab,Car,Cbrown,Cw,Cm,Ns,ALA,lai,hspot,tts,tto,psi,$
    ;  psoil,skyl,resh,resv
    ;  Basicpara=[Cab,Cw,Cm,ALA,Lai,Hspot,Ns,psoil,reform(resv)];存放基本的参考数据
    ;  Basicpara0=Basicpara(8:2108,*)
    ;客观参数
    Cab=fltarr(20)+30           ;[20,60]步长为  2   [30,50]步长为  2
    for k=0,18 do begin
      Cab[k+1]=Cab[k]+1
    endfor
    
    ;    Cw=fltarr(20)+0.005        ;[0.005,0.045]步长为0.002
    ;    for k=0,18 do begin
    ;    Cw[k+1]=Cw[k]+0.002
    ;    endfor
    
    ;    Cm=fltarr(20)+0.002        ;[0.002,0.01]步长为0.0004
    ;    for k=0,18 do begin
    ;    Cm[k+1]=Cm[k]+0.0004
    ;    endfor
    ;---------------------------------------------------------------
        ALA=fltarr(10)+30          ;[30,80]步长为5
        for k=0,8 do begin
        ALA[k+1]=ALA[k]+5
        endfor
    ;;
    ;    Lai=fltarr(10)+1           ;[1,7]步长为0.6
    ;    for k=0,8 do begin
    ;    Lai[k+1]=Lai[k]+0.6
    ;    endfor
    ;
    ;    Hspot=fltarr(10)           ;[0,1]步长为0.1
    ;    for k=0,8 do begin
    ;    Hspot[k+1]=Hspot[k]+0.1
    ;    endfor
    ;
        Ns=fltarr(5)+1            ;[1,2]步长为0.2
        for k=0,3 do begin
        Ns[k+1]=Ns[k]+0.2
        endfor
    ;-----------------------------------------------------------
    ;    Psoil=fltarr(20)+0.05      ;[0.05,0.25]步长为0.01
    ;    for k=0,18 do begin
    ;    Psoil[k+1]=Psoil[k]+0.01
    ;    endfor
    
    OPENW,table,chtableoutpath+'\'+inputtype+'chtable.txt',/GET_LUN
    ;太阳天顶角 tts   观测天顶角tto
    ;diffuse/direct radiation
    ;ENVI进度条
    ENVI,/restore_base_save_files
    ENVI_BATCH_INIT
    ;初始化进度条
    ENVI_REPORT_INIT, '建立查找表中…', $
      title="进度条", $
      base=base ,/INTERRUPT
    ENVI_REPORT_INC, base,n_elements(Cab)
    
    for ab=0,n_elements(Cab)-1 do begin
      for n =0,n_elements(Ns)-1 do begin
        for a =0,n_elements(ALA)-1 do begin
          for i=0,n_elements(LAI)-1 do begin
            for hs=0,n_elements(hspot)-1 do begin
            
              ;开始建立查找表
              PRO4SAIL5B,Cab[ab],Car,Cbrown,Cw,Cm,Ns[n],ALA[a],lai[i],hspot[hs],tts,tto,psi,$
                psoil,skyl,resh,resv
              ;关系型运算符：EQ  =  ;LT < ;GT >;NE 不等于;LE <=;GE >=
              HJ_respsose  = GET_HJ_CCD_response()  ; HJ星传感器的光谱响应函数              环境星A  ccd1 ccd2 星B ccd1  ccd2
              ;选择环境行CCD数据类型:分别有环境星A的CCD1、CCD2和环境星B的CCD1和CCD2
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
      ;Reform()函数可以使数组在元素个数不修改的前提下，改变数组的维数，方便了数组的动态使用
      ccdref = strjoin(string(ccdref0,format='(2108f10.6)'));2108代表格式符的重复次数，默认为1次，10代表字符宽度，6表示把数值四舍五入到6位的精度。
      PRINTF,table,ccdref    ;format='(10(f," "),f)';格式中的数字表示为列数减一
    endfor
  endfor
endfor
endfor
ENVI_REPORT_STAT,base, ab+1, float(n_elements(Cab)), CANCEL=cancelvar
;判断是否点击取消
IF cancelVar EQ 1 THEN BEGIN
  ; tmp = DIALOG_MESSAGE('点击了取消'+'%'+STRING(Tn),/info)
  ENVI_REPORT_INIT, base=base, /finish
  return
  ENVI_BATCH_EXIT
ENDIF
endfor
FREE_LUN,table
ENVI_REPORT_INIT, base=base, /finish
;结束进度条
;ENVI_BATCH_EXIT
;print,systime()
Message=''
end
 pro test_main_ch_buildtable
    inputtype='HJCCDA1'
    chtableoutpath='D:\10_test'
    main_ch_buildtable,inputtype=inputtype,chtableoutpath=chtableoutpath,Message=Message
  end
