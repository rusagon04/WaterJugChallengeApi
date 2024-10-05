using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterJugChallenge.Application.Functions;
using WaterJugChallenge.Application.WaterJugChallenge.Models;
using WaterJugChallenge.Infrastructure;

namespace WaterJugChallenge.Application.WaterJugChallenge.Services
{
    public class WaterJugChallengeService : IWaterJugChallengeService
    {
        private readonly IContextCache<WaterJugChallengeDTO> _WaterJugChallengeCache;
        public WaterJugChallengeService(IContextCache<WaterJugChallengeDTO> WaterJugChallengeCache) 
        {
            _WaterJugChallengeCache = WaterJugChallengeCache;
        }

        public List<WaterJugChallengeDTO> CalculateSteps(int x, int y, int z)
        {
            string cacheKey = $"WaterJugChallenge_{x}_{y}_{z}";
            
            _WaterJugChallengeCache.SetCacheKey(cacheKey);

            List<WaterJugChallengeDTO> listWaterJugChallengeCache = _WaterJugChallengeCache.Find();

            if (!listWaterJugChallengeCache.Any())
            {
                if (z > x && z > y || z % WaterJugUtils.GCD(x, y) != 0)
                {
                    throw new("No solution possible. Display “No Solution”");
                }

                List<WaterJugChallengeDTO> listWaterJugChallengeDTO = new List<WaterJugChallengeDTO>();

                bool startWithX = Math.Abs(x - z) <= Math.Abs(y - z);

                int jugXVolume = 0, jugYVolume = 0, currentStep = 0;

                while (jugXVolume != z && jugYVolume != z)
                {
                    WaterJugChallengeDTO waterJugChallengeDTO = startWithX ? WaterJugUtils.PerformJugAction(ref jugXVolume, ref jugYVolume, x, y, "X", "Y") : WaterJugUtils.PerformJugAction(ref jugYVolume, ref jugXVolume, y, x, "Y", "X");

                    waterJugChallengeDTO.Step = ++currentStep;

                    if (jugXVolume == z || jugYVolume == z)
                    {
                        waterJugChallengeDTO.Status = "Solved";

                    }

                    listWaterJugChallengeDTO.Add(waterJugChallengeDTO);

                }

                _WaterJugChallengeCache.Set(listWaterJugChallengeDTO);
                return listWaterJugChallengeDTO;
            }

            return listWaterJugChallengeCache;
        }
    }
}
