﻿using LocadoraVeiculos.Controladores.ModuloServicoGrupoVeiculos;
using LocadoraVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraVeiculos.Dominio.ModuloLocacao;
using LocadoraVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraVeiculos.Infra.Configuracao;
using LocadoraVeiculos.Infra.Orm.Compatilhado;
using LocadoraVeiculos.Infra.Orm.ModuloGrupoVeiculo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LocadoraVeiculos.Testes.TestesIntegradorBanco.TesteIntegradoGrupoVeiculos
{
    [TestClass]
    public class IntegratedTestsGrupoVeiculos
    {
        LocadoraVeiculosDbContext dbContext;
        public IntegratedTestsGrupoVeiculos()
        {
            var config = new ConfiguracaoAplicacao();

            dbContext = new LocadoraVeiculosDbContext(config.connectionStrings.SqlServer);

            var locacao = dbContext.Set<Locacao>();
            locacao.RemoveRange(locacao);

            var planoCobranca = dbContext.Set<PlanoCobranca>();
            planoCobranca.RemoveRange(planoCobranca);


            var grupoVeiculos = dbContext.Set<GrupoVeiculos>();
            grupoVeiculos.RemoveRange(grupoVeiculos);
            dbContext.SaveChanges();
        }

        [TestMethod]
        public void DeveInserirGrupoVeiculos()
        {
            ServicoGrupoVeiculos repo = new ServicoGrupoVeiculos(new RepositorioGrupoVeiculoOrm(dbContext), dbContext);
            GrupoVeiculos gveh = new GrupoVeiculos("Grupo 1");
            repo.InserirNovo(gveh);

            var gveiculos = repo.SelecionarPorId(gveh.Id).Value;

            Assert.AreEqual(gveiculos, gveh);
        }

        [TestMethod]
        public void DeveBuscarVariosGrupoVeiculos()
        {
            ServicoGrupoVeiculos repo = new ServicoGrupoVeiculos(new RepositorioGrupoVeiculoOrm(dbContext), dbContext);
            GrupoVeiculos gveh = new GrupoVeiculos("Grupo 1");
            GrupoVeiculos gveh2 = new GrupoVeiculos("Grupo 2");

            repo.InserirNovo(gveh);
            repo.InserirNovo(gveh2);

            var dados = repo.SelecionarTodos().Value;

            Assert.AreEqual(2, dados.Count);

        }

        [TestMethod]
        public void DeveVerificarExistenciaGrupoVeiculos()
        {
            ServicoGrupoVeiculos repo = new ServicoGrupoVeiculos(new RepositorioGrupoVeiculoOrm(dbContext), dbContext);
            GrupoVeiculos gveh = new GrupoVeiculos("Grupo 1");
            repo.InserirNovo(gveh);

            var exite = repo.Existe(gveh.Id);

            Assert.IsTrue(exite.Value);
        }

        [TestMethod]
        public void DeveEditarGrupoVeiculos()
        {
            ServicoGrupoVeiculos repo = new ServicoGrupoVeiculos(new RepositorioGrupoVeiculoOrm(dbContext), dbContext);
            GrupoVeiculos gveh = new GrupoVeiculos("Grupo 2");
            repo.InserirNovo(gveh);

            gveh.NomeGrupo = "Novo nome do grupo2";

            repo.Editar(gveh);

            var gvehNovo = repo.SelecionarPorId(gveh.Id).Value;

            Assert.AreEqual(gvehNovo, gveh);
        }

        [TestMethod]
        public void DeveDeletarGrupoVeiculos()
        {
            ServicoGrupoVeiculos repo = new ServicoGrupoVeiculos(new RepositorioGrupoVeiculoOrm(dbContext), dbContext);
            GrupoVeiculos gveh = new GrupoVeiculos("Grupo 2");
            repo.InserirNovo(gveh);

            repo.Excluir(repo.SelecionarPorId(gveh.Id).Value);

            var existe = repo.Existe(gveh.Id);

            Assert.IsFalse(existe.Value);
        }
    }
}
