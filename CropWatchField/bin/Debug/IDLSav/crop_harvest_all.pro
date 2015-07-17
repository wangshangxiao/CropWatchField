pro crop_harvest_all,in_hx_crop_class=in_hx_crop_class,in_file_bio=in_file_bio,maize_live_day=maize_live_day,bean_live_day=bean_live_day,wheat_live_day=wheat_live_day,out_filename=out_filename,Message=Message
  ;input1=hx_crop_class         :作物分布图
  ;input2=file_bio              :生长期每天生物量存储路径
  ;input3=start_end_day         :三类作物生长期起始截止时间参数，六行两列：第一列月，第二列日，前三行起始时间（顺序：玉米大豆小麦），后三行截止时间（顺序：玉米大豆小麦）
  ;output=out                   :输出作物单产
  ;  in_hx_crop_class='D:\share\Hongxingtest\wxf\text_data\model\hx_crop_class6.tif'
  ;  in_file_bio='D:\share\Hongxingtest\wxf\text_data\bio'
  ;  out_filename='C:\Users\Administrator\Desktop\Hongxing\harvest_1.tif'
  ;  start_end_day = [[6,15],[6,1],[5,20],[10,1],[9,2],[7,3]]
  ;  year=2010
  
;  
;  start_end_day = [[6,15],[6,1],[5,20],[10,1],[9,2],[7,3]]
;  out ='D:\watch_system\yield\'
;  in_file_bio='D:\watch_system\biomass\'
;  in_hx_crop_class='D:\biomass\NEW\temp\hongxing_2013_geo_2.tif'
  
;   result0=dialog_message('dddd',/information)
  hx_crop_class_1 = read_tiff(in_hx_crop_class,geotiff = geotiff)
  hx_crop_class = fltarr(3,(size(hx_crop_class_1))[1],(size(hx_crop_class_1))[2])
  size_class = size(hx_crop_class_1)
  nl = size_class[2]
  ns = size_class[1]
  for i_ns=0,ns-1 do begin
  
    for i_nl=0,nl-1 do begin
      data = hx_crop_class_1[i_ns,i_nl]
      case(data) of
      0:begin
      hx_crop_class[0,i_ns,i_nl] = 1
      hx_crop_class[1,i_ns,i_nl] = 1
      hx_crop_class[2,i_ns,i_nl] = 1
      end
      1:begin
      hx_crop_class[0,i_ns,i_nl] = 0
      hx_crop_class[1,i_ns,i_nl] = 0
      hx_crop_class[2,i_ns,i_nl] = 0
    end
    2:begin
    hx_crop_class[0,i_ns,i_nl] = 0
    hx_crop_class[1,i_ns,i_nl] = 1
    hx_crop_class[2,i_ns,i_nl] = 0
  end
  3:begin
  hx_crop_class[0,i_ns,i_nl] = 0
  hx_crop_class[1,i_ns,i_nl] = 0
  hx_crop_class[2,i_ns,i_nl] = 1
end
endcase
endfor
endfor
file_bio = file_search(in_file_bio+'\'+'*.tif', count = count)
start_end_day = [[maize_live_day[1],maize_live_day[2]],[bean_live_day[1],bean_live_day[2]],[wheat_live_day[1],wheat_live_day[2]] $
  ,[maize_live_day[4],maize_live_day[5]],[bean_live_day[4],bean_live_day[5]],[wheat_live_day[4],wheat_live_day[5]]]                                ;假定生长期
year=maize_live_day[0]                                                                               ;计算单产年份
;year = 2010
;Result = DIALOG_MESSAGE('ok')

;构建矩阵
all_harvest = read_tiff(file_bio[0], geotiff = geotiff)*0.
crop_harvest = fltarr(3,(size(hx_crop_class))[2],(size(hx_crop_class))[3])
;固定参数
crop_a=[[3.78,2.3,2.5],[0.53,0.5,0.47],[1.09,2.2,1.15]]                                 ;模型中的各种参数：依次为光能吸收系数、收获指数、修正系数

for i=0,2 do begin

  sum = read_tiff(file_bio[0], geotiff = geotiff)*0.
  
  wheat_day = julday(start_end_day[0,2],start_end_day[1,2], year)
  jday_start = julday(start_end_day[0,i],start_end_day[1,i], year)-wheat_day;每天生物量起始时间3
  jday_end = julday(start_end_day[0,i+3],start_end_day[1,i+3], year)-wheat_day
  for j = jday_start, jday_end do begin
    data = read_tiff(file_bio[j])
    sum = sum + data
  endfor
  ;  if i eq 0 then begin
  ;    for j = jday_start, jday_end do begin
  ;      data = read_tiff(file_bio[j])
  ;      sum = sum + data
  ;    endfor
  ;  endif else if i eq 1 then begin
  ;    for j = jday_start, jday_end do begin
  ;      data = read_tiff(file_bio[j])
  ;      sum = sum + data
  ;    endfor
  ;  endif else begin
  ;    for j = jday_start, jday_end do begin
  ;      data = read_tiff(file_bio[j])
  ;      sum = sum + data
  ;    endfor
  ;  endelse
  harvest_data =sum*crop_a[i,0]*crop_a[i,1]/crop_a[i,2]
   if i eq 0 then begin
  crop_harvest[0,*,*] =  harvest_data
  crop_harvest[0,*,*] = hx_crop_class[0,*,*]*crop_harvest[0,*,*]
  all_harvest = all_harvest+crop_harvest[0,*,*]
  all_harvest = long(all_harvest)
  endif else if i eq 1 then begin
    crop_harvest[1,*,*] = crop_harvest[1,*,*] *0 + harvest_data
  crop_harvest[1,*,*] = hx_crop_class[1,*,*]*crop_harvest[1,*,*]
  all_harvest = all_harvest+crop_harvest[1,*,*]
  all_harvest = long(all_harvest)
  endif else if i eq 2 then begin
    crop_harvest[2,*,*] = crop_harvest[2,*,*] *0 + harvest_data
  crop_harvest[2,*,*] = hx_crop_class[2,*,*]*crop_harvest[2,*,*]
  all_harvest = all_harvest+crop_harvest[2,*,*]
  all_harvest = long(all_harvest)
  endif
endfor
;all_harvest = long(all_harvest*10)
;all_harvest=FLOAT(all_harvest)/10
;write_tiff,out+'hongxing.tif',all_harvest,GEOTIFF=GEOTIFF,/Long
write_tiff,out_filename,all_harvest,GEOTIFF=GEOTIFF,/Long
Message=''
end