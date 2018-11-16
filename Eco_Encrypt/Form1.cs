using System;
using System.Windows.Forms;

/// <summary>
/// Eco_Encrypt namespace contém toda solução em sua diversidade com forms e métodos agrupados em suas respctivas classes
/// </summary>
namespace Eco_Encrypt
{
    /// <summary>
    /// Fomulário de apresentação inicial a primeira tela
    /// </summary>
    /// <remarks>
    /// Este form trabalha com Panel por isso alguns objetos são inacessíveis em seus estados em determinados momentos durante a execução.
    /// </remarks>
    public partial class Form1 : Form
    {
        Encripitacao EncriptaTexto;

        //CONSTRUTORRE DO FORM

        /// <summary>
        /// Construtor padrão para objeto da classe Forms
        /// </summary>
        public Form1() => InitializeComponent();

        /// <summary>
        /// Evtento de Leitura do Form.
        /// </summary>
        /// <remarks>
        /// Neste contexto é responsávle por determinar o estado da tela em relação a visibilidade de alguns objetos e dar a data inicial para o campo "Que dia é Hoje?"
        /// </remarks>
        private void LerOForm(object sender, EventArgs e)
        {
            TxbData.Text = DateTime.Today.ToShortDateString();
            EstadoOpening();
        }



        //AÇÕES DE BOTÕES
        /// <summary>
        /// Evento de clique no Botão de entrada.
        /// </summary>
        ///<remarks>
        ///Altera a composição de objetos visíveis do form.
        ///Gera uma alfabeto aleatório.
        ///Trata exceções para casos em que os TxtBoxes são vazios.
        ///</remarks>
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

        /// <summary>
        /// Evento do clique no botão Enviar
        /// </summary>
        /// <remarks>
        /// Apenas visível após a ação do botão ENTRAR
        /// Trabalha diretamente sobre o texto para gerar o valor encriptado
        /// </remarks>
        private void btEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(TxbMensagem.Text)) { throw new Exception("Não é possível gerar um texto Ecrypta partindo de um texto nulo ou inválido"); }
                else
                {
                    UtilidadePublica Util = new UtilidadePublica(TxbData.Text, TxbCredencial.Text.ToLower());

                    EncriptaTexto.PrimeiroPasso(Util.RemoverEspacos(EncriptaTexto.VerificarOTamanho(TxbMensagem.Text.ToLower())));
                    EncriptaTexto.SegundoPasso();
                    EncriptaTexto.TerceiroPasso();

                    Util.SalvarTxtStream(Util.DialogSalvarEm(UtilidadePublica.TipoDeSalvar.TxtEncriptado), 1, true, EncriptaTexto.MensagemCriptografada());

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Um erro ocorreu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Chama o Form que da as diretrizes para a Transcrição
        /// </summary>
        private void btnDecifrar_Click(object sender, EventArgs e)
        {
            TxbMensagem.Text = null;
            frm_ConfirmaDecrypt Confirmacao = new frm_ConfirmaDecrypt();
            Confirmacao.Show();
        }

        /// <summary>
        /// Propõe um estado de retorno ao form Inicial
        /// </summary>
        private void btnVoltar_Click(object sender, EventArgs e)
        {
            EstadoRetorno();
        }



        //MUNDAÇA DE ESTADO DO PANEL
        /// <summary>
        /// Estado de abertura do form1, seu estado primário no que diz sobre a visibildade das variáveis
        /// </summary>
        public void EstadoOpening()
        {
            TxbMensagem.Visible = false;
            picMensagem.Visible = false;
            PanelEncrypt.Height = 110;
            picLogo2.Visible = false;
        }

        /// <summary>
        /// Estado de encriptação do form1, diz respeito a visibilidade dos objetos.
        /// </summary>
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

        /// <summary>
        /// Retorna o programa ao estado inicial, diz respeito a visibilidade dos objetos.
        /// </summary>
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
