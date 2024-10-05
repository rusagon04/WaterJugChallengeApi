using Microsoft.AspNetCore.Mvc;
using WaterJugChallengeController.Controllers.WaterJugChallenge.Models;
using static WaterJugChallengeController.Controllers.WaterJugChallenge.Models.WaterJugChallengeRequest;

namespace WaterJugChallengeController.Controllers.WaterJugChallenge
{
    public interface IWaterJugChallengeController
    {
        ActionResult<WaterJugChallengeResponse> Post([FromBody] WaterJugChallengePost waterJugChallengePost);
    }
}
