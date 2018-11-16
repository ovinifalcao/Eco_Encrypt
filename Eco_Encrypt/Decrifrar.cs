using System;

namespace Eco_Encrypt
{
    /// <summary>
    /// Classe contém os métodos que implementam a mecânica a fim de decifrar, ou desfazer os passos da criptografia préviamente implementada
    /// </summary>
    class Decifrar
    {

        public string CaminhoPasta { get; set; }
        public string[,] AFBtranscricao { private get; set; } = new string[8, 8];
        private string CredFication;
        private string DateFication;
        public string DesconvertidaMesg { get; private set; }
        private int[,] TranscricaoAlfabetos;


        //CONSTRUTORES
        /// <summary>
        /// CONSTRUTOR ESPECIFICO CONSTROI A APLICAÇÃO QUE RODA DESDE O INICIO
        /// </summary>
        /// <param name="credFication">Crednecial disponível no TxtBox realtivo a mesma</param>
        /// <param name="dateFication">Dara disponivel no txtbox relativo a essa informação</param>
        public Decifrar(string credFication, string dateFication)
        {
            CredFication = credFication;
            DateFication = dateFication;
        }

        /// <summary>
        /// CONSTRUTOR VAZIO SE APLICA A CASOS ESPECIFICOS
        /// </summary>
        public Decifrar()
        {
        }


        //PASSOS DA CRIPTOGRAFIA
        /// <summary>
        /// NESSE PASSO A APLICAÇÃO TENTA ENCONTRAR OS VALORES MATRICIAIS DE TODOS OS CARACTERES BASEADO NO ALFABETO FORNECIDO
        /// </summary>
        public void PrimeiroPasso(string TextoOriginal)
        {

            char[] CharPorLetra;

            CharPorLetra = TextoOriginal.ToCharArray();

            int ContadorDeChar = 0, x = 0, y = 0;
            TranscricaoAlfabetos = new int[2, CharPorLetra.Length];

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
        }

        /// <summary>
        /// TRANSCREVE OS VALORES MATRICIAIS ENCONTRADOS PARA FORMATO LINHA
        /// </summary>
        public string SegundoPasso()
        {
            string ValoresLinhaTransc=null;
            for (int i = 0; i < (TranscricaoAlfabetos.Length / 2); i++)
            {
                ValoresLinhaTransc = ValoresLinhaTransc + TranscricaoAlfabetos[0, i].ToString();
                ValoresLinhaTransc = ValoresLinhaTransc + TranscricaoAlfabetos[1, i].ToString();
            }

            return ValoresLinhaTransc;

        }

        /// <summary>
        /// Usa a a credencial para reler o limite considerado como Razão divisora no momento da Encripitação para retorar os valores as posições originais
        /// </summary>
        /// <param name="LinhaDeTextos">Texto que passou metodo da segunda etapa da desencriptação</param>
        public int[,] TerceiroPasso(string LinhaDeTextos)
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

            return TextoPreTranscrit;

        }

        /// <summary>
        /// Torna os valores tranpostos e covertidos para o alfabetoTradicional
        /// </summary>
        /// <param name="CodigoFinal"></param>
        public void PassaFinal(int[,] CodigoFinal)
        {
            //GRAÇAS A DEUS
            string MensagemFinal = null;

            for (int i = 0; i < (CodigoFinal.Length / 2); i++)
            {
                MensagemFinal = MensagemFinal + AFBtranscricao[(CodigoFinal[0, i]), (CodigoFinal[1, i])];
            }

            DesconvertidaMesg = MensagemFinal;

            UtilidadePublica Util = new UtilidadePublica();
            Util.SalvarTxtStream(Util.DialogSalvarEm(UtilidadePublica.TipoDeSalvar.TxtDesencript),true, DesconvertidaMesg);

            GC.Collect();
        }

    }
}
