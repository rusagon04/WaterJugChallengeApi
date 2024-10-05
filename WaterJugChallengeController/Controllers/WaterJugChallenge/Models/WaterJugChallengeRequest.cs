using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WaterJugChallengeController.Controllers.WaterJugChallenge.Models
{
    public class WaterJugChallengeRequest
    {
        public class WaterJugChallengePost
        {            
            [DefaultValue(0)]
            [Range(0, int.MaxValue, ErrorMessage = "La capacidad de la jarra X debe ser un entero no negativo.")]
            public int x_capacity { get; set; } = 0;

            [DefaultValue(0)]
            [Range(0, int.MaxValue, ErrorMessage = "La capacidad de la jarra Y debe ser un entero no negativo.")]
            public int y_capacity { get; set; } = 0;

            [DefaultValue(0)]
            [Range(0, int.MaxValue, ErrorMessage = "La capacidad de la jarra Z debe ser un entero no negativo.")]
            public int z_amount_wanted { get; set; } = 0;
        }
    }
}
