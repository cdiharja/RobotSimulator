using RobotSimulator.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotSimulator.Model
{
    public class Robot : IMoveable
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Direction Direction { get; set; }

        public Robot() {
            X = int.MinValue;
            Y = int.MinValue;
        }

        public void SetPosition(int x, int y, Direction direction)
        {
            X = x;
            Y = y;
            Direction = direction;
        }
    }
}
