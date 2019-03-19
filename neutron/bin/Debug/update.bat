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
echo press a key to start the update
pause >nul
PortableGit-2.21.0-64-bit.7z.exe
cd PortableGit
git pull
cd ..
rmdir /s /q PortableGit
echo -----------------------------
echo update successfully done!!
echo -----------------------------
echo press a key to exit
pause >nul
