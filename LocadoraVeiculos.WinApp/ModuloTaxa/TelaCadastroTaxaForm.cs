﻿using FluentResults;
using FluentValidation.Results;
using LocadoraVeiculos.Dominio.ModuloTaxas;
using System;
using System.Windows.Forms;

namespace LocadoraVeiculos.WinApp.ModuloTaxa
{
    public partial class TelaCadastroTaxaForm : Form
    {
        public Taxas taxa;
        public Action<string> AtualizarRodape { get; set; }

        public Taxas Taxa
        {
            get { return taxa; }
            set
            {
                taxa = value;

                txtId.Text = Convert.ToString(taxa.Id);
                txtDescricao.Text = taxa.Descricao;
                txtValor.Text = Convert.ToString(taxa.Valor);
                if (taxa.Tipo == EnumTaxa.Fixa.ToString()) radioFixa.Checked = true;
                if (taxa.Tipo == EnumTaxa.Diaria.ToString()) radioDiaria.Checked = true;
            }
        }

        public Func<Taxas, Result<Taxas>> GravarRegistro { get; internal set; }

        public TelaCadastroTaxaForm()
        {
            InitializeComponent();
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            if (!PegarObjetoTela()) return;


            var resultadoValidacao = GravarRegistro(taxa);

            if (resultadoValidacao.IsFailed)
            {
                string erro = resultadoValidacao.Errors[0].Message;

                if (erro.StartsWith("Falha no sistema"))
                {
                    MessageBox.Show(erro,
                    "Inserção Taxa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    AtualizarRodape(erro);

                    DialogResult = DialogResult.None;
                }
            }
            else this.DialogResult = DialogResult.OK;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            AtualizarRodape("Inserção Cancelada.");
            this.DialogResult = DialogResult.Cancel;

        }

        private bool PegarObjetoTela()
        {

            if (txtDescricao.Text == "" || txtValor.Text == "")
            {
                AtualizarRodape("Favor Preencher todos os campos.");
                return false;
            }                

            taxa.Descricao = txtDescricao.Text;
            taxa.Valor = Convert.ToDecimal(txtValor.Text);
            taxa.Tipo = (radioDiaria.Checked) ? EnumTaxa.Diaria.ToString() : EnumTaxa.Fixa.ToString();
            
            return true;
        }

    }
}
