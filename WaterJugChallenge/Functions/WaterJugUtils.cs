using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterJugChallenge.Application.WaterJugChallenge.Models;

namespace WaterJugChallenge.Application.Functions
{
    public class WaterJugUtils
    {
        public static WaterJugChallengeDTO PerformJugAction(ref int sourceJugVolume, ref int targetJugVolume, int sourceJugCapacity, int targetJugCapacity, string sourceJugName, string targetJugName)
        {
            WaterJugChallengeDTO stepDTO = new WaterJugChallengeDTO();

            // Si el jarrón actual está vacío, lo llenamos
            if (sourceJugVolume == 0)
            {
                sourceJugVolume = sourceJugCapacity;
                stepDTO.Action = $"Fill bucket {sourceJugName}";
            }
            // Si el otro jarrón está lleno, lo vaciamos
            else if (targetJugVolume == targetJugCapacity)
            {
                targetJugVolume = 0;
                stepDTO.Action = $"Empty bucket {targetJugName}";
            }
            // Transferimos del jarrón actual al otro sin exceder la capacidad
            else
            {
                int transferAmount = Math.Min(sourceJugVolume, targetJugCapacity - targetJugVolume);
                sourceJugVolume -= transferAmount;
                targetJugVolume += transferAmount;
                stepDTO.Action = $"Transfer from bucket {sourceJugName} to bucket {targetJugName}";
            }

            stepDTO.BucketX = sourceJugName == "X" ? sourceJugVolume : targetJugVolume;
            stepDTO.BucketY = sourceJugName == "X" ? targetJugVolume : sourceJugVolume;

            return stepDTO;
        }

        public static int GCD(int x, int y)
        {
            while (y != 0)
            {
                int temp = y;
                y = x % y;
                x = temp;
            }

            return x;
        }
    }
}
