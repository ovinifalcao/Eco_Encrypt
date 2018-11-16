namespace Eco_Encrypt
{
    partial class frm_ConfirmaDecrypt
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
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_ConfirmaDecrypt));
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.TxbData = new System.Windows.Forms.MaskedTextBox();
            this.btEntrar = new System.Windows.Forms.Button();
            this.BtFechar = new System.Windows.Forms.Button();
            this.TxbCredencial = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox3
            // 
            resources.ApplyResources(this.pictureBox3, "pictureBox3");
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.TabStop = false;
            // 
            // TxbData
            // 
            this.TxbData.BackColor = System.Drawing.SystemColors.WindowFrame;
            resources.ApplyResources(this.TxbData, "TxbData");
            this.TxbData.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.TxbData.Name = "TxbData";
            this.TxbData.ValidatingType = typeof(System.DateTime);
            // 
            // btEntrar
            // 
            this.btEntrar.BackColor = System.Drawing.Color.YellowGreen;
            this.btEntrar.FlatAppearance.BorderSize = 5;
            resources.ApplyResources(this.btEntrar, "btEntrar");
            this.btEntrar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btEntrar.Name = "btEntrar";
            this.btEntrar.UseVisualStyleBackColor = false;
            this.btEntrar.Click += new System.EventHandler(this.btEntrar_Click);
            // 
            // BtFechar
            // 
            this.BtFechar.BackColor = System.Drawing.Color.YellowGreen;
            this.BtFechar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            resources.ApplyResources(this.BtFechar, "BtFechar");
            this.BtFechar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BtFechar.Name = "BtFechar";
            this.BtFechar.UseVisualStyleBackColor = false;
            this.BtFechar.Click += new System.EventHandler(this.button1_Click);
            // 
            // TxbCredencial
            // 
            this.TxbCredencial.BackColor = System.Drawing.Color.DimGray;
            resources.ApplyResources(this.TxbCredencial, "TxbCredencial");
            this.TxbCredencial.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.TxbCredencial.Name = "TxbCredencial";
            // 
            // pictureBox2
            // 
            resources.ApplyResources(this.pictureBox2, "pictureBox2");
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.TabStop = false;
            // 
            // frm_ConfirmaDecrypt
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Controls.Add(this.TxbCredencial);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.BtFechar);
            this.Controls.Add(this.btEntrar);
            this.Controls.Add(this.TxbData);
            this.Controls.Add(this.pictureBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_ConfirmaDecrypt";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button btEntrar;
        private System.Windows.Forms.Button BtFechar;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.MaskedTextBox TxbData;
        private System.Windows.Forms.TextBox TxbCredencial;
        //private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        //private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape1;
    }
}