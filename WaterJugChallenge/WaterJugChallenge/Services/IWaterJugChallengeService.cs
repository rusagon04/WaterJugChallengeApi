using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterJugChallenge.Application.WaterJugChallenge.Models;

namespace WaterJugChallenge.Application.WaterJugChallenge.Services
{
    public interface IWaterJugChallengeService
    {
        List<WaterJugChallengeDTO> CalculateSteps(int x, int y, int z);
    }
}
