using Autorizador.Business.Interfaces;
using Autorizador.Business.Interfaces.Repositories;
using Autorizador.Business.Interfaces.Services;
using Autorizador.Business.Models;
using Autorizador.Business.Models.Validations;
using Autorizador.Business.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autorizador.Business.Services
{
    public class AplicativoService : BaseService, IAplicativoService
    {
        private readonly IAplicativoRepository _aplicativoRepository;

        public AplicativoService(IAplicativoRepository AplicativoRepository,
                              INotificador notificador) : base(notificador)
        {
            _aplicativoRepository = AplicativoRepository;
        }

        public async Task<bool> Adicionar(Aplicativo aplicativo)
        {
            if (!ExecutarValidacao(new AplicativoValidation(), aplicativo)) return false;

            bool cpfCnpjJaCadastrado = _aplicativoRepository.Buscar(c => c.Identificador == aplicativo.Identificador).Result.Any();
            if (cpfCnpjJaCadastrado)
            {
                Notificar(AplicativoMensagem.JaExisteUmAplicativoComEsseIdentificador);
                return false;
            }

            await _aplicativoRepository.Adicionar(aplicativo);
            return true;
        }

        public async Task<bool> Atualizar(Aplicativo aplicativo)
        {
            if (!ExecutarValidacao(new AplicativoValidation(), aplicativo)) return false;

            bool cpfCnpjJaCadastrado = _aplicativoRepository.Buscar(c => c.Identificador == aplicativo.Identificador && c.Id != aplicativo.Id).Result.Any();
            if (cpfCnpjJaCadastrado)
            {
                Notificar(AplicativoMensagem.JaExisteUmAplicativoComEsseIdentificador);
                return false;
            }

            await _aplicativoRepository.Atualizar(aplicativo);
            return true;
        }

        public async Task<bool> Remover(Guid id)
        {
            var aplicativos = await _aplicativoRepository.ObterClientesPorAplicativo(id);
            if (aplicativos.Any())
            {
                Notificar(AplicativoMensagem.AplicativoPossuiClienteVinculados);
                return false;
            }

            await _aplicativoRepository.Remover(id);
            return true;
        }
    }
}
