namespace Autorizador.Business.Models
{
    public class Cliente : Entity
    {
        public Cliente(string razaoSocial, string fantasia, string cpfCnpj)
        {
            RazaoSocial = razaoSocial;
            Fantasia = fantasia;
            CpfCnpj = cpfCnpj;
        }

        public string RazaoSocial { get; set; }
        public string Fantasia { get; set; }
        public string CpfCnpj { get; set; }
        public string? Email { get; set; }
    }
}
