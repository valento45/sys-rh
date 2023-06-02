using ClosedXML.Excel;
using Rh.Auva.Domain.ControlesIndices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH.Auva.Factory.Interfaces
{
    public interface IExcelFactory
    {
        Task<RelatorioDepartamentos> Obter(IXLWorksheet planilha);
    }
}
