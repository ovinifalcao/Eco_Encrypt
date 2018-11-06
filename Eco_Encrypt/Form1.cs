using System;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace Eco_Encrypt
{
    public partial class Form1 : Form
    {
        string[,] AlfabetoMatriz = new string[8, 8];

        public Form1()
        {
            InitializeComponent();
        }

        private void LerOForm(object sender, EventArgs e)
        {
            TxbData.Text = DateTime.Today.ToShortDateString();
            EstadoOpening();
        }

        private void BtEntrar_Click(object sender, EventArgs e)
        {
            try
            {
                if ((TxbCredencial.Text.Length) < 4) throw new Exception("Desculpe, mas a credencial não pode ser menor que 4 valores.");

                if (!((String.IsNullOrEmpty(TxbCredencial.Text) && String.IsNullOrEmpty(TxbData.Text))))
                {
                    EstadoEnviar();
                    GerarAlfabetoAleatorio();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Erro na validação de entrada", MessageBoxButtons.OK);
            }
        }

        private void picVoltar_Click(object sender, EventArgs e)
        {

        }

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

        public void GerarAlfabetoAleatorio()
        {
            //Vetores que permitem passar do alfabeto tradicional para uma versão randomica gerada
            string[] StrAlfaTradicional = new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "ç", "ã", "õ", "+", "-", "*", "é", "?", "!", "=", "_", "@", "#", ";", ",", " ", ".", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "<", ">", "/", ":", "(", ")", "[", "]", "{", "}", "ú","í" };
            string[] StrBetaTradicional = new string[64];

            //TrocaContador é o contador de letras que estão sendo substituidas
            //NumeroRd é o numero randomico gerado
            int TrocaContador = 0, numeradorRd = 0;
            Random rdTrocador = new Random();


            //Enquanto a quantidade total de numeros presentes no Vetor Alfabeto não estiver alocado em Beta continue testando posições randomicas para as caracteres
            while (TrocaContador != 64)
            {
                numeradorRd = rdTrocador.Next(0, 64);
                if (String.IsNullOrEmpty(StrBetaTradicional[numeradorRd]))
                {
                    StrBetaTradicional[numeradorRd] = StrAlfaTradicional[TrocaContador];
                    TrocaContador++;
                }
            }

            var desktop = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop);
            SaveFileDialog CaixaDeSalvar = new SaveFileDialog
            {
                Title = "Salvar Arquivo Texto",
                Filter = "Text File|.txt",
                FilterIndex = 0,
                FileName = "Alfabeto_" + TxbData.Text.Replace('/', '-'),
                DefaultExt = ".txt",
                InitialDirectory = desktop,
                RestoreDirectory = true
            };
            DialogResult CaixaSalvarResultado = CaixaDeSalvar.ShowDialog();

            FileStream FileAlfabeto = File.Create(CaixaDeSalvar.FileName);
            using (StreamWriter EscreverArquivo = new StreamWriter(FileAlfabeto))
            { 
                for (int i = 0; i < 64; i++)
                {
                    EscreverArquivo.Write(StrBetaTradicional[i]);
                }
            EscreverArquivo.Close();
            }

            GerarVetorDoAlfabeto(StrBetaTradicional);
        }

        public void GerarVetorDoAlfabeto(string[] alfabetoVigente)
        {
            int ContadorPassagem = 0;

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    AlfabetoMatriz[i, j] = alfabetoVigente[ContadorPassagem];
                    ContadorPassagem++;

                }
            }
        }

        private void btEnviar_Click(object sender, EventArgs e)
        {
            Encripitacao EncriptaTexto = new Encripitacao(TxbCredencial.Text, AlfabetoMatriz);
            EncriptaTexto.VerificarOTamanho(RemoverEspacos());
            MensCriptografada(EncriptaTexto.Pass);
        }

        public void MensCriptografada(string Mensagem)
        {
            var desktop = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop);
            SaveFileDialog CaixaDeSalvar = new SaveFileDialog
            {
                Title = "Salvar Arquivo Texto",
                Filter = "Text File|.txt",
                FilterIndex = 0,
                FileName = TxbCredencial.Text.ToLower(),
                DefaultExt = ".txt",
                InitialDirectory = desktop,
                RestoreDirectory = true
            };
            DialogResult CaixaSalvarResultado = CaixaDeSalvar.ShowDialog();

            FileStream FileAlfabeto = File.Create(CaixaDeSalvar.FileName);
            using (StreamWriter EscreverArquivo = new StreamWriter(FileAlfabeto))
            {

                EscreverArquivo.Write(Mensagem);
                EscreverArquivo.Close();
                Process.Start(CaixaDeSalvar.FileName);
            }
        }

        public string RemoverEspacos()
        {
            string texto;
            texto = TxbMensagem.Text;
            texto = texto.ToLower();
            texto = texto.Replace("\r\n", " ");
            return texto;

        }

        private void btnDecifrar_Click(object sender, EventArgs e)
        {
            frm_ConfirmaDecrypt Confirmacao = new frm_ConfirmaDecrypt();
            Confirmacao.Show();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            EstadoRetorno();
        }
    }


}
