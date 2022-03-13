using Autorizador.Business.Interfaces;
using Autorizador.Business.Interfaces.Repositories;
using Autorizador.Business.Interfaces.Services;
using Autorizador.Business.Models;
using Autorizador.Business.Models.Validations;
using Autorizador.Business.Utils;

namespace Autorizador.Business.Services
{
    public class ClienteService : BaseService, IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository,
                              INotificador notificador) : base(notificador)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<bool> Adicionar(Cliente cliente)
        {
            if (!ExecutarValidacao(new ClienteValidation(), cliente)) return false;

            bool cpfCnpjJaCadastrado = _clienteRepository.Buscar(c => c.CpfCnpj == cliente.CpfCnpj).Result.Any();
            if (cpfCnpjJaCadastrado)
            {
                Notificar(ClienteMensagem.JaExisteClienteCadastradoNesseCpfCnpj);
                return false;
            }

            await _clienteRepository.Adicionar(cliente);
            return true;
        }

        public async Task<bool> Atualizar(Cliente cliente)
        {
            if (!ExecutarValidacao(new ClienteValidation(), cliente)) return false;

            bool cpfCnpjJaCadastrado = _clienteRepository.Buscar(c => c.CpfCnpj == cliente.CpfCnpj && c.Id != cliente.Id).Result.Any();
            if (cpfCnpjJaCadastrado)
            {
                Notificar(ClienteMensagem.JaExisteClienteCadastradoNesseCpfCnpj);
                return false;
            }

            await _clienteRepository.Atualizar(cliente);
            return true;
        }

        public async Task<bool> Remover(Guid id)
        {
            var aplicativos = await _clienteRepository.ObterAplicativosCliente(id);
            if(aplicativos.Any())
            {
                Notificar(ClienteMensagem.ClienteComRegistrosVinculados);
                return false;
            }

            await _clienteRepository.Remover(id);
            return true;
        }
    }
}
