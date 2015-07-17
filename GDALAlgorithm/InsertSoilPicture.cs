using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GDALAlgorithm
{
    public partial class InsertSoilPicture : Form
    {
        List<string> list=new List<string>();
        public InsertSoilPicture(string list1, string list2, string list3,string list4)
        {
            InitializeComponent(list1, list2, list3,list4);
        }
    }
}
