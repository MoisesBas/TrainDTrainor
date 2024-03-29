﻿using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.CommandQuery.Models;

namespace TrainDTrainorV2.Core.Domain.CommitteeQuestion.Models
{
    
    public class CommitteeQuestionReadModel : EntityReadModel<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }       
        public int QuestionType { get; set; }
        public bool Selected { get; set; }
    }
}
