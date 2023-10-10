using System.ComponentModel.DataAnnotations;


namespace WebClinicaMVC.Models
{
    public class Profissional
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }


        public List<Especialidade> Especialidades { get; } = new();
        public List<ProfissionalEspecialidade> ProfissionalEspecialidades { get; set; } = null!;
    }
}
