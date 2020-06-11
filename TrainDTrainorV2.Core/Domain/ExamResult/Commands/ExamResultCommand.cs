using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.Core.Domain.ExamResult.Models;

namespace TrainDTrainorV2.Core.Domain.ExamResult.Commands
{
    public class ExamResultCommand<TModel>: IRequest<IEnumerable<ExamResultReadModel>>
    {
        public ExamResultCommand(TModel exam)
        {
            Exam = exam;
        }
        public TModel Exam { get; set; }
    }
}
