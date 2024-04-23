# SS&C Robot Exam by Arrak

The solution for the robot exam

# How to run

## Prequisites

- Visual Studio Community with .NET 8 support
- Git

## Step

1. Clone the repository
2. Open the solution
3. Right click on **SSCRobot** project. Then **Debug** -> **Start New Instance**.

## Support Commands (copied from the instruction)

**PLACE** will put the toy robot on the table in position X,Y and facing NORTH, SOUTH, EAST or WEST. The
origin (0,0) can be considered to be the SOUTH WEST most corner. This command is required to initiate the robot.

**MOVE** will move the toy robot one unit forward in the direction it is currently facing.

**LEFT** and **RIGHT** will rotate the robot 90 degrees in the specified direction without changing the position of
the robot.

**REPORT** will announce the X,Y and F of the robot.

## Running Tests

1. Click on **Test** menu bar item.
2. Click on **Run All Tests**.

## Sample

```
PLACE 0,0,NORTH
MOVE
REPORT
Output: 0,1,NORTH
```
