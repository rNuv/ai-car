# Self-Driving-Car-Unity
A Unity MLAgents project that uses deep reinforcement learning, ray casting and imitation learning to train a car to drive around a track on its own. 

## 😄 Summary 
For my Independent Study - AI Class, I used Unity's MLAgents toolkit to train a car to drive around a track on its own. Each track as a checkpoint system in which an event is invoked after a car travels through a checkpoint. Each checkpoint event triggers a positive reward to the car agent. Each track also has walls that negatively reward the agent if it collides with them. As for the agent's observations, most of them come from the ray casts of the car (the red lines coming out of the car). To train faster, I also did another training session with imitation learning, where I had a pre recorded demonstration of the car going aroupd the track multiple times and let the training algorithm use that demo as a reference. I found that imitation learning made the training process faster, but also made the agent learn the mistakes of the demo as well. 

## 💻 Tech 
-Unity <br />
-Unity ML-Agents (https://github.com/Unity-Technologies/ml-agents)

## 📷 Pictures
Here was the initial left and right turn tracks used to train the agent.
![](images/leftright.gif)
<br />
Here is the complex track that I tested the agent on after training.
![](images/complex.gif)
