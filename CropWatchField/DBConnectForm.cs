using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CropWatchField
{
    
    public partial class DBConnectForm : Form
    {
        Database db = new Database();
        public DBConnectForm()
        {
            InitializeComponent();
        }

        private void btn_DBConnTest_Click(object sender, EventArgs e)
        {
            bool b = db.IsHasTable("COUNTRY_CODE");
        }
    }
}
