using Rh.Auva.Domain.ControlePonto;
using Rh.Auva.Domain.ControlesIndices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH.Auva.Factory.Factorys.Interfaces
{
    public interface IResumoFinanceiroDepartamentoFactory
    {
        /// <summary>
        /// Calcula o resumo financeiro por departamento atraves do controle de ponto dos funcionarios
        /// </summary>
        /// <param name="id_departamento"></param>
        /// <param name="pontosFuncionarios"></param>
        /// <returns></returns>
        Task<DepartamentoRendimentoDomain> Calcular(int id_departamento, IEnumerable<PontoFuncionarioDomain> pontosFuncionarios);
    }
}
