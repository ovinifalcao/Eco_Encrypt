﻿using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eco_Encrypt
{
    class UtilidadePublica
    {
        string[,] AlfabetoMatriz = new string[8, 8];
        public string DataCriacaoAlfabeto { private get; private set; }
        public string CredencialDoCriador { private get; private set; }
        public string[] AlfabetoVigente { private get; private set; } 


        //CONSTRUTOR
        public UtilidadePublica(string Date, string Credent)
        {
            this.DataCriacaoAlfabeto = Date;
            this.CredencialDoCriador = Credent;
        }



        //CLASSES ESTÃO SUMARIZADAS PELA ORDEM DE CHAMADA

        /// <summary>
        /// Transforma o Alfabeto Padrão Para uma versão Linear, Array e Randomica
        /// </summary>
        public void GerarAlfabetoAleatorio()
        {
            //Vetores que permitem passar do alfabeto tradicional para uma versão randomica gerada
            string[] StrAlfaTradicional = new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "ç", "ã", "õ", "+", "-", "*", "é", "?", "!", "=", "_", "@", "#", ";", ",", " ", ".", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "<", ">", "/", ":", "(", ")", "[", "]", "ú", "í", "ê" };
            AlfabetoVigente = new string[64];

            //TrocaContador é o contador de letras que estão sendo substituidas
            //NumeroRd é o numero randomico gerado
            int TrocaContador = 0, numeradorRd = 0;
            Random rdTrocador = new Random();


            //Enquanto a quantidade total de numeros presentes no Vetor Alfabeto não estiverem alocado em Beta continue testando posições randomicas para as caracteres
            while (TrocaContador != 64)
            {
                numeradorRd = rdTrocador.Next(0, 64);
                if (String.IsNullOrEmpty(AlfabetoVigente[numeradorRd]))
                {
                    AlfabetoVigente[numeradorRd] = StrAlfaTradicional[TrocaContador];
                    TrocaContador++;
                }
            }

           //OS MÉTODOS PODERIAM SE CHAMAR INTERNAMENTE, POREM PARA MELHOR FORMAÇÃO DO PERSURSO DO ALGORITMO, SÃO USADO VARIÁVEIS PUBLICAS
        }

        /// <summary>
        /// Traansforma o Alfabeto Randomico Gerado em Um alfabeto Matricial
        /// </summary>
        public void GerarVetorDoAlfabeto()
        {
            int ContadorPassagem = 0;

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    AlfabetoMatriz[i, j] = AlfabetoVigente[ContadorPassagem];
                    ContadorPassagem++;
                }
            }
        }

        /// <summary>
        /// Remove os espaços não compuáveis para a aplicação
        /// </summary>
        /// <param name="TextoDoBox">String de texto com quebras</param>
        /// <returns>Retorna texto sem quebras</returns>
        public string RemoverEspacos(string TextoDoBox)
        {
            string texto;
            texto = TextoDoBox;
            texto = texto.ToLower();
            texto = texto.Replace("\r\n", " ");
            return texto;
        }



        //USO RECORRENTE FORA DE ORDEM

        public enum TipoDeSalvarDialog
        {
            TxtAlfabeto = 1,
            TxtEncriptado = 2,
            TxtDesencript =3
        }

        /// <summary>
        /// Cria Arquivo baseados nas Chamadas possíveis da Aplicação
        /// </summary>
        /// <param name="tipo">Tipo enumerado que define a instancia salvar será utilizado</param>
        public void DialogSalvarEm(TipoDeSalvarDialog tipo)
        {
            try
            {
                string NomenclarutaPadrao = null;
                string Excep = null;
                switch (tipo)
                {
                    case TipoDeSalvarDialog.TxtAlfabeto:
                        NomenclarutaPadrao = "Alfabeto_" + DataCriacaoAlfabeto.Replace('/', '-');
                        Excep = "Não existe maneira de continar sem gerarl o alfabeto, é preciso o alfabeto para desencripitar, partindo do fato que eles nunca são os mesmos, voc~e irá gerar uma mensagem nunca passível de nunca ser transcrita de volta por esse programa.";
                        break;

                    case TipoDeSalvarDialog.TxtEncriptado:
                        NomenclarutaPadrao = CredencialDoCriador.ToLower();
                        Excep = "Não há outro meio de recuperar o texto incriptado se não for através desse arquivo, por favor, envie novamente a mensagem para o programa e salve o arquivo para receber o valor criptografado";
                        break;

                    case TipoDeSalvarDialog.TxtDesencript:
                        NomenclarutaPadrao = "Final";
                        Excep = "Esse é o arquivo de texto descriptografado, se preferir não salva-lo, não poderá ver a mensagem original.";
                        break;

                    default:
                        throw new Exception("Não é possível salvar o arquivo");
                }


                var desktop = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop);
                using(SaveFileDialog CaixaDeSalvar = new SaveFileDialog())
                {
                    CaixaDeSalvar.Title = "Salvar Arquivo:";
                    CaixaDeSalvar.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                    CaixaDeSalvar.FilterIndex = 0;
                    CaixaDeSalvar.FileName = NomenclarutaPadrao;
                    CaixaDeSalvar.DefaultExt = ".txt";
                    CaixaDeSalvar.InitialDirectory = desktop;
                    CaixaDeSalvar.RestoreDirectory = true;

                    if (CaixaDeSalvar.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = CaixaDeSalvar.FileName;
                    }
                    else 
                    {
                        throw new Exception(Excep);
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Erro em salvar o arquivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        enum TipoDeSalve
        {
 
        }

        public void SalvarTxtStream(string NameFile, int QtdDeLoopsNecessarios)
        {

            //FileStream FileAlfabeto = File.Create(NameFile);
            //using (StreamWriter EscreverArquivo = new StreamWriter(FileAlfabeto))
            //{
            //    for (int i = 0; i < 64; i++)
            //    {
            //        EscreverArquivo.Write(AlfabetoVigente[i]);
            //    }
            //    EscreverArquivo.Close();
            //}



            //FileStream FileAlfabeto = File.Create(CaixaDeSalvar.FileName);
            //using (StreamWriter EscreverArquivo = new StreamWriter(FileAlfabeto))
            //{

            //    EscreverArquivo.Write(Mensagem);
            //    EscreverArquivo.Close();
            //    Process.Start(CaixaDeSalvar.FileName);
            }

    }
}
