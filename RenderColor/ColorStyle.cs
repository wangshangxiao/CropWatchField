using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Display;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using System.Collections;

namespace CropWatchField
{
   public class ColorStyle
    {
       public List<IColorRamp> pListRamp=new List<IColorRamp>();
       public List<IColor> pListColor=new List<IColor>();

       public void Style(string name, List<ComboBoxSym> cmblist)
        {
            IStyleGallery pStyleGallery;
            IStyleGalleryStorage pStyleStorage;
            IEnumStyleGalleryItem enumStyleGalleryItem;
            IStyleGalleryItem styleItem;

            pStyleGallery = new ServerStyleGalleryClass();
            pStyleStorage = pStyleGallery as IStyleGalleryStorage;
            //默认地址,也可以自己定义
            string stylePath = Application.StartupPath + "\\ESRI.ServerStyle";
            pStyleStorage.AddFile(stylePath);
            switch (name)
            {
                case "Color Ramps":
                    IStyleGalleryClass pStyleGalleryClass = new ColorRampStyleGalleryClassClass();
                    enumStyleGalleryItem = pStyleGallery.get_Items("Color Ramps", "ESRI.ServerStyle", "");
                    enumStyleGalleryItem.Reset();
                    styleItem = enumStyleGalleryItem.Next();
                    for (int i = 1; i <55; i++)
                    //while(styleItem!=null)
                    {
                        pListRamp.Add((IColorRamp)styleItem.Item);
                        Bitmap bitmap = PreviewSymbol(pStyleGalleryClass, styleItem.Item, cmblist[0].Width, cmblist[0].Height);
                        cmblist[0].Items.Add(bitmap);
                        cmblist[1].Items.Add(bitmap);
                        styleItem = enumStyleGalleryItem.Next();
                    }
                    break;
                case "Colors":
                    IStyleGalleryClass pStyleGalleryClass1 = new ColorStyleGalleryClassClass();
                    enumStyleGalleryItem = pStyleGallery.get_Items("Colors", "ESRI.ServerStyle", "");
                    enumStyleGalleryItem.Reset();
                    styleItem = enumStyleGalleryItem.Next();
                    for (int i = 1; i < 55; i++)
                    //while (styleItem != null)
                    {
                        pListColor.Add((IColor)styleItem.Item);
                        Bitmap bitmap = PreviewSymbol(pStyleGalleryClass1, styleItem.Item, cmblist[0].Width, cmblist[0].Height);
                        cmblist[0].Items.Add(bitmap);
                        cmblist[1].Items.Add(bitmap);
                        styleItem = enumStyleGalleryItem.Next();

                    }
                    break;

            }
            pStyleStorage.RemoveFile(stylePath);
        }

        public Bitmap PreviewSymbol(IStyleGalleryClass pStyleGalleryClass, object galleryItem, int imgWidth, int imgHeight)
        {
            Bitmap bitmap = new Bitmap(imgWidth, imgHeight);
            Graphics graphics = Graphics.FromImage(bitmap);
            tagRECT rect = new tagRECT();
            rect.right = bitmap.Width;
            rect.bottom = bitmap.Height;
            System.IntPtr hdc = graphics.GetHdc();
            pStyleGalleryClass.Preview(galleryItem, hdc.ToInt32(), ref rect);
            graphics.ReleaseHdc(hdc);
            graphics.Dispose();
            return bitmap;
        }
    }
}
