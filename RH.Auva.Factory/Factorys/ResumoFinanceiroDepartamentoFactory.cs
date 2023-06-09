﻿using Rh.Auva.Domain.ControlePonto;
using Rh.Auva.Domain.ControlesIndices;
using Rh.Auva.Domain.Departamentos;
using RH.Auva.Factory.Factorys.Interfaces;
using RH.Auva.Persistence.Repositorys.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH.Auva.Factory.Factorys
{
    public class ResumoFinanceiroDepartamentoFactory : IResumoFinanceiroDepartamentoFactory
    {
        private readonly IDepartamentoRepository _departamentoRepository;

        public ResumoFinanceiroDepartamentoFactory(IDepartamentoRepository departamentoRepository)
        {
            _departamentoRepository = departamentoRepository;
        }

        public async Task<DepartamentoRendimentoDomain> Calcular(DepartamentoDomain departamento, IEnumerable<PontoFuncionarioDomain> pontosFuncionarios)
        {
            var dptoRendimento = new DepartamentoRendimentoDomain();

            dptoRendimento.InformarDepartamento(departamento);
            dptoRendimento.InformarPontosFuncionario(pontosFuncionarios.ToList());

            dptoRendimento.Calcular();

            return dptoRendimento;

        }
    }
}
