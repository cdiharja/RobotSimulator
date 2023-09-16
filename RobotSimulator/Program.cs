using RobotSimulator.Model;

RobotSimulator.Model.RobotSimulator robotSimulator= new RobotSimulator.Model.RobotSimulator(5, 5);
Console.WriteLine("Enter a command:\r\n- PLACE X,Y,DIRECTION\r\n- MOVE\r\n- LEFT\r\n- RIGHT\r\n- REPORT\r\n- EXIT\r\n- FILE {filename}");

string input = Console.ReadLine();
var inputCommand = input.Split(" ");
if (inputCommand.Length >= 1)
{   
    if (inputCommand[0] == "FILE")
    {   //process file input file
        var fileName = inputCommand[1];
        string[] lines = File.ReadAllLines(fileName);
        foreach (var line in lines)
        {
                ExecuteCommand(line);
        }
        Console.ReadLine();
    }
    else
    {   //process stdin input file
        do
        {
            ExecuteCommand(input);
            input = Console.ReadLine().ToUpper();
        } while (true);
    }
}

void ExecuteCommand(string input)
{
    switch (input.Split(" ")[0])
    {
        case "PLACE":
            var pos = input.Split(" ");
            if (pos.Length > 1)
            {
                var coordinates = pos[1].Split(",");
                if (coordinates.Length > 2)
                {
                    int x = Int16.Parse(coordinates[0]);
                    int y = Int16.Parse(coordinates[1]);
                    if (Enum.TryParse<Direction>(coordinates[2], out Direction dir))
                    {
                        robotSimulator.SetPosition(x, y, dir);
                    }
                }
            }
            break;
        case "MOVE":
            robotSimulator.MoveForward();
            break;
        case "LEFT":
            robotSimulator.TurnLeft();
            break;
        case "RIGHT":
            robotSimulator.TurnRight();
            break;
        case "REPORT":
            string report = robotSimulator.ReportPosition();
            if(!String.IsNullOrEmpty(report))
                Console.WriteLine(report);
            break;
        case "EXIT":
            Environment.Exit(0);
            break;
        default:
            break;
    }
}