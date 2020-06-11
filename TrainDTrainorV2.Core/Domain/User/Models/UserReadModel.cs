using System;
using TrainDTrainorV2.CommandQuery.Models;
using TrainDTrainorV2.Core.Domain.UserRole.Models;

namespace TrainDTrainorV2.Core.Domain.Models
{
    public class UserReadModel : EntityReadModel<Guid>
    {
        #region Generated Properties
        public string EmailAddress { get; set; }
        public bool IsEmailAddressConfirmed { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsPhoneNumberConfirmed { get; set; }
        public string DisplayName { get; set; }
        public string ResetHash { get; set; }
        public string InviteHash { get; set; }
        public int AccessFailedCount { get; set; }
        public bool LockoutEnabled { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public DateTimeOffset? LastLogin { get; set; }
        public Guid? LastOrganizationId { get; set; }
        public bool IsGlobalAdministrator { get; set; }
        public bool IsAgree { get; set; }
        public string OTP { get; set; }
        public string Course { get; set; }
        public UserRoleReadModel Roles { get; set; }
        public string Gender { get; set; }

        #endregion
    }
}
