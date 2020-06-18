# Platform Game in C#

This is a simple tile-based platform game in C# and MonoGame

## About the project

This is a game made in my free time. The maps come from txt files included in the project. The project is easy to extend by adding new functionalities such as: new types of mobs, shooting player etc. 

**The goal was to:**
- practice OOP concept in C#
- create a game loop with the option exit and restart game
- use Monogame as a GUI

## Used technology:
- C#
- Monogame

## Rules:

1. Player moves the character by pressing arrows (ESC is exit from game)
2. There are several types of mobs: moving randomly, moving linearly, shooting
3. Player cannot touch any mob or arrow shot by mob. If player touches any of them - the game stops and it must be started from the scratch
4. Sometimes it's necessary to take the key to open the door
5. Player tries to go to the next map by touching the door
6. Player also can come back to the previous map by touching door near the player at the beginning of the map
7. There are 5 maps. If the player finishes all of them, the game starts from the scratch

## Screenshots:
![alt text](https://github.com/KacperMitkowski/Platform_Game/blob/master/CodecoolQuest/Screenshots/gif_1.gif)
![alt text](https://github.com/KacperMitkowski/Platform_Game/blob/master/CodecoolQuest/Screenshots/screenshot_1.PNG)

## Graphics

The tiles used in the game are from [1-Bit Pack by Kenney](https://kenney.nl/assets/bit-pack), shared on [CC0 1.0 Universal license](https://creativecommons.org/publicdomain/zero/1.0/).


