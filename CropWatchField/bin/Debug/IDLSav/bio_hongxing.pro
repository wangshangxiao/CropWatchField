function jdl_isleap,  year
  if ((year mod 4) eq 0) then $
    if ((year mod 100) eq 0) then $
    isleap  =  (year mod 400) eq 0 $
  else isleap  =  1b $
else isleap  =  0b
return,  isleap
end

function par_calc, date, latitude, sunt, albedo
  Lat = FLOAT(latitude) * !PI / 180
  ; ActSuntime = FLOAT(sunt)
  Ju = julday(date.month, date.day, date.year) - julday(12, 31, date.year - 1)
  Gsc = 0.0820
  Dr = 1 + 0.033 * COS(2 * !PI * Ju / 365)
  Declination  = 0.409 * SIN(2 * !PI * Ju / 365 - 1.39)
  SunsetAngle  = ACOS(-1.0 * TAN(Lat) * TAN(Declination))
  MaxSuntime   = 24 / !PI * SunsetAngle
  PARvalue = (1 - Albedo) * (0.25 + 0.50 * sunt / MaxSuntime) * $
    24 * 60 / !PI * Gsc * Dr * (SunsetAngle * SIN(Lat) * SIN(Declination) + COS(Lat) * COS(Declination) * SIN(SunsetAngle))
  RETURN, PARvalue
end

function fpar_calc, ndvi, sr_max, sr_min;4.46,1.08
  sr = (1 + Ndvi) / (1 - Ndvi)
  FparMin = 0.001
  FparMax = 0.95
  fPARvalue = (SR - SR_Min) * (FparMax - FparMin) / (SR_Max - SR_Min) + FparMin
  fPARvalue = fPARvalue < 0.95
  LT3 = WHERE(fPARvalue LT 0.0, Num)
  IF Num NE 0 THEN fPARvalue[LT3] = 0.0
  RETURN, fPARvalue
end

function lue_calc, maxlue, avetemp, et_w, c, optimalT
  T1 = -0.0005 * (OptimalT - 20.0) ^ 2.0 + 1.0
  T2 = C / ((1 + EXP(0.2 * (OptimalT - 10.0 - AveTemp))) * (1.0 + EXP(0.3 * (-1 * OptimalT - 10 + AveTemp)))) ;?????Field?????1??
  DeviValue = AveTemp - OptimalT
  DeviID = WHERE(((DeviValue GT 10.0) OR (DeviValue LT -13.0)), Num)
  IF Num NE 0L THEN T2[DeviID]=0.5 * C / ((1 + EXP(-2.)) * (1 + EXP(-3.)))
  LUE = MaxLue * T1 * T2 * ET_W
  RETURN, LUE
end

function bio_calc, date, sunt, avetemp, ndvi, albedo, et_w, latitude, maxlue, sr_max, sr_min, c, optimalT
  bio = par_calc(date, latitude, sunt, albedo) * fpar_calc(ndvi, sr_max, sr_min) * lue_calc(maxlue, avetemp, et_w, c, optimalT)
  return, bio
end

