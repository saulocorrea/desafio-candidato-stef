using FluentValidation;
using PedidoApi.Core.Dtos;

namespace PedidoApi.Core.Validators
{
    public class InserirPedidoValidator : AbstractValidator<InserirPedidoDto>
    {
        public InserirPedidoValidator()
        {
            RuleFor(x => x.NomeCliente)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("O nome do cliente não pode ser nulo")
                .NotEmpty().WithMessage("O nome do cliente não pode ser vazio")
                .Must(x => x.Length > 0 && x.Length <= 60)
                .WithMessage("O nome do cliente é muito longo");

            RuleFor(x => x.EmailCliente)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("O email do cliente não pode ser nulo")
                .NotEmpty().WithMessage("O email do cliente não pode ser vazio")
                .Must(x => x.Length > 0 && x.Length <= 60)
                .WithMessage("O nome do cliente é muito longo");
            
            RuleFor(x => x.ItensPedido)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("O pedido deve conter itens")
                .DependentRules(() =>
                {
                    RuleForEach(x => x.ItensPedido).Cascade(CascadeMode.Stop)
                        .NotNull()
                        .Must(a => a.Quantidade > 0).WithMessage("Informar quantidade");
                });
        }
    }
}
