namespace Autorizador.Business.Models
{
    public abstract class Entity
    {
        public Entity()
        {
            Id = Guid.NewGuid();
            Ativo = true;
            Removido = false;
        }

        public Guid Id { get; private set; }
        public bool Ativo { get; private set; }
        public bool Removido { get; private set; }
    }
}
