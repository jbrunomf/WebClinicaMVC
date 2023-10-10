using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace WebClinicaMVC.Models
{
    public class Consulta
    {
        public int Id { get; set; }

        [Display(Name = "Profissional")]
        public int ProfissionalId { get; set; }
        public Profissional? Profissional { get; set; }

        [Display(Name = "Paciente")]
        public int PacienteId { get; set; }
        public Paciente? Paciente { get; set; }

        [Display(Name = "Data e Hora")]
        public DateTime DataHoraConsulta { get; set; }
    }
}
