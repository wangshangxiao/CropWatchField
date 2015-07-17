pro ccdimg_to_soil_nitrogen,inputfile_path,inputfile_crop,outputfile_path,message = message

  ;inputfile_path='D:\share\Hongxingtest\wxf\text_data\in_hj\20100523.tif'
  ;inputfile_crop='D:\share\Hongxingtest\wxf\text_data\model\hx_crop_class6.tif'
  ;outputfile_path='D:\share\Hongxingtest\wxf\text_data\soil\soil_nutrition.tif'
  
  z = [0,1,1,2,2,3,4,4,5,5,6,7,8,9,10,11,13,15,18,19,21,22,23,24,26,27,28,29,30,31,32,32,33,34,34,35,35,35,35,35]
  hj_ccd_img = read_tiff(inputfile_path,geotiff = geotiff)
  soil_class_img = read_tiff(inputfile_crop,geotiff = geotiff)
  
  initial_soil_o = 5.4+(160.3*hj_ccd_img[0,*,*]-73.7*hj_ccd_img[1,*,*]-62.0*hj_ccd_img[2,*,*]+10.6*hj_ccd_img[3,*,*])*0.0001
  result_soil_o = float(z[byte((initial_soil_o-11.5)*20)])*7/40+1

  result_soil_o = (soil_class_img gt 0)*1.0*result_soil_o

  write_tiff,outputfile_path,result_soil_o,GEOTIFF=GEOTIFF,/FLOAT
  message=''
end