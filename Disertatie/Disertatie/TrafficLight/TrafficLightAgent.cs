using System;
using System.Collections.Generic;
using System.Text;
using ActressMas;

namespace Disertatie
{
    public enum Color { RED, GREEN };
    abstract class TrafficLightAgent : Agent
    {
        // use a hashmap instead?
        private List<Road> roads;
        private Dictionary<string, Position> carPositions;
        private int id;
        private Color color;
        private int colorSwitchingTime;

        public TrafficLightAgent(int id)
        {
            this.id = id;
            this.Name = "TrafficLight_" + id;
            this.roads = new List<Road>();
            this.carPositions = new Dictionary<string, Position>();
            this.color = Color.RED;
            colorSwitchingTime = Utils.trafficLightColorSwitchingTime;
            logTheTrafficCreation();
        }

        public override void Act(Message message)
        {

            Console.WriteLine("\t[{1} -> {0}]: {2}", this.Name, message.Sender, message.Content);

            string[] parameters = message.Content.Split();

            string action = parameters[0];
            string source = parameters[1];

            switch (action)
            {

                case "comming":
                    handleComming(message.Sender, source);
                    break;
                case "leaving":
                    handleLeaving(message.Sender, source);
                    break;
                default:
                    break;
            }
        }

        private void handleLeaving(string sender, string source)
        {
            int roadStartingPoint = Int32.Parse(source);
            foreach (var road in roads)
            {

                if (road.getSource() == roadStartingPoint)
                {
                    road.removeCar(sender);
                }
            }
        }
        private void handleMove()
        {
            while(color == Color.GREEN)
            {
                foreach(var road in roads)
                {
                    string car = road.getFirstCar();
                    Road nextRoad = RouteCalculator.findBestRoad(roads);
                    Send("move", car + " " + nextRoad);
                }
            }
        }

        public void handleComming(string sender, string source)
        {
            int previousPosition = getPreviousPosition(source);
            foreach (var road in roads) {

                if (road.getSource() == previousPosition)
                {
                    road.addCar(sender);
                }
            }
        }

        private int getPreviousPosition(string position)
        {
            int startIndex = position.IndexOf('_');
            if (startIndex != -1)
            {
                position = position.Substring(startIndex, position.Length);
            }
            return Int32.Parse(position);
        }

        public int getId()
        {
            return id;
        }

        public void setRoads(List<Road> roads)
        {
            this.roads = roads;
            printRoadsToConsole();
        }

        public Boolean isOnTheLeftSide()
        {
            return this.id % 4 == 0;
        }

        public Boolean isOnTheRightSide()
        {
            return this.id % 4 == 3;
        }

        private void logTheTrafficCreation()
        {
            Console.WriteLine("create trafficLightAgent --> " + this.Name);
        }

        private void printRoadsToConsole()
        {
            Console.WriteLine("roads for " + this.id);
            foreach (var road in roads)
            {
                Console.WriteLine(road.getSource() + " --> " + road.getDestination() + " " + road.getDirection().ToString());
            }
        }

    }
}
