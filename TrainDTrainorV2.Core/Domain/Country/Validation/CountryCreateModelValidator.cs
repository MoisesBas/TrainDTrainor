using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.Core.Domain.Role.Models;

namespace TrainDTrainorV2.Core.Domain.Country.Validation
{
    public class CountryCreateModelValidator : AbstractValidator<CountryCreateModel>
    {
        public CountryCreateModelValidator()
        {
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.Name).MaximumLength(256);           
            RuleFor(p => p.Code).MaximumLength(256);

        }
    }
}
