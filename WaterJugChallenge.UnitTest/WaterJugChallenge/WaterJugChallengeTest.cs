using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterJugChallenge.Application.WaterJugChallenge.Services;
using Xunit;
using ControllerWaterJugChallenge = WaterJugChallengeController.Controllers.WaterJugChallenge;
using WaterJugChallenge.Application.WaterJugChallenge.Models;
using WaterJugChallengeController.Controllers.WaterJugChallenge.Models;
using static WaterJugChallenge.UnitTest.UtilsTest;


namespace WaterJugChallenge.UnitTest.WaterJugChallenge
{
    public class WaterJugChallengeTest
    {
        private readonly Mock<IWaterJugChallengeService> mockWaterJugChallengeService;

        public WaterJugChallengeTest()
        {
            mockWaterJugChallengeService = new Mock<IWaterJugChallengeService>();
        }

        [Fact]
        public void Test_Post()
        {
            mockWaterJugChallengeService.Reset();
            mockWaterJugChallengeService.Setup(mock => mock.CalculateSteps(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(new List<WaterJugChallengeDTO>()
            {
                new WaterJugChallengeDTO()
                {
                    Step = 0,                    
                    BucketX = 2,
                    BucketY = 3,
                    Action = "",
                    Status = "",   
                }
            });

            ControllerWaterJugChallenge.WaterJugChallengeController controller = new ControllerWaterJugChallenge.WaterJugChallengeController(mockWaterJugChallengeService.Object);

            ActionResult<WaterJugChallengeResponse> response = controller.Post(new WaterJugChallengeRequest.WaterJugChallengePost());

            Assert.IsType<OkObjectResult>(response.Result);
            OkObjectResult result = (OkObjectResult)response.Result;

            Assert.IsType<WaterJugChallengeResponse>(result.Value);
            WaterJugChallengeResponse waterJugChallengeResponse = (WaterJugChallengeResponse)result.Value;

            Assert.True(waterJugChallengeResponse.Solution.Count > 0);
            Assert.Equal("", waterJugChallengeResponse.Message);
        }

        [Fact]
        public void Test_Bad_Post()
        {
            mockWaterJugChallengeService.Reset();
            ControllerWaterJugChallenge.WaterJugChallengeController controller = new ControllerWaterJugChallenge.WaterJugChallengeController(mockWaterJugChallengeService.Object);
            controller.ModelState.AddModelError("FakeError", "Fake error in model state");

            ActionResult<WaterJugChallengeResponse> response = controller.Post(new WaterJugChallengeRequest.WaterJugChallengePost());

            Assert.IsType<BadRequestObjectResult>(response.Result);
        }

        [Fact]
        public void Test_Post_Exception()
        {
            mockWaterJugChallengeService.Reset();
            mockWaterJugChallengeService.Setup(mock => mock.CalculateSteps(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Throws(exception);

            ControllerWaterJugChallenge.WaterJugChallengeController controller = new ControllerWaterJugChallenge.WaterJugChallengeController(mockWaterJugChallengeService.Object);

            ActionResult<WaterJugChallengeResponse> response = controller.Post(new WaterJugChallengeRequest.WaterJugChallengePost());

            Assert.IsType<OkObjectResult>(response.Result);
            OkObjectResult result = (OkObjectResult)response.Result;

            Assert.IsType<WaterJugChallengeResponse>(result.Value);
            WaterJugChallengeResponse waterJugChallengeResponse = (WaterJugChallengeResponse)result.Value;

            Assert.True(waterJugChallengeResponse.Solution.Count <= 0);
            Assert.Equal(exception.Message, waterJugChallengeResponse.Message);

        }
    }
}
