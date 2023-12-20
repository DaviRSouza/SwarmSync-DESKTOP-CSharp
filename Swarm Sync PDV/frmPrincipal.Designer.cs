namespace Swarm_Sync_PDV
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.MenuPrincipal = new System.Windows.Forms.MenuStrip();
            this.MenuCadastro = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFuncionario = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuClientes = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuCargo = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFornecedor = new System.Windows.Forms.ToolStripMenuItem();
            this.ProdutosMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuProdutos = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuEstoque = new System.Windows.Forms.ToolStripMenuItem();
            this.movimentaçõesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFluxoCaixa = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuLancarVendas = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuEntradasSaidas = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuDespesas = new System.Windows.Forms.ToolStripMenuItem();
            this.relatorioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuProdutosRel = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuVendas = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuMovimentacao = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuEntradasSaidasRel = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuDespesasRel = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuSair = new System.Windows.Forms.ToolStripMenuItem();
            this.Img04 = new System.Windows.Forms.PictureBox();
            this.Img03 = new System.Windows.Forms.PictureBox();
            this.img02 = new System.Windows.Forms.PictureBox();
            this.Img01 = new System.Windows.Forms.PictureBox();
            this.MenuPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Img04)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Img03)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.img02)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Img01)).BeginInit();
            this.SuspendLayout();
            // 
            // MenuPrincipal
            // 
            this.MenuPrincipal.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuCadastro,
            this.ProdutosMenu,
            this.movimentaçõesToolStripMenuItem,
            this.relatorioToolStripMenuItem,
            this.MenuSair});
            this.MenuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.MenuPrincipal.Name = "MenuPrincipal";
            this.MenuPrincipal.Padding = new System.Windows.Forms.Padding(13, 3, 0, 3);
            this.MenuPrincipal.Size = new System.Drawing.Size(1190, 30);
            this.MenuPrincipal.TabIndex = 0;
            this.MenuPrincipal.Text = "menuStrip1";
            // 
            // MenuCadastro
            // 
            this.MenuCadastro.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuFuncionario,
            this.MenuClientes,
            this.MenuUsuarios,
            this.MenuCargo,
            this.MenuFornecedor});
            this.MenuCadastro.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuCadastro.Name = "MenuCadastro";
            this.MenuCadastro.Size = new System.Drawing.Size(91, 24);
            this.MenuCadastro.Text = "Cadastro";
            // 
            // MenuFuncionario
            // 
            this.MenuFuncionario.Name = "MenuFuncionario";
            this.MenuFuncionario.Size = new System.Drawing.Size(224, 26);
            this.MenuFuncionario.Text = "Funcionarios";
            this.MenuFuncionario.Click += new System.EventHandler(this.MenuFuncionario_Click);
            // 
            // MenuClientes
            // 
            this.MenuClientes.Name = "MenuClientes";
            this.MenuClientes.Size = new System.Drawing.Size(224, 26);
            this.MenuClientes.Text = "Clientes";
            this.MenuClientes.Click += new System.EventHandler(this.MenuClientes_Click);
            // 
            // MenuUsuarios
            // 
            this.MenuUsuarios.Name = "MenuUsuarios";
            this.MenuUsuarios.Size = new System.Drawing.Size(224, 26);
            this.MenuUsuarios.Text = "Usuarios";
            // 
            // MenuCargo
            // 
            this.MenuCargo.Name = "MenuCargo";
            this.MenuCargo.Size = new System.Drawing.Size(224, 26);
            this.MenuCargo.Text = "Cargos";
            this.MenuCargo.Click += new System.EventHandler(this.MenuCargo_Click);
            // 
            // MenuFornecedor
            // 
            this.MenuFornecedor.Name = "MenuFornecedor";
            this.MenuFornecedor.Size = new System.Drawing.Size(224, 26);
            this.MenuFornecedor.Text = "Fornecedor";
            // 
            // ProdutosMenu
            // 
            this.ProdutosMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuProdutos,
            this.MenuEstoque});
            this.ProdutosMenu.Name = "ProdutosMenu";
            this.ProdutosMenu.Size = new System.Drawing.Size(82, 24);
            this.ProdutosMenu.Text = "Produtos";
            // 
            // MenuProdutos
            // 
            this.MenuProdutos.Name = "MenuProdutos";
            this.MenuProdutos.Size = new System.Drawing.Size(151, 26);
            this.MenuProdutos.Text = "Produtos";
            // 
            // MenuEstoque
            // 
            this.MenuEstoque.Name = "MenuEstoque";
            this.MenuEstoque.Size = new System.Drawing.Size(151, 26);
            this.MenuEstoque.Text = "Estoque";
            // 
            // movimentaçõesToolStripMenuItem
            // 
            this.movimentaçõesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuFluxoCaixa,
            this.MenuLancarVendas,
            this.MenuEntradasSaidas,
            this.MenuDespesas});
            this.movimentaçõesToolStripMenuItem.Name = "movimentaçõesToolStripMenuItem";
            this.movimentaçõesToolStripMenuItem.Size = new System.Drawing.Size(128, 24);
            this.movimentaçõesToolStripMenuItem.Text = "Movimentações";
            // 
            // MenuFluxoCaixa
            // 
            this.MenuFluxoCaixa.Name = "MenuFluxoCaixa";
            this.MenuFluxoCaixa.Size = new System.Drawing.Size(198, 26);
            this.MenuFluxoCaixa.Text = "Fluxo Caixa";
            // 
            // MenuLancarVendas
            // 
            this.MenuLancarVendas.Name = "MenuLancarVendas";
            this.MenuLancarVendas.Size = new System.Drawing.Size(198, 26);
            this.MenuLancarVendas.Text = "Lançar Venda";
            // 
            // MenuEntradasSaidas
            // 
            this.MenuEntradasSaidas.Name = "MenuEntradasSaidas";
            this.MenuEntradasSaidas.Size = new System.Drawing.Size(198, 26);
            this.MenuEntradasSaidas.Text = "Entradas/Saidas";
            // 
            // MenuDespesas
            // 
            this.MenuDespesas.Name = "MenuDespesas";
            this.MenuDespesas.Size = new System.Drawing.Size(198, 26);
            this.MenuDespesas.Text = "Despesas";
            // 
            // relatorioToolStripMenuItem
            // 
            this.relatorioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuProdutosRel,
            this.MenuVendas,
            this.MenuMovimentacao,
            this.MenuEntradasSaidasRel,
            this.MenuDespesasRel});
            this.relatorioToolStripMenuItem.Name = "relatorioToolStripMenuItem";
            this.relatorioToolStripMenuItem.Size = new System.Drawing.Size(84, 24);
            this.relatorioToolStripMenuItem.Text = "Relatorio";
            // 
            // MenuProdutosRel
            // 
            this.MenuProdutosRel.Name = "MenuProdutosRel";
            this.MenuProdutosRel.Size = new System.Drawing.Size(206, 26);
            this.MenuProdutosRel.Text = "Produtos";
            // 
            // MenuVendas
            // 
            this.MenuVendas.Name = "MenuVendas";
            this.MenuVendas.Size = new System.Drawing.Size(206, 26);
            this.MenuVendas.Text = "Vendas";
            // 
            // MenuMovimentacao
            // 
            this.MenuMovimentacao.Name = "MenuMovimentacao";
            this.MenuMovimentacao.Size = new System.Drawing.Size(206, 26);
            this.MenuMovimentacao.Text = "Movimentação";
            // 
            // MenuEntradasSaidasRel
            // 
            this.MenuEntradasSaidasRel.Name = "MenuEntradasSaidasRel";
            this.MenuEntradasSaidasRel.Size = new System.Drawing.Size(206, 26);
            this.MenuEntradasSaidasRel.Text = "Entradas / Saidas";
            // 
            // MenuDespesasRel
            // 
            this.MenuDespesasRel.Name = "MenuDespesasRel";
            this.MenuDespesasRel.Size = new System.Drawing.Size(206, 26);
            this.MenuDespesasRel.Text = "Despesas";
            // 
            // MenuSair
            // 
            this.MenuSair.Name = "MenuSair";
            this.MenuSair.Size = new System.Drawing.Size(48, 24);
            this.MenuSair.Text = "Sair";
            this.MenuSair.Click += new System.EventHandler(this.MenuSair_Click);
            // 
            // Img04
            // 
            this.Img04.Image = global::Swarm_Sync_PDV.Properties.Resources.carrinho_de_compras;
            this.Img04.Location = new System.Drawing.Point(676, 375);
            this.Img04.Name = "Img04";
            this.Img04.Size = new System.Drawing.Size(325, 243);
            this.Img04.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Img04.TabIndex = 4;
            this.Img04.TabStop = false;
            // 
            // Img03
            // 
            this.Img03.Image = global::Swarm_Sync_PDV.Properties.Resources.carrinho_de_supermercado;
            this.Img03.Location = new System.Drawing.Point(271, 375);
            this.Img03.Name = "Img03";
            this.Img03.Size = new System.Drawing.Size(325, 243);
            this.Img03.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Img03.TabIndex = 3;
            this.Img03.TabStop = false;
            // 
            // img02
            // 
            this.img02.Image = global::Swarm_Sync_PDV.Properties.Resources.dolar;
            this.img02.Location = new System.Drawing.Point(676, 86);
            this.img02.Name = "img02";
            this.img02.Size = new System.Drawing.Size(325, 243);
            this.img02.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.img02.TabIndex = 2;
            this.img02.TabStop = false;
            // 
            // Img01
            // 
            this.Img01.Image = global::Swarm_Sync_PDV.Properties.Resources.carrinho_de_supermercado;
            this.Img01.Location = new System.Drawing.Point(271, 86);
            this.Img01.Name = "Img01";
            this.Img01.Size = new System.Drawing.Size(325, 243);
            this.Img01.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Img01.TabIndex = 1;
            this.Img01.TabStop = false;
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(84)))), ((int)(((byte)(92)))));
            this.ClientSize = new System.Drawing.Size(1190, 653);
            this.Controls.Add(this.Img04);
            this.Controls.Add(this.Img03);
            this.Controls.Add(this.img02);
            this.Controls.Add(this.Img01);
            this.Controls.Add(this.MenuPrincipal);
            this.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MenuPrincipal;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frmPrincipal";
            this.Text = "Swarm Sync PDV";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.MenuPrincipal.ResumeLayout(false);
            this.MenuPrincipal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Img04)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Img03)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.img02)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Img01)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuPrincipal;
        private System.Windows.Forms.ToolStripMenuItem MenuCadastro;
        private System.Windows.Forms.ToolStripMenuItem ProdutosMenu;
        private System.Windows.Forms.ToolStripMenuItem movimentaçõesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem relatorioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuSair;
        private System.Windows.Forms.PictureBox Img01;
        private System.Windows.Forms.PictureBox img02;
        private System.Windows.Forms.PictureBox Img03;
        private System.Windows.Forms.PictureBox Img04;
        private System.Windows.Forms.ToolStripMenuItem MenuFuncionario;
        private System.Windows.Forms.ToolStripMenuItem MenuClientes;
        private System.Windows.Forms.ToolStripMenuItem MenuUsuarios;
        private System.Windows.Forms.ToolStripMenuItem MenuCargo;
        private System.Windows.Forms.ToolStripMenuItem MenuFornecedor;
        private System.Windows.Forms.ToolStripMenuItem MenuProdutos;
        private System.Windows.Forms.ToolStripMenuItem MenuEstoque;
        private System.Windows.Forms.ToolStripMenuItem MenuFluxoCaixa;
        private System.Windows.Forms.ToolStripMenuItem MenuLancarVendas;
        private System.Windows.Forms.ToolStripMenuItem MenuEntradasSaidas;
        private System.Windows.Forms.ToolStripMenuItem MenuDespesas;
        private System.Windows.Forms.ToolStripMenuItem MenuProdutosRel;
        private System.Windows.Forms.ToolStripMenuItem MenuVendas;
        private System.Windows.Forms.ToolStripMenuItem MenuMovimentacao;
        private System.Windows.Forms.ToolStripMenuItem MenuEntradasSaidasRel;
        private System.Windows.Forms.ToolStripMenuItem MenuDespesasRel;
    }
}

