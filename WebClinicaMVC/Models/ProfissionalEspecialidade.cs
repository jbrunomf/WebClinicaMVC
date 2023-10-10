namespace WebClinicaMVC.Models
{
    public class ProfissionalEspecialidade
    {
        public int IdProfissional { get; set; }
        public int IdEspecialidade { get; set; }
        public Profissional Profissional { get; set; }
        public Especialidade Especialidade { get; set; }
    }
}
