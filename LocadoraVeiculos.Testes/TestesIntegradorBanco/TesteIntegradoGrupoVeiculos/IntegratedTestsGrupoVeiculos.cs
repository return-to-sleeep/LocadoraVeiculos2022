﻿using LocadoraVeiculos.Controladores.ModuloServicoGrupoVeiculos;
using LocadoraVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraVeiculos.RepositorioProject.ModuloGrupoVeiculos;
using LocadoraVeiculos.RepositorioProject.shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LocadoraVeiculos.Testes.TestesIntegradorBanco.TesteIntegradoGrupoVeiculos
{
    [TestClass]
    public class IntegratedTestsGrupoVeiculos
    {
        public IntegratedTestsGrupoVeiculos()
        {
            string query = @"delete from TB_VEICULO;";
            DataBase.ExecutarComando(query);
            string query2 = @"delete from TB_PLANOCOBRANCA;";
            DataBase.ExecutarComando(query2);
            string query3 = @"delete from TB_GRUPOVEICULOS;";
            DataBase.ExecutarComando(query3);
        }

        [TestMethod]
        public void DeveInserirGrupoVeiculos()
        {
            ServicoGrupoVeiculos repo = new ServicoGrupoVeiculos();
            GrupoVeiculos gveh = new GrupoVeiculos("Grupo 1");
            repo.InserirNovo(gveh);

            var gveiculos = repo.SelecionarPorId(gveh._id).Value;

            Assert.AreEqual(gveiculos, gveh);
        }

        [TestMethod]
        public void DeveBuscarVariosGrupoVeiculos()
        {
            ServicoGrupoVeiculos repo = new ServicoGrupoVeiculos();
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
            ServicoGrupoVeiculos repo = new ServicoGrupoVeiculos();
            GrupoVeiculos gveh = new GrupoVeiculos("Grupo 1");
            repo.InserirNovo(gveh);

            var exite = repo.Existe(gveh._id);

            Assert.IsTrue(exite.Value);
        }

        [TestMethod]
        public void DeveEditarGrupoVeiculos()
        {
            ServicoGrupoVeiculos repo = new ServicoGrupoVeiculos();
            GrupoVeiculos gveh = new GrupoVeiculos("Grupo 2");
            repo.InserirNovo(gveh);

            GrupoVeiculos gveh2 = new GrupoVeiculos("Grupo 3");
            gveh2._id = gveh._id;
            repo.Editar(gveh2);

            var gvehNovo = repo.SelecionarPorId(gveh2._id).Value;

            Assert.AreEqual(gvehNovo, gveh2);
        }

        [TestMethod]
        public void DeveDeletarGrupoVeiculos()
        {
            ServicoGrupoVeiculos repo = new ServicoGrupoVeiculos();
            GrupoVeiculos gveh = new GrupoVeiculos("Grupo 2");
            repo.InserirNovo(gveh);

            repo.Excluir(repo.SelecionarPorId(gveh._id).Value);

            var existe = repo.Existe(gveh._id);

            Assert.IsFalse(existe.Value);
        }
    }
}
