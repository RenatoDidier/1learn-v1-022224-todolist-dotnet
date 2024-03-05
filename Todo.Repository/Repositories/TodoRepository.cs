﻿using System.Data.SqlClient;
using Todo.Repository.Configuration;
using Todo.Shared.Models;
using Todo.Repository.Repositories.Contracts;
using Dapper;
using Todo.Shared.ViewModel;
using System.Data;

namespace Todo.Repository.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly SqlConnection _connection;

        public TodoRepository(SqlConnection connection)
            => _connection = connection;


        public List<Atividade> ListarTodasAtividades()
        {
            string procedure = "PRC_LISTAR_ATIVIDADES";
            var listaFinal = new List<Atividade>();

            var resultado = _connection.Query<Atividade>(
                    procedure,
                    commandType: CommandType.StoredProcedure
                );

            foreach (var item in resultado)
            {
                Atividade atividadeItem = new Atividade();

                atividadeItem.Id = item.Id;
                atividadeItem.Titulo = item.Titulo;
                atividadeItem.Conclusao = BitConverter.ToBoolean(item.ByteBanco, 0);
                //atividadeItem.Conclusao = item.Conclusao;
                atividadeItem.DataCriacao = item.DataCriacao;
                atividadeItem.DataUltimaModificacao = item.DataUltimaModificacao;

                listaFinal.Add(atividadeItem);
            }

            return listaFinal;
        }


        public bool CriarAtividade(NovaAtividadeViewModel atividade)
        {
            string procedure = "PRC_CRIAR_ATIVIDADE";

            object novaAtividade = new { 
                Titulo = atividade.Titulo, 
                Conclusao = atividade.Conclusao, 
                DataCriacao = atividade.DataCriacao 
            };

            var resultado = _connection.Execute(
                    procedure,
                    novaAtividade,
                    commandType: CommandType.StoredProcedure
                );

            return resultado > 0;
        }


    }
}
