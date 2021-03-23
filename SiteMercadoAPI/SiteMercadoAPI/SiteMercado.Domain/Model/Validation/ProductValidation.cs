using FluentValidation;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace SiteMercado.Domain.Model.Validation
{
    public class ProductValidation : AbstractValidator<Product>
    {

        public ProductValidation()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(1, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres")
                .WithName("NOME");

            RuleFor(c => c.Value)
                 .NotNull().WithMessage("O campo {PropertyName} precisa ser fornecido")
                 .GreaterThan(0).WithMessage("O Valor do Produto não produto tem que ser maior que 0")
                 .WithName("VALOR DO PRODUTO");

            RuleFor(c => c.Image)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(1, 255).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres")
                .WithName("IMAGEM");

            RuleFor(c => c.CreatedDate)
                .NotNull().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .WithName("DATA COMENTÁRIO");

            RuleFor(c => c.CreatedUser)
                .NotNull()
                .Length(1, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres")
                .WithName("DATA COMENTÁRIO");

            RuleFor(c => c.UpdatedDate)
                .NotNull()
                .Must(BeAUpdateDateIsValideDate).When(x=>x.UpdatedDate>x.CreatedDate)
                .WithName("DATA ATUALIZAÇÃO");
        }

        private bool BeAUpdateDateIsValideDate(DateTime? date)
        {
            if(date != null)
            {
                var updateDate = (DateTime)date;
                if (!DateTime.TryParse(updateDate.ToShortDateString(), new CultureInfo("pt-BR"), DateTimeStyles.None, out _))
                    return false;
                return true;
            }
            return true;
        }

    }
}
