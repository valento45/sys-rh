using Rh.Auva.Domain.ControlePonto;
using Rh.Auva.Domain.ControlesIndices;
using Rh.Auva.Domain.Funcionarios;
using RH.Auva.Factory.Mappers.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH.Auva.Factory.Factorys.Interfaces
{
    public interface ICsvFactory
    {
        /// <summary>
        /// Método responsavel por importar o arquivo excel da folha de pontos dos funcionarios
        /// </summary>
        /// <param name="planilha"></param>
        /// <returns></returns>
        Task<IEnumerable<PontoFuncionarioDomain>> ImportarFolhaFuncionarios(byte[] bytes);
    }
}
