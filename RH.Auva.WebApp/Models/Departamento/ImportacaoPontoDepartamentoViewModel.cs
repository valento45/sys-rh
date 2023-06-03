using Rh.Auva.Domain.Departamentos;


namespace RH.Auva.Application.Models.Departamento
{
    public class ImportacaoPontoDepartamentoViewModel
    {
        public List<DepartamentoDomain> Departamentos { get; set; }
        public IFormFile File { get; set; }
        public int IdDepartamentoSelecionao { get; set; }
    }
}
