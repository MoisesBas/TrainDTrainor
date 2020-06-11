﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TrainDTrainorV2.Core.Data.Entities
{
    public partial class TrainingExperience
    {
        public TrainingExperience()
        {
            Created = DateTimeOffset.UtcNow;
            Updated = DateTimeOffset.UtcNow;
        }
        public Guid Id { get; set; }
        public string CourseName { get; set; }
        public string Location { get; set; }
        public int Attended { get; set; }
        public int Year { get; set; }
        public Guid? UserProfileId { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTimeOffset Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTimeOffset Updated { get; set; }
        public string UpdatedBy { get; set; }
        public Byte[] RowVersion { get; set; }
        public virtual UserProfile UserProfile { get; set; }
    }
}