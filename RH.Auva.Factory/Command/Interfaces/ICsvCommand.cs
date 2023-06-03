using Irony.Parsing;
using Rh.Auva.Domain.ControlePonto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH.Auva.Factory.Command.Interfaces
{
    public interface ICsvCommand
    {
        /// <summary>
        /// Importar arquivo de pontos dos funcionarios
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        Task<IEnumerable<PontoFuncionarioDomain>> ImportarPontosFuncionario(byte[] bytes);
    }
}
