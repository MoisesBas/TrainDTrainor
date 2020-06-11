using System;
using System.Collections.Generic;
using System.Text;

namespace TrainDTrainorV2.Core.Security
{
    public interface IPasswordHasher
    {        
        string HashPassword(string password);        
        bool VerifyPassword(string hashedPassword, string password);
    }
}
