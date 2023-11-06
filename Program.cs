using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

class TemperatureSensor
{
    private Random random = new Random();

    public double? GenerateSingleValue()
    {
        double temperature = random.NextDouble() * 200 - 100;

        if (temperature < -80)
        {
            return null;
        }

        return temperature;
    }

    public List<double?> GenerateNValues(int N)
    {
        List<double?> values = new List<double?>();

        for (int i = 0; i < N; i++)
        {
            double? temperature = GenerateSingleValue();
            values.Add(temperature);
        }

        return values;
    }
}

class Program
{
    static void Main(string[] args)
    {
        TemperatureSensor sensor = new TemperatureSensor();

        Console.WriteLine("Generowanie pojedynczej wartości:");
        double? singleValue = sensor.GenerateSingleValue();
        if (singleValue.HasValue)
        {
            Console.WriteLine($"Wygenerowana temperatura: {singleValue.Value}");
        }
        else
        {
            Console.WriteLine("Błąd odczytu temperatury.");
        }

        Console.WriteLine("\nGenerowanie N wartości:");
        Console.Write("Podaj liczbę N: ");
        //Zad. 3
        if (int.TryParse(Console.ReadLine(), out int N))
        {
            List<double?> values = sensor.GenerateNValues(N);
            Console.WriteLine("Wygenerowane temperatury:");
            //Zad. 4
            using (StreamWriter sw = new StreamWriter("C:\\Users\\BUGI\\Desktop\\INFA\\!SEM2\\.Net\\Lab1\\Data.txt"))
            {
                foreach (var value in values)
                {
                    if (value.HasValue)
                    {
                        //Zad. 2
                        string result = String.Format("{0,7:0.00}", value.Value);
                        Console.WriteLine(result);
                        sw.WriteLine(result);
                    }
                    else
                    {
                        Console.WriteLine("Błąd odczytu temperatury.");
                    }
                }
            }
        }
        else
        {
            Console.WriteLine("Błędna liczba.");
        }
    }
}

