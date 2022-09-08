using System;
using System.Collections.Generic;
using System.Text;

namespace Disertatie
{
    class RouteCalculator
    {
        public static Road findBestRoad(List<Road> roads)
        {
            double costMin = Double.MaxValue;
            Road bestRoad = null; //todo do not leave null in code!
            foreach(var road in roads)
            {
                double cost = computeCost(road.getMaxSpeed(), road.getCurrentNoOfCars(), road.getMaximNoOfCars());
                if(cost < costMin)
                {
                    costMin = cost;
                    bestRoad = road;
                }
            }

            return bestRoad;
        }

        private static double computeCost(int maxSpeed, int currentNoOfCars, int maxNoOfCars)
        {
            int speed = maxSpeed * (1 - (currentNoOfCars / maxNoOfCars));
            return (Utils.roadLength / speed);
        }
    }
}
