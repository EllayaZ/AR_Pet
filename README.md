# AR_Pet


## Concept
<p align="center">
  <img src="Images/Dino_AR.jpg"> 
</p>
AR pet companion. 
​
A manager will review the scores of the staff after completing the VR training course and will decide if the trainee is capable of operating the drones to real deliveries.
​
## Scope
​
### Functional Requirements
​
- The operator **receives** a new shipment order.
- Operator **starts** the drone program.
- Program has a short tutorial to **understand** the control of the drone.
- Operator **locates** the pickup destination.
- Controls must **simulate** actual drone movement and control.
- The simulation **highlight** the position of the package.
- Operator **picks up** package.
- Operator **locates** the drop off destination.
- The simulation **shows** current time and delivery time.
- The customer **recieves** a notification that the delivery is close.
- The customer **moves** towards a specific location to recieve the package.
- Operator **drops off** the package.
- The operator **confirms** delivery.
- Operator **returns** the drone to central office.
​
### User Experience
​
Once the operator enters the simulation in VR, she/he will be in a room similar to the one physically found in real life.  A computer where notifications, deliveries, and emails can be received is in front of the user. Within the work area there are different interactable objects with the objective of creating an immersive and entertaining environment.
​
The operator receives a notification about a new available delivery, accepts it and begins the flight simulation.
​
The drone is activated and the interface instructs the operator on how to take off and subsequently test the drone's movement, a process that will serve to train the operator and at the same time verify that the drone works properly.
​
Once the process aboved explained is complete, a mini map will be added in the interface to guide the operator to the pick up destination. The current time as well as the delivery time will be added to the interface for the operator to calculate the flight time.
​
One package can be delivered at once. The user is free to navigate wherever he/she wants but the fastest he/she gets to the delivery destination the better the score, which they can’t see until the simulation is over.  
​
When the operator gets close enough to the drop off location, the level changes so he can control the client that is waiting for the package for him to understand completely the process of delivery. The client should receive a notification saying the delivery is close and needs to approach to a pick up location without being so close, or the drone won’t drop the delivery.
​
Once the delivery is finished, the operator has to confirm it. If he/she does the confirmation before the client pick ups the package, the score will drop.
​
After confirmation the operator will return to the main office to recharge the drone and wait for the next job.
​
### Tasks
​
- Import and optimize the 3D models.
​
	- Street buildings, warehouse bay, residential house, drone Content Prep
​
	- Organize the Content browser. Content Prep
​
	- Review the 3D models before importing into UE. Content Prep
​
	- Optimize any high-poly mesh. Content Prep
​
- Create interior office
​
	- Build interior design.
	
	- Add static mesh models.
	
	- Add pick up BPs.
	
	- Lights.
​
- Create a street block.
​
	- Create level style
​
	- Add static mesh models to the level to recreate a street block. style
​
	- Add lighting for the street. style
	
- Create drone.
	
	- Add drone mesh to VR Pawn BP.
​
	- Add collision to the drone.
	
	
- Creating the contact site between the drone and the delivery.
​
	- Add collision to the drone for overlap events
​
	- Drone communicate with the delivery pawn through level BP, Dispatch, or state machine for the delivery animation BP.
​
​
- Program the HUD for the pilot of the drone.
​
	- Get score from GameMode or GameScore. 
​
	- Count down for the delivery time.
​
	- Track the altitude and latitude (Yaw offset). Use a holo-drone to visually track drone orientation.
​
	- Add minimap widget.
	
	- Add current time 
​
	- Develop BP for the mini map. 
​
	- Add battery life graphic to the HUD. Content Prep
​
	- Battery life.
​
	- Add package info to the HUD. 
​
- Drone Interaction
​
	- Add pickup and drop-off input.
	
	- Develop BP for auto pickup and drop-off events. 
​
	- Add motion controller inputs to the vr pawn. All the drone controls are on the sticks.
​
	- Add rotation and movement for the controllers
​
	- Add haptics for collision
​
	- Thumbstick for direction control.
​
	- Add grip to drop or pickup event.
​
- Score Management
​
	- Make an Enum list of tasks to complete.
​
	- Print the enum list for the player.
​
	- Add switch by Enum to go to next task.
​
	- Add a TimeNode to track time per task.
​
	- Add widget to print scores. style
​
- Sound.
​
	- Flying FX.
	

		
