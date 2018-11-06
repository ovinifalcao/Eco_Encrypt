namespace Eco_Encrypt
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.PanelEncrypt = new System.Windows.Forms.Panel();
            this.TxbMensagem = new System.Windows.Forms.TextBox();
            this.picMensagem = new System.Windows.Forms.PictureBox();
            this.btEnviar = new System.Windows.Forms.Button();
            this.btEntrar = new System.Windows.Forms.Button();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.TxbCredencial = new System.Windows.Forms.TextBox();
            this.TxbData = new System.Windows.Forms.MaskedTextBox();
            this.picLogo2 = new System.Windows.Forms.PictureBox();
            this.btnDecifrar = new System.Windows.Forms.Button();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.PanelEncrypt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMensagem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo2)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelEncrypt
            // 
            this.PanelEncrypt.BackColor = System.Drawing.Color.YellowGreen;
            this.PanelEncrypt.Controls.Add(this.TxbMensagem);
            this.PanelEncrypt.Controls.Add(this.picMensagem);
            this.PanelEncrypt.Controls.Add(this.btEnviar);
            this.PanelEncrypt.Controls.Add(this.btEntrar);
            this.PanelEncrypt.Location = new System.Drawing.Point(0, 551);
            this.PanelEncrypt.Name = "PanelEncrypt";
            this.PanelEncrypt.Size = new System.Drawing.Size(384, 590);
            this.PanelEncrypt.TabIndex = 0;
            // 
            // TxbMensagem
            // 
            this.TxbMensagem.Location = new System.Drawing.Point(12, 43);
            this.TxbMensagem.Multiline = true;
            this.TxbMensagem.Name = "TxbMensagem";
            this.TxbMensagem.Size = new System.Drawing.Size(360, 469);
            this.TxbMensagem.TabIndex = 5;
            // 
            // picMensagem
            // 
            this.picMensagem.Image = ((System.Drawing.Image)(resources.GetObject("picMensagem.Image")));
            this.picMensagem.Location = new System.Drawing.Point(13, 13);
            this.picMensagem.Name = "picMensagem";
            this.picMensagem.Size = new System.Drawing.Size(100, 24);
            this.picMensagem.TabIndex = 3;
            this.picMensagem.TabStop = false;
            // 
            // btEnviar
            // 
            this.btEnviar.FlatAppearance.BorderSize = 5;
            this.btEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btEnviar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btEnviar.Image = ((System.Drawing.Image)(resources.GetObject("btEnviar.Image")));
            this.btEnviar.Location = new System.Drawing.Point(67, 530);
            this.btEnviar.Name = "btEnviar";
            this.btEnviar.Size = new System.Drawing.Size(231, 46);
            this.btEnviar.TabIndex = 1;
            this.btEnviar.UseVisualStyleBackColor = true;
            this.btEnviar.Click += new System.EventHandler(this.btEnviar_Click);
            // 
            // btEntrar
            // 
            this.btEntrar.FlatAppearance.BorderSize = 5;
            this.btEntrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btEntrar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btEntrar.Image = ((System.Drawing.Image)(resources.GetObject("btEntrar.Image")));
            this.btEntrar.Location = new System.Drawing.Point(67, 34);
            this.btEntrar.Name = "btEntrar";
            this.btEntrar.Size = new System.Drawing.Size(231, 46);
            this.btEntrar.TabIndex = 0;
            this.btEntrar.UseVisualStyleBackColor = true;
            this.btEntrar.Click += new System.EventHandler(this.BtEntrar_Click);
            // 
            // picLogo
            // 
            this.picLogo.Image = ((System.Drawing.Image)(resources.GetObject("picLogo.Image")));
            this.picLogo.Location = new System.Drawing.Point(52, 26);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(283, 193);
            this.picLogo.TabIndex = 1;
            this.picLogo.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(13, 298);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(94, 20);
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(13, 405);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(131, 24);
            this.pictureBox3.TabIndex = 3;
            this.pictureBox3.TabStop = false;
            // 
            // TxbCredencial
            // 
            this.TxbCredencial.BackColor = System.Drawing.Color.DimGray;
            this.TxbCredencial.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxbCredencial.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.TxbCredencial.Location = new System.Drawing.Point(32, 331);
            this.TxbCredencial.Name = "TxbCredencial";
            this.TxbCredencial.Size = new System.Drawing.Size(314, 37);
            this.TxbCredencial.TabIndex = 4;
            // 
            // TxbData
            // 
            this.TxbData.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.TxbData.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxbData.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.TxbData.Location = new System.Drawing.Point(32, 447);
            this.TxbData.Mask = "00/00/0000";
            this.TxbData.Name = "TxbData";
            this.TxbData.Size = new System.Drawing.Size(314, 37);
            this.TxbData.TabIndex = 5;
            this.TxbData.ValidatingType = typeof(System.DateTime);
            // 
            // picLogo2
            // 
            this.picLogo2.Image = ((System.Drawing.Image)(resources.GetObject("picLogo2.Image")));
            this.picLogo2.Location = new System.Drawing.Point(122, 6);
            this.picLogo2.Name = "picLogo2";
            this.picLogo2.Size = new System.Drawing.Size(134, 57);
            this.picLogo2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo2.TabIndex = 6;
            this.picLogo2.TabStop = false;
            // 
            // btnDecifrar
            // 
            this.btnDecifrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDecifrar.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDecifrar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDecifrar.Location = new System.Drawing.Point(273, 19);
            this.btnDecifrar.Name = "btnDecifrar";
            this.btnDecifrar.Size = new System.Drawing.Size(99, 36);
            this.btnDecifrar.TabIndex = 8;
            this.btnDecifrar.Text = "DECIFRAR";
            this.btnDecifrar.UseVisualStyleBackColor = true;
            this.btnDecifrar.Visible = false;
            this.btnDecifrar.Click += new System.EventHandler(this.btnDecifrar_Click);
            // 
            // btnVoltar
            // 
            this.btnVoltar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVoltar.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVoltar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnVoltar.Location = new System.Drawing.Point(8, 19);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(99, 36);
            this.btnVoltar.TabIndex = 9;
            this.btnVoltar.Text = "VOLTAR";
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Visible = false;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(384, 662);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.btnDecifrar);
            this.Controls.Add(this.picLogo2);
            this.Controls.Add(this.PanelEncrypt);
            this.Controls.Add(this.TxbData);
            this.Controls.Add(this.TxbCredencial);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.picLogo);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.LerOForm);
            this.PanelEncrypt.ResumeLayout(false);
            this.PanelEncrypt.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMensagem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PanelEncrypt;
        private System.Windows.Forms.Button btEntrar;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.TextBox TxbCredencial;
        private System.Windows.Forms.MaskedTextBox TxbData;
        private System.Windows.Forms.Button btEnviar;
        private System.Windows.Forms.PictureBox picMensagem;
        private System.Windows.Forms.PictureBox picLogo2;
        private System.Windows.Forms.Button btnDecifrar;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.TextBox TxbMensagem;
    }
}

