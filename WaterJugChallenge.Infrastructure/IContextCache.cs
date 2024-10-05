using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterJugChallenge.Infrastructure
{
    public interface IContextCache<Dto>
    {
        List<Dto> Find();

        List<Dto> Find(Predicate<Dto> predicate);

        void Set(List<Dto> dtos);

        void SetCacheKey(string cacheKey);
    }
}
