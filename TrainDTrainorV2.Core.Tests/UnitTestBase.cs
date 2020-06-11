using System;
using System.Collections.Generic;
using System.Text;
using Xunit.Abstractions;

namespace TrainDTrainorV2.Core.Tests
{
    public abstract class UnitTestBase
    {
        protected UnitTestBase(ITestOutputHelper outputHelper)
        {
            OutputHelper = outputHelper;

        }

        public ITestOutputHelper OutputHelper { get; }
    }
}
