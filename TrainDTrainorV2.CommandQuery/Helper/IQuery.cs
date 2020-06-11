using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace TrainDTrainorV2.CommandQuery.Helper
{
    public interface IQuery<T>
    {
        IQueryable<T> Filter(IQueryable<T> items);
         string IncludeProperties { get; set; }
    }
}
