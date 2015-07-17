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
;���룺
;inputfile1=in_farm_land:���ؿ��������ͼ���������1�������2��С�����3���涨��С��
;inputfile3=in_crop_harvest:���ײ����ֲ�ͼ���涨��С��
;�����
;out_dir_N = soil_nitrogen.tif�л��ʷֲ�ͼ
;out_dir_O = soil_organic.tif��Ч���ֲ�ͼ

;;��ȡ�ļ�
  ;in_farm_land = 'D:\share\Hongxingtest\wxf\text_data\model\hx_crop_class6.tif'
  ;in_crop_harvest = 'D:\share\Hongxingtest\wxf\text_data\harvest\harvest.tif'                     ;�������
;
;;����ļ�
  ;out_dir_N = 'C:\Users\Administrator\Desktop\Hongxing\soil_nitrogen.tif'
  ;out_dir_O = 'C:\Users\Administrator\Desktop\Hongxing\soil_organic.tif'


;��ȡ�ļ�
  hx_crop_class_img = read_tiff(in_farm_land,GEOTIFF = GEOTIFF)
  crops_Harvest_img = read_tiff(in_crop_harvest,GEOTIFF = GEOTIFF)
;����ָ������
  crop_index = fltarr(3,(size(hx_crop_class_img))[1],(size(hx_crop_class_img))[2])

;3������ֱ����һ��ֲ��ָ��
  for bn=0,2 do begin

;����ؿ�������_tiff
    crop_land_har = float((hx_crop_class_img) eq (bn+1))*crops_Harvest_img[*,*]

;    b = Dialog_Message(total(crop_land_har)) 
    ;�󶹵ؿ���������ֱ��ͼ
    crop_l_hist = histogram(crop_land_har, BINSIZE=10)
    crop_l_hist[0] = 0

;����Чֵ��Χ
    harvest_min = virtual_value(crop_l_hist,0.05)
    harvest_max = virtual_value(crop_l_hist,0.95)
;��������һ������ָ��
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
;�����������
  crop_index_all = crop_index[0,*,*]+crop_index[1,*,*]+crop_index[2,*,*]
;������Ч����������  
  soil_nitrogen = 290.4*(crop_index_all^0.27)
  soil_nitrogen = long(soil_nitrogen*100)
  soil_nitrogen=FLOAT(soil_nitrogen)/100
;�����л��ʺ�������
  soil_organic = 6.265*(crop_index_all^0.3)
  soil_organic = long(soil_organic*100)
  soil_organic=FLOAT(soil_organic)/100
  
  ;print,soil_organic
  write_tiff,out_dir_N,soil_nitrogen,GEOTIFF=GEOTIFF,/FLOAT
  write_tiff,out_dir_O,soil_organic,GEOTIFF=GEOTIFF,/FLOAT
  message=''
end
