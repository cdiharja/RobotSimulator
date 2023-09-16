using RobotSimulator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotSimulator.Interface
{
    internal interface IMoveable
    {
        public void SetPosition(int x, int y, Direction direction);
    }
}
