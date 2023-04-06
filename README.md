# Space Ship Core Game

Game Link: https://tarik775.itch.io/spaceship-core-game

<img src="https://user-images.githubusercontent.com/10331972/229952540-a749aaac-064c-434a-b8e1-3192531ca3fd.png">



## About the game

hit those astroids, and get as many points as you can


## Implemented

- 1 - the shiled power up will abear in random position
- 3- the space ship has 3 hits till it gets destroyed
- 4- the player cant spam the last button, there is a trigger delay
- 5- two types of obstacles, one is fast big and 2 points for hitting it, and the other is slow little and one point for hitting it
- Rounded world
- Fire rate power up that decresses the trigger delay for 6 seconds 


## Changes

the changes where made in **scences -> triggers -> d-shield**

- TimedSpawnerRandom now supports multipule prefabs 
- ShieldThePlayer will run a courotine waiting 5 seconds and displaying the shiled image with a fading opacity
- added a shield spawner
- DestroyOnTrigger takes "hits" as a parameter which indictes how many hits it could take till it gets destroyed
- Added two types of eneimes on is small and the other is large, changes in prefabs and ScoreAdder script
- Laser Shooter take a delay time which makes delays between each shot, The changes in **CickSpawner**

# Contributers

- Tarik Husin -> https://www.linkedin.com/in/tarik-husin-706754184/
