using System;
using System.Collections.Generic;
using System.Text;

namespace Disertatie
{
    class TrafficLightFactory
    {
        // todo: refactor this after UI is thought-out
        // should we allow a mix between these two types of traffic lights?
        Boolean isSimpleTrafficLight;

        public TrafficLightFactory(Boolean isSimpleTrafficLight)
        {
            this.isSimpleTrafficLight = isSimpleTrafficLight;
        }

        
        public TrafficLightAgent getTrafficLight(int id)
        {
            if (isSimpleTrafficLight)
            {
                return new SimpleTrafficLightAgent(id);
            }

            return new SmartTrafficLightAgent(id);
        }
    }
}
