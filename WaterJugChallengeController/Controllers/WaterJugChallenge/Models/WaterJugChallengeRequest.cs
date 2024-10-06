using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WaterJugChallengeController.Controllers.WaterJugChallenge.Models
{
    public class WaterJugChallengeRequest
    {
        public class WaterJugChallengePost
        {            
            [DefaultValue(0)]
            [Range(0, int.MaxValue, ErrorMessage = "The capacity of jar X must be a non-negative integer")]
            public int x_capacity { get; set; } = 0;

            [DefaultValue(0)]
            [Range(0, int.MaxValue, ErrorMessage = "The capacity of jar Y must be a non-negative integer")]
            public int y_capacity { get; set; } = 0;

            [DefaultValue(0)]
            [Range(0, int.MaxValue, ErrorMessage = "The capacity of jar Z must be a non-negative integer")]
            public int z_amount_wanted { get; set; } = 0;
        }
    }
}
