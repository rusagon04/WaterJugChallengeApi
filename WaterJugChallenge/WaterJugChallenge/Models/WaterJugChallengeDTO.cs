using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterJugChallenge.Application.WaterJugChallenge.Models
{
    public class WaterJugChallengeDTO
    {
        public int Step { get; set; } = 0;
        public int BucketX { get; set; } = 0;
        public int BucketY { get; set; } = 0;
        public string Action { get; set; } = "";
        public string Status { get; set; } = "";
    }
}
