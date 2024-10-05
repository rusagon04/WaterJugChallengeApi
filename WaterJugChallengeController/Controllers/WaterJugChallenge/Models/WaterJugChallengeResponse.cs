using WaterJugChallenge.Application.WaterJugChallenge.Models;

namespace WaterJugChallengeController.Controllers.WaterJugChallenge.Models
{
    public class WaterJugChallengeResponse
    {
        public string Message { get; set; } = "";
        public List<WaterJugChallengeDTO> Solution { get; set; } = new List<WaterJugChallengeDTO>();
    }
}
