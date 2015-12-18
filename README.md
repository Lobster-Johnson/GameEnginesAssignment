# GameEnginesAssignment
Game Engines 2015 assignment
Pool table with android accelerometer controls
The game starts by procedurally generating a cue ball, billiard balls and a table.
The cue ball is controlled by tilting the android device, and the accelerometer inputs are translated onto a force on the ball.
If a ball lands in a pocket, the player gets a point.
If the cue ball lands in a pocket, the player loses.

Components:
AccelerometerInput: Adds a force to the cue ball based on the tilt of the device

Generator: Creates and colours the billiard balls

CreateTable: Creates and colours the cue ball, inner wall, outer wall, floor and pocket triggers

TriggerScript: Trigger for determining what happens if a ball falls in a pocket, if it's a ball the player gets a point, if it's the cue ball the player loses

CollisionScript: Makes clack noise when balls hit into each other

Score: Creates GUI, displays score and lets the player know if they lose.


Marcus Daly
C12474932
