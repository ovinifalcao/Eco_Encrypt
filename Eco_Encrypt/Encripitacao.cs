using System;
using System.Windows.Forms;
using System.IO;

namespace Eco_Encrypt
{
    class Encripitacao
    {
        private string Credencial {  get ; set; } 
        private string[,] Alfabeto { get; set; } 
        public string Pass { get; private set; } 

        public Encripitacao(string credencial, string[,] alfabeto)
        {
            Alfabeto = alfabeto;
            Credencial = credencial;
        }

        public void PrimeiroPasso(string TextoComum)
        {
            //AQUI CADA LETRA RECEBE SEU EQUIVALENTE MATRICIAL NO NOVO ALFABETO
            char[] CharPorLetra = null;
            int ContadorDeChar = 0, x = 0, y = 0;
            try
            {
                CharPorLetra = TextoComum.ToCharArray();
                int[,] TranscricaoAlfabetos = new int[2, CharPorLetra.Length];

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

                SegundoPasso(TranscricaoAlfabetos);
            }
            catch (Exception ex)
            {
                MessageBox.Show("O caracter " + CharPorLetra[ContadorDeChar].ToString() + " não consta na referência padrão do Alfabeto Base, Substitua por outro caractere válido. " + ex.ToString(), "Erro no limite do Alfabeto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Form1 AcessoFrmUm = new Form1();
                AcessoFrmUm.EstadoRetorno();
            }

        }

        public void VerificarOTamanho(string TextoComum)
        {

            if (TextoComum.Length < Credencial.Length)
            {
                for (int i = TextoComum.Length; i < Credencial.Length; i++)
                {
                    TextoComum = TextoComum + " ";
                }
            }
            else if ((TextoComum.Length > Credencial.Length)&&((TextoComum.Length % Credencial.Length)!=0))
            {
                int Loops = ((Credencial.Length / 2) - (TextoComum.Length % Credencial.Length));
                

                for (int i = 0; i < Loops; i++)
                {
                    TextoComum = TextoComum + " ";
                }
            }

            PrimeiroPasso(TextoComum);
        }

        public void SegundoPasso(int[,] TxtFromPrimeiroPasso)
        {
            int RazaoDivisora= Math.Abs((Credencial.Length / 2));
            string TranscricaoVertical=null;
            byte V = 0, W = 0;

            int QtdLoops = 0;
            double VerificadorDeLoop = ((TxtFromPrimeiroPasso.Length/2) / RazaoDivisora);
            if (Math.Abs(((TxtFromPrimeiroPasso.Length) / 2) / RazaoDivisora) != VerificadorDeLoop)
            {
                QtdLoops = Math.Abs(((TxtFromPrimeiroPasso.Length)/2) / RazaoDivisora) + 1;
            }
            else
            {
                QtdLoops = Math.Abs(((TxtFromPrimeiroPasso.Length) / 2) / RazaoDivisora);
            }


                for (int j=0; j < QtdLoops; j++)
            {
                for(int i = 0; i < RazaoDivisora; i++)
                {
                    TranscricaoVertical = TranscricaoVertical + TxtFromPrimeiroPasso[0, V];
                    V++;

                    if (V > (TxtFromPrimeiroPasso.Length / 2) - 1) i = RazaoDivisora;
                }
                for (int i = 0; i < RazaoDivisora; i++)
                {
                    TranscricaoVertical = TranscricaoVertical + TxtFromPrimeiroPasso[1, W];
                    W++;
                    if (W > (TxtFromPrimeiroPasso.Length / 2) - 1) i = RazaoDivisora;
                }

            }
            TerceiroPasso(TranscricaoVertical);
        }

        public void TerceiroPasso(string NumeracaoFromSegundoPasso)
        {
            Char[] CombinacaoFinal = new char[NumeracaoFromSegundoPasso.Length];

            CombinacaoFinal = NumeracaoFromSegundoPasso.ToCharArray();
            int ContadorHorizontal = 0, ContadorCombinacao = 0;
            string[,] StrCombinacaoFinal = new string[2,(NumeracaoFromSegundoPasso.Length/2)];

            for (int i = 0; i < (CombinacaoFinal.Length / 2); i++)
            {
                    StrCombinacaoFinal[0, ContadorHorizontal] = CombinacaoFinal[ContadorCombinacao].ToString();
                    ContadorCombinacao++;
                    StrCombinacaoFinal[1, ContadorHorizontal] = CombinacaoFinal[ContadorCombinacao].ToString();
                    ContadorCombinacao++;
                    ContadorHorizontal++;
            }

            MensagemCriptografada(StrCombinacaoFinal);
        }

        public void MensagemCriptografada(string[,] CodigoFinal)
        {
            string MensagemFinal=null;

            for (int i = 0; i < (CodigoFinal.Length/2); i++)
            {
                MensagemFinal = MensagemFinal + Alfabeto[int.Parse(CodigoFinal[0, i]), int.Parse(CodigoFinal[1, i])];
            }

            Pass = MensagemFinal;

        }

    }
}
