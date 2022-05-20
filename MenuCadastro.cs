using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Sorveteria_TI13N
{

    public partial class MenuCadastro : Form
    {
        MySqlConnection conexao;
        public string dados = "";
        public string comando = "";

        public int id = 0;
        public string nomeProduto = "";
        public string tipoProduto = "";
        public double valorProduto = 0;
        public int qtdEstoque = 0;

        public MenuCadastro()
        {
            InitializeComponent();
            conexao = new MySqlConnection("server=localhost;DataBase=SorveteriaTI13N;Uid=root;Password=;");
            try
            {
                conexao.Open();
            }
            catch (Exception e)
            {
                MessageBox.Show("Algo deu errado.\n\n" + e);
                conexao.Close();

            }
        }
        public void Inserir()
        {
            try
            {
                dados = "('','" + nomeProduto + "','" + tipoProduto + "','" + valorProduto + "','" + qtdEstoque + "')";
                comando = "insert into Estoque(id,nomeProduto, tipoProduto, valorProduto, qtdEstoque) values" + dados;
                MySqlCommand sql = new MySqlCommand(comando, conexao);
                comando = "" + sql.ExecuteNonQuery();
                MessageBox.Show("Produto inserido com sucesso.");
            }
            catch (Exception e)
            {
                MessageBox.Show("Algo deu errado!\n\n" + e);
            }
        }//fim do método inserir


        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void MenuCadastro_Load(object sender, EventArgs e)
        {

        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            bool ok = campoVazio();
            if (ok == true)
            {
                MessageBox.Show("Todos os campos são de preenchimento obrigatório!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                nomeProduto = txtProduto.Text;
                tipoProduto = txtTipo.Text;
                valorProduto = Convert.ToDouble(txtValor.Text);
                qtdEstoque = Convert.ToInt32(txtQuantidade.Text);                                                                                                                  

                Inserir();
            }
        }
        private bool campoVazio()
        {
            foreach (Control item in this.Controls)
            {
                if (item is TextBoxBase)
                {
                    var txt = (TextBoxBase)item;
                    if (String.IsNullOrEmpty(txt.Text))
                        return true;
                }
            }//fim da validação de campo nulo

            return false;
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuEscolha mostrar = new MenuEscolha();
            mostrar.Show();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
