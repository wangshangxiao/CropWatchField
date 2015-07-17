PRO GetFileHist,file,CSVPath,Background=Background,errorFile=errorFile,DataArray=DataArray;,$
;PercentArray=PercentArray,ValueArray=ValueArray
    COMPILE_OPT idl2
    ;file='D:\share\Hongxingtest\recode.tif'
    ;CSVPath='D:\Workspaces\CropWatchField\CropWatchField\bin\Debug\AllSense.csv'
    IF N_ELEMENTS(Background) GT 0 THEN BEGIN
        Background=FIX(Background)
    ENDIF ELSE BEGIN
        Background=0
    ENDELSE
    ENVI,/RESTORE_BASE_SAVE_FILES
    ENVI_BATCH_INIT,/NO_STATUS_WINDOW
    ENVI_OPEN_FILE,file,R_FID=fid
    IF fid EQ 0 THEN BEGIN
        OPENW,lun,errorFile,/GET_LUN,/APPEND
        PRINTF,lun,'File cannot be opened. File name:',file
        FREE_LUN,lun
    ENDIF
    mapinfo=ENVI_GET_MAP_INFO(FID=fid)
    PixelSize=mapinfo.ps[0:1]
    PixelArea=double(PixelSize[0]*PixelSize[1])
    ENVI_FILE_QUERY,fid,DIMS=dims
    ENVI_DOIT, 'ENVI_STATS_DOIT', COMP_FLAG=3 ,DMax=max,dmin=min,$
        DIMS=dims , FID=fid , HIST=hist, POS=0
    num_bins=N_ELEMENTS(hist)
    binSize=(DOUBLE(max)-min)/(num_bins-1)
    ValueArray=INDGEN(num_bins)*binSize[0]
    ValueArray=ROUND(ValueArray)
    index=WHERE(hist NE 0)
    hist=hist[index]
    AreaArray=PixelArea*hist
    
    ValueArray=ValueArray[index]
    index=WHERE(ValueArray NE Background,count)
    IF count NE 0 THEN BEGIN
        hist=hist[index]
        ValueArray=ValueArray[index]
        AreaArray=AreaArray[index]/666.7
    ENDIF
    DataArray=[]
    PercentArray=hist/TOTAL(hist)*100
    
    ;PRINT,PercentArray
    ValueArray=strtrim(string(ValueArray))
    AreaArray = strtrim(string(AreaArray,format='(I)'),2)
    PercentArray = strtrim(string(PercentArray,format='(f20.2)'))
    ;PercentArray=strtrim(string(PercentArray))
    ;PercentArray=ROUND(PercentArray)
    ;PRINT,PercentArray
    ;PercentArray = strtrim(string(PercentArray,format='(I)'),2)
    ;PRINT,PercentArray
    FOR i=0,N_ELEMENTS(HIST)-1 DO BEGIN
        ;PRINT,'Nums: ',PercentArray[i],"  value:",ValueArray[i]," Area:",AreaArray[i]
        DataLine=ValueArray[i]+","+AreaArray[i]+","+PercentArray[i]
        ;DataLine=strtrim(DataLine,2)
        DataLine=STRCOMPRESS(DataLine, /REMOVE_ALL)
        ;print,DataLine
        DataArray=[DataArray,[DataLine]]
    ENDFOR
    ;index=where(DataArray[1,*] ne 0.00000000); 
    ;DataArray=DataArray[*,[index]]
    
    ;print,DataArray
    ;DataArray=transpose(DataArray)
    ;print,DataArray
    ;ncount=N_elements(DataArray)
    ;Sensetxt='D:\AllSense.csv'
    ;DataArray=string(DataArray,format='(8(f," "),f)')
    OPENW,lun,CSVPath,/GET_LUN
    PRINTF,lun,DataArray;,format='(8(f," "),f)'
    FREE_LUN,lun
    
    ENVI_BATCH_EXIT
END