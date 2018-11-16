using System;
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
                UtilidadePublica CifrasLog = new UtilidadePublica(TxbData.Text, TxbCredencial.Text.ToLower());
                Decifrar decifrar = new Decifrar(TxbCredencial.Text.ToLower(), TxbData.Text);
                string CaminhoPath = CifrasLog.DialogBoxEncontraPasta();
                this.Close();

                decifrar.AFBtranscricao = CifrasLog.GerarVetorDoAlfabeto(CifrasLog.LeituraArquivosPMemoria(CaminhoPath, UtilidadePublica.Arquivo.Alfabeto));

                decifrar.PrimeiroPasso(CifrasLog.LeituraArquivosPMemoria(CaminhoPath, UtilidadePublica.Arquivo.Texto));
                decifrar.PassaFinal(decifrar.TerceiroPasso(decifrar.SegundoPasso()));

            }
            catch (Exception ex) { 
                MessageBox.Show(ex.ToString(), "Erro Inesperado na Decifragem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
    }
}
