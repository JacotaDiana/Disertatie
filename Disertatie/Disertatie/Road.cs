using System;
using System.Collections.Generic;
using System.Text;

namespace Disertatie
{
    public enum Direction { LEFT, RIGHT, DOWN, UP};
    class Road
    {
        int maximNoOfCars;
        int maximSpeed;
        int source;
        int destination;
        int currentNoOfCars;
        Direction direction;
        LinkedList<string> cars;

        const int defauldNoOfCars = 100;
        const int defaultMaximumSpeed = 50;

        public Road(int source, int destination, Direction direction)
        {
            this.source = source;
            this.destination = destination;
            this.direction = direction;
            maximNoOfCars = defauldNoOfCars;
            maximSpeed = defaultMaximumSpeed;
            currentNoOfCars = 0;
        }

        public Road(int source, int destination, int maximNoOfCars, int maximSpeed)
        {
            this.source = source;
            this.destination = destination;
            this.maximNoOfCars = maximNoOfCars;
            this.maximSpeed = maximSpeed;
        }

        public void addCar(String car)
        {
            cars.AddLast(car);
            currentNoOfCars++;
        }

        public void removeCar(String car)
        {
            cars.Remove(car);
            currentNoOfCars--;
        }

        public string getFirstCar()
        {
            return cars.First.Value;
        }

        public int getSource()
        {
            return source;
        }
        
        public int getDestination()
        {
            return destination;
        }

        public Direction getDirection()
        {
            return direction;
        }

        public int getCurrentNoOfCars()
        {
            return currentNoOfCars;
        }

        public int getMaxSpeed()
        {
            return maximSpeed;
        }

        public int getMaximNoOfCars()
        {
            return maximNoOfCars;
        }

        public bool isRoadFullyOcupied()
        {
            return maximNoOfCars == currentNoOfCars;
        }
    }
}
