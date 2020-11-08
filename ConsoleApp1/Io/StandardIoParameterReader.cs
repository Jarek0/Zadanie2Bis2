using System;
using System.Globalization;
using ConsoleApp1.Equations;

namespace ConsoleApp1.Io
{
    public class StandardIoParameterReader: IEquationParameterProvider
    {
        public double Provide(string parameterName)
        {
            for (;;)
            {
                Console.WriteLine($"Podaj współczynnik {parameterName} równania");
                string userInput = Console.ReadLine();
                if (double.TryParse(userInput, 
                    NumberStyles.Any, 
                    CultureInfo.InvariantCulture, 
                    out var result))
                {
                    return result;
                }
                Console.WriteLine("Nie udało się podać współczynnika równania. Być może wpisana wartość nie jest liczbą. Spróbuj ponownie.");
            }
        }
    }
}