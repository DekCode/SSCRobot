
using SSCRobot;

var inputProvider = new ConsoleInputProvider();
var outputProvider = new ConsoleOutputProvider();

var demo = new RobotRunner(inputProvider, outputProvider);
demo.Run();
