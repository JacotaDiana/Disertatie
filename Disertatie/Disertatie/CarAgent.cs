using System;
using System.Collections.Generic;
using System.Text;
using ActressMas;

namespace Disertatie
{
    class CarAgent : Agent
    {
        private String startingPoint;
        private String destination;

        public CarAgent(String startingPoint, String destination)
        {
            this.startingPoint = startingPoint;
            this.destination = destination;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
