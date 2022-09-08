using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ActressMas;
using System.Threading;

namespace Disertatie
{
    static class Program
    {
        static void Main()
        {
            TrafficEnvironment trafficEnvironment = new TrafficEnvironment();

            generateTrafficLights(trafficEnvironment);
            generateRoads(trafficEnvironment);
            generateCars(trafficEnvironment);
        }

        private static void generateTrafficLights(TrafficEnvironment environment)
        {
            //todo add also the upper road?
            Boolean isSimpleTrafficLight = true;
            TrafficLightFactory trafficLightFactory = new TrafficLightFactory(isSimpleTrafficLight);
            for(int i = 4; i < 20; i++)
            {
                TrafficLightAgent trafficLightAgent = trafficLightFactory.getTrafficLight(i);
                environment.addTrafficLight(trafficLightAgent);
            }
        }

        private static void generateRoads(TrafficEnvironment trafficEnvironment)
        {
            List<TrafficLightAgent> trafficLightAgents = trafficEnvironment.getTrafficLightAgents();

            foreach(var trafficLightAgent in trafficLightAgents)
            {
                List<Road> roads = new List<Road>();
                int trafficLightId = trafficLightAgent.getId();
                if (trafficLightAgent.isOnTheLeftSide())
                {
                    roads.Add(generateVerticalRoad(trafficLightId));
                    roads.Add(generateRightRoad(trafficLightId));
                    trafficLightAgent.setRoads(roads);
                    continue;
                }

                if (trafficLightAgent.isOnTheRightSide())
                {
                    roads.Add(generateVerticalRoad(trafficLightId));
                    roads.Add(generateLeftRoad(trafficLightId));
                    trafficLightAgent.setRoads(roads);
                    continue;
                }

                roads.Add(generateVerticalRoad(trafficLightId));
                roads.Add(generateRightRoad(trafficLightId));
                roads.Add(generateLeftRoad(trafficLightId));

                trafficLightAgent.setRoads(roads);
            }
        }
        private static Road generateVerticalRoad(int trafficLightId)
        {
            return new Road(trafficLightId - 4, trafficLightId, Direction.DOWN);
        }

        private static Road generateRightRoad(int trafficLightId)
        {
            return new Road(trafficLightId + 1, trafficLightId, Direction.RIGHT);
        }

        private static Road generateLeftRoad(int trafficLightId)
        {
            return new Road(trafficLightId - 1, trafficLightId, Direction.LEFT);
        }

        private static void generateCars(EnvironmentMas environment)
        {
            CarGenerator carGenerator0 = new CarGenerator(environment, 0, Utils.noOfCarsPerMinute[0], Utils.totalNoOfCars[0]);
            Thread thread0 = new Thread(new ThreadStart(carGenerator0.generateCar));
            thread0.Start();

            CarGenerator carGenerator1 = new CarGenerator(environment, 1, Utils.noOfCarsPerMinute[1], Utils.totalNoOfCars[1]);
            Thread thread1 = new Thread(new ThreadStart(carGenerator1.generateCar));
            thread1.Start();

            CarGenerator carGenerator2 = new CarGenerator(environment, 2, Utils.noOfCarsPerMinute[2], Utils.totalNoOfCars[2]);
            Thread thread2 = new Thread(new ThreadStart(carGenerator2.generateCar));
            thread2.Start();

            CarGenerator carGenerator3 = new CarGenerator(environment, 3, Utils.noOfCarsPerMinute[3], Utils.totalNoOfCars[3]);
            Thread thread3 = new Thread(new ThreadStart(carGenerator3.generateCar));
            thread3.Start();
        }
    }
}
