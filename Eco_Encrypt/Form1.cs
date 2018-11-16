using System;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace Eco_Encrypt
{
    public partial class Form1 : Form
    {
        Encripitacao EncriptaTexto;

        //CONSTRUTOR DO FORM
        public Form1() => InitializeComponent();


        private void LerOForm(object sender, EventArgs e)
        {
            TxbData.Text = DateTime.Today.ToShortDateString();
            EstadoOpening();
        }



        //AÇÕES DE BOTÕES
        private void BtEntrar_Click(object sender, EventArgs e)
        {
            try
            {
                if ((TxbCredencial.Text.Length) < 4) throw new Exception("Desculpe, mas a credencial não pode ser menor que 4 valores.");

                if (!((String.IsNullOrEmpty(TxbCredencial.Text) && String.IsNullOrEmpty(TxbData.Text))))
                {
                    UtilidadePublica Util = new UtilidadePublica(TxbData.Text, TxbCredencial.Text);
                    EstadoEnviar();
                    Util.GerarAlfabetoAleatorio();
                    Util.GerarVetorDoAlfabeto();
                    Util.SalvarTxtStream(Util.DialogSalvarEm(UtilidadePublica.TipoDeSalvar.TxtAlfabeto), 64, true);
                    EncriptaTexto = new Encripitacao(TxbCredencial.Text.ToLower(), Util.AlfabetoMatriz);
                }
                else throw new Exception("Os campos acima não podem estar vazios, ou estão com valores invalidos");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Erro na validação de entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btEnviar_Click(object sender, EventArgs e)
        {
            UtilidadePublica Util = new UtilidadePublica(TxbData.Text, TxbCredencial.Text.ToLower());
                    
            EncriptaTexto.PrimeiroPasso(Util.RemoverEspacos(EncriptaTexto.VerificarOTamanho(TxbMensagem.Text.ToLower())));
            EncriptaTexto.SegundoPasso();
            EncriptaTexto.TerceiroPasso();

            Util.SalvarTxtStream(Util.DialogSalvarEm(UtilidadePublica.TipoDeSalvar.TxtEncriptado), 1, true, EncriptaTexto.MensagemCriptografada());

        }

        private void btnDecifrar_Click(object sender, EventArgs e)
        {
            TxbMensagem.Text = null;
            frm_ConfirmaDecrypt Confirmacao = new frm_ConfirmaDecrypt();
            Confirmacao.Show();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            EstadoRetorno();
        }



        //MUNDAÇA DE ESTADO DO PANEL
        public void EstadoOpening()
        {
            TxbMensagem.Visible = false;
            picMensagem.Visible = false;
            PanelEncrypt.Height = 110;
            picLogo2.Visible = false;
        }

        public void EstadoEnviar()
        {
            TxbMensagem.Visible = true;
            picMensagem.Visible = true;
            PanelEncrypt.Height = 600;
            PanelEncrypt.Top = 73;
            picLogo.Visible = false;
            picLogo2.Visible = true;
            btnVoltar.Visible = true;
            btEntrar.Visible = false;
            btnDecifrar.Visible = true;
        }

        public void EstadoRetorno()
        {
            TxbMensagem.Text = null;
            TxbMensagem.Visible = false;
            picMensagem.Visible = false;
            PanelEncrypt.Top = 550;
            picLogo.Visible = true;
            picLogo2.Visible = false;
            btnVoltar.Visible = false;
            btnDecifrar.Visible = false;
            btEntrar.Visible = true;
        }


    }
}
