# COXI_Kart
### Welcome to the most realistic Arcade Racer of 2022 (At least if you yourself are a polygon of 6 edges)!
<img src="/pictures/FinalCOXI.png" alt="Coxi Map" width="500"/>
This is a somewhat 3D Racer with rainbow special effects and an extra dose of Coxi.
You can experience the glorious amount of two hand created maps with teleporters, speed-boosts and turrets that will mostlikely bully you!
(One of which is in kinda beta mode because of the time it takes to create the objects in Blender). 


## Requirements
- Unity 2021.3.3f1
- System Requirements:
  - If you can see this it is powerfull enough

## How does it work?
To play the game you can either run it in Unity or Build it for your system and run the built version.
You will be prompted with a Main Menu Screen where you have three options:
- Start
- Settings
- Quit

On Start you will come to a selection of which map you would like to play, either the Platypus Highway, the  HillBilly Road(our finished tracks) or the Mayhem Drive (not so finished track).

In the settings you can choose if you would like to play in fullscreen, wheter you want vsync to be activated, and you can choose between the resolutions 720p and 1080p.

Quit quits the game.

### Ingame Controls

- The car can be driven by WASD to go forward/backward and steer left and right
- You can press R to be resetted to a checkpoint
- You can press ESC to get back to the Mainmenu

## Sources

Normally used sources and the credits are at the end of a Readme, but since we really enjoyed and benefitted from the community who creates helpful content and ressources and makes them available for free!

### Music
- Fluffing a Duck Kevin MacLeod (incompetech.com)
Licensed under Creative Commons: By Attribution 3.0 License
http://creativecommons.org/licenses/by/3.0/
Music promoted by https://www.chosic.com/free-music/all/

- Sundown Drive by Ghostrifter Official | https://soundcloud.com/ghostrifter-official
Music promoted by https://www.chosic.com/free-music/all/
Creative Commons CC BY-SA 3.0
https://creativecommons.org/licenses/by-sa/3.0/

- The Cognitive Science Song by the Aarhus Universitet
Melody and Lyrics by Kristian Tylén
Src: https://www.youtube.com/watch?v=XH42KFvnXyI
Creative Commons CC BY
http://creativecommons.org/licenses/by/3.0/

### Assets
- Font, Designidea and Particle-system by gamesplusjames
Video: https://youtu.be/76WOa6IU_s8
Src: https://drive.google.com/file/d/1UQ7becz4NNAI5Tyy5rCCooGrF-yA0h6s/view

## Development history

We started with the idea to have a small racer that the player could race a given track with jumps etc to make it a bit more fun.

The first steps were getting a car driveable, for that went through a number of Car versions until we found one that feels rather natural (physics wise).
In the beginning we only had a cube that could steer and go forwards and backwards but without acceleration/deceleration and a horrible collision concept.
With that we already tested the speed boosts and the shells that can be seen in the Mayhem Drive.

In the second version we had a cube that at least looked like a car, that had a real acceleration/deceleration, features like drag and grip; which made it feel far better that our cube of terrors in the first try. You can still take a look at it and drive if you want in the CarV2 Scene in Unity. It was cool but we tricked the system and made up our own system for drag grip etc. which was ok but not really satisfying enough. Here you can see how the second version looked like: <br>
<img src="/pictures/CarV2.png" alt="Second Car Version" width="500"/>

The CarV3
comes in. This time we modelled a car in blender and gave it real world measurements which looked far better than our little cuby-drivers. For this we also modelled wheels which are the main and most important differences to the other tries. The power of the car comes from the wheels turning and making contact to the ground with values for when the tire looses its grip etc. TL DR: We started making use of the physics engine and our car started moving by the same principles real cars do.

<img src="/pictures/CarV3.png" alt="Third Car Version" width="500"/>

After having the car up and running we built our Platypus Highway (The Coxi circuit).
First we tried to model it in Unity but it doesn't even look half as nice as if done in Blender. And so we began the journey of building a racetrack in Blender by using modular pieces and putting them together to get our letter-tracks. Since that is really time consuming we only did it for our two main tracks. The third track (Mayhem Drive) is still kind of in beta mode and therefore only modelled in Unity to first get the functionality right. More on that later.
We then imported the tracks into Unity, lined them up, tweaked the scales, added our car, teleporters, a finding beacon a number of UI elements to know what to do and a pinch of pepper and salt, et voila Track rdy to be played. (Kind of sounds easier than it felt like).

<img src="/pictures/CoxiComparison.jpg" alt="Coxi Maps" width="500"/>

Next to that we created our Main Menu inspired by the tutorial of gamesplusjames, mentionned at the top.
We mainly used his font throughout the entire game and used his particle system to create our own stylish ones.

<img src="/pictures/Menu.png" alt="Menu" width="500"/>

For the second map (HillBilly Road), we used the road templates of the Platypus Highway to include a more 'classical' map, which is better to train your driving and speeding skills.  

<img src="/pictures/HillBilly.png" alt="HillyBilly Road" width="500"/>

Lastly we worked on the Mayhem Drive which should be a fun arcade like track with many moving objects, speed boosts, shooting turrets etc. It looks like you would expect a pre-alpha to look like, but it is what it is. At least it works without crashing all the time, better than some tripple A games out there. Yes Cyberpunk I am looking at you. 
Although the maps was set to be "fun" it depends on your understanding of fun really. If you like a challenge: Welcome! Otherwise you will feel what I meant by writing that the turrets will "bully" you.

<img src="/pictures/Mayhem.png" alt="Mayhem Road" width="500"/>

And thats where the journey ends (at least for now, for the project).
We had a lot of fun making it and really enjoyed diving into game development and will most likely do more with Unity in the future, especially with the AI Toolkit I think, since we are really into Deep Learning and Reinforcement Learning.

We hope you enjoyed it all, and until then farewell!
Yours Tim and Tim

