@echo off
echo -----------------------------------
echo This Program runs automatically
echo and it will update neutron
echo The updater will install git, then do 
echo the update and delete git.
echo -----------------------------------
cd..
cd..
cd..
pause
PortableGit-2.21.0-64-bit.7z.exe
cd PortableGit
git pull
pause
cd ..
echo pleas wait ...
rmdir /s /q PortableGit
echo -----------------------------
echo update successfully done!!
echo -----------------------------
echo press any key to exit
pause > nul
