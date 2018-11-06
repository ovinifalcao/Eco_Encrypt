using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace Eco_Encrypt
{
    class Decrifrar
    {

        public string CaminhoPasta { get; set; }
        private string AlfabetoTranscricao;
        private string MensagemCrypto;
        private string[,] AFBtranscricao = new string[8,8];
        private string CredFication;
        private string DateFication;
        public string DesconvertidaMesg { get; private set; }

        public Decrifrar(string credFication, string dateFication)
        {
            CredFication = credFication;
            DateFication = dateFication;
        }

        public Decrifrar()
        {
        }

        public void EncontrarArquivos()
        {

            DateFication = DateFication.Replace('/', '-');


            var desktop = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop);
            FolderBrowserDialog CaixaDeSalvar = new FolderBrowserDialog
            {
                Description = "Selecione a pasta onde estão os recebidos",
            };
            DialogResult CaixaSalvarResultado = CaixaDeSalvar.ShowDialog();

            CaminhoPasta = CaixaDeSalvar.SelectedPath;



            //LEITURA DO ALFABETO DESENCRIPTADOR
            StreamReader LeitorAFB = new StreamReader(CaminhoPasta + "/Alfabeto_" + DateFication + ".txt");
            AlfabetoTranscricao = LeitorAFB.ReadLine();
            LeitorAFB.Close();

            //
            StreamReader LeitorTexto = new StreamReader(CaminhoPasta +"/"+ CredFication + ".txt" );
            MensagemCrypto = LeitorTexto.ReadLine();
            LeitorTexto.Close();

            SplitAFB();
        }

        public void SplitAFB()
        {
            char[] AFBDesencript;
            AFBDesencript = AlfabetoTranscricao.ToCharArray();


            int ContadorPassagem = 0;

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    AFBtranscricao[i, j] = AFBDesencript[ContadorPassagem].ToString();
                    ContadorPassagem++;
                }
            }


            PrimeiroPasso();
        }

        public void PrimeiroPasso()
        {

            //AQUI CADA LETRA RECEBE SEU EQUIVALENTE MATRICIAL NO ALFABETO FORNCIDO
            char[] CharPorLetra;
            CharPorLetra =  MensagemCrypto.ToCharArray();

            int ContadorDeChar = 0, x = 0, y = 0;
            int[,] TranscricaoAlfabetos = new int[2, CharPorLetra.Length];

            foreach (char ch in CharPorLetra)
            {

                while (CharPorLetra[ContadorDeChar].ToString() !=  AFBtranscricao[x, y])
                {
                    if (y == 7)
                    {
                        x++;
                        y = 0;
                    }
                    else
                    {
                        y++;
                    }
                }

                TranscricaoAlfabetos[0, ContadorDeChar] = x;
                TranscricaoAlfabetos[1, ContadorDeChar] = y;

                ContadorDeChar++;
                x = 0;
                y = 0;

            }

            SegundoPasso(TranscricaoAlfabetos);
        }

        public void SegundoPasso(int[,] TrascricaoDoPrimeiroPasso)
        {
            string ValoresLinhaTransc=null;
            for (int i = 0; i < (TrascricaoDoPrimeiroPasso.Length / 2); i++)
            {
                ValoresLinhaTransc = ValoresLinhaTransc + TrascricaoDoPrimeiroPasso[0, i].ToString();
                ValoresLinhaTransc = ValoresLinhaTransc + TrascricaoDoPrimeiroPasso[1, i].ToString();
            }

            TerceiroPasso(ValoresLinhaTransc);

        }

        public void TerceiroPasso(string LinhaDeTextos)
        {
            char[] SplitTranscrit;
            SplitTranscrit = LinhaDeTextos.ToCharArray();

            int[,] TextoPreTranscrit = new int[2, (LinhaDeTextos.Length / 2)];
            int RazaoDivisora = Math.Abs((CredFication.Length / 2));
            int QtdLoops = Math.Abs((((LinhaDeTextos.Length) / 2) / RazaoDivisora));
            int ContadoraDePassagemX = 0, ContadoraDePassagemY =0, PassadorSplit = 0;

            for (int i = 0; i < QtdLoops; i++)
            {

                for (int j = 0; j < RazaoDivisora; j++)
                {
                    TextoPreTranscrit[0, ContadoraDePassagemX] = int.Parse(SplitTranscrit[PassadorSplit].ToString());
                    ContadoraDePassagemX++;
                    PassadorSplit++;
                }

                for (int j = 0; j < RazaoDivisora; j++)
                {
                    TextoPreTranscrit[1, ContadoraDePassagemY] = int.Parse(SplitTranscrit[PassadorSplit].ToString());
                    ContadoraDePassagemY++;
                    PassadorSplit++;
                }

            }

            PassaFinal(TextoPreTranscrit);

        }

        public void PassaFinal(int[,] CodigoFinal)
        {
            //GRAÇAS A DEUS
            string MensagemFinal = null;

            for (int i = 0; i < (CodigoFinal.Length / 2); i++)
            {
                MensagemFinal = MensagemFinal + AFBtranscricao[(CodigoFinal[0, i]), (CodigoFinal[1, i])];
            }

            DesconvertidaMesg = MensagemFinal;

                        var desktop = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop);
            SaveFileDialog CaixaDeSalvar = new SaveFileDialog
            {
                Title = "Mensagem Pronta, escolha onde Salvar",
                Filter = "Text File|.txt",
                FilterIndex = 0,
                FileName = "final",
                DefaultExt = ".txt",
                InitialDirectory = desktop,
                RestoreDirectory = true
            };
            DialogResult CaixaSalvarResultado = CaixaDeSalvar.ShowDialog();

            using (StreamWriter TextoFinal = new StreamWriter(CaixaDeSalvar.FileName))
            {
                TextoFinal.WriteLine(DesconvertidaMesg);
                TextoFinal.Close();
                Process.Start(CaixaDeSalvar.FileName);
            }

            GC.Collect();
        }

    }
}
