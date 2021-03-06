﻿using System;
using TrainDTrainorV2.CommandQuery.Models;

namespace TrainDTrainorV2.Core.Domain.Models
{
    public class UserUpdateModel : EntityUpdateModel
    {
        #region Generated Properties
        public string EmailAddress { get; set; }
        public bool IsEmailAddressConfirmed { get; set; }
        public string DisplayName { get; set; }
        public string ResetHash { get; set; }
        public string InviteHash { get; set; }
        public int AccessFailedCount { get; set; }
        public bool LockoutEnabled { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public DateTimeOffset? LastLogin { get; set; }
        public Guid? LastOrganizationId { get; set; }
        public bool IsGlobalAdministrator { get; set; }

        #endregion
    }
}
