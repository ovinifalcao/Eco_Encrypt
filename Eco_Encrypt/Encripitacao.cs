using System;
using System.Windows.Forms;

namespace Eco_Encrypt
{
    /// <summary>
    /// Classe contém os métodos separados em passos para a encriptação segundo a tal prática pelo modelo de BIFID
    /// </summary>
    class Encripitacao
    {
        private string Credencial {  get ; set; } 
        private string[,] Alfabeto { get; set; } 
        public string Pass { get; private set; }
        private int[,] TranscricaoAlfabetos;
        private string TranscricaoVertical = null;
        private string[,] StrCombinacaoFinal;

        //CONSTRUTOR
        /// <summary>
        /// Construtor para a Classe Adiciona informações recorrentes para o funcionamento da mesma
        /// </summary>
        /// <param name="credencial">Informação do TextBox da Credencial</param>
        /// <param name="alfabeto">Recebe o Alfabeto Vigente Já Randomico da versão vigente</param>
        public Encripitacao(string credencial, string[,] alfabeto)
        {
            Alfabeto = alfabeto;
            Credencial = credencial;
        }
                
        /// <summary>
        /// Realiza ações relacionadas ao ajuste do texto um passso pré Criptografia
        /// </summary>
        /// <param name="TextoComum">Texto recebido do Txtbox pertinente a mensagem a ser encripitada</param>
        /// <remarks>        
        ///PASSO NECESSÁRIO PARA REFORÇAR A SEGURANÇA EM RELAÇÃO AS CHAVES CRIPTOGRAFICA
        ///O RAZÃO DE DIVISÃO DAS STRINGS PARA A TRANSPOSIÇÃO MATRICIAL PROPOSTO MAIS A DIANTE NO MÉTODO DE BIFID PRECISA QUE OS VALORES SEJAM PARTICIONAVEIS PELO ÍNDICE QUE LHES É PROPOSTO
        ///PARA MANTER A VALIDADE DA REGRA O METODO É IMPLANTADO PARA QUE O PROGRAMA NÃO EXECUTE EXCEPITIONS EM CASOS INCOMUNS A REGRA
        /// </remarks>
        /// <returns>Retorna Texto com as verificações adicionadas </returns>
        public string VerificarOTamanho(string TextoComum)
        {

            if (TextoComum.Length < Credencial.Length)
            {
                for (int i = TextoComum.Length; i < Credencial.Length; i++)
                {
                    TextoComum = TextoComum + " ";
                }
            }
            else if ((TextoComum.Length > Credencial.Length) && ((TextoComum.Length % Credencial.Length) != 0))
            {
                int Loops = ((Credencial.Length / 2) - (TextoComum.Length % Credencial.Length));


                for (int i = 0; i < Loops; i++)
                {
                    TextoComum = TextoComum + " ";
                }
            }

            return (TextoComum);
        }


        // PASSOS DESCRITOS NA ORDEM EM QUE SÃO COMUMENTE CHAMADOS
        /// <summary>
        ///NESTE PASSO AS LETRAS DO ALFABETO COMUM ENCONTRAM SUA COMBINAÇÃO MATRICIAL NO NOVO ALFABETO GERADO RANDOMICAMENTE
        /// </summary>
        /// <param name="TextoComum">Recebe texto com tamanho já correto</param>
        public void PrimeiroPasso(string TextoComum)
        {
            //AQUI CADA LETRA RECEBE SEU EQUIVALENTE MATRICIAL NO NOVO ALFABETO
            char[] CharPorLetra = null;
            int ContadorDeChar = 0, x = 0, y = 0;
            try
            {
                CharPorLetra = TextoComum.ToCharArray();
                TranscricaoAlfabetos = new int[2, CharPorLetra.Length];

                foreach (char ch in CharPorLetra)
                {

                    while (CharPorLetra[ContadorDeChar].ToString() != Alfabeto[x, y])
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

            }
            catch (Exception ex)
            {
                MessageBox.Show("O caracter " + CharPorLetra[ContadorDeChar].ToString() + " não consta na referência padrão do Alfabeto Base, Substitua por outro caractere válido. " + ex.ToString(), "Erro no limite do Alfabeto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Form1 AcessoFrmUm = new Form1();
                AcessoFrmUm.EstadoRetorno();
            }

        }

        /// <summary>
        ///NESSE PASSO A CIFRA DE BIFID HÁ FRACIONAMENTO DA STRING PELA RAZÃO FORNCEDIDA NO LENGTH DA CREDECIAL
        ///O TEXTO PASSA A CONTER INFORMAÇÕES MATRICIAIS QUE SÃO EMBARALHADAS PELA LINEARIZÃO DO NUMERO
        /// </summary>
        public void SegundoPasso()
        {
            int RazaoDivisora= Math.Abs((Credencial.Length / 2));

            byte V = 0, W = 0;

            int QtdLoops = 0;
            double VerificadorDeLoop = ((TranscricaoAlfabetos.Length/2) / RazaoDivisora);
            if (Math.Abs(((TranscricaoAlfabetos.Length) / 2) / RazaoDivisora) != VerificadorDeLoop)
            {
                QtdLoops = Math.Abs(((TranscricaoAlfabetos.Length)/2) / RazaoDivisora) + 1;
            }
            else
            {
                QtdLoops = Math.Abs(((TranscricaoAlfabetos.Length) / 2) / RazaoDivisora);
            }


            for (int j = 0; j < QtdLoops; j++)
            {
                for (int i = 0; i < RazaoDivisora; i++)
                {
                    TranscricaoVertical = TranscricaoVertical + TranscricaoAlfabetos[0, V];
                    V++;

                    if (V > (TranscricaoAlfabetos.Length / 2) - 1) i = RazaoDivisora;
                }
                for (int i = 0; i < RazaoDivisora; i++)
                {
                    TranscricaoVertical = TranscricaoVertical + TranscricaoAlfabetos[1, W];
                    W++;
                    if (W > (TranscricaoAlfabetos.Length / 2) - 1) i = RazaoDivisora;
                }
            }
           
        }

        /// <summary>
        /// RECOMPOSIÇÃO MATRICIAL [2, N] PARA GERAR NOVA COMBINALÃO DE TEXTO JÁ CRIPTOGRAFADO
        /// </summary>
        public void TerceiroPasso()
        {
            Char[] CombinacaoFinal = new char[TranscricaoVertical.Length];

            CombinacaoFinal = TranscricaoVertical.ToCharArray();
            int ContadorHorizontal = 0, ContadorCombinacao = 0;
            StrCombinacaoFinal = new string[2,(TranscricaoVertical.Length/2)];

            for (int i = 0; i < (CombinacaoFinal.Length / 2); i++)
            {
                    StrCombinacaoFinal[0, ContadorHorizontal] = CombinacaoFinal[ContadorCombinacao].ToString();
                    ContadorCombinacao++;
                    StrCombinacaoFinal[1, ContadorHorizontal] = CombinacaoFinal[ContadorCombinacao].ToString();
                    ContadorCombinacao++;
                    ContadorHorizontal++;
            }

        }

        /// <summary>
        /// BUSCA NO ALFABETO PELAS LETRAS DA NOVA MATRIZ FORMADA
        /// </summary>
        public string MensagemCriptografada()
        {
            string MensagemFinal=null;

            for (int i = 0; i < (StrCombinacaoFinal.Length/2); i++)
            {
                MensagemFinal = MensagemFinal + Alfabeto[int.Parse(StrCombinacaoFinal[0, i]), int.Parse(StrCombinacaoFinal[1, i])];
            }

            return MensagemFinal;
        }

    }
}
