﻿using Rh.Auva.Domain.ControlePonto;
using Rh.Auva.Domain.Funcionarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rh.Auva.Domain.Departamentos
{
    public class DepartamentoDomain
    {
        #region Propriedades 
        
        public int Codigo { get; set; }
        public string NomeDepartamento { get; set; }
        #endregion


        #region Construtores
        public DepartamentoDomain()
        {
           
        }

        #endregion

    }
}
