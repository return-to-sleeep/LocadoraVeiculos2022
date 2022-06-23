﻿using LocadoraVeiculos.Dominio.ModuloTaxas;
using LocadoraVeiculos.RepositorioProject.shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace LocadoraVeiculos.RepositorioProject.ModuloTaxas
{
    public class MapeadorTaxas : MapeadorBase<Taxas>
    {
        public override Taxas ConverterEmRegistro(IDataReader dataReader)
        {
            int id = Convert.ToInt32(dataReader[0]);
            string descricao = Convert.ToString(dataReader[1]);
            decimal valor = Convert.ToDecimal(dataReader[2]);

            var taxa = new Taxas(descricao, valor);
            taxa._id = id;

            return taxa;
        }

        public override Dictionary<string, object> ObtemParametrosRegistro(Taxas taxas)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", taxas._id);
            parametros.Add("DESCRICAO", taxas.Descricao);
            parametros.Add("VALOR", taxas.Valor);

            return parametros;
        }


    }
}
