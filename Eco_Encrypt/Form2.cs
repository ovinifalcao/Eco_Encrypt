using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Eco_Encrypt
{
    public partial class frm_ConfirmaDecrypt : Form
    {
        public frm_ConfirmaDecrypt()
        {
            
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btEntrar_Click(object sender, EventArgs e)
        {
            try
            {
                Decrifrar CifrasLog = new Decrifrar(TxbCredencial.Text, TxbData.Text);
                CifrasLog.EncontrarArquivos();

                this.Close();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.ToString(), "Erro Inesperado na Decifragem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
    }
}
