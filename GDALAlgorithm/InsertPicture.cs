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
    public partial class InsertPicture : Form
    {
        List<string> list = new List<string>();
        public InsertPicture(string list1,string list2,string list3)
        {
            InitializeComponent(list1,list2,list3);   
        }

    }
}
