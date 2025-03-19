﻿using FluentValidation;
using OnionPortfolioBe.Application.Features.MediatR.AboutSlice.Commands.CreateAbout;

namespace OnionPortfolioBe.Application.Validations.About;

public class CreateAboutValidator : AbstractValidator<CreateAboutRequest>
{
    public CreateAboutValidator()
    {
        RuleFor(x => x.Title)
               .NotEmpty()
               .NotNull()
               .WithMessage("Title is required.");

        RuleFor(x => x.Description)
               .NotEmpty()
               .NotNull()
               .WithMessage("Description is required.");

        RuleFor(x => x.Birthday)
               .NotEmpty()
               .NotNull()
               .WithMessage("Birthday is required.");

        RuleFor(x => x.Age)
               .NotEmpty()
               .NotNull()
               .GreaterThanOrEqualTo(10)
               .WithMessage("Age is required.");

        RuleFor(x => x.Website)
               .NotEmpty()
               .NotNull()
               .WithMessage("Website is required.");

        RuleFor(x => x.Degree)
               .NotEmpty()
               .NotNull()
               .WithMessage("Degree is required.");

        RuleFor(x => x.Phone)
               .NotEmpty()
               .NotNull()
               .WithMessage("Phone is required.");

        RuleFor(x => x.Email)
               .NotEmpty()
               .NotNull()
               .WithMessage("Email is required.");

        RuleFor(x => x.City)
               .NotEmpty()
               .NotNull()
               .WithMessage("City is required.");
        
        RuleFor(x => x.IsFreelanceAvailable)
               .NotEmpty()
               .NotNull()
               .WithMessage("IsFreelanceAvailable is required.");
            
    }
}

