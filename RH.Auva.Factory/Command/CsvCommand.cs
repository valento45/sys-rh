using Rh.Auva.Domain.ControlePonto;
using RH.Auva.Factory.Command.Interfaces;
using RH.Auva.Factory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH.Auva.Factory.Command
{
    public class CsvCommand : ICsvCommand
    {

        private readonly ICsvFactory _csvFactory;


        public CsvCommand(ICsvFactory csvFactory)
        {
            _csvFactory = csvFactory;
        }

        public async Task<IEnumerable<PontoFuncionarioDomain>> ImportarPontosFuncionario(byte[] bytes)
        {
            return await _csvFactory.ImportarFolhaFuncionarios(bytes);
        }
    }
}
