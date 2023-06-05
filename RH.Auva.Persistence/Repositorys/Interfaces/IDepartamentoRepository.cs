using Rh.Auva.Domain.Departamentos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH.Auva.Persistence.Repositorys.Interfaces
{
    public interface IDepartamentoRepository
    {
        /// <summary>
        /// Inserir o departamento na base de dados
        /// </summary>
        /// <param name="departamento"></param>
        /// <returns></returns>
        Task<bool> InserirAsync(DepartamentoDomain departamento);

        /// <summary>
        /// Atualizar o departamento na base de dados
        /// </summary>
        /// <param name="departamento"></param>
        /// <returns></returns>
        Task<bool> AtualizarAsync(DepartamentoDomain departamento);


        /// <summary>
        /// Excluir o departamento na base de dados
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        Task<bool> ExcluirAsync(int codigo);

        /// <summary>
        /// Obter todos os departamentos com opção de usar filtro por nome.
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        Task<List<DepartamentoDomain>> GetAllAsync(string filtro = "");       


        /// <summary>
        /// Obter departamento por ID na base de dados
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<DepartamentoDomain> GetByIdAsync(int id);


        /// <summary>
        /// Verifica se existe o departamento na base de dados
        /// </summary>
        /// <param name="departamento"></param>
        /// <returns></returns>
        Task<bool> Exists(string departamento);


        /// <summary>
        /// Obter departamento por nome 
        /// </summary>
        /// <param name="departamento"></param>
        /// <returns></returns>
        Task<DepartamentoDomain> GetByNome(string departamento);
    }
}
