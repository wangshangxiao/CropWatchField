PRO Test
    InputFile=['E:\Segment.tif']
    OutputPath='E:\D'
    Format='ENVI'
    Format_Convertion,InputFile,OutputFile=OutputFile,OutputPath=OutputPath,Format=Format,Message=Message
END

PRO Format_Convertion,InputFile,OutputFile=OutputFile,OutputPath=OutputPath,Format=Format,Message=Message
    ;InputFile输入文件全路径
    ;OutputFile输出文件全路径
    ;OutputPath输出文件夹
    ;Format为格式字符串，如"TIFF",能输出的类型有：ARCVIEW,$
    ;        ASCII,ENVI,ERDAS,ERMAPPER,IMAGINE,JP2,NITF,PCI,TIFF
    ;特别说明：批量处理时，请搭配OutputPath关键字，否则使用OutputFile
    N_inputFiles=N_ELEMENTS(InputFile)
    IF N_inputFiles GT 1 THEN BEGIN
        IF N_ELEMENTS(OutputPath) NE 1 THEN BEGIN
            Message='批量处理，请指定唯一一个输出目录'
            RETURN
        ENDIF
        MessageArray=STRARR(N_inputFiles)
        outDIR=FILE_DIRNAME(OutputPath,/MARK_DIRECTORY)+$
            FILE_BASENAME(OutputPath)+PATH_SEP()
        FOR i=0,N_inputFiles-1 DO BEGIN
            file_name=FILE_BASENAME(InputFile[i])
            fields=strsplit(file_name,'.',COUNT=count,/EXTRACT)
            file_mainName=(count GT 1)?STRJOIN(fields[0:count-2],'.'):file_name
            Ac_outFile=outDIR+file_mainName
            Format_Convertion,InputFile[i],OutputFile=Ac_outFile,OutputPath=outDIR,Format=Format,Message=tmpmsg
            MessageArray[i]=tmpmsg
        ENDFOR
        Message=STRJOIN(MessageArray)
        RETURN
    ENDIF ELSE BEGIN
        ;单个文件处理
        IF N_ELEMENTS(OutputFile) NE 1 THEN BEGIN
            IF N_ELEMENTS(OutputPath) EQ 0 THEN BEGIN
                Message='输出文件未设定'
                RETURN
            ENDIF
            outDIR=FILE_DIRNAME(OutputPath[0],/MARK_DIRECTORY)+$
            FILE_BASENAME(OutputPath[0])+PATH_SEP()
            file_name=FILE_BASENAME(InputFile[0])
            fields=strsplit(file_name,'.',COUNT=count,/EXTRACT)
            file_mainName=(count GT 1)?STRJOIN(fields[0:count-2],'.'):file_name
            OutputFile=outDIR+file_mainName
        ENDIF
    ENDELSE
    Ac_outFile=OutputFile
    outDIR=FILE_DIRNAME(OutputFile,/MARK_DIRECTORY)
    IF outDIR EQ '' THEN BEGIN
        Message='OutputFile关键字变量需要指定全路径'
        RETURN
    ENDIF
    CATCH,error
    IF error NE 0 THEN BEGIN
        CATCH,/CANCEL
        GOTO,process
    ENDIF
    FILE_MKDIR,outDIR
    CATCH,/CANCEL
    process:
    ENVI,/RESTORE_BASE_SAVE_FILES
    ENVI_BATCH_INIT,LOG_FILE="C:\envi_Preprocessing.Log"
    ENVI_OPEN_FILE,InputFile,R_FID=fid
    ENVI_FILE_QUERY,fid,nb=nb,DIMS=dims
    CASE (Format) OF
        "ARCVIEW": BEGIN
            ARCVIEW=1
            poststr='.arc'
        END
        "ASCII": BEGIN
            ASCII=1
            poststr=''
        END
        "ENVI": BEGIN
            ENVI=1
            poststr=''
        END
        "ERDAS": BEGIN
            ERDAS=1
            poststr='.lan'
        END
        "ERMAPPER": BEGIN
            ERMAPPER=1
            poststr='.ers'
        END
        "IMAGINE": BEGIN
            IMAGINE=1
            poststr='.img'
        END
        "JP2": BEGIN
            JP2=1
            poststr='.jpeg'
        END
        "NITF": BEGIN
            NITF=1
            poststr='.nitf'
        END
        "PCI": BEGIN
            PCI=1
            poststr='.pci'
        END
        "TIFF": BEGIN
            TIFF=1
            poststr='.tif'
        END
        ELSE: BEGIN
            Message='不支持的文件格式'
            ENVI_BATCH_EXIT
            RETURN
        END
    ENDCASE
    Ac_outFile=Ac_outFile+poststr
    ENVI_OUTPUT_TO_EXTERNAL_FORMAT,dims=dims,fid=fid,pos=INDGEN(nb),out_name=Ac_outFile,ARCVIEW=ARCVIEW,$
        ASCII=ASCII,ENVI=ENVI,ERDAS=ERDAS,ERMAPPER=ERMAPPER,IMAGINE=IMAGINE,$
        JP2=JP2,NITF=NITF,PCI=PCI,TIFF=TIFF
    ENVI_OPEN_FILE,Ac_outFile,R_FID=tmpfid
    IF tmpfid EQ -1 THEN BEGIN
        ENVI_BATCH_EXIT
        Message=STRARR(FILE_LINES("C:\envi_Preprocessing.Log"))
        OPENR,lun,"C:\envi_Preprocessing.Log",/GET_LUN
        READF,lun,Message
        FREE_LUN,lun
        Message=STRJOIN(Message,STRING(10b))
        RETURN
    ENDIF
    ENVI_BATCH_EXIT
    Message=''
END