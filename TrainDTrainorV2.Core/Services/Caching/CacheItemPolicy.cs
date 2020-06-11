using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainDTrainorV2.Core.Services.Caching
{
    [Obsolete(
        "CacheItemPolicy was part of System.Runtime.Caching which is no longer used by LazyCache. " +
        "This class is a fake used to maintain backward compatibility and will be removed in a later version." +
        "Change to MemoryCacheEntryOptions instead")]
    public class CacheItemPolicy : MemoryCacheEntryOptions
    {
        public PostEvictionCallbackRegistration RemovedCallback => PostEvictionCallbacks.FirstOrDefault();
    }
}
