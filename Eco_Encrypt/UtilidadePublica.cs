using System;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;

namespace Eco_Encrypt
{
    /// <summary>
    /// Classe que acumula recursos que não são de contidos diremente para mecanica da encripitação mas se fazem necessários na implementação dessa aplicação;
    /// </summary>
    class UtilidadePublica
    {
        public string[,] AlfabetoMatriz { get; protected set; } = new string[8, 8];
        string DataCriacaoAlfabeto;
        string CredencialDoCriador;
        string[] AlfabetoVigente;


        //CONSTRUTORES
        public UtilidadePublica(string Date, string Credent)
        {
            this.DataCriacaoAlfabeto = Date;
            this.CredencialDoCriador = Credent;
        }

        public UtilidadePublica()
        { }


        //METODOS ESTÃO SUMARIZADAS PELA ORDEM DE CHAMADA
        /// <summary>
        /// Transforma o Alfabeto Padrão Para uma versão Linear, Array e Randomica
        /// </summary>
        public void GerarAlfabetoAleatorio()
        {
            //Vetores que permitem passar do alfabeto tradicional para uma versão randomica gerada
            string[] StrAlfaTradicional = new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "ç", "ã", "õ", "+", "-", "*", "é", "?", "!", "=", "_", "@", "#", ";", ",", " ", ".", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "<", ">", "ó", ":", "(", ")", "[", "]", "ú", "í", "ê" };
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

        public string[,] GerarVetorDoAlfabeto(string AlfabetoEstrangeiro)
        {
            int ContadorPassagem = 0;
            string[,] AlfabetoNovo = new string[8,8];

            char[] AlfaChar = AlfabetoEstrangeiro.ToCharArray();

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    AlfabetoNovo[i, j] = AlfaChar[ContadorPassagem].ToString();
                    ContadorPassagem++;
                }
            }
            return AlfabetoNovo;
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

