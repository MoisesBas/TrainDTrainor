using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.Core.Domain.JobHistory.Models;

namespace TrainDTrainorV2.Core.Domain.JobHistory.Validation
{
    public class JobHistoryUpdateModelValidator: AbstractValidator<JobHistoryUpdateModel>
    {
        public JobHistoryUpdateModelValidator()
        {           
            RuleFor(p => p.UserProfileId).NotEmpty();
            RuleFor(p => p.Position).NotEmpty();
            RuleFor(p => p.Position).MaximumLength(150);
            RuleFor(p => p.CompanyName).NotEmpty();
            RuleFor(p => p.CompanyName).MaximumLength(150);
        }
    }
}
