using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Swarm_Sync_PDV
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void MenuSair_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja Sair do Programa?", "Sair do Programa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void MenuFuncionario_Click(object sender, EventArgs e)
        {
            Cadastro.frmFuncionario frm = new Cadastro.frmFuncionario();
            frm.ShowDialog();
        }

        private void MenuCargo_Click(object sender, EventArgs e)
        {
            Cadastro.frmCargo frm = new Cadastro.frmCargo();
            frm.ShowDialog();
        }

        private void MenuClientes_Click(object sender, EventArgs e)
        {
            Cadastro.Clientes frm = new Cadastro.Clientes();
            frm.ShowDialog();
        }
    }
}
