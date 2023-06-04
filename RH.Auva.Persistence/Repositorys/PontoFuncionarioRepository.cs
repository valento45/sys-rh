using Rh.Auva.Domain.ControlePonto;
using RH.Auva.Persistence.Base;
using RH.Auva.Persistence.Repositorys.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH.Auva.Persistence.Repositorys
{
    public class PontoFuncionarioRepository : RepositoryBase, IPontoFuncionarioRepository
    {
        public PontoFuncionarioRepository(IDbConnection connection) : base(connection)
        {
            
        }

        public async Task<bool> InserirPontoAsync(PontoFuncionarioDomain pontoFuncionarioDomain)
        {
            string query = "insert into tb_ponto_funcionario (entrada, saida, almoco, data_ponto, id_funcionario)" +
                $" values ({pontoFuncionarioDomain.Entrada}, {pontoFuncionarioDomain.Saida}, " +
                $"'{pontoFuncionarioDomain.Almoco}', {pontoFuncionarioDomain.DataPonto}," +
                $"{pontoFuncionarioDomain.IdFuncionario})";

            return await base.ExecuteAsync(query);
        }

        public async Task<bool> AlterarPontoAsync(PontoFuncionarioDomain pontoFuncionarioDomain)
        {
            string query = $"update tb_ponto_funcionario  set " +
                $"entrada = {pontoFuncionarioDomain.Entrada}, " +
                $"saida = {pontoFuncionarioDomain.Saida}, almoco = '{pontoFuncionarioDomain.Almoco}', " +
                $"data_ponto = {pontoFuncionarioDomain.DataPonto}," +
                $"id_funcionario = {pontoFuncionarioDomain.IdFuncionario}";
 
            return await base.ExecuteAsync(query);
        }

        public async Task<bool> ExcluirPontoAsync(int codigo)
        {
            string query = "delete from tb_ponto_funcionario where id = " + codigo;

            return await base.ExecuteAsync(query);
        }

        public async Task<IEnumerable<PontoFuncionarioDomain>> GetAllPontoFuncionarioAsync()
        {
            string query = "select id as Codigo, entrada as Entrada, saida as Saida, almoco as Almoco, " +
                "data_ponto as DataPonto, id_funcionario as IdFuncionario";


            return await base.QueryAsync<PontoFuncionarioDomain>(query);
        }

        public async Task<IEnumerable<PontoFuncionarioDomain>> GetPontoFuncionarioAsync(string nome = "")
        {
            string query = "select tp.id as Codigo , entrada as Entrada, saida as Saida, almoco as Almoco," +
                 "data_ponto as DataPonto, id_funcionario as IdFuncionario " +
                 "from tb_ponto_funcionario as tp " +
                 $"inner join tb_funcionario as tf on tf.id = tp.id_funcionario where tf.nome LIKE '{nome}%'";

            return await base.QueryAsync<PontoFuncionarioDomain>(query);
        }

        public async Task<IEnumerable<PontoFuncionarioDomain>> GetPontoFuncionarioAsync(int codigo)
        {
            string query = "select tp.id as Codigo , entrada as Entrada, saida as Saida, almoco as Almoco, " +
                  "data_ponto as DataPonto, id_funcionario as IdFuncionario from tb_ponto_funcionario as tp " +
                  $"inner join tb_funcionario as tf on tf.id = tp.id_funcionario where tf.id = {codigo}";

            return await base.QueryAsync<PontoFuncionarioDomain>(query);
        }

      
    }
}
