using System;
using System.Collections.Generic;
using ActressMas;
using System.Linq;

namespace Disertatie
{
    class CarAgent : Agent
    {
        private String currentRoadSource;
        private String currentRoadDestination;
        private String finalDestination;
        private Position position;

        public CarAgent(String currentRoadSource, String currentRoadDestination, String finalDestination, Position position)
        {
            this.currentRoadSource = currentRoadSource;
            this.currentRoadDestination = currentRoadDestination;
            this.finalDestination = finalDestination;
            this.position = position;
        }

        public override void Setup()
        {
            Console.WriteLine("Starting " + Name + " from " + currentRoadSource);

            Send("trafficLight_" + currentRoadDestination, "comming " + currentRoadSource);
        }

        public override void Act(Message message)
        {
            Console.WriteLine("\t[{1} -> {0}]: {2}", this.Name, message.Sender, message.Content);

            string[] parameters = message.Content.Split();

            string action = parameters[0];
            string nextDestination = parameters[1];

            switch (action)
            {
                case "move":
                    handleMove(message.Sender, nextDestination);
                    break;
                default:
                    break;
            }
        }

        private void handleMove(string currentTrafficLight, string nextDestination)
        {
            if(nextDestination == finalDestination)
            {
                Console.WriteLine(Name + " --> Reaching the final destination " + finalDestination);
            }
            else
            {
                Send(currentTrafficLight, "leaving " + currentRoadSource);
                Send("trafficLight_" + nextDestination, "comming " + currentTrafficLight);
            }
        }
    }
}
