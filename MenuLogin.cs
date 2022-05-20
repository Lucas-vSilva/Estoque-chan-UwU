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
    public partial class MenuLogin : Form
    {
        MySqlConnection conexao;

        public long usuario;
        public string senha;
        public string nome;

        public string dados;
        public string comando;
        public long CPF;

        public MenuLogin()
        {
            InitializeComponent();
        }
        private void verificarAcesso()
        {
            conexao = new MySqlConnection("server=localhost;DataBase=SorveteriaTI13N;Uid=root;Password=;");
            try
            {
                conexao.Open();
            }
            catch (Exception e)
            {
                MessageBox.Show("Algo deu errado.\n\n" + e);
                conexao.Close();
            }//fim da conexão

            try
            {
                string verficarUsuario = "SELECT * FROM Login WHERE(usuario ='" + usuario + "') and (senha='" + senha + "')";
                MySqlCommand comando = new MySqlCommand(verficarUsuario, conexao);
                MySqlDataReader ler = comando.ExecuteReader();

                if (ler.HasRows)
                {
                    this.Visible = false;
                    MenuEscolha mostrar = new MenuEscolha();
                    mostrar.Show();
                }
                else
                {
                    MessageBox.Show("Usuário ou senha inválidos.");
                }

                ler.Close();

            }
            catch (Exception e)
            {
                MessageBox.Show("Algo deu errado. \n\n" + e);
            }//fim do try/catch
        }//fim do método de verificação

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if ((txtUser.Text == "") || (txtPasswd.Text == ""))
            {
                MessageBox.Show("Preencha todos os campos para acessar o sistema!");
            }

            else
            {
                usuario = Convert.ToInt64(txtUser.Text);
                senha = txtPasswd.Text;
                verificarAcesso();
            }
        }//fim da validação 

        private void btnCadastro_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuCriarLogin mostrar = new MenuCriarLogin();
            mostrar.Show();
        }

        private void BtnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MenuLogin_Load(object sender, EventArgs e)
        {

        }
    }//fim do botão acessar

}//fim do projeto