

namespace Need_For_Speed_3
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Collections.Generic;
    using System.Numerics;
    using System.Linq;
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> carsMileAges = new Dictionary<string, int>();
            Dictionary<string, int> carsFuel = new Dictionary<string, int>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] carData = Console.ReadLine()
                    .Split('|');
                string carName = carData[0];
                int mileAge = int.Parse(carData[1]);
                int fuel = int.Parse(carData[2]);
                carsMileAges.Add(carName, mileAge);
                carsFuel.Add(carName, fuel);
            }

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Stop")
            {
                string[] inputParameters = command.Split(" : ");
                string commandType = inputParameters[0];
                string carName = inputParameters[1];

                if (commandType == "Drive")
                {
                    int distance = int.Parse(inputParameters[2]);
                    int fuel = int.Parse(inputParameters[3]);

                    if (carsFuel[carName] >= fuel)
                    {
                        carsMileAges[carName] += distance;
                        carsFuel[carName] -= fuel;
                        Console.WriteLine($"{carName} driven for {distance} kilometers. {fuel} liters of fuel consumed.");
                    }
                    else
                    {
                        Console.WriteLine($"Not enough fuel to make that ride");
                    }

                    if (carsMileAges[carName] >= 100000)
                    {
                        Console.WriteLine($"Time to sell the {carName}!");
                        carsMileAges.Remove(carName);
                        carsFuel.Remove(carName);
                    }

                }
                else if (commandType == "Refuel")
                {
                    int fuel = int.Parse(inputParameters[2]);
                    

                    if (carsFuel[carName] + fuel > 75)
                    {
                        Console.WriteLine($"{carName} refueled with {75 - carsFuel[carName]} liters");
                        carsFuel[carName] = 75;
                    }
                    else
                    {
                        Console.WriteLine($"{carName} refueled with {fuel} liters");
                        carsFuel[carName] += fuel;
                    }

                }
                else if(commandType == "Revert")
                {
                    int kilometers = int.Parse(inputParameters[2]);
                    carsMileAges[carName] -= kilometers;
                    
                    if (carsMileAges[carName] < 10000)
                    {
                        carsMileAges[carName] = 10000;
                    }
                    else
                    {
                        Console.WriteLine($"{carName} mileage decreased by {kilometers} kilometers");
                    }

                }

            }

            foreach (var (carName, mileAge) in carsMileAges)
            {
                Console.WriteLine($"{carName} -> Mileage: {mileAge} kms, Fuel in the tank: {carsFuel[carName]} lt.");
            }
        }
    }
}
