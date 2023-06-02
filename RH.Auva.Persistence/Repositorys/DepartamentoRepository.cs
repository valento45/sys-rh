using Dapper;
using Rh.Auva.Domain.Departamentos;
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
    public class DepartamentoRepository : RepositoryBase, IDepartamentoRepository
    {

        public DepartamentoRepository(IDbConnection dbConnection) : base(dbConnection)
        {

        }


        public async Task<bool> InserirRendimentoAsync(Departamento departamento)
        {
            string query = $"insert into tb_departamento (nome) values ('{departamento.NomeDepartamento}')";


            return await base.ExecuteAsync(query);
        }

        public async Task<bool> AtualizarAsync(Departamento departamento)
        {
            string query = $"update tb_departamento  set nome = '{departamento.NomeDepartamento}'" +
                $" WHERE id = {departamento.Codigo}";


            return await base.ExecuteAsync(query);
        }
        

        public async Task<bool> ExcluirAsync(int codigo)
        {
            string query = $"delete from tb_departamento" +
                 $" WHERE id = {codigo}";

            return await base.ExecuteAsync(query);
        }

        public async Task<List<Departamento>> GetAllAsync(string filtro = "")
        {
            string query = $"select id as Codigo, nome as NomeDepartamento from tb_departamento" +
                  $" WHERE nome  LIKE '{filtro}%'";

            return await base.QueryAsync<Departamento>(query);
        }
    }
}
