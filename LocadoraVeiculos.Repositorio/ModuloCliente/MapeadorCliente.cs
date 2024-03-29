﻿using LocadoraVeiculos.Dominio.ModuloCliente;
using LocadoraVeiculos.RepositorioProject.shared;
using System;
using System.Collections.Generic;
using System.Data;

namespace LocadoraVeiculos.RepositorioProject.ModuloCliente
{
    public class MapeadorCliente : MapeadorBase<Cliente>
    {
        public override Cliente ConverterEmRegistro(IDataReader dataReader)
        {
            var id = Guid.Parse(dataReader[0].ToString());
            string nome = Convert.ToString(dataReader[1]);
            string cpf = Convert.ToString(dataReader[2]);
            string endereco = Convert.ToString(dataReader[3]);
            string email = Convert.ToString(dataReader[4]);
            string telefone = Convert.ToString(dataReader[5]);
            string tipoCliente = Convert.ToString(dataReader[6]);
            string cnpj = Convert.ToString(dataReader[7]);

            var cliente = new Cliente(nome,cpf,endereco,email,telefone,tipoCliente,cnpj);
            cliente.Id = id;

            return cliente;
        }
        public override Dictionary<string, object> ObtemParametrosRegistro(Cliente registro)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", registro.Id);
            parametros.Add("NOME", registro.Nome);
            parametros.Add("CPF", registro.Cpf);
            parametros.Add("ENDERECO", registro.Endereco);
            parametros.Add("EMAIL", registro.Email);
            parametros.Add("TELEFONE", registro.Telefone);
            parametros.Add("TIPOCLIENTE", registro.TipoCliente);
            parametros.Add("CNPJ", registro.Cnpj);

            return parametros;
        }
    }
}
