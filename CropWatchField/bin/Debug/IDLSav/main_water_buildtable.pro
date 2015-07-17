    pro main_water_buildtable,watertableoutpath=watertableoutpath,Message=Message
    compile_opt idl2
;    Result = DIALOG_MESSAGE(watertableoutpath)
    ;实现功能：建立反演水分含量的查找表
    ;print,systime()
    ;建立查找表大约需要25分钟
    ;outwaterfindtablepath：输出的查找表的存储路径
    ;使用Cw Cm ALA Hspot Ns无购物参数来反演
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
    
    ;客观参数
    ;    Cab=fltarr(20)+20           ;[20,60]步长为  2
    ;    for k=0,18 do begin
    ;    Cab(k+1)=Cab(k)+2
    ;    endfor
    
    Cw=fltarr(20)+0.005        ;[0.005,0.045]步长为0.002
    for k=0,18 do begin
      Cw[k+1]=Cw[k]+0.002
    endfor
    
    Cm=fltarr(10)+0.002        ;[0.002,0.01]步长为0.0008
    for k=0,8 do begin
      Cm[k+1]=Cm[k]+0.0008
    endfor
    ;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;    ALA=fltarr(10)+30          ;[30,80]步长为5
;    for k=0,8 do begin
;      ALA[k+1]=ALA[k]+5
;    endfor
    ;  ;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
    ;    Lai=fltarr(10)+1           ;[1,7]步长为0.6
    ;    for k=0,8 do begin
    ;    Lai(k+1)=Lai(k)+0.6
    ;    endfor
    ;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
;        Hspot=fltarr(10)           ;[0,1]步长为0.1
;        for k=0,8 do begin
;        Hspot[k+1]=Hspot[k]+0.1
;        endfor
;    
;        Ns=fltarr(5)+1            ;[1,2]步长为0.2
;        for k=0,3 do begin
;        Ns[k+1]=Ns[k]+0.2
;        endfor
    ;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
    ;    Psoil=fltarr(20)+0.05      ;[0.05,0.25]步长为0.01
    ;    for k=0,18 do begin
    ;    Psoil(k+1)=Psoil(k)+0.01
    ;    endfor
    
    
    
    ;太阳天顶角 tts   观测天顶角tto
    ;diffuse/direct radiation
    
    
    ;ENVI进度条
    ENVI,/restore_base_save_files
    ENVI_BATCH_INIT
    ;初始化进度条
    ENVI_REPORT_INIT, '建立查找表中…',title="进度条",base=base ,/INTERRUPT
    ENVI_REPORT_INC, base,n_elements(Cw)
    OPENW,table,watertableoutpath+'\'+'IRSwatertable.txt',/GET_LUN       ;保存查找表
        
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
              IRSref = strjoin(string(IRSref0,format='(2108f10.6)'));2108代表格式符的重复次数，默认为1次，10代表字符宽度，6表示把数值四舍五入到6位的精度。
              ;str = transpose(string(lut,format='(2108f10.6)'))
              ;strjoin表示字符串相连接，string表示格式化输出的字符串数据
              ;print,string(lut,format='(2108f10.6)')
              ;OPENW打开文件，用于读写;/GET_LUN,变量，申请一个合法的逻辑设备号（100-128）并存入变量中
              ;/APPEND:在原数据的后面以追加的形式，向文件写入数据
              ;PRINTF,LUN,transpose(str)
              PRINTF,table,IRSref    ;format='(10(f," "),f)';格式中的数字表示为列数减一
            endfor
          endfor
        endfor
      endfor
      ENVI_REPORT_STAT,base, w+1, float(n_elements(Cw)), CANCEL=cancelvar
      ;判断是否点击取消
        IF cancelVar EQ 1 THEN BEGIN
        ; tmp = DIALOG_MESSAGE('点击了取消'+'%'+STRING(Tn),/info)
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
