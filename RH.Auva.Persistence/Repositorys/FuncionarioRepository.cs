using MySql.Data.MySqlClient;
using Rh.Auva.Domain.Departamentos;
using Rh.Auva.Domain.Funcionarios;
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
    public class FuncionarioRepository : RepositoryBase, IFuncionarioRepository
    {
        public FuncionarioRepository(IDbConnection connection) : base(connection)
        {

        }

        public async Task<bool> InserirAsync(FuncionarioDomain funcionario)
        {

            MySqlCommand cmd = new MySqlCommand("insert into tb_funcionario (nome, valor_hora, data_importacao)" +
                " values (@nome, @valor_hora, @data_importacao)");

            cmd.Parameters.AddWithValue(@"nome", funcionario.Nome);
            cmd.Parameters.AddWithValue(@"valor_hora", funcionario.ValorHora);
            cmd.Parameters.AddWithValue(@"data_importacao", DateTime.Now);


            return await base.ExecuteCommand(cmd);

            //string query = "insert into tb_funcionario (nome, valor_hora, data_importacao)" +
            //    $" values ('{funcionario.Nome}', {funcionario.ValorHora}, str_to_date('{funcionario.DataImportacao.ToString("dd/MM/yyyy")}','%d/%m/%Y'))";

            //return await base.ExecuteAsync(query);
        }

        public async Task<bool> UpdateAsync(FuncionarioDomain funcionario)
        {
            string query =
                $"update tb_funcionario set nome = '{funcionario.Nome}' , " +
                $"valor_hora = {funcionario.ValorHora} , data_importacao = {funcionario.DataImportacao}) " +
                $"WHERE id = {funcionario.Codigo}";


            return await base.ExecuteAsync(query);
        }


        public async Task<bool> DeleteAsync(int codigo)
        {
            string query = $"delete from tb_funcionario where id = {codigo}";
            return await base.ExecuteAsync(query);
        }

        public async Task<IEnumerable<FuncionarioDomain>> GetAllAsync(string filtro = "")
        {
            string query = $"select id as Codigo, nome as Nome, valor_hora as ValorHora," +
                $" data_importacao as DataImportacao from tb_funcionario" +
                $" WHERE nome LIKE '{filtro}%'";

            return await base.QueryAsync<FuncionarioDomain>(query);
        }

        public async Task<FuncionarioDomain> GetByIdAsync(int id)
        {
            string query = $"select id as Codigo, nome as Nome, valor_hora as ValorHora," +
            $" data_importacao as DataImportacao from tb_funcionario" +
            $" WHERE id = {id}";

            var result = await base.QueryAsync<FuncionarioDomain>(query);

            return result?.FirstOrDefault() ?? null;
        }

        public async Task<bool> InserirAllAsync(IEnumerable<FuncionarioDomain> funcionarios)
        {

            foreach (var funcionario in funcionarios.Distinct())
            {
                if (await GetByIdAsync(funcionario.Codigo) == null)
                {
                    await InserirAsync(funcionario);
                }
            }

            return true;
        }
    }
}
