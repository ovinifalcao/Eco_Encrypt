using System;
using System.Windows.Forms;

namespace Eco_Encrypt
{
    /// <summary>
    /// Form que responsável por dar uma interface para o usuário "Setar" os valores para Transcrição
    /// </summary>
    public partial class frm_ConfirmaDecrypt : Form
    {
        /// <summary>
        /// Construtor padrão para a classe Form
        /// </summary>
        public frm_ConfirmaDecrypt()
        {
            
            InitializeComponent();
        }

        /// <summary>
        /// Acão do botão X, fechar o form.
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Evento do botão que ativa todo processo para decifrar a mensagem.
        /// </summary>
        private void btEntrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(TxbCredencial.Text) && String.IsNullOrEmpty(TxbData.Text)) { throw new Exception("Não é possível decifrar se os dois campos não foram preenchidos"); }

                else
                {
                    UtilidadePublica CifrasLog = new UtilidadePublica(TxbData.Text, TxbCredencial.Text.ToLower());
                    Decifrar decifrar = new Decifrar(TxbCredencial.Text.ToLower(), TxbData.Text);
                    string CaminhoPath = CifrasLog.DialogBoxEncontraPasta();
                    this.Close();

                    decifrar.AFBtranscricao = CifrasLog.GerarVetorDoAlfabeto(CifrasLog.LeituraArquivosPMemoria(CaminhoPath, UtilidadePublica.Arquivo.Alfabeto));

                    decifrar.PrimeiroPasso(CifrasLog.LeituraArquivosPMemoria(CaminhoPath, UtilidadePublica.Arquivo.Texto));
                    decifrar.PassaFinal(decifrar.TerceiroPasso(decifrar.SegundoPasso()));
                }

            }
            catch (Exception ex) { 
                MessageBox.Show(ex.ToString(), "Erro Inesperado na Decifragem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
    }
}
