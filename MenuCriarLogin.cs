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
    public partial class MenuCriarLogin : Form
    {
        MySqlConnection conexao;

        public string dados;
        public string comando;
        public long CPF;
        public MenuCriarLogin()
        {
            InitializeComponent();
            conexao = new MySqlConnection("server=localhost;DataBase=SorveteriaTI13N;Uid=root;password=;");
            try
            {
                conexao.Open();
            }
            catch (Exception e)
            {
                MessageBox.Show("Algo deu errado.\n\n" + e);
                conexao.Close();
            }//fim da conexão
        }
        private void CadastroLogin()
        {
            try
            {
                dados = "('" + CPF + "','" + txtNome.Text + "','" + txtSenha.Text + "')";

                comando = "INSERT INTO Login(CPF, usuario, senha) values" + dados;

                MySqlCommand sql = new MySqlCommand(comando, conexao);
                comando = "" + sql.ExecuteNonQuery();
                MessageBox.Show("Cadastro de usuário realizado!");
            }
            catch (Exception e)
            {
                MessageBox.Show("Algo deu errado." + e);
            }//fim do try catch
        }//fim do método cadastroLogin


        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void MenuCriarLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnCriar_Click(object sender, EventArgs e)
        {
            if (txtSenha.Text == "" || txtSenha2.Text == "" || txtNome.Text == "" || txtCpf.Text == "")
            {
                MessageBox.Show("Preencha todos os campos!");
            }
            else
            {
              
                if (Convert.ToInt64(txtCpf.Text) < 10000000000)
                {
                    MessageBox.Show("Preencha o campo CPF com todos os digitos!");
                }
                else
                {
                    if (txtSenha.Text == txtSenha2.Text)
                    {
                        CPF = Convert.ToInt64(this.txtCpf.Text);
                        CadastroLogin();
                    }
                    else
                    {
                        MessageBox.Show("As senhas não coincidem.");
                    }
                }//fim da validação de campo CPF incompleto

                txtNome.Text = "";
                txtCpf.Text = "";
                txtSenha.Text = "";
                txtSenha2.Text = "";

            } 
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuLogin mostrar = new MenuLogin();
            mostrar.Show();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