        /// <summary>
        /// Transforma o alfabeto como StringLinear em um alfabeto matricial
        /// </summary>
        /// <param name="ALfabetoStringLinear">Alfabeto que foi lido a prtir do arquivo</param>
        public void SplitAFB(string ALfabetoStringLinear)
        {
            char[] AFBDesencript;
            AFBDesencript = ALfabetoStringLinear.ToCharArray();


            int ContadorPassagem = 0;

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    AlfabetoMatriz[i, j] = AFBDesencript[ContadorPassagem].ToString();
                    ContadorPassagem++;
                }
            }
        }



        //USO RECORRENTE FORA DE ORDEM
        /// <summary>
        /// Tipo enumerado que viabiliza as opções para o meodo de DialogBox
        /// </summary>
        public enum TipoDeSalvar
        {
            TxtAlfabeto = 1,
            TxtEncriptado = 2,
            TxtDesencript =3
        }

        /// <summary>
        /// Cria Arquivo baseados nas Chamadas possíveis da Aplicação
        /// </summary>
        /// <param name="tipo">Tipo enumerado que define a instancia salvar será utilizado</param>
        public string DialogSalvarEm(TipoDeSalvar tipo)
        {
            try
            {
                string NomenclarutaPadrao = null;
                string Excep = null;
                switch (tipo)
                {
                    case TipoDeSalvar.TxtAlfabeto:
                        NomenclarutaPadrao = "Alfabeto_" + DataCriacaoAlfabeto.Replace('/', '-');
                        Excep = "Não existe maneira de continar sem gerarl o alfabeto, é preciso o alfabeto para desencripitar, partindo do fato que eles nunca são os mesmos, voc~e irá gerar uma mensagem nunca passível de nunca ser transcrita de volta por esse programa.";
                        break;

                    case TipoDeSalvar.TxtEncriptado:
                        NomenclarutaPadrao = CredencialDoCriador.ToLower();
                        Excep = "Não há outro meio de recuperar o texto incriptado se não for através desse arquivo, por favor, envie novamente a mensagem para o programa e salve o arquivo para receber o valor criptografado";
                        break;

                    case TipoDeSalvar.TxtDesencript:
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
                        return filePath;
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
                return null;
            }
        }

        /// <summary>
        /// Faz o Stream do Txt especificado
        /// </summary>
        /// <param name="NameFile">Caminho para o arquivo</param>
        /// <param name="QtdDeLoopsNecessarios">Quantidade de loops que o programa dará pra salvar</param>
        /// <param name="OpenAfter">Verificia a abertura após a conclusão do Stream</param>
        public void SalvarTxtStream(string NameFile, int QtdDeLoopsNecessarios, bool OpenAfter, string Conteudo = null)
        {

            FileStream FileAlfabeto = File.Create(NameFile);

            using (StreamWriter EscreverArquivo = new StreamWriter(FileAlfabeto))
            {
                if (QtdDeLoopsNecessarios > 1)
                {
                    for (int i = 0; i < QtdDeLoopsNecessarios; i++)
                    {
                        EscreverArquivo.Write(AlfabetoVigente[i]);

                    }
                    EscreverArquivo.Close();
                    if (OpenAfter == true) Process.Start(NameFile);
                }
                else
                {
                        EscreverArquivo.Write(Conteudo);
                        EscreverArquivo.Close();

                    if (OpenAfter == true) Process.Start(NameFile);
                }
               
            }

            GC.WaitForFullGCComplete();
            GC.Collect();

        }
        

        public void SalvarTxtStream(string NameFile, bool OpenAfter, string ConteudoTexto)
        {

            FileStream FileAlfabeto = File.Create(NameFile);

            using (StreamWriter EscreverArquivo = new StreamWriter(FileAlfabeto))
            {
                    EscreverArquivo.Write(ConteudoTexto);
                    EscreverArquivo.Close();
                    if (OpenAfter == true) Process.Start(NameFile);
            }

            GC.WaitForFullGCComplete();
            GC.Collect();

        }

        /// <summary>
        /// Encontra a pasta em que vão estar os arquivos para a desencriptação
        /// </summary>
        /// <returns>
        /// Retorna a pasta raiz dos arquivos
        /// </returns>
        public string DialogBoxEncontraPasta()
        {
            var desktop = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop);
            FolderBrowserDialog CaixaDeSalvar = new FolderBrowserDialog
            {
                Description = "Selecione a pasta onde estão os recebidos",
            };
            DialogResult CaixaSalvarResultado = CaixaDeSalvar.ShowDialog();

            return CaixaDeSalvar.SelectedPath;
        }

        public enum Arquivo
        {
            Alfabeto = 1,
            Texto = 2,
        }

        /// <summary>
        /// Realiza a Tarefa de ler os arquivos TXT que a aplicação usará
        /// </summary>
        /// <param name="CaminhoPasta">Caminho da pasta obitido atrasvés do DialogBoxEncontraPasta</param>
        /// <returns>
        /// Retorna o texto contido no arquivo que foi lido
        /// </returns>
        public string LeituraArquivosPMemoria(string CaminhoPasta, Arquivo Qual)
        {
            string TextoContidoNoArquivo;

            if (Qual == Arquivo.Alfabeto)
            {
                DataCriacaoAlfabeto = DataCriacaoAlfabeto.Replace('/', '-');
                using (StreamReader LeitorTxt = new StreamReader(CaminhoPasta + "/Alfabeto_" + DataCriacaoAlfabeto + ".txt"))
                {
                    TextoContidoNoArquivo = LeitorTxt.ReadLine();
                    LeitorTxt.Close();
                    return TextoContidoNoArquivo;
                }
            }

            else if (Qual == Arquivo.Texto)
            {
                using (StreamReader LeitorTxt = new StreamReader(CaminhoPasta + '/' + CredencialDoCriador + ".txt"))
                {
                    TextoContidoNoArquivo = LeitorTxt.ReadLine();
                    LeitorTxt.Close();
                    return TextoContidoNoArquivo;
                }
            }
            else { return null; }          
        }


    }

}
