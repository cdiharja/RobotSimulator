using System.ComponentModel.Design;
using RobotSimulator.Model;

namespace RobotTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMoveForward()
        {
            var simulator = new RobotSimulator.Model.RobotSimulator(5,5);
            simulator.SetPosition(2, 2, Direction.NORTH);
            simulator.MoveForward();
            var result = simulator.ReportPosition();
            Assert.AreEqual("2,3,NORTH", result);
        }


        [TestMethod]
        public void TestIgnoreInvalidCommand1()
        {
            var simulator = new RobotSimulator.Model.RobotSimulator(5, 5);
            simulator.SetPosition(2, 2, Direction.SOUTH);
            simulator.MoveForward();
            simulator.SetPosition(5, 5, Direction.NORTH);
            var result = simulator.ReportPosition();
            Assert.AreEqual("2,1,SOUTH", result);
        }


        [TestMethod]
        public void TestIgnoreInvalidCommand2()
        {
            var simulator = new RobotSimulator.Model.RobotSimulator(5, 5);
            simulator.MoveForward();
            simulator.SetPosition(5, 5, Direction.NORTH);
            simulator.TurnLeft();
            simulator.MoveForward();
            simulator.SetPosition(1, 1, Direction.SOUTH);
            var result = simulator.ReportPosition();
            Assert.AreEqual("1,1,SOUTH", result);
        }
    }
}