using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TrainDTrainorV2.Core.Domain.Models;

namespace TrainDTrainorV2.Core.Services
{
    public interface IEmailTemplateService
    {
        Task<bool> SendResetPasswordEmail(UserResetPasswordEmail resetPassword);
    }
}
