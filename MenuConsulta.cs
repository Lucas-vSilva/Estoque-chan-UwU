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
    public partial class MenuConsulta : Form
    {
        MySqlConnection conexao;

        public string total;
        public string atualizacao;
        public int validacao = 0;

        public string nomeProduto;
        public string tipoProduto;
        public double valorProduto;
        public int qtdEstoque;
        public MenuConsulta()
        {
            InitializeComponent();
            lstEstoque.AllowColumnReorder = true;
            //cada item vai ser exibido em uma linha separada
            lstEstoque.View = View.Details;
            //clicar em um item seleciona toda a linha
            lstEstoque.FullRowSelect = true;
            //desenha linhas de grade
            lstEstoque.GridLines = true;

            //adiciona dentro do listBox as colunas com nomes, tamanhos e alinhamentos
            lstEstoque.Columns.Add("ID", 50, HorizontalAlignment.Left);
            lstEstoque.Columns.Add("Nome", 100, HorizontalAlignment.Left);
            lstEstoque.Columns.Add("Tipo", 100, HorizontalAlignment.Left);
            lstEstoque.Columns.Add("Valor", 100, HorizontalAlignment.Left);
            lstEstoque.Columns.Add("Quantidade", 100, HorizontalAlignment.Left);

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
        public void ConsultarDados()
        {
            try
            {
                string query = "select * from Estoque where(nomeProduto = " + nomeProduto + ") and (tipoProduto = " + tipoProduto + ") and (valorProduto = " + valorProduto + ") and (qtdEstoque = " + qtdEstoque + ")";

                MySqlCommand comando = new MySqlCommand(query, conexao);

                MySqlDataReader ler = comando.ExecuteReader();

                lstEstoque.Items.Clear();

                while (ler.Read())
                {
                    string[] linha =
                    {
                        ler.GetString(0),
                        ler.GetString(1),
                        ler.GetString(2),
                        ler.GetString(3),
                        ler.GetString(4),
                        ler.GetString(5),
                        ler.GetString(6),
                    };

                    var linha_view = new ListViewItem(linha);

                    lstEstoque.Items.Add(linha_view);
                }//fim do while          

                ler.Close();

            }//fim da consulta ao banco
            catch (Exception e)
            {
                MessageBox.Show("Algo deu errado!\n\n" + e);
            }

        }//fim do método Preencher

        private void MenuConsulta_Load(object sender, EventArgs e)
        {

        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text == "" || txtTipo.Text == "" || txtValor.Text == "" || txtQtd.Text == "")//impede o erro caso o campo esteja vazio
            {
                MessageBox.Show("Preencha todos os campos para realizar a consulta!");
            }
            else
            {
                validacao = 1;


                nomeProduto = txtNome.Text;
                tipoProduto = txtTipo.Text;
                valorProduto = Convert.ToDouble(txtValor.Text);
                qtdEstoque = Convert.ToInt32(txtQtd.Text);

                ConsultarDados();
            }//fim da validação consulta
        }
        private void Deletar()//deleta da base de dados TODA uma linha de acordo com o código
        {
            if (txtNome.Text == "")//impede o erro caso o campo esteja vazio
            {
                MessageBox.Show("Preencha o campo que deseja deletar!");
            }
            else
            {
                string funcao = "delete from Estoque where id =" + txtNome.Text + "";

                MySqlCommand comando = new MySqlCommand(funcao, conexao);

                funcao = "" + comando.ExecuteNonQuery();

                MessageBox.Show("Linha deletada com sucesso", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }//fim da validação 
        }//fim do método deletar linha

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            Deletar();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (validacao == 1)
            {
                var msg = MessageBox.Show("Você tem certeza que deseja realizar essa operação?", "Aviso", MessageBoxButtons.YesNo);

                if (msg == DialogResult.Yes)
                {
                    nomeProduto = txtNome.Text;
                    tipoProduto = txtTipo.Text;//Convert.ToString(cmbMes.SelectedItem);
                    valorProduto = Convert.ToDouble(txtValor.Text);
                    qtdEstoque = Convert.ToInt32(txtQtd.Text);

                    if (nomeProduto == txtNome.Text)
                    {
                        atualizacao = "update Estoque set situacao = '0' where (nomeProduto = " + nomeProduto + ") and (tipoProduto =" + tipoProduto +  ") and (valorProduto =" + valorProduto + "and (qtdEstoque =" + qtdEstoque +")";
                        MySqlCommand atual = new MySqlCommand(atualizacao, conexao);
                        atualizacao = "" + atual.ExecuteNonQuery();
                        MessageBox.Show("Produto atualizado.");
                    }//fim da atualização
                }//fim da ação de atualização em caso positivo
                if (msg == DialogResult.No)
                {
                    MenuConsulta mostrar = new MenuConsulta();
                    mostrar.Show();
                }//fim da ação que encerra o textbox               
            }//fim da condição necessária para atualizar o dado

            lstEstoque.Items.Clear();
            validacao = 0;

        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuEscolha mostrar = new MenuEscolha();
            mostrar.Show();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
