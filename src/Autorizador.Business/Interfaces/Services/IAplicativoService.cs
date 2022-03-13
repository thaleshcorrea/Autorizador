using Autorizador.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autorizador.Business.Interfaces.Services
{
    public interface IAplicativoService
    {
        Task<bool> Adicionar(Aplicativo aplicativo);

        Task<bool> Atualizar(Aplicativo aplicativo);

        Task<bool> Remover(Guid id);
    }
}
