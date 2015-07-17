namespace GDALAlgorithm
{
    partial class InsertSoilPicture
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent(string list1, string list2, string list3, string list4)
        {
            this.SuspendLayout();
            // 
            // InsertSoilPicture
            // 
            this.ClientSize = new System.Drawing.Size(104, 0);
            this.Name = "InsertSoilPicture";
            this.ResumeLayout(false);
            list.Add(list1);
            list.Add(list2);
            list.Add(list3);
            list.Add(list4);
            OperatePicture.InsertSoilPicture(list.ToArray());
            this.Dispose();
        }

        #endregion
    }
}