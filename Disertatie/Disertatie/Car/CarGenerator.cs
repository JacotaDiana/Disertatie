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

        //todo: refactor this. Find a better place to add the car to the environment
        public void generateCar()
        {
            for(int i = 0; i < totalNoOfCars; i++)
            {
                String finalDestination = getRandomDestination();
                CarAgent carAgent = new CarAgent(entranceId.ToString(), (entranceId + 4).ToString(), finalDestination, new Position(entranceId, 0));
                environmentMas.Add(carAgent, "Car_" + entranceId + "_" + i);
                printToConsole(carAgent);
                Thread.Sleep(frequency);
            }
        }

        private String getRandomDestination()
        {
            return random.Next(4).ToString();
        }

        private void printToConsole(CarAgent carAgent)
        {
            Console.WriteLine("generateCar --> " + carAgent.Name + " time: " + DateTime.Now.ToString("h:mm:ss tt"));
        }
    }
}
