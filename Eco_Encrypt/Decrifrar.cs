using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

namespace Eco_Encrypt
{
    class Decrifrar
    {

        public string CaminhoPasta { get; set; }
        private string AlfabetoTranscricao;
        private string MensagemCrypto;

        public void EncontrarArquivos(string CredFication, string DateFication)
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
        }

    }
}
