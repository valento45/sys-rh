using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rh.Auva.Domain.Extensions
{
    public static class MetodosExtensao
    {

        public static string GetMesExtenso(this int mes)
        {
           return System.Globalization.DateTimeFormatInfo.CurrentInfo.GetMonthName(mes).ToLower();
        }
    }
}
