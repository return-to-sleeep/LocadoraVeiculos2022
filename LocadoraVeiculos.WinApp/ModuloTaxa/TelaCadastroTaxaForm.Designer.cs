﻿namespace LocadoraVeiculos.WinApp.ModuloTaxa
{
    partial class TelaCadastroTaxaForm
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
            this.laId = new System.Windows.Forms.Label();
            this.laNome = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.laValor = new System.Windows.Forms.Label();
            this.txtValor = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // laId
            // 
            this.laId.AutoSize = true;
            this.laId.Location = new System.Drawing.Point(57, 20);
            this.laId.Name = "laId";
            this.laId.Size = new System.Drawing.Size(58, 20);
            this.laId.TabIndex = 6;
            this.laId.Text = "Id Taxa:";
            // 
            // laNome
            // 
            this.laNome.AutoSize = true;
            this.laNome.Location = new System.Drawing.Point(12, 74);
            this.laNome.Name = "laNome";
            this.laNome.Size = new System.Drawing.Size(110, 20);
            this.laNome.TabIndex = 7;
            this.laNome.Text = "Descrição Taxa:";
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(138, 71);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(273, 27);
            this.txtDescricao.TabIndex = 8;
            // 
            // txtId
            // 
            this.txtId.Enabled = false;
            this.txtId.Location = new System.Drawing.Point(138, 17);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(273, 27);
            this.txtId.TabIndex = 9;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(296, 177);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(115, 44);
            this.btnSalvar.TabIndex = 10;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(170, 177);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(115, 44);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // laValor
            // 
            this.laValor.AutoSize = true;
            this.laValor.Location = new System.Drawing.Point(36, 130);
            this.laValor.Name = "laValor";
            this.laValor.Size = new System.Drawing.Size(79, 20);
            this.laValor.TabIndex = 12;
            this.laValor.Text = "Valor Taxa:";
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(138, 127);
            this.txtValor.Mask = "99999999";
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(273, 27);
            this.txtValor.TabIndex = 13;
            this.txtValor.ValidatingType = typeof(int);
            // 
            // TelaCadastroTaxaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 248);
            this.Controls.Add(this.txtValor);
            this.Controls.Add(this.laValor);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.laNome);
            this.Controls.Add(this.laId);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TelaCadastroTaxaForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TelaCadastroTarefaForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label laId;
        private System.Windows.Forms.Label laNome;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label laValor;
        private System.Windows.Forms.MaskedTextBox txtValor;
    }
}