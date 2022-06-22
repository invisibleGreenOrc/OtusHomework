using System;

namespace OtusHomework
{
    internal class Program
    {
        static void Main()
        {
            var quadcopter = new Quadcopter();

            Console.WriteLine("Quadcopter");

            Console.WriteLine(quadcopter.GetInfo());
            Console.WriteLine(quadcopter.GetRobotType());
            quadcopter.Charge();

            Console.WriteLine();
            Console.WriteLine("IChargeable");

            IChargeable chargeable = new Quadcopter();

            Console.WriteLine(chargeable.GetInfo());
            chargeable.Charge();

            Console.WriteLine();
            Console.WriteLine("IFlyingRobot");

            IFlyingRobot flyingRobot = new Quadcopter();

            Console.WriteLine(flyingRobot.GetInfo());
            Console.WriteLine(flyingRobot.GetRobotType());

            Console.WriteLine();
            Console.WriteLine("IRobot");

            IRobot robot = new Quadcopter();

            Console.WriteLine(robot.GetInfo());
            Console.WriteLine(robot.GetRobotType());

            Console.WriteLine();
            Console.WriteLine("IRobotVar");
        }
    }
}