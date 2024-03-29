﻿using FluentValidation.Results;
using LocadoraVeiculos.Controladores.ModuloServicoGrupoVeiculos;
using LocadoraVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraVeiculos.Dominio.ModuloPlanoCobranca;
using System;
using System.Windows.Forms;

namespace LocadoraVeiculos.WinApp.ModuloPlanoCobranca
{
    public partial class TelaCadastroPlanoCobranca : Form
    {
        public PlanoCobranca planoCobranca;
        public Action<string> AtualizarRodape { get; set; }
        public PlanoCobranca PlanoCobranca
        {
            get { return planoCobranca; }
            set
            {
                planoCobranca = value;

                txtId.Text = Convert.ToString(planoCobranca.Id);
                txtLimiteKM.Text = Convert.ToString(planoCobranca.LimiteKM);
                txtTipo.Text = Convert.ToString(planoCobranca.TipoPlano);
                txtValorDia.Text = Convert.ToString(planoCobranca.ValorDia);
                txtValorKM.Text = Convert.ToString(planoCobranca.ValorKM);
                cmbGrupoVeiculo.SelectedItem = planoCobranca.GrupoVeiculos;
            }
        }

        public Func<PlanoCobranca, FluentResults.Result<PlanoCobranca>> GravarRegistro { get; internal set; }
        public ServicoGrupoVeiculos Servico { get; }

        public TelaCadastroPlanoCobranca(ServicoGrupoVeiculos servico)
        {
            InitializeComponent();
            Servico = servico;
            AtualizarPlanosCobranca();

        }

        private void AtualizarPlanosCobranca()
        {
            var dados = Servico.SelecionarTodos().Value; 
            foreach (var dado in dados)
            {
                cmbGrupoVeiculo.Items.Add(dado);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            AtualizarRodape("Inserção Cancelada.");
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            PegarObjetoTela();


            var resultadoValidacao = GravarRegistro(planoCobranca);

            if (resultadoValidacao.IsFailed)
            {
                string erro = resultadoValidacao.Errors[0].Message;

                if (erro.StartsWith("Falha no sistema"))
                {
                    MessageBox.Show(erro,
                    "Inserção Plano de Cobrança", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    AtualizarRodape(erro);

                    DialogResult = DialogResult.None;
                }
            }
            else this.DialogResult = DialogResult.OK;
        }

        private void PegarObjetoTela()
        {
            planoCobranca.TipoPlano = txtTipo.Text;
            decimal valorDia = 0;
            decimal limite = 0;
            decimal valorKm = 0;
            if (txtValorDia.Text != "") valorDia = Convert.ToDecimal(txtValorDia.Text);
            if (txtLimiteKM.Text != "") limite = Convert.ToDecimal(txtLimiteKM.Text);
            if (txtValorKM.Text != "") valorKm = Convert.ToDecimal(txtValorKM.Text);
            planoCobranca.ValorDia = valorDia;
            planoCobranca.LimiteKM = limite;
            planoCobranca.ValorKM = valorKm;

            if (cmbGrupoVeiculo.SelectedIndex != -1)
                planoCobranca.GrupoVeiculos = (GrupoVeiculos)cmbGrupoVeiculo.SelectedItem;
            else planoCobranca.GrupoVeiculos = null;
            
        }
    }
}
