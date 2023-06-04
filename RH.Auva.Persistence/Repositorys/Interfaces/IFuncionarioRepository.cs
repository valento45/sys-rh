using Rh.Auva.Domain.Funcionarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH.Auva.Persistence.Repositorys.Interfaces
{
    public interface IFuncionarioRepository
    {
        /// <summary>
        /// Insere funcionario na base de dados
        /// </summary>
        /// <param name="funcionario"></param>
        /// <returns></returns>
        Task<bool> InserirAsync(FuncionarioDomain funcionario);


        /// <summary>
        /// Inserir varios funcionarios na base de dados
        /// </summary>
        /// <param name="funcionarios"></param>
        /// <returns></returns>
        Task<bool> InserirAllAsync(IEnumerable<FuncionarioDomain> funcionarios);

        /// <summary>
        /// Atualiza dados do funcionario
        /// </summary>
        /// <param name="funcionario"></param>
        /// <returns></returns>
        Task<bool> UpdateAsync(FuncionarioDomain funcionario);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        Task<bool> DeleteAsync(int codigo);

        /// <summary>
        /// Lista os funcionarios por nome na base de dados
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        Task<IEnumerable<FuncionarioDomain>> GetAllAsync(string filtro = "");

        /// <summary>
        /// Busca funcionario por codigo na base de dados
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<FuncionarioDomain> GetByIdAsync(int id);
        

        
    }
}
