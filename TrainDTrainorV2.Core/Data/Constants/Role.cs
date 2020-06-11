using System;
using System.Collections.Generic;
using System.Text;

namespace TrainDTrainorV2.Core.Data.Constants
{
    public static class Role
    {
       
        public static readonly Guid Trainee = new Guid("d373fbb2-39eb-e711-87c1-708bcd56aa6d");       
        public static readonly Guid Trainor = new Guid("808c0ec0-39eb-e711-87c1-708bcd56aa6d");      
        public static readonly Guid Administrator = new Guid("8fa6aec8-39eb-e711-87c1-708bcd56aa6d");

        public const string MemberName = "Trainee";
        public const string TrainorName = "Trainor";
        public const string AdministratorName = "Administrator";     

    }
}