pro bio_hongxing,latitude=latitude, HJ_file=HJ_file, meteorology_data=meteorology_data, out_bio=out_bio,start_end_day=start_end_day, Message=Message
;  result0=dialog_message('dddd',/information)
  ;  out_bio = 'E:\'
  ;  latitude = 'E:\HX_TestData\Yield\Biomass\IN\Latitude\china_1km_latitude_p_s_30_r.tif'
  ;  HJ_file = 'E:\HX_TestData\Yield\Biomass\IN\Image\'
 ;   meteorology_data = 'E:\HX_TestData\Yield\Biomass\IN\Meteo\2013.txt'
  ;input3=lat$                :锟斤拷纬锟斤拷锟斤拷锟�
  ;input4=HJ_file             :锟矫硷拷锟斤拷却锟叫★拷锟酵队帮拷幕锟斤拷锟斤拷锟接帮拷欤拷锟斤拷诰锟斤拷锟�锟斤拷锟斤拷锟斤拷一锟斤拷
  ;input5=meteorology_data    :锟斤拷锟斤拷锟斤拷锟揭拷锟脚拷锟斤拷锟斤拷校锟斤拷锟揭伙拷锟绞憋拷洌拷诙锟斤拷锟斤拷锟斤拷拢锟斤拷锟斤拷锟斤拷锟斤拷锟斤拷锟绞憋拷锟斤拷锟斤拷锟�100401  -2  0锟斤拷锟斤拷要锟斤拷锟斤拷锟斤拷锟斤拷锟斤拷锟斤拷锟侥憋拷锟侥硷拷锟斤拷路锟斤拷
  ;output=out                 :锟斤拷锟铰凤拷锟斤拷锟斤拷锟斤拷锟斤拷锟斤拷锟斤拷锟侥硷拷
  ;锟斤拷锟斤拷锟斤拷锟�
  ;  lat$ = 'D:\biomass\biomass-hongxing\DEM\hongxing\result\china_1km_latitude_p_s_30_r.tif'  ;锟斤拷纬锟斤拷锟斤拷荩锟斤拷潭锟斤拷锟�
  ;  HJ_file ='D:\1\in_HJ\'
  ;  start_end_day = [[6,15],[6,1],[5,20],[10,1],[9,2],[7,3]]                                 ;锟劫讹拷锟斤拷锟斤拷
  ;  meteorology_data = 'D:\1\in_hj\2010.txt'     ;锟斤拷锟斤拷锟斤拷锟揭拷锟脚拷锟斤拷锟斤拷校锟斤拷锟揭伙拷锟绞憋拷洌拷诙锟斤拷锟斤拷锟斤拷拢锟斤拷锟斤拷锟斤拷锟斤拷锟斤拷锟绞憋拷锟斤拷锟斤拷锟�100401  -2  0锟斤拷锟斤拷要锟斤拷锟斤拷锟斤拷锟斤拷锟斤拷锟斤拷锟侥憋拷锟侥硷拷锟斤拷路锟斤拷
  ;;锟斤拷锟铰凤拷锟�
  ;  out = 'D:\1\out\' ;锟斤拷锟�
  ;锟教讹拷锟斤拷锟斤拷
  maxlue = 1.0
  sr_max = 4.46
  sr_min = 1.08
  c = 1
  optimalT = 20
  et_w = 1
  albedo = 0.5
  ;锟斤拷取锟斤拷锟�
  latitude = read_tiff(latitude) +0.001
  file_HJ = file_search(HJ_file+'hj*.tif',count=count)
  
  for j = 0, n_elements(file_HJ) - 1 do begin
     basename = file_basename(file_HJ[j])
     DNVI_name = strmid(basename,17,8)
    HJ_DATA = read_tiff(file_HJ[j], geotiff = geotiff)
    ndvi = REFORM((HJ_DATA[3,*,*]*1.0- HJ_DATA[2,*,*]*1.0)/(HJ_DATA[3,*,*]+ HJ_DATA[2,*,*]+0.0000000000000000001),(size(HJ_DATA))[2],(size(HJ_DATA))[3])
    NDVI_data = HJ_DATA *0. +ndvi
    write_tiff, HJ_file + 'a_' + DNVI_name + '_NDVI.tif', NDVI_data, geotiff = geotiff, /float
    endfor
    
    file_NDVI= file_search(HJ_file+'*_NDVI.tif',count=count)
    result1=dialog_message('eeee',/information)
    for i = 0, n_elements(file_NDVI) - 1 do begin
    if i eq 0 then begin
      basename = file_basename(file_NDVI[i])
      year = strmid(basename,2,4)
      month = strmid(basename,6,2)
      day = strmid(basename,8,2)
      
      jday_start = julday(5,1,year)
      jday_end = julday(month,day, year)
      
    endif else begin
      basename1 = file_basename(file_NDVI[i-1])
      year = strmid(basename1,2,4)
      month = strmid(basename1,6,2)
      day = strmid(basename1,8,2)
      
      basename2 = file_basename(file_NDVI[i])
      year2 = strmid(basename2,2,4)
      month2 = strmid(basename2,6,2)
      day2 = strmid(basename2,8,2)
      
      jday_start = julday(month,day, year)
      jday_end = julday(month2,day2, year2)
    endelse
       Dt = strmid(basename,2,1)
      if DT eq 2 then begin
    for j = jday_start, jday_end do begin
    
      caldat,  j, month, day, y
      date = {year: year, month: month, day: day}
      
      mark = strtrim(string(y),2) + strtrim(string(month,format='(i2.2)'),2) + strtrim(string(day,format='(i2.2)'),2)
    
;      openr,lun,meteorology_data,/get_lun
;      Lines = file_lines(meteorology_data)
;      data = dblarr(3,Lines)
;      readf,lun,data  
;    for x = 0,lines-1 do begin
;      h = data(0,x)
;      a=strtrim(string(floor(h)),2)
;      
;      if a eq mark then begin
;        w = x
;        break
;      endif else begin
;        continue
;      endelse
;    endfor
;        h = data(0,x)
;        a=strtrim(string(floor(h)),2)
;        
;        if a eq mark then begin
;          w = x
;          break
;        endif else begin
;          continue
;        endelse
;      ;mark = data(0,i)
;      endfor
;      free_lun,lun
;      tt = data(1,w)
;      ss = data(2,w)
      openr,lun,meteorology_data,/get_lun
      Lines = file_lines(meteorology_data)
      data = dblarr(3,Lines)
      readf,lun,data
      for x = 0,lines-1 do begin
        ;mark = data(0,0)
;        mark = 20110402
        h = data(0,x)
      a=strtrim(string(floor(h)),2)

        if a eq mark then begin
         w = x
          break
        endif else begin
          continue
        endelse
      ;mark = data(0,i)
      endfor
      free_lun,lun
      tt = data(1,w)
      ss = data(2,w)
      
      sunt = latitude*0+ss
      avetemp = latitude*0+tt
      
      bio = bio_calc(date, sunt, avetemp, ndvi, albedo, et_w, latitude, maxlue, sr_max, sr_min, c, optimalT)
      bio=bio*10.
;            write_tiff, out_bio, bio, geotiff = geotiff, /float   ;锟斤拷锟斤拷锟皆硷拷锟斤拷锟斤拷要锟睫革拷锟斤拷锟斤拷募锟斤拷锟斤拷锟斤拷锟�
      write_tiff, out_bio + 'hongxing_' + mark + '_bio.tif', bio, geotiff = geotiff, /float   ;锟斤拷锟斤拷锟皆硷拷锟斤拷锟斤拷要锟睫革拷锟斤拷锟斤拷募锟斤拷锟斤拷锟斤拷锟�
      endfor
        endif else begin
          continue
        endelse
    endfor
  Message=''
end