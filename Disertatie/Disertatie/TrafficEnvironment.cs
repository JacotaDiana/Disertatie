using System;
using System.Collections.Generic;
using System.Text;
using ActressMas;

namespace Disertatie
{
    class TrafficEnvironment : EnvironmentMas
    {
        private List<TrafficLightAgent> trafficLights;
        private List<Road> roads;
        //private List<List<int>> adjacencyList;

        public List<TrafficLightAgent> getTrafficLightAgents()
        {
            return trafficLights;
        }

        public TrafficEnvironment()
        {
            trafficLights = new List<TrafficLightAgent>();
            //adjacencyList = new List<List<int>>();
        }

        public void addTrafficLight(TrafficLightAgent trafficLightAgent)
        {
            trafficLights.Add(trafficLightAgent);
            this.Add(trafficLightAgent, trafficLightAgent.Name);
        }
    }
}
