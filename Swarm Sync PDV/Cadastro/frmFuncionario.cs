using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;


namespace Swarm_Sync_PDV.Cadastro
{
    public partial class frmFuncionario : Form
    {
        Conexao conn = new Conexao();
        string sql;
        SqlCommand cmd;
        string id;
        string cpfAntigo;
        public frmFuncionario()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if(txtNome.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Preencha o campo nome", "Cadastro Funcionarios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNome.Clear();
                txtNome.Focus();
                return;
            }
            if (txtCPF.Text == "   ,   ,   -" || txtCPF.Text.Length < 14)
            {
                MessageBox.Show("Preencha o campo CPF", "Cadastro Funcionarios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCPF.Focus();
                return;
            }
            if (txtTel.Text == "(  )      -" || txtTel.Text.Length < 14)
            {
                MessageBox.Show("Preencha o campo Telefone", "Cadastro Funcionarios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTel.Focus();
                return;
            }
            if (txtCPF.Text != cpfAntigo)
            {
                conn.AbrirConexao();
                SqlCommand cmdVerificar;
                cmdVerificar = new SqlCommand("SELECT * FROM funcionario WHERE CPFFuncionario = @cpf", conn.conn);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmdVerificar;
                cmdVerificar.Parameters.AddWithValue("@cpf", txtCPF.Text);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conn.FecharConexao();
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("CPF ja Registrado", "Cadastro de Funcionario", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txtCPF.Clear();
                    txtCPF.Focus();
                    return;
                }
            }

            conn.AbrirConexao();
            sql = "INSERT INTO [dbo].[funcionario] (NomeFuncionario, CPFFuncionario, TelFuncionario, CargoFuncionario, EnderecoFuncionario, DataRegistro) VALUES (@NomeFuncionario, @CPFFuncionario, @TelFuncionario, @CargoFuncionario, @EnderecoFuncionario, GETDATE());";
            cmd = new SqlCommand(sql, conn.conn);
            cmd.Parameters.AddWithValue("@NomeFuncionario", txtNome.Text);
            cmd.Parameters.AddWithValue("CPFFuncionario", txtCPF.Text);
            cmd.Parameters.AddWithValue("@TelFuncionario", txtTel.Text);
            cmd.Parameters.AddWithValue("@CargoFuncionario", cbCargo.Text);
            cmd.Parameters.AddWithValue("@EnderecoFuncionario", txtEnde.Text);

            int rowsAffected = cmd.ExecuteNonQuery();

            if (rowsAffected > 0)
            {
                Listar();
                MessageBox.Show("Registro Salvo com Sucesso!", "Cadastro Funcionario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnNovo.Enabled = true;
                btnSalvar.Enabled = false;
                btnEditar.Enabled = false;
                btnExcluir.Enabled = false;
            }
            else
            {
                MessageBox.Show("Nenhuma linha inserida.");
            }
            LimparCampos();
            DesabilitarCampos();
            conn.FecharConexao();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            habilitarCampos();
            LimparCampos();
            txtNome.Focus();
        }
        private void habilitarCampos()
        {
            btnSalvar.Enabled = true;
            txtNome.Enabled = true;
            txtCPF.Enabled = true;
            txtTel.Enabled = true;
            txtEnde.Enabled = true;
            cbCargo.Enabled = true;
            btnNovo.Enabled = false;
        }
        private void LimparCampos()
        {
            txtNome.Clear();
            txtCPF.Clear();
            txtTel.Clear();
            txtEnde.Clear();
            cbCargo.Text = "";
        }
        private void DesabilitarCampos()
        {
            txtNome.Enabled=false;
            txtCPF.Enabled=false;
            txtTel.Enabled=false;
            txtEnde.Enabled=false;
            cbCargo.Enabled=false;
        }
        private void Listar() 
        {
            conn.AbrirConexao();
            sql = "SELECT * FROM [dbo].[funcionario] ORDER BY NomeFuncionario ASC";
            cmd = new SqlCommand(sql, conn.conn);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            grid.DataSource = dt;
            conn.FecharConexao();

            FormatarGD();
        }

        private void frmFuncionario_Load(object sender, EventArgs e)
        {
            Listar();
            ListarCargos();
            cbCargo.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private void FormatarGD()
        {
            grid.Columns[0].HeaderText = "ID:";
            grid.Columns[1].HeaderText = "Colaborador:";
            grid.Columns[2].HeaderText = "CPF:";
            grid.Columns[3].HeaderText = "Tel:";
            grid.Columns[4].HeaderText = "Cargo:";
            grid.Columns[5].HeaderText = "Endereço:";
            grid.Columns[6].HeaderText = "Data:";

            grid.Columns[0].Width = 50;
            grid.Columns[6].Width = 50;
            grid.Columns[0].Visible = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            btnNovo.Enabled = true;
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
            btnSalvar.Enabled = false;
            DesabilitarCampos();
            LimparCampos();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show("Deseja Realmente excluir o registro do Funcionario " +txtNome.Text+ "?", "Cadastro Funcionario", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                conn.AbrirConexao();
                sql = "DELETE FROM funcionario WHERE IDFuncionario = @id";
                cmd = new SqlCommand(sql, conn.conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                conn.FecharConexao();
                Listar();
                MessageBox.Show("Registro Excluido com Sucesso", "Cadastro Funcionarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnNovo.Enabled=true;
                btnEditar.Enabled=false;
                btnExcluir.Enabled=false;
                btnSalvar.Enabled=false;
                DesabilitarCampos();
                LimparCampos();
            }
        }

        private void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                habilitarCampos();
                btnEditar.Enabled = true;
                btnExcluir.Enabled = true;
                btnSalvar.Enabled = false;
                btnNovo.Enabled = false;
                id = grid.CurrentRow.Cells[0].Value.ToString();
                txtNome.Text = grid.CurrentRow.Cells[1].Value.ToString();
                txtCPF.Text = grid.CurrentRow.Cells[2].Value.ToString();
                cpfAntigo = grid.CurrentRow.Cells[2].Value.ToString();
                txtTel.Text = grid.CurrentRow.Cells[3].Value.ToString();
                cbCargo.Text = grid.CurrentRow.Cells[4].Value.ToString();
                txtEnde.Text = grid.CurrentRow.Cells[5].Value.ToString();
            }
            else
            {
                return;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (txtNome.ToString().Trim() == "")
            {
                MessageBox.Show("Preencha o Campo Nome", "Cadastro Funcionario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNome.Clear();
                return;
            }
            if (txtCPF.Text == "   ,   ,   -" || txtCPF.Text.Length < 14)
            {
                MessageBox.Show("Preencha o campo CPF", "Cadastro Funcionarios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCPF.Focus();
                return;
            }
            if (txtTel.Text == "(  )      -" || txtTel.Text.Length < 14)
            {
                MessageBox.Show("Preencha o campo Telefone", "Cadastro Funcionarios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCPF.Focus();
                return;
            }
            conn.AbrirConexao();

            sql = "UPDATE [dbo].[funcionario] SET NomeFuncionario = @NomeFuncionario, CPFFuncionario = @CPFFuncionario, TelFuncionario = @TelFuncionario, CargoFuncionario = @CargoFuncionario, EnderecoFuncionario = @EnderecoFuncionario WHERE IDFuncionario = @id;";
            cmd = new SqlCommand(sql, conn.conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@NomeFuncionario", txtNome.Text);
            cmd.Parameters.AddWithValue("CPFFuncionario", txtCPF.Text);
            cmd.Parameters.AddWithValue("@TelFuncionario", txtTel.Text);
            cmd.Parameters.AddWithValue("@CargoFuncionario", cbCargo.Text);
            cmd.Parameters.AddWithValue("@EnderecoFuncionario", txtEnde.Text);

            if (txtCPF.Text != cpfAntigo)
            {
                SqlCommand cmdVerificar;
                cmdVerificar = new SqlCommand("SELECT * FROM funcionario WHERE CPFFuncionario = @cpf", conn.conn);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmdVerificar;
                cmdVerificar.Parameters.AddWithValue("@cpf", txtCPF.Text);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("CPF ja Registrado", "Cadastro de Funcionario", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txtCPF.Clear();
                    txtCPF.Focus();
                    return;
                }
            }
            int rowsAffected = cmd.ExecuteNonQuery();

            if (rowsAffected > 0)
            {
                Listar();
                MessageBox.Show("Registro Editado com Sucesso!", "Cadastro Funcionario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnNovo.Enabled = true;
                btnSalvar.Enabled = false;
                btnEditar.Enabled = false;
                btnExcluir.Enabled = false;
            }
            else
            {
                MessageBox.Show("Nenhuma linha inserida.");
            }
            conn.FecharConexao();
            LimparCampos();
            DesabilitarCampos();
        }
        private void ListarCargos()
        {
            conn.AbrirConexao();
            sql = "SELECT * FROM cargos ORDER BY NomeCargo ASC";
            cmd = new SqlCommand(sql, conn.conn);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            cbCargo.DataSource = dt;
            //cbCargo.ValueMember = "id";
            cbCargo.DisplayMember = "NomeCargo";
            conn.FecharConexao();
        }
    }
}
