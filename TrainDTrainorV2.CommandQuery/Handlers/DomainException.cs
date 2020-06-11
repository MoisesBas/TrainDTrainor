using System;
using System.Runtime.Serialization;

namespace TrainDTrainorV2.CommandQuery.Handlers
{
    [Serializable]
    internal class DomainException : Exception
    {
        private int v1;
        private string v2;

        public DomainException()
        {
        }

        public DomainException(string message) : base(message)
        {
        }

        public DomainException(int v1, string v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }

        public DomainException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DomainException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}