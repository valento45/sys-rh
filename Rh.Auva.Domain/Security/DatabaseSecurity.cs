using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rh.Auva.Domain.Security
{
    public class DatabaseSecurity
    {
        public string Server { get; set; }
        public string Database { get; set; }
        public string User { get; set; }
        public string Pass  { get; set; }
        public DatabaseSecurity()
        {
                
        }
    }
}
