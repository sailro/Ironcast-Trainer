# Ironcast-Trainer

This is an attempt -for educational purposes only- to alter a Unity game at runtime without patching the binaries (so without using [Cecil](https://github.com/jbevain/cecil) nor [Reflexil](https://github.com/sailro/reflexil)).
To achieve that, we use [mono-assembly-injector](https://github.com/gamebooster/mono-assembly-injector), able to:
- dynamically attach to a process
- call suitable methods to load an assembly in the Game AppDomain
- call managed methods in the assembly.

So we have a very simple trainer for the excellent [IronCast](http://store.steampowered.com/app/327670/) game. 

How to use the trainer:
- Start a new game 
- When you are in the hangar, go back to the desktop
- Run load.bat to inject the trainer into the process (you do not need to copy files in a specific location).
- Use keypad + - to add/remove 1000 scraps
- Use keypad * / to add/remove 100 war assets
- Run unload.bat to disable the trainer.

This is just a demo, so if you start a battle and go back to the Hangar, the trainer will not be active anymore. (but you will keep scraps and war assets).

You can compile everything or simply use the [demo release](https://github.com/sailro/Ironcast-Trainer/releases).

Have fun !
