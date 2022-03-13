using Autorizador.Business.Models;

namespace Autorizador.Business.Interfaces.Repositories
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        Task<List<Aplicativo>> ObterAplicativosCliente(Guid clienteId);
    }
}
