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
            Decrifrar CifrasLog = new Decrifrar();
            CifrasLog.EncontrarArquivos();
        }
    }
}
