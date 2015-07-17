function virtual_value,hist,int_n
  delete_num = total(hist)*int_n
  delete_sum = 0
  a=0
  for n=0,size(hist,/n_elements)-1 do begin
    delete_sum = delete_sum+hist[n]
    if delete_sum gt delete_num then begin
    a = n*10
    break
    endif
  endfor
  return,a
end

pro harvest_to_soil_nitrogen,in_farm_land,in_crop_harvest,out_dir_N,out_dir_O,message = message
;输入：
;inputfile1=in_farm_land:各地块作物分类图，玉米田块1，大豆田块2，小麦田块3（规定大小）
;inputfile3=in_crop_harvest:玉米产量分布图（规定大小）
;输出：
;out_dir_N = soil_nitrogen.tif有机质分布图
;out_dir_O = soil_organic.tif速效氮分布图

;;读取文件
  ;in_farm_land = 'D:\share\Hongxingtest\wxf\text_data\model\hx_crop_class6.tif'
  ;in_crop_harvest = 'D:\share\Hongxingtest\wxf\text_data\harvest\harvest.tif'                     ;玉米田块
;
;;输出文件
  ;out_dir_N = 'C:\Users\Administrator\Desktop\Hongxing\soil_nitrogen.tif'
  ;out_dir_O = 'C:\Users\Administrator\Desktop\Hongxing\soil_organic.tif'


;读取文件
  hx_crop_class_img = read_tiff(in_farm_land,GEOTIFF = GEOTIFF)
  crops_Harvest_img = read_tiff(in_crop_harvest,GEOTIFF = GEOTIFF)
;构建指数矩阵
  crop_index = fltarr(3,(size(hx_crop_class_img))[1],(size(hx_crop_class_img))[2])

;3类作物分别求归一化植被指数
  for bn=0,2 do begin

;作物地块生物量_tiff
    crop_land_har = float((hx_crop_class_img) eq (bn+1))*crops_Harvest_img[*,*]

;    b = Dialog_Message(total(crop_land_har)) 
    ;大豆地块有用像素直方图
    crop_l_hist = histogram(crop_land_har, BINSIZE=10)
    crop_l_hist[0] = 0

;求有效值范围
    harvest_min = virtual_value(crop_l_hist,0.05)
    harvest_max = virtual_value(crop_l_hist,0.95)
;求各作物归一化单产指数
    for i=0,(size(hx_crop_class_img))[1]-1 do begin
      for j=0,(size(hx_crop_class_img))[2]-1 do begin
        if crop_land_har[i,j] gt 0 then begin
          crop_index[bn,i,j] = (crop_land_har[i,j]*1.0 - harvest_min)/(harvest_max - harvest_min)
          crop_index[bn,i,j] = crop_index[bn,i,j]>0.02
          crop_index[bn,i,j] = crop_index[bn,i,j]<0.98
        endif
      endfor
    endfor
  endfor
;三类作物叠加
  crop_index_all = crop_index[0,*,*]+crop_index[1,*,*]+crop_index[2,*,*]
;土壤速效氮含量计算  
  soil_nitrogen = 290.4*(crop_index_all^0.27)
  soil_nitrogen = long(soil_nitrogen*100)
  soil_nitrogen=FLOAT(soil_nitrogen)/100
;土壤有机质含量计算
  soil_organic = 6.265*(crop_index_all^0.3)
  soil_organic = long(soil_organic*100)
  soil_organic=FLOAT(soil_organic)/100
  
  ;print,soil_organic
  write_tiff,out_dir_N,soil_nitrogen,GEOTIFF=GEOTIFF,/FLOAT
  write_tiff,out_dir_O,soil_organic,GEOTIFF=GEOTIFF,/FLOAT
  message=''
end
