using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using System.Xml;

namespace CropWatchField
{
    public partial class CodeListXtraForm : DevExpress.XtraEditors.XtraForm
    {
        public CodeListXtraForm()
        {
            InitializeComponent();
            
        }


        private void BindDataSource()
        {
            string sPath = FileManage.getApplicatonPath() + "cropcode.xml";
            DataTable dt = XmlManage.getCropCodeFromXml(sPath);
            gridControl1.DataSource = dt;
        }

        private void CodeListXtraForm_Load(object sender, EventArgs e)
        {
            BindDataSource();
        }

    }
}