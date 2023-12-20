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
    public partial class Clientes : Form
    {
        Conexao conn = new Conexao();
        string sql;
        SqlCommand cmd;

        string id;
        string cpf;
        string desbloquead, inadiplente;
        bool emailAdress = false;
        int codCliente, IaAnterior;

        private void FormataGD()
        {
            grid.Columns[0].HeaderText = "ID:";
            grid.Columns[1].HeaderText = "Cod:";
            grid.Columns[2].HeaderText = "Nome:";
            grid.Columns[3].HeaderText = "CPF:";
            grid.Columns[4].HeaderText = "Valor Aberto:";
            grid.Columns[5].HeaderText = "Telefone:";
            grid.Columns[6].HeaderText = "Situação:";
            grid.Columns[7].HeaderText = "inadiplente?";
            grid.Columns[8].HeaderText = "Endereço:";
            grid.Columns[9].HeaderText = "Funcionario";
            grid.Columns[10].HeaderText = "Data";

            grid.Columns[0].Width = 50;
            grid.Columns[0].Visible = false;
        }

        private void Listar()
        {
            conn.AbrirConexao();
            sql = "SELECT * FROM Clientes ORDER BY NomeCliente ASC;";
            cmd = new SqlCommand(sql, conn.conn);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            grid.DataSource = dt;
            conn.FecharConexao();
            FormataGD();
        }

        private void BuscarNome()
        {
            conn.AbrirConexao();
            sql = "SELECT * FROM [dbo].[Clientes] WHERE NomeCliente LIKE @nome ORDER BY NomeCliente ASC";
            cmd = new SqlCommand (sql, conn.conn);
            cmd.Parameters.AddWithValue("@nome", txtBuscarNome.Text + "%");
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            grid.DataSource = dt;
            conn.FecharConexao();
            FormataGD();
        }

        private void BuscarCPF()
        {
            conn.AbrirConexao();
            sql = "SELECT * FROM Clientes WHERE CPFCliente = @cpf ORDER BY NomeCliente ASC;";
            cmd = new SqlCommand(sql, conn.conn);
            cmd.Parameters.AddWithValue("@cpf", txtBuscarCPF.Text);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            grid.DataSource = dt;
            conn.FecharConexao();
        }
        private void HabilitarCampos()
        {
            txtNome.Enabled = true;
            txtCPF.Enabled = true;
            txtTel.Enabled = true;
            txtEmail.Enabled = true;
            cbInadiplente.Enabled = true;
            txtValor.Enabled = true;
            txtNome.Focus();
        }

        private void DesabilitarCampos()
        {
            txtNome.Enabled = false;
            txtCPF.Enabled = false;
            txtTel.Enabled = false;
            txtEmail.Enabled = false;
            cbInadiplente.Enabled = false;
            txtValor.Enabled = false;
        }

        private void LimparCampos()
        {
            txtNome.Clear();
            txtCPF.Clear();
            txtTel.Clear();
            txtEmail.Clear();
            txtValor.Clear();
        }

        private void txtBuscarNome_TextChanged(object sender, EventArgs e)
        {
            BuscarNome();
        }

        private void txtBuscarCPF_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            BuscarCPF();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text.ToString().Trim() == "")
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
            if (true)
            {
                conn.AbrirConexao();
                SqlCommand cmdVerificar;
                cmdVerificar = new SqlCommand("SELECT * FROM funcionario WHERE CPFCliente = @cpf", conn.conn);
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
            sql = "INSERT INTO [dbo].[Clientes] (IDCliente, CodigoCliente, NomeCliente, CPFCliente, ValorAberto, TelCliente, EndeCliente, DataCliente) VALUES (@Cod, @nome, @CPF, @valor, @Tel, @Endereco, GETDATE());";
            cmd = new SqlCommand(sql, conn.conn);
            cmd.Parameters.AddWithValue("@nome", txtNome.Text);
            cmd.Parameters.AddWithValue("@CPF", txtCPF.Text);
            cmd.Parameters.AddWithValue("@Cod", txtCodigo.Text);
            cmd.Parameters.AddWithValue("@Endereco", txtEnde.Text);
            cmd.Parameters.AddWithValue("@valor", txtValor.Text);
            cmd.Parameters.AddWithValue("@Tel", txtTel.Text);

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

        private void Clientes_Load(object sender, EventArgs e)
        {
            Listar();
            txtBuscarCPF.Enabled=true;
            txtBuscarNome.Enabled=true;
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

            sql = "UPDATE [dbo].[Clientes]\r\nSET NomeCliente = @nome, CPFCliente = @CPF, ValorAberto = @valor, TelCliente = @Tel, EndeCliente = @Endereco, DataCliente = GETDATE() WHERE IDCliente = @ID;";
            cmd = new SqlCommand(sql, conn.conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@nome", txtNome.Text);
            cmd.Parameters.AddWithValue("@CPF", txtCPF.Text);
            cmd.Parameters.AddWithValue("@Cod", txtCodigo.Text);
            cmd.Parameters.AddWithValue("@Endereco", txtEnde.Text);
            cmd.Parameters.AddWithValue("@valor", txtValor.Text);
            cmd.Parameters.AddWithValue("@Tel", txtTel.Text);

            if (true)
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

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show("Deseja Realmente excluir o registro do Funcionario " + txtNome.Text + "?", "Cadastro Funcionario", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                conn.AbrirConexao();
                sql = "DELETE FROM clientes WHERE IDCliente = @id";
                cmd = new SqlCommand(sql, conn.conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                conn.FecharConexao();
                Listar();
                MessageBox.Show("Registro Excluido com Sucesso", "Cadastro Funcionarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnNovo.Enabled = true;
                btnEditar.Enabled = false;
                btnExcluir.Enabled = false;
                btnSalvar.Enabled = false;
                DesabilitarCampos();
                LimparCampos();
            }
        }

        private void grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                HabilitarCampos();
                btnEditar.Enabled = true;
                btnExcluir.Enabled = true;
                btnSalvar.Enabled = false;
                btnNovo.Enabled = false;
                id = grid.CurrentRow.Cells[0].Value.ToString();
                txtNome.Text = grid.CurrentRow.Cells[1].Value.ToString();
                txtCPF.Text = grid.CurrentRow.Cells[2].Value.ToString();
                txtTel.Text = grid.CurrentRow.Cells[3].Value.ToString();
                txtEnde.Text = grid.CurrentRow.Cells[5].Value.ToString();
            }
            else
            {
                return;
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            HabilitarCampos();
            LimparCampos();
            btnSalvar.Enabled = true;
            btnNovo.Enabled = false;
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
        }

        public Clientes()
        {
            InitializeComponent();
        }
    }
}
