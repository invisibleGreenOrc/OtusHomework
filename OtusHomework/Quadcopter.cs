using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtusHomework
{
    public class Quadcopter : IFlyingRobot, IChargeable
    {
        private List<string> _components = new() { "rotor1", "rotor2", "rotor3", "rotor4" };

        public void Charge()
        {
            throw new NotImplementedException();
        }

        public List<string> GetComponents() => _components;

        public string GetInfo()
        {
            throw new NotImplementedException();
        }
    }
}
