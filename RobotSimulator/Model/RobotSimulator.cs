using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotSimulator.Model
{
    public class RobotSimulator
    {
        private Robot robot;
        public int BoardSizeX { get; set; }
        public int BoardSizeY  { get; set; }
        public bool IsActive { get; set; }

        public RobotSimulator(int boarSizeX,int boardSizeY)
        {
            robot = new Robot();
            BoardSizeX = boarSizeX;
            BoardSizeY = boardSizeY;
            IsActive = false;
        }
        public bool IsValidMovement(int nextX, int nextY) 
        {   if (nextX < 0 || nextX >= BoardSizeX || nextY < 0 || nextY >= BoardSizeY) return false;
            return true;
        }
        public void SetPosition(int x, int y, Direction direction)
        {   if (IsValidMovement(x, y))
            {
                robot.SetPosition(x, y, direction);
                IsActive = true;
            }
        }

        public void MoveForward()
        {   if (!IsActive) return;
            switch(robot.Direction)
            {
                case Direction.EAST:
                    SetPosition(robot.X+1, robot.Y, Direction.EAST);
                    break;
                case Direction.NORTH:
                    SetPosition(robot.X, robot.Y+1, Direction.NORTH);
                    break;
                case Direction.WEST:
                    SetPosition(robot.X-1, robot.Y, Direction.WEST);
                    break;
                case Direction.SOUTH:
                    SetPosition(robot.X, robot.Y-1, Direction.SOUTH);
                    break;
            }
        }

        public void TurnLeft()
        {
            if (!IsActive) return;
            switch (robot.Direction)
            {
                case Direction.EAST:
                    SetPosition(robot.X, robot.Y, Direction.NORTH);
                    break;
                case Direction.NORTH:
                    SetPosition(robot.X, robot.Y , Direction.WEST);
                    break;
                case Direction.WEST:
                    SetPosition(robot.X, robot.Y, Direction.SOUTH);
                    break;
                case Direction.SOUTH:
                    SetPosition(robot.X, robot.Y, Direction.EAST);
                    break;
            }
        }

        public void TurnRight()
        {
            if (!IsActive) return;
            switch (robot.Direction)
            {
                case Direction.EAST:
                    SetPosition(robot.X, robot.Y, Direction.SOUTH);
                    break;
                case Direction.NORTH:
                    SetPosition(robot.X, robot.Y, Direction.EAST);
                    break;
                case Direction.WEST:
                    SetPosition(robot.X, robot.Y, Direction.NORTH);
                    break;
                case Direction.SOUTH:
                    SetPosition(robot.X, robot.Y, Direction.WEST);
                    break;
            }
        }

        public string ReportPosition()
        {
            if (!IsActive) return String.Empty;
            return $"{robot.X},{robot.Y},{robot.Direction.ToString()}";
        }
    }
}
