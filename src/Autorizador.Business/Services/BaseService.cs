using Autorizador.Business.Interfaces;
using Autorizador.Business.Models;
using Autorizador.Business.Notificacoes;
using FluentValidation;
using FluentValidation.Results;

namespace Autorizador.Business.Services
{
    public abstract class BaseService
    {
        private readonly INotificador _notificador;

        protected BaseService(INotificador notificador)
        {
            _notificador = notificador;
        }

        protected void Notificar(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notificar(error.ErrorMessage);
            }
        }

        protected void Notificar(string mensagem)
        {
            _notificador.Handle(new Notificacao(mensagem));
        }

        protected bool ExecutarValidacao<TValidator, TEntity>(TValidator validacao, TEntity entity) where TValidator : AbstractValidator<TEntity> where TEntity : Entity
        {
            var validator = validacao.Validate(entity);

            if (validator.IsValid) return true;

            Notificar(validator);

            return false;
        }
    }
}
