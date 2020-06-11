using Microsoft.EntityFrameworkCore.Migrations;
using TrainDTrainorV2.Core.BaseMigrations;
using TrainDTrainorV2.Core.Data.Entities;

namespace TrainDTrainorV2.Core.Migrations
{
    public partial class AddPaymentTransactionFile : CreateFiletable
    {
        protected override string TableName => typeof(PaymentTransactionPic).Name;

        protected override string DbName => "TrainDTrainor";
        protected override string JoinTableName => "tbl" + typeof(PaymentTransaction).Name + "s";
    }
}
