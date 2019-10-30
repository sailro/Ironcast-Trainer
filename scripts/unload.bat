@echo off
if "%1"=="" GOTO usage
smi eject -p ironcast -a %1 -n Ironcast.Trainer -c Loader -m Unload
goto end

:usage
echo usage: unload [address of the assembly to eject]

:end
