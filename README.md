# Legal Plotter
###### Plugin Build 1.0

## Overview
In the legal, surveying, and civil engineering fields, real estate properties are described by specifying the length, bearing, and radius of lines and arcs of the outer property line. When you start working on a project, the first thing you often do is take these legal descriptions and plot them into a CAD software. It can be quite tedious to do this by hand, and I knew there had to be a better way to do this.

This was my inspiration for making legal Plotter! This project takes a text legal description as input and plots it into AutoCAD for you. This was initially made in Python using a macro, but it is now a full fledged plugin for AutoCAD built in C#.

[Legal Plotter: AutoCAD Plugin](https://youtu.be/-bcxn0hQiHg)

## Running the Plugin

### Method 1: Downloading LegalPlotter.dll
* Open powershell and run ```wget -O Downloads/LegalPlotter.dll https://raw.githubusercontent.com/RileyStratton/LegalPlotter/main/LegalPlotter.dll```
* Open AutoCAD 2022
* Type ```NETLOAD``` and press enter
* Select ```LegalPlotter.dll``` from where you downloaded it
* Default location is ```Downloads/LegalPlotter.dll```
* Type ```LEGALPLOTTER``` and press enter
* Fill out the form, press submit, and watch the magic happen

### Method 2: Cloning Repository
Some steps may already be completed
* Clone this repository
* Open the project in Visual Studio Community 2022
* Select ```acad.exe``` as the startup object
* Default location is ```C:\Program Files\Autodesk\AutoCAD 2022\acad.exe```
* Optional: Use the ```/nologo``` command line argument for a faster startup. 
* Install ObjectArx 2022
* Add ```AcCoreMgd.dll```, ```AcDbMgd.dll```, and ```AcMgd.dll``` as references
* Default location is ```C:\Autodesk\ObjectARX_for_AutoCAD_2022_Win_64bit_dlm\inc\```
* Set Copy Local to False for the three references you added
* Run the program by pressing start
* Once AutoCAD is open, type ```NETLOAD``` and press enter
* Select ```LegalPlotter.dll```
* Default location is ```Repository/LegalPlotter/Debug/LegalPlotter.dll```
* Type ```LEGALPLOTTER``` and press enter
* Fill out the form, press submit, and watch the magic happen

## Classes
* __Legal:__ This is the meat of this project. It calls on the LegalForm class to open a form for user input. Once that it is submitted it parses the string, calls the Calculate class to calculate what the legal description should look like, then calls on the Active class to draw the legal description.
* __LegalForm:__ Opens a form that accepts the parcel name and legal description as input.
* __Calculate:__ Computes all necessary information to turn a string into data ready to go into AutoCAD. Determines the quadrant; converts degrees, minutes, and seconds to radians; determines x and y deltas; and returns the verticies of lines to be drawn.
* __Active:__ This is a static helper class. It instantiates three lambda variables that are called repeatedly, being the active Document, Database, and Editor. It is drawing lines, curves, and text in AutoCAD.

## Development Environment
* __Visual Studio Community 2022 (IDE):__ An IDE with strong support for C# and referencing external files in your project.
* __.NET 4.8 Framework (C#):__ The .NET framework currently supported by AutoCAD.
* __AutoCAD 2022:__ Student trial of AutoCAD to test the development of plugins.
* __ObjectARX SDK:__ A software development kit that assists in developing plugins for AutoCAD.

## Useful Websites
* [W3 Schools: C#](https://www.w3schools.com/cs/index.php)
* [Geeks for Geeks: C#](https://www.geeksforgeeks.org/csharp-programming-language/)
* [Microsoft .NET Documentation](https://docs.microsoft.com/en-us/dotnet/)
* [AutoDesk .NET Forum](https://forums.autodesk.com/t5/net/bd-p/152)
* [Arnold Higuit's C# AutoCAD Programming Tutorials](https://www.youtube.com/c/ArnoldHiguit)
* [AutoCAD 2022 ObjectARX Documentation](https://help.autodesk.com/view/OARX/2022/ENU/)

## Future Work
* Implement code for being able to draw curves (tangent, non-tangent, and reverse)
* Draw individual lines and curves, then join them all together (using layer as criteria for join)
* Make regular expressions more robust, working in more situations
* Implement error correction for text legal descriptions (replacing an incorrect letter "O" with the number "0")
* Remove pre-filled information from the form
* Edit the form to make it look and behave better (user can't resize, add minimize button, etc.)
