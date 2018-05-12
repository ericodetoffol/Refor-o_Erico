namespace DonaLaura.Apresentacao.Funcionalidades.VendaModulo
{
    partial class CadastroVendaDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNomeCliente = new System.Windows.Forms.TextBox();
            this.nudQuantidade = new System.Windows.Forms.NumericUpDown();
            this.cbxNomeProduto = new System.Windows.Forms.ComboBox();
            this.btnSalvarVenda = new System.Windows.Forms.Button();
            this.btnCancelarVenda = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantidade)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome Produto:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nome Cliente:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Quantidade:";
            // 
            // txtNomeCliente
            // 
            this.txtNomeCliente.Location = new System.Drawing.Point(96, 29);
            this.txtNomeCliente.Name = "txtNomeCliente";
            this.txtNomeCliente.Size = new System.Drawing.Size(221, 20);
            this.txtNomeCliente.TabIndex = 4;
            // 
            // nudQuantidade
            // 
            this.nudQuantidade.Location = new System.Drawing.Point(96, 55);
            this.nudQuantidade.Name = "nudQuantidade";
            this.nudQuantidade.Size = new System.Drawing.Size(70, 20);
            this.nudQuantidade.TabIndex = 5;
            // 
            // cbxNomeProduto
            // 
            this.cbxNomeProduto.FormattingEnabled = true;
            this.cbxNomeProduto.Location = new System.Drawing.Point(95, 4);
            this.cbxNomeProduto.Name = "cbxNomeProduto";
            this.cbxNomeProduto.Size = new System.Drawing.Size(222, 21);
            this.cbxNomeProduto.TabIndex = 6;
            // 
            // btnSalvarVenda
            // 
            this.btnSalvarVenda.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSalvarVenda.Location = new System.Drawing.Point(187, 55);
            this.btnSalvarVenda.Name = "btnSalvarVenda";
            this.btnSalvarVenda.Size = new System.Drawing.Size(62, 23);
            this.btnSalvarVenda.TabIndex = 9;
            this.btnSalvarVenda.Text = "Salvar";
            this.btnSalvarVenda.UseVisualStyleBackColor = true;
            this.btnSalvarVenda.Click += new System.EventHandler(this.btnSalvarVenda_Click);
            // 
            // btnCancelarVenda
            // 
            this.btnCancelarVenda.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelarVenda.Location = new System.Drawing.Point(255, 55);
            this.btnCancelarVenda.Name = "btnCancelarVenda";
            this.btnCancelarVenda.Size = new System.Drawing.Size(60, 23);
            this.btnCancelarVenda.TabIndex = 10;
            this.btnCancelarVenda.Text = "Cancelar";
            this.btnCancelarVenda.UseVisualStyleBackColor = true;
            // 
            // CadastroVendaDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 84);
            this.Controls.Add(this.btnCancelarVenda);
            this.Controls.Add(this.btnSalvarVenda);
            this.Controls.Add(this.cbxNomeProduto);
            this.Controls.Add(this.nudQuantidade);
            this.Controls.Add(this.txtNomeCliente);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CadastroVendaDialog";
            this.ShowIcon = false;
            this.Text = "Venda";
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantidade)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNomeCliente;
        private System.Windows.Forms.NumericUpDown nudQuantidade;
        private System.Windows.Forms.ComboBox cbxNomeProduto;
        private System.Windows.Forms.Button btnSalvarVenda;
        private System.Windows.Forms.Button btnCancelarVenda;
    }
}