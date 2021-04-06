using System.Security.Cryptography;

namespace rngTryout
{
    class Round
    {
        readonly byte allNumbersRange;
        readonly byte selectedNumbersRange;
        public Round(byte selectedNumbersRange, byte allNumbersRange)
        {
            this.allNumbersRange = allNumbersRange;
            this.selectedNumbersRange = selectedNumbersRange;

        }

        public byte[] DrawNumbers()
        {
            byte[] allAvailableNumbers = CreateAllAvailableNumbers(allNumbersRange);
            byte[] drawnNumbers = new byte[selectedNumbersRange];
            var selectionRange = allNumbersRange;

            for (int i = 0; i < selectedNumbersRange; i++)
            {
                byte randomIndex = RandomIndexGenerator((decimal)(selectionRange));
                drawnNumbers[i] = allAvailableNumbers[randomIndex];

                for (int j = randomIndex; j < allAvailableNumbers.Length - 1; j++)
                {
                    allAvailableNumbers[j] = allAvailableNumbers[j + 1];
                }
                selectionRange--;
            }

            RandomNumGenerator.Dispose();
            return drawnNumbers;
        }

        public byte[] CreateAllAvailableNumbers(byte range)
        {
            byte [] numsArray = new byte[range];
            for (byte i = 0; i < range; i++)
            {
                numsArray[i] = (byte)(i + 1);
            }

            return numsArray;
        }

        private readonly static RNGCryptoServiceProvider RandomNumGenerator = new RNGCryptoServiceProvider();
        public static byte RandomIndexGenerator(decimal range)
        {
            decimal k = 256M / range;
            byte[] randomNumber = new byte[1];
            RandomNumGenerator.GetBytes(randomNumber);
            return (byte)(randomNumber[0] / k);



        }
        
    }
}
