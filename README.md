# AI Car

## Description 
For my Independent Study - AI Class, I used Unity's MLAgents toolkit to train a car to drive around a track on its own. Each track has a checkpoint system in which an event is invoked after a car travels through a checkpoint. Each checkpoint event triggers a positive reward to the car agent. Each track also has walls that negatively reward the agent if it collides with them. As for the agent's observations, most of them come from the ray casts of the car (the red lines coming out of the car). To train faster, I also trained the agent with imitation learning, where I had a pre recorded demonstration of the car going aroupd the track multiple times and let the training algorithm use that demo as a reference. I found that imitation learning made the training process faster, but also made the agent learn the mistakes of the demo as well. 

## Pictures
<div align="center">
  <img src="images/leftright.gif" width="800" height="600">  
</div>
<p align="center">
  The initial left and right turn tracks used to train the agent.
</p>

<div align="center">
  <img src="images/complex.gif" width="800" height="600">  
</div>
<p align="center">
  The agent (car) is controlling itself and has learned to stay on track.
</p>

## Technologies 
- ![Unity](https://img.shields.io/badge/unity-%23000000.svg?style=for-the-badge&logo=unity&logoColor=white)
- ![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=c-sharp&logoColor=white)

---
*Made with <3 by Arnav, circa 2020*
