PRO Test
    File=['D:\02_HongXing\04_system\HX_TestData\Pretreat\Subset\IN\TIFF\1-hx-hj1b-ccd2-445-56-20101006.tif']
    OUTPUTDIR='D:\'
    ;OUTPUTFILE='D:\share\zm\global-cropland_07052013v6_clip_multiyear_aver_8images.tif'
    ReferFile='D:\02_HongXing\04_system\HX_TestData\Pretreat\Subset\IN\Refer\boundry.tif'
    FileCut,File,OUTPUTDIR=OUTPUTDIR,ReferFile,/TIFF,Message=Message;,OUTPUTFILE=OUTPUTFILE
END

PRO FileCut,File,OUTPUTDIR=OUTPUTDIR,ReferFile,TIFF=TIFF,OUTPUTFILE=OUTPUTFILE,$
    OVERWRITE=OVERWRITE,Message=Message
    ;功能：将File文件按ReferFile的范围裁剪（坐标系也会与ReferFile一致）
    ;OUTPUTDIR与OUTPUTFILE两个关键字使用其中一个生成输出文件
    COMPILE_OPT idl2
    filename=FILE_BASENAME(file)
    EnviType=['hdr','tif','img']
    ;如果不是根目录则在路径后面加\
    IF strmid(OutputDir,strlen(OutputDir)-1,1) NE '\' THEN BEGIN
      OutputDir = OutputDir+'\'
    ENDIF
    ;检查是否存在所建立的文件夹，如果不存在，则建立文件夹
    test_file = file_test(OutputDir,/directory)
    IF test_file eq 0 then begin
      file_mkdir,OutputDir
    ENDIF
    ;获取文件名字的主要部分
    fields=strsplit(filename,'.',/EXTRACT,COUNT=count)
    MainNameFlag=0
    IF count LE 1 THEN BEGIN
    ENDIF ELSE BEGIN
        FOR i=0,N_ELEMENTS(EnviType)-1 DO BEGIN
            IF STRCMP(fields[count-1],EnviType[i],/FOLD_CASE) EQ 1 THEN BEGIN
                TypeName=EnviType[i]
                fileMainName=FILE_BASENAME(file,'.'+TypeName,/FOLD_CASE)
                MainNameFlag=1
                BREAK
            ENDIF
        ENDFOR
    ENDELSE
    IF ~MainNameFlag THEN fileMainName=filename
    IF KEYWORD_SET(tiff) THEN BEGIN
        IF N_ELEMENTS(outputfile) THEN BEGIN
            outputdir=FILE_DIRNAME(outputfile,/MARK_DIRECTORY)
            outMainName=FILE_BASENAME(outputfile,'.tif',/FOLD_CASE)
            TempOutFile=outputdir+outMainName+'temp'
            outputfile=outputdir+outMainName+'.tif'
        ENDIF ELSE BEGIN
            IF ~N_ELEMENTS(outputdir) THEN BEGIN
                Message='输出目录和输出文件均没有指定！'
                RETURN
            ENDIF ELSE BEGIN
                outMainName=fileMainName
                TempOutFile=outputdir+outMainName+'temp'
                outputfile=outputdir+outMainName+'.tif'
            ENDELSE
        ENDELSE
    ENDIF ELSE BEGIN
        IF N_ELEMENTS(outputfile) THEN BEGIN
            outputdir=FILE_DIRNAME(outputfile,/MARK_DIRECTORY)
            outMainName=FILE_BASENAME(outputfile)
            outputfile=outputdir+outMainName
        ENDIF ELSE BEGIN
            IF ~N_ELEMENTS(outputdir) THEN BEGIN
                Message='输出目录和输出文件均没有指定！'
                RETURN
            ENDIF ELSE BEGIN
                outMainName=fileMainName
                outputfile=outputdir+outMainName
            ENDELSE
        ENDELSE
        TempOutFile=outputfile
    ENDELSE
    ENVI,/RESTORE_BASE_SAVE_FILES
    ENVI_BATCH_INIT,LOG_FILE="C:\envi_Preprocessing.Log"
    maskfile=outputdir+outMainName+'MSK'
    NewPrjFile=outputdir+outMainName+'NewPrj'
    CATCH,error
    IF error NE 0 THEN GOTO,next
    FILE_MKDIR,outputdir
    next:
    CATCH,/CANCEL
    ENVI_OPEN_FILE,referfile,r_fid=referfid
    ENVI_FILE_QUERY,referfid,ns=referns,nl=refernl,dims=referdims
    ENVI_OPEN_FILE,file,r_fid=fid
    ENVI_FILE_QUERY,fid,ns=sample,nl=line,dims=dims,nb=nb
    InputPRJ=ENVI_GET_PROJECTION(fid=fid)
    ReferPRJ=ENVI_GET_PROJECTION(fid=ReferFid)
    
    datum_Input=InputPRJ.DATUM
    datum_Refer=ReferPRJ.DATUM
    ;print,'----',datum_Input
    ;s=datum_Input[WHERE(STRMATCH(datum_Input, '*ERDAS*', /FOLD_CASE))]
    index_Input=WHERE(STRMATCH(datum_Input, '*ERDAS*', /FOLD_CASE))
    index_Refer=WHERE(STRMATCH(datum_Refer, '*ERDAS*', /FOLD_CASE))
    print,'index_Input:',index_Input,'----index_Refer:',index_Refer
    
    IF index_Input eq 0 THEN BEGIN
        Message=filename+'输入文件投影不是标准投影，请转投影！'
        print,Message
        RETURN
    ENDIF
    IF index_Refer eq 0 THEN BEGIN
        Message=referfile+'输入文件投影不是标准投影，请转投影！'
        print,Message
        RETURN
    ENDIF
    refer_map_info=ENVI_GET_MAP_INFO(fid=referfid)
    IF STRCMP(InputPRJ.PE_COORD_SYS_STR, ReferPRJ.PE_COORD_SYS_STR,/FOLD_CASE) NE 0 THEN BEGIN
        NewPrjFid=fid
    ENDIF ELSE BEGIN
        ENVI_CONVERT_FILE_MAP_PROJECTION, fid=fid, r_fid=NewPrjFid, $
            O_PIXEL_SIZE=refer_map_info.PS[0:1],$
            pos=LINDGEN(nb),dims=dims,o_proj=ReferPRJ,WARP_METHOD=3,out_name=NewPrjFile
    ENDELSE
    map_info=ENVI_GET_MAP_INFO(fid=NewPrjFid)
    ENVI_FILE_QUERY,NewPrjFid,ns=sample,nl=line,dims=dims,nb=nb
    pixel=map_info.PS[0:1]
    UL_X=map_info.MC[2]-pixel[0]*map_info.MC[0]
    UL_Y=map_info.MC[3]+pixel[1]*map_info.MC[1]
    UL_X_REFER=refer_map_info.MC[2]-refer_map_info.PS[0]*refer_map_info.MC[0]
    UL_Y_REFER=refer_map_info.MC[3]+refer_map_info.PS[1]*refer_map_info.MC[1]
    LR_X_REFER=UL_X_REFER+(referns-1)*refer_map_info.PS[0]
    LR_Y_REFER=UL_Y_REFER-(refernl-1)*refer_map_info.PS[1]
    x0=0>ROUND((UL_X_REFER-UL_X)/pixel[0])
    x1=ROUND((LR_X_REFER-UL_X)/pixel[0])<(sample-1)
    y0=0>ROUND((UL_Y-UL_Y_REFER)/pixel[1])
    y1=ROUND((UL_Y-LR_Y_REFER)/pixel[1])<(line-1)
    roi_id=ENVI_CREATE_ROI(color=4,ns=sample,nl=line)
    xpts=[x0,x1,x1,x0,x0]
    ypts=[y0,y0,y1,y1,y0]
    ENVI_DEFINE_ROI,roi_id,/polygon,xpts=xpts,ypts=ypts
    ENVI_MASK_DOIT,AND_OR=1,OUT_NAME=maskfile,$
        ROI_IDS=roi_id,ns=sample,nl=line,/inside,r_fid=m_fid
    newdims=[-1,x0,x1,y0,y1]
    ENVI_MASK_APPLY_DOIT, FID=NewPrjFid, POS =INDGEN(nb),dims=newdims,M_FID=m_fid,$
        M_POS=[0],VALUE =0,OUT_NAME=TempOutFile,$
        IN_MEMORY=0,R_FID=newfid
    ENVI_FILE_MNG, id =m_fid,/remove,/DELETE;删除ROI MSK
    IF NewPrjFid NE fid THEN BEGIN
        ENVI_FILE_MNG, id =NewPrjFid,/remove,/DELETE
    ENDIF
    IF newfid EQ -1 THEN BEGIN
        ENVI_BATCH_EXIT
        Message=STRARR(FILE_LINES("C:\envi_Preprocessing.Log"))
        OPENR,lun,"C:\envi_Preprocessing.Log",/GET_LUN
        READF,lun,Message
        FREE_LUN,lun
        Message=STRJOIN(Message,STRING(10b))
        RETURN
    ENDIF
    IF KEYWORD_SET(TIFF) THEN BEGIN
        ENVI_FILE_QUERY,newfid,nb=nb,DATA_TYPE=out_dt,dims=dims
        ENVI_OUTPUT_TO_EXTERNAL_FORMAT,fid=newfid,dims=dims,pos=INDGEN(nb),$
            out_name=outputfile,/TIFF
        ENVI_FILE_MNG, id=newfid, /REMOVE, /DELETE
    ENDIF
 ;    ENVI_BATCH_EXIT
    Message=''
END
