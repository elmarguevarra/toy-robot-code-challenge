# ToyRobotCodeChallenge

### Introduction
This application is a simulation of a toy moving on a square table top of dimensions 5 units x 5 units.
There are no other obstructions on the table surface. The robot is free to roam around the surface of the table, but must be prevented
from falling to destruction. Any movement that would result in the robot falling from the table must be prevented,
however further valid movement commands must still be allowed.

### How to run the application
1. Change directory to ToyRobotCodeChallenge folder
2. Build the Docker image ```docker build -t toyrobotcodechallenge .```
3. Run the Docker container ```docker run -it --rm  toyrobotcodechallenge```

 You will be prompted with blank console application that you use to type the following commands below to control your robot.
    Commands:
        1. PLACE X,Y,F
            - PLACE will put the toy robot on the table in position X,Y and facing NORTH, SOUTH, EAST or WEST. The origin (0,0)
            can be considered to be the SOUTH WEST most corner. It is required that the first command to the robot is a PLACE
            command, after that, any sequence of commands may be issued, in any order, including another PLACE command. The
            application should discard all commands in the sequence until a valid PLACE command has been executed.
        2. MOVE
            - MOVE will move the toy robot one unit forward in the direction it is currently facing.
        3. LEFT and RIGHT
            - LEFT and RIGHT will rotate the robot 90 degrees in the specified direction without changing the position of the robot.
        4. REPORT
            - REPORT will announce the X,Y and F of the robot.This will also terminates the application.


### Note:
 - A robot that is not on the table can choose to ignore the MOVE, LEFT, RIGHT and REPORT commands.
 - Any input string other than the stated commands and format above will raise an error "Invalid command".
 - Any movement that would cause the robot to fall would be ignored. This also includes the initial placement of the toy robot.


### Example Input and Output

a) ---------------------------

PLACE 1,2,EAST
MOVE
LEFT
MOVE
RIGHT
MOVE
LEFT
LEFT
MOVE
MOVE
MOVE
RIGHT
REPORT
Output: 0,3,NORTH

b) ---------------------------
place 1,2,EAST
Invalid command

