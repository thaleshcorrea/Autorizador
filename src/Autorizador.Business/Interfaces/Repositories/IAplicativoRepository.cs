using Autorizador.Business.Models;

namespace Autorizador.Business.Interfaces.Repositories
{
    public interface IAplicativoRepository : IRepository<Aplicativo>
    {
        Task<IEnumerable<Aplicativo>> ObterClientesPorAplicativo(Guid id);
    }
}
