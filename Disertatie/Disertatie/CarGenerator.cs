using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using ActressMas;

namespace Disertatie
{
    class CarGenerator
    {
        private EnvironmentMas environmentMas;
        private int entranceId;
        private int frequency;
        private int totalNoOfCars;
        private Random random = new Random();

        public CarGenerator(EnvironmentMas environmentMas, int entranceId, int noOfCarsPerMinute, int totalNoOfCars)
        {
            this.environmentMas = environmentMas;
            this.entranceId = entranceId;
            this.totalNoOfCars = totalNoOfCars;
            this.frequency = mapNoOfCarsPerMinuteToFrequency(noOfCarsPerMinute);
        }

        private int mapNoOfCarsPerMinuteToFrequency(int noOfCarsPerMinute)
        {
            int millisecondsInOneMinute = 60000;
            return millisecondsInOneMinute / noOfCarsPerMinute;
        }

        public void generateCar()
        {
            for(int i = 0; i < totalNoOfCars; i++)
            {
                String destination = getRandomDestination();
                CarAgent carAgent = new CarAgent(entranceId.ToString(), destination);
                environmentMas.Add(carAgent, "Car_" + entranceId + "_" + i);
                Console.WriteLine("generateCar --> " + carAgent.ToString() + " time: " + DateTime.Now.ToString("h:mm:ss tt"));
                Thread.Sleep(frequency);
            }
        }

        private String getRandomDestination()
        {
            return random.Next(4).ToString();
        }
    }
}
