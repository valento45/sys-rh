using Rh.Auva.Domain.ControlePonto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH.Auva.Persistence.Repositorys.Interfaces
{
    public interface IPontoFuncionarioRepository
    {

        /// <summary>
        /// Inserir ponto do funcionario na base de dados
        /// </summary>
        /// <param name="pontoFuncionarioDomain"></param>
        /// <returns></returns>
        Task<bool> InserirPontoAsync(PontoFuncionarioDomain pontoFuncionarioDomain);

        /// <summary>
        /// Alterar ponto do funcionario na base de dados
        /// </summary>
        /// <param name="pontoFuncionarioDomain"></param>
        /// <returns></returns>
        Task<bool> AlterarPontoAsync(PontoFuncionarioDomain pontoFuncionarioDomain);


        /// <summary>
        /// Excluir ponto do funcionario na base de dados
        /// </summary>
        /// <param name="codigo">Codigo do funcionario coluna (id) tabela (tb_funcionario)</param>
        /// <returns></returns>
        Task<bool> ExcluirPontoAsync(int codigo);

        /// <summary>
        /// Listar pontos funcionario pelo nome na base de dados
        /// </summary>
        /// <param name="nome">coluna (nome) tabela (tb_funcionario)</param>
        /// <returns></returns>
        Task<IEnumerable<PontoFuncionarioDomain>> GetPontoFuncionarioAsync(string nome = "");


        /// <summary>
        /// Listar pontos do funcionario pelo codigo deste
        /// </summary>
        /// <param name="codigo">Codigo do funcionario - coluna (id) tabela (tb_funcionario) </param>
        /// <returns></returns>
        Task<IEnumerable<PontoFuncionarioDomain>> GetPontoFuncionarioAsync(int codigo);

        /// <summary>
        /// Listar todos os pontos de todos funcionarios na base de dados
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<PontoFuncionarioDomain>> GetAllPontoFuncionarioAsync();

        
    }
}
