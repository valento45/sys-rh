using ClosedXML.Excel;
using Rh.Auva.Domain.ControlesIndices;
using RH.Auva.Factory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH.Auva.Factory.Factorys
{
    public class ExcelFactory : IExcelFactory
    {
        public Task<RelatorioDepartamentos> Obter(IXLWorksheet planilha)
        {
            RelatorioDepartamentos result = null;

            if(planilha != null)
            {
                result = new RelatorioDepartamentos();

                for(int linha = 2; linha < planilha.RowsUsed().Count(); linha++)
                {

                }
            }

            throw new NotImplementedException();
        }
    }
}
