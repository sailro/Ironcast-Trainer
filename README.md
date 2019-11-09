# Ironcast-Trainer

This is an attempt -for educational purposes only- to alter a Unity game at runtime without patching the binaries (so without using [Cecil](https://github.com/jbevain/cecil) nor [Reflexil](https://github.com/sailro/reflexil)).
To achieve that, we use [SharpMonoInjector](https://github.com/warbler/SharpMonoInjector), able to:
- dynamically attach to a process
- call suitable methods to load an assembly in the Game AppDomain
- call managed methods in the assembly.

So we have a very simple trainer for the excellent [IronCast](http://store.steampowered.com/app/327670/) game. 

How to use the trainer:
- Start a new game 
- When you are in the hangar, go back to the desktop
- Run load.bat to inject the trainer into the process (you do not need to copy files in a specific location).
- Use keypad + - to add/remove 1000 scraps
- Use keypad * / to add/remove 1000 war assets
- Use keypad . to add 5000 xp
- Use keypad 0 to fill health/ammo/coolant/energy/repair
- Run unload.bat to disable the trainer.

You can compile everything or simply use the [demo release](https://github.com/sailro/Ironcast-Trainer/releases).

Have fun !
