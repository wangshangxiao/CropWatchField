pro Histogram,ObserFilename,Message=Message
  ;ObserFilename='C:\Users\yxz\Desktop\OM\Sub\hx\hx.txt'
  OutFilename = file_dirname(ObserFilename)+'\'+'Histogram.jpg'
  ;r=dialog_message(ObserFilename)
  lines = file_lines(ObserFilename)
  data = fltarr(lines)
  openr,lun,ObserFilename,/get_lun
  readf,lun,data
  free_lun,lun
  Max = Max(data)
  Min = min(data)
  Binsize = ((Max-min)/10.0)
  H = Histogram((data), Binsize=Binsize, Min=min, Max=max)
  X=min+indgen(11)*Binsize
  aM=barplot(X,H,WINDOW_TITLE='地面观测数据直方图及高斯拟合',TITLE='',buffer=1)
  yfit = GAUSSFIT( X, H, coeff, NTERMS=4);高斯拟合
  bM=plot(X,yfit,LINESTYLE='dash', THICK=2,/CURRENT,AXIS_STYLE=0)
  bM.COLOR='red'
  bM.save,OutFilename
  Message=''
end