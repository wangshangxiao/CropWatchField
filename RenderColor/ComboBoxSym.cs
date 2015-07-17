using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using DevExpress.XtraEditors;

namespace CropWatchField
{
    public partial class ComboBoxSym :System.Windows.Forms.ComboBox
    {
        private CheckedListBox checkedListBox1;
    
        public ComboBoxSym()
        {
            //以下两句是关键的；
            DrawMode = DrawMode.OwnerDrawFixed;
            DropDownStyle = ComboBoxStyle.DropDownList;
            //InitializeComponent();
        }

        //重写函数
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.DrawFocusRectangle();
            try
            {
                //显示图片
                Image image = (Image)Items[e.Index];
                System.Drawing.Rectangle rect = e.Bounds;
                e.Graphics.DrawImage(image, rect);
            }
            catch
            {
                if (e.Index != -1)
                {
                    //不是图片则显示字符
                    e.Graphics.DrawString(Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds.X, e.Bounds.Y);
                }
            }
            finally
            {
                base.OnDrawItem(e);
            }

        }

        private void InitializeComponent()
        {
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(0, 0);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(120, 96);
            this.checkedListBox1.TabIndex = 0;
            this.ResumeLayout(false);

        }

    }

}
