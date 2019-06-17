# starter-net-core-api
Guide to Renaming Your Visual Studio Solution and/or Projects

1. Decide ahead of time what your new solution name is and if you want to change any project titles inside of the solution as well
2. Close the Visual Studio window that contains the solution that you want to rename
   1. Keep it closed when changing any files
3. Create a backup folder that contains the solution you want to rename so that any mistakes can be fixed
4. Rename the .sln file using either Windows Explorer or VS Code


To Rename Projects

1. Make sure above steps 1-3 have been completed
2. Open the folder containing your solution in a text editor, I suggest VS Code
3. If your project name is different from your solution name and over arching directory, you can use ctrl + shift + f to find and replace all occurrences of your old project name 
  1. If your project name isn’t unique, you’ll have to go through each file to make sure you don’t replace the incorrect things. An example would befile paths
4. Manually rename the files that contain .csproj to the new name as well as theproject folders
  1. Other files should be remade when you build again
5.Close VS Code and open visual studio and run your project to ensure it builds properly
