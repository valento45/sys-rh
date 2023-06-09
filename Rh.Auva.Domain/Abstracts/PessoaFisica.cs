﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rh.Auva.Domain.Abstracts
{
    public abstract class PessoaFisica
    {
        #region PROPRIEDADE PUBLICAS
        public string Nome { get; set; }
        #endregion

        #region Construtores
        public PessoaFisica(string nome)
        {
            Nome = nome;
        }

        #endregion
    }
}
