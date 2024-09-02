namespace GestaoDeRH.Dominio.Validators;
using FluentValidation;
using GestaoDeRH.Dominio.Pessoas;

public class ColaboradorValidator : AbstractValidator<Colaborador>
{
    public ColaboradorValidator()
    {
        RuleFor(c => c.Nome)
            .NotEmpty().WithMessage("Por favor, preencha o campo de nome com caracteres alfabéticos.");

        RuleFor(c => c.Sobrenome)
            .NotEmpty().WithMessage("Por favor, preencha o campo de sobrenome com caracteres alfabéticos.");

        RuleFor(c => c.Email)
            .EmailAddress().WithMessage("Por favor, preencha o campo de email com um email válido.");
        
        RuleFor(c => c.DataDeNascimento)
            .Must(dataNascimento => dataNascimento.AddYears(18) <= DateTime.Now).WithMessage("Por favor, insira sua data de nascimento e certifique-se de ter pelo menos 18 anos.")
            .NotEmpty().WithMessage("Por favor, insira sua data de nascimento e certifique-se de ter pelo menos 18 anos.");

        RuleFor(c => c.CPF)
            .Matches(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$").WithMessage("Por favor, preencha o campo de CPF com caracteres numéricos.");

        RuleFor(c => c.Cargo)
            .NotEmpty().WithMessage("Por favor, especifique o cargo do colaborador.");

        RuleFor(c => c.Salario)
            .GreaterThan(0).WithMessage("Por favor, insira o salário do colaborador.");
        
        RuleFor(c => c.DataFimContratoDeTrabalho)
            .Must((colaborador, dataDemissao) => dataDemissao == null || dataDemissao > colaborador.DataFimContratoDeTrabalho).WithMessage("Por favor, insira sua data de nascimento e certifique-se de ter pelo menos 18 anos.")
            .NotEmpty().WithMessage( "A data de término do contrato deve ser posterior à data de início do contrato.");


    }

}
