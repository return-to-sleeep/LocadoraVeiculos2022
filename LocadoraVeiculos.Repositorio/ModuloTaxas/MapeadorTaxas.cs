﻿using LocadoraVeiculos.Dominio.ModuloTaxas;
using LocadoraVeiculos.RepositorioProject.shared;
using System;
using System.Collections.Generic;
using System.Data;

namespace LocadoraVeiculos.RepositorioProject.ModuloTaxas
{
    public class MapeadorTaxas : MapeadorBase<Taxas>
    {
        public override Taxas ConverterEmRegistro(IDataReader dataReader)
        {
            var id = Guid.Parse(dataReader[0].ToString());
            string descricao = Convert.ToString(dataReader[1]);
            decimal valor = Convert.ToDecimal(dataReader[2]);
            string tipo = Convert.ToString(dataReader[3]);
            var taxa = new Taxas(descricao, valor,tipo);
            taxa.Id = id;

            return taxa;
        }

        public override Dictionary<string, object> ObtemParametrosRegistro(Taxas taxas)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", taxas.Id);
            parametros.Add("DESCRICAO", taxas.Descricao);
            parametros.Add("VALOR", taxas.Valor);
            parametros.Add("TIPO", taxas.Tipo);

            return parametros;
        }


    }
}
