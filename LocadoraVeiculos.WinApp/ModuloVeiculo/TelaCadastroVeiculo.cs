﻿using LocadoraVeiculos.Dominio.ModuloVeiculo;
using System;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using LocadoraVeiculos.Controladores.ModuloServicoGrupoVeiculos;
using LocadoraVeiculos.Dominio.ModuloGrupoVeiculos;
using FluentResults;

namespace LocadoraVeiculos.WinApp.ModuloVeiculo
{
    public partial class TelaCadastroVeiculo : Form
    {
        public TelaCadastroVeiculo(ServicoGrupoVeiculos servico)
        {
            InitializeComponent();
            Servico = servico;
            AtualizarPlanosCobranca();
            CarregarTipoCombustivel();
        }
        private TipoCombustivelEnum PegarTipoCombustivel()
        {
            if (cmbTipoCombustivel.SelectedIndex == -1) return TipoCombustivelEnum.Gasolina;

            var nivel = cmbTipoCombustivel.SelectedItem.ToString();

            TipoCombustivelEnum nivelFinal = (TipoCombustivelEnum)Enum.Parse(typeof(TipoCombustivelEnum), nivel);

            return nivelFinal;
        }
        private void CarregarTipoCombustivel()
        {

            cmbTipoCombustivel.Items.Clear();

            foreach (TipoCombustivelEnum tanque in Enum.GetValues(typeof(TipoCombustivelEnum)))
            {
                cmbTipoCombustivel.Items.Add(tanque.ToString());
            }
        }

        private void AtualizarPlanosCobranca()
        {
            var dados = Servico.SelecionarTodos().Value;
            foreach (var dado in dados)
            {
                cmbGrupoVeiculo.Items.Add(dado);
            }
        }

        private Bitmap bmp;
        public Action<string> AtualizarRodape { get; set; }

        public Veiculo veiculo;
        public Veiculo Veiculo
        {
            get { return veiculo; }
            set
            {
                veiculo = value;
                CarregarFoto();
                txtId.Text = veiculo.Id.ToString();
                textBoxModelo.Text = veiculo.Modelo;
                textBoxPlacas.Text = veiculo.Placa;
                textBoxMarca.Text = veiculo.Marca;
                data.Value = veiculo.Ano;
                textCor.Text = veiculo.Cor;
                textBoxCapacidadeTanque.Text =  veiculo.CapacidadeTanque.ToString();
                textBoxQuilometragem.Text = veiculo.Quilometragem.ToString();
                cmbGrupoVeiculo.SelectedItem = veiculo.GrupoVeiculos;
                cmbTipoCombustivel.SelectedItem = veiculo.TipoCombustivel;
            }
        }

        private void CarregarFoto()
        {
            MemoryStream memory = new MemoryStream(veiculo.Foto);

            pictureBoxFoto.Image = Image.FromStream(memory);

            bmp = new Bitmap(pictureBoxFoto.Image);
        }

        public Func<Veiculo, Result<Veiculo>> GravarRegistro { get; internal set; }
        public ServicoGrupoVeiculos Servico { get; }

        private void PegarObjetoTela()
        {           
            MemoryStream memory = new MemoryStream();

            byte[] foto = null;
            if (bmp != null)
            {
                bmp.Save(memory, ImageFormat.Bmp);
                foto = memory.ToArray();
            }

            veiculo.Foto = foto;
            veiculo.Modelo = textBoxModelo.Text;
            veiculo.Placa = textBoxPlacas.Text;
            veiculo.Marca = textBoxMarca.Text;
            veiculo.Cor = textCor.Text;
            veiculo.TipoCombustivel = PegarTipoCombustivel();
            veiculo.Ano = data.Value;
            
            veiculo.CapacidadeTanque =  (textBoxCapacidadeTanque.Text == "")? 0:  Convert.ToDecimal(textBoxCapacidadeTanque.Text);
            veiculo.Quilometragem =  (textBoxQuilometragem.Text == "")? 0: Convert.ToDecimal(textBoxQuilometragem.Text);
            veiculo.GrupoVeiculos = null;            
            if (cmbGrupoVeiculo.SelectedIndex != -1) veiculo.GrupoVeiculos = (GrupoVeiculos)cmbGrupoVeiculo.SelectedItem;
        }
        private void buttonCarregarFoto_Click(object sender, EventArgs e)
        {
            if (openFileDialogFoto.ShowDialog() == DialogResult.OK)
            {
                string nome = openFileDialogFoto.FileName;

                bmp = new Bitmap(nome);

                pictureBoxFoto.Image = bmp;
            }
        }
        private void btnSalvar_Click_1(object sender, EventArgs e)
        {
            PegarObjetoTela();


            if(veiculo.Foto is null)
            {
                AtualizarRodape("Foto deve ser selecionada");

                DialogResult = DialogResult.None;
                return;
            }

            var resultadoValidacao = GravarRegistro(veiculo);

            if (resultadoValidacao.IsFailed)
            {
                string erro = resultadoValidacao.Errors[0].Message;

                if (erro.StartsWith("Falha no sistema"))
                {
                    MessageBox.Show(erro,
                    "Inserção Veiculo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    AtualizarRodape(erro);

                    DialogResult = DialogResult.None;
                }
            }
            else this.DialogResult = DialogResult.OK;
        }
        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            AtualizarRodape("Inserção Cancelada.");
            this.DialogResult = DialogResult.Cancel;
        }
    }
}