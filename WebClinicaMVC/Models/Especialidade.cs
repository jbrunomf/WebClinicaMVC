using System.ComponentModel.DataAnnotations;

namespace WebClinicaMVC.Models
{
    public class Especialidade
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Especialidade deve conter entre 3 e 50 caracteres.")]
        public string Nome { get; set; }

        public List<Profissional> Profissionais { get; set; }
        public List<ProfissionalEspecialidade> ProfissionalEspecialidades { get; set; }
    }
}
