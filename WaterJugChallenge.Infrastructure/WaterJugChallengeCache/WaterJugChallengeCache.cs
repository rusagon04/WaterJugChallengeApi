using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterJugChallenge.Infrastructure.WaterJugChallengeCache
{
    public class WaterJugChallengeCache<Dto> : ContextCache<Dto>
    {
        public WaterJugChallengeCache(IMemoryCache memoryCache) : base(memoryCache)
        {

        }
    }
}
