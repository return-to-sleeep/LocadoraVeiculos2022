﻿using LocadoraVeiculos.Dominio.ModuloTaxas;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LocadoraVeiculos.Testes.TestesUnitarios.TesteUnitarioTaxas
{
    [TestClass]
    public class UnitTaxasTeste
    {
        [TestMethod]
        public void DeveImpedirCriarTaxaSemValor()
        {
            ValidadorTaxas validador = new ValidadorTaxas();

            Taxas taxas = new Taxas("Aluguel Onix", 0, EnumTaxa.Diaria.ToString());
            var result = validador.Validate(taxas);
            Assert.AreEqual(result.IsValid, false);
        }

        [TestMethod]
        public void DeveImpedirCriarTaxaDescricao1Caractere()
        {
            ValidadorTaxas validador = new ValidadorTaxas();

            Taxas taxas = new Taxas("A", 1800, EnumTaxa.Diaria.ToString());
            var result = validador.Validate(taxas);
            Assert.AreEqual(result.IsValid, false);
        }

        [TestMethod]
        public void DevePermitirCriarTaxas()
        {
            ValidadorTaxas validador = new ValidadorTaxas();
            Taxas taxas = new Taxas("Aluguel Onix", 1500, EnumTaxa.Diaria.ToString());
            var result = validador.Validate(taxas);
            Assert.AreEqual(result.IsValid, true);

        }
    }
}
