using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sorveteria_TI13N
{
    public partial class MenuEscolha : Form
    {
        public MenuEscolha()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnMenuCadastrar_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuCadastro mostrar = new MenuCadastro();
            mostrar.Show();
        }

        private void btnMenuConsultar_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuConsulta mostrar = new MenuConsulta();
            mostrar.Show();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();                       
        }
    }
}
