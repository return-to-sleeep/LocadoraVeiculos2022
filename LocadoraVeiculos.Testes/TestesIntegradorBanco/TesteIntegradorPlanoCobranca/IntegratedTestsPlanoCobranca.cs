﻿using LocadoraVeiculos.Controladores.ModuloServicoGrupoVeiculos;
using LocadoraVeiculos.Controladores.ModuloServicoPlanoCobranca;
using LocadoraVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraVeiculos.Dominio.ModuloLocacao;
using LocadoraVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraVeiculos.Infra.Configuracao;
using LocadoraVeiculos.Infra.Orm.Compatilhado;
using LocadoraVeiculos.Infra.Orm.ModuloGrupoVeiculo;
using LocadoraVeiculos.Infra.Orm.ModuloPlanoCobranca;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LocadoraVeiculos.Testes.TestesIntegradorBanco.TesteIntegradorPlanoCobranca
{
    [TestClass]
    public class IntegratedTestsPlanoCobranca
    {
        private LocadoraVeiculosDbContext dbContext;

        public IntegratedTestsPlanoCobranca()
        {
            var config = new ConfiguracaoAplicacao();

            dbContext = new LocadoraVeiculosDbContext(config.connectionStrings.SqlServer);


            var locacao = dbContext.Set<Locacao>();
            locacao.RemoveRange(locacao);

            var planoCobrancas = dbContext.Set<PlanoCobranca>();
            planoCobrancas.RemoveRange(planoCobrancas);
            dbContext.SaveChanges();
        }

        [TestMethod]
        public void DeveInserirPlanoCobranca()
        {
            ServicoPlanoCobranca contro = new ServicoPlanoCobranca(new RepositorioPlanoCobrancaOrm(dbContext), dbContext);
            ServicoGrupoVeiculos controGrupo = new ServicoGrupoVeiculos(new RepositorioGrupoVeiculoOrm(dbContext), dbContext);

            GrupoVeiculos grupo = new GrupoVeiculos("Nome grupo Veiculos 1");
            controGrupo.InserirNovo(grupo);

            PlanoCobranca plano = new PlanoCobranca("Tipo Grupo 1", 100, 0, 10, grupo);
            contro.InserirNovo(plano);

            var planoNovo = contro.SelecionarPorId(plano.Id).Value;

            Assert.AreEqual(planoNovo, plano);
        }

        [TestMethod]
        public void DeveBuscarVariosPlanos()
        {
            ServicoPlanoCobranca contro = new ServicoPlanoCobranca(new RepositorioPlanoCobrancaOrm(dbContext), dbContext);
            ServicoGrupoVeiculos controGrupo = new ServicoGrupoVeiculos(new RepositorioGrupoVeiculoOrm(dbContext), dbContext);

            GrupoVeiculos grupo = new GrupoVeiculos("Nome grupo Veiculos 1");

            var ne = controGrupo.InserirNovo(grupo);


            PlanoCobranca plano = new PlanoCobranca("Tipo Grupo 1", 100, 0, 10, grupo);
            PlanoCobranca plano2 = new PlanoCobranca("Tipo Grupo 2", 10, 100, 16, grupo);

            var le = contro.InserirNovo(plano);
            var le2 = contro.InserirNovo(plano2);

            var planosNovos = contro.SelecionarTodos().Value;

            Assert.AreEqual(planosNovos.Count, 2);
        }

        [TestMethod]
        public void DeveVerificarExistenciaPlano()
        {
            ServicoPlanoCobranca contro = new ServicoPlanoCobranca(new RepositorioPlanoCobrancaOrm(dbContext), dbContext);
            ServicoGrupoVeiculos controGrupo = new ServicoGrupoVeiculos(new RepositorioGrupoVeiculoOrm(dbContext), dbContext);

            GrupoVeiculos grupo = new GrupoVeiculos("Nome grupo Veiculos 1");
            var le1 = controGrupo.InserirNovo(grupo);

            PlanoCobranca plano = new PlanoCobranca("Tipo Grupo 1", 100, 0, 10, grupo);

            var le = contro.InserirNovo(plano);

            var planoNovo = contro.Existe(plano.Id);

            Assert.IsTrue(planoNovo.Value);
        }

        [TestMethod]
        public void DeveDeletarPlano()
        {
            ServicoPlanoCobranca contro = new ServicoPlanoCobranca(new RepositorioPlanoCobrancaOrm(dbContext), dbContext);
            ServicoGrupoVeiculos controGrupo = new ServicoGrupoVeiculos(new RepositorioGrupoVeiculoOrm(dbContext), dbContext);

            GrupoVeiculos grupo = new GrupoVeiculos("Nome grupo Veiculos 1");
            controGrupo.InserirNovo(grupo);

            PlanoCobranca plano = new PlanoCobranca("Tipo Grupo 1", 100, 0, 10, grupo);

            contro.InserirNovo(plano);

            contro.Excluir(contro.SelecionarPorId(plano.Id).Value);

            var planoNovo = contro.Existe(plano.Id).Value;

            Assert.IsFalse(planoNovo);
        }

        [TestMethod]
        public void DeveEditarPlano()
        {
            ServicoPlanoCobranca contro = new ServicoPlanoCobranca(new RepositorioPlanoCobrancaOrm(dbContext), dbContext);
            ServicoGrupoVeiculos controGrupo = new ServicoGrupoVeiculos(new RepositorioGrupoVeiculoOrm(dbContext), dbContext);

            GrupoVeiculos grupo = new GrupoVeiculos("Nome grupo Veiculos 1");
            controGrupo.InserirNovo(grupo);

            PlanoCobranca plano = new PlanoCobranca("Tipo Grupo 1", 100, 0, 10, grupo);

            contro.InserirNovo(plano);
            plano.TipoPlano = "Novo Tipo do plano";

            contro.Editar(plano);

            var planoNovo = contro.SelecionarPorId(plano.Id).Value;

            Assert.AreEqual(planoNovo, plano);
        }
    }
}
