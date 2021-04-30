using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ValidaCPF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            ocultarResultado();
        }

        private void limpar()
        {
            // Metodo para limpar a caixa de texto e voltar a escrita;
            txtCPF.Clear(); // Limpa o texto
            txtCPF.Focus(); // Coloca a digitação dentro da caixa;

            ocultarResultado(); // Oculta os textos do resultado;
            
        }

        private void ocultarResultado()
        {
            lblResultado.Visible = false;
            lblCPF.Visible = false;
        }

        private void mostrarResultado()
        {
            lblResultado.Visible = true;
            lblCPF.Visible = true;
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            limpar();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {

            // Captura dos dados na caixa de texto da tela;
            string cpf = txtCPF.Text;

            // Condição para tratar erro na quantidade de digitos do usuário;
            if (cpf.Length != 14)
            {
                MessageBox.Show("Digite 11 números do CPF!");
                limpar();
            }
            else
            {
                // Instanciamento do atributo dentro da classe;
                if (ValidacaoCPF.verificarCPF(cpf))
                {
                    lblCPF.Text = cpf;

                    lblResultado.Text = "CPF Válido!";
                    lblResultado.ForeColor = Color.Blue;

                    mostrarResultado();
                    
                }
                else
                {
                    lblCPF.Text = cpf;

                    lblResultado.Text = "CPF Inválido!";
                    lblResultado.ForeColor = Color.Red;

                    mostrarResultado();
                    
                }
            }

            
        }

        private void txtCPF_Click(object sender, EventArgs e)
        {
            limpar();
        }
    }
}
