using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Swarm_Sync_PDV.Cadastro
{
    public partial class frmCargo : Form
    {
        Conexao conn = new Conexao();
        string sql;
        SqlCommand cmd;
        string id;
        string cargoAntigo;
        public frmCargo()
        {
            InitializeComponent();
        }

        private void frmCargo_Load(object sender, EventArgs e)
        {
            Listar();
            txtCargo.Enabled = false;
        }

        private void FormatarGD()
        {
            grid.Columns[0].HeaderText = "ID:";
            grid.Columns[1].HeaderText = "Cargo:";
            grid.Columns[0].Visible = false;
        }
        private void Listar()
        {
            conn.AbrirConexao();
            sql = "SELECT * FROM [dbo].[Cargos] ORDER BY NomeCargo ASC";
            cmd = new SqlCommand(sql, conn.conn);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            grid.DataSource = dt;
            conn.FecharConexao();
            FormatarGD();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show("Deseja Realmente excluir o Cargo " +txtCargo.Text+ "?", "Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                conn.AbrirConexao();
                sql = "DELETE FROM cargos WHERE IDCargo = @id";
                cmd = new SqlCommand(sql, conn.conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                conn.FecharConexao();
                Listar();
                MessageBox.Show("Registro Excluido com Sucesso", "Exclusão", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnNovo.Enabled = true;
                btnEditar.Enabled = false;
                btnExcluir.Enabled = false;
                btnSalvar.Enabled = false;
                txtCargo.Enabled = false;
                txtCargo.Clear();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            btnNovo.Enabled = true;
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
            btnSalvar.Enabled = false;
            txtCargo.Enabled = false;
            txtCargo.Clear();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (txtCargo.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Preencha o Campo do Cargo", "Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCargo.Clear();
                txtCargo.Focus();
                return;
            }
            if (txtCargo.Text != cargoAntigo)
            {
                conn.AbrirConexao();
                SqlCommand cmdVerificar;
                cmdVerificar = new SqlCommand("SELECT * FROM [dbo].[Cargos] WHERE NomeCargo = @cargo", conn.conn);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmdVerificar;
                cmdVerificar.Parameters.AddWithValue("@cargo", txtCargo.Text);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conn.FecharConexao();
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("O Cargo " + txtCargo.Text + " ja Esta Registrado", "Cadastro de Cargos", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txtCargo.Clear();
                    txtCargo.Focus();
                    return;
                }
            }

            conn.AbrirConexao();
            sql = "INSERT INTO [dbo].[cargos] (NomeCargo) VALUES (@Cargo);";
            cmd = new SqlCommand(sql, conn.conn);
            cmd.Parameters.AddWithValue("@cargo", txtCargo.Text);

            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                Listar();
                MessageBox.Show("Registro Salvo com Sucesso!", "Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Nenhuma linha inserida.");
            }
            conn.FecharConexao();
            txtCargo.Clear();
            btnNovo.Enabled = true;
            btnSalvar.Enabled = false;
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
            txtCargo.Enabled = false;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (txtCargo.ToString().Trim() == "")
            {
                MessageBox.Show("Preencha o Campo Cargo", "Cadastro Cargo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCargo.Clear();
                return;
            }

            conn.AbrirConexao();

            sql = "UPDATE [dbo].[cargos] SET  NomeCargo = @Cargo WHERE IDcargo = @id;";
            cmd = new SqlCommand(sql, conn.conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@Cargo", txtCargo.Text);
            if (txtCargo.Text == cargoAntigo)
            {
                SqlCommand cmdVerificar;
                cmdVerificar = new SqlCommand("SELECT * FROM [dbo].[Cargos] WHERE NomeCargo = @cargo", conn.conn);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmdVerificar;
                cmdVerificar.Parameters.AddWithValue("@cargo", txtCargo.Text);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("O Cargo " +txtCargo.Text+ " ja Registrado", "Cadastro de Cargos", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txtCargo.Clear();
                    txtCargo.Focus();
                    return;
                }
            }

            int rowsAffected = cmd.ExecuteNonQuery();

            if (rowsAffected > 0)
            {
                Listar();
                MessageBox.Show("Registro Editado com Sucesso!", "Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Nenhuma linha inserida.");
            }
            conn.FecharConexao();
            btnNovo.Enabled = true;
            btnSalvar.Enabled = false;
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
            txtCargo.Clear();
            txtCargo.Enabled = false;

        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            txtCargo.Enabled = true;
            btnSalvar.Enabled = true;
        }

        private void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                btnEditar.Enabled = true;
                btnExcluir.Enabled = true;
                btnSalvar.Enabled = false;
                btnNovo.Enabled = false;
                txtCargo.Enabled=true;
                id = grid.CurrentRow.Cells[0].Value.ToString();
                txtCargo.Text = grid.CurrentRow.Cells[1].Value.ToString();
                cargoAntigo = grid.CurrentRow.Cells[1].Value.ToString();
            }
            else
            {
                return;
            }
        }
    }
}
