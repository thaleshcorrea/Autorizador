using Autorizador.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autorizador.Business.Interfaces.Services
{
    public interface IClienteService
    {
        Task<bool> Adicionar(Cliente cliente);

        Task<bool> Atualizar(Cliente cliente);

        Task<bool> Remover(Guid id);
    }
}
