using Microsoft.AspNetCore.Mvc;
using WaterJugChallenge.Application.WaterJugChallenge.Models;
using WaterJugChallenge.Application.WaterJugChallenge.Services;
using WaterJugChallengeController.Controllers.WaterJugChallenge.Models;
using static WaterJugChallengeController.Controllers.WaterJugChallenge.Models.WaterJugChallengeRequest;

namespace WaterJugChallengeController.Controllers.WaterJugChallenge
{
    [ApiController]
    [Route("[controller]")]
    public class WaterJugChallengeController : ControllerBase, IWaterJugChallengeController
    {

        private readonly IWaterJugChallengeService _waterJugChallengeService;


        public WaterJugChallengeController(IWaterJugChallengeService waterJugChallengeService)
        {
            _waterJugChallengeService = waterJugChallengeService;
        }

        [HttpPost]
        public ActionResult<WaterJugChallengeResponse> Post([FromBody] WaterJugChallengePost waterJugChallengePost)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            WaterJugChallengeResponse response = new WaterJugChallengeResponse();
           
            try
            {
                List<WaterJugChallengeDTO> listWaterJugChallengeDTO = _waterJugChallengeService.CalculateSteps(waterJugChallengePost.x_capacity, waterJugChallengePost.y_capacity, waterJugChallengePost.z_amount_wanted);
                response.Solution = listWaterJugChallengeDTO;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return Ok(response);
        }
    }
}