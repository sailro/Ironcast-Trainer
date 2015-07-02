@echo off
injector.exe -dll Ironcast.Trainer.dll -target ironcast.exe -namespace Ironcast.Trainer -class Loader -method Unload
pause