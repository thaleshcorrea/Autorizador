namespace Autorizador.Business.Models
{
    public class Aplicativo : Entity
    {
        public Aplicativo(string nome, string identificador)
        {
            Nome = nome;
            Identificador = identificador;
        }

        public string Nome { get; set; }
        public string Identificador { get; set; }
        public string? Observacao { get; set; }
    }
}
