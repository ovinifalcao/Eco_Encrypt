using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Eco_Encrypt
{
    class Decrifrar
    {
        public string CaminhoPasta { get; set; }

        public void EncontrarArquivos()
        {

            var desktop = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop);
            FolderBrowserDialog CaixaDeSalvar = new FolderBrowserDialog
            {
                Description = "Selecione a pasta onde estão os recebidos",
            };
            DialogResult CaixaSalvarResultado = CaixaDeSalvar.ShowDialog();

            CaminhoPasta = CaixaDeSalvar.SelectedPath;



        }


    }
}
