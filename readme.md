# Installation Instructions.

1. Download the latest release bin.zip from the releases page.
2. Extract the contents into your ClassicUO/data/plugins/ folder
3. Edit your settings.json file to include CEasyUO
```   
"plugins": [
    "./Razor/Razor.exe",
    "./CEasyUO/CEasyUO.exe"
  ]
```

## Prerequisites
- Visual Studio or the .NET SDK 4.7.1
- Ensure `dotnet` is installed or use Visual Studio

## Building from source
1. Run `dotnet build CEasyUO.csproj -c Release`
2. Copy `bin/CEasyUO/CEasyUO.exe` to `ClassicUO/data/plugins/`

## Building from Source

### Prerequisites
- Windows with the .NET Framework 4.7.1 Developer Pack installed
- Visual Studio 2019 or newer with the "Desktop development with C#" workload (or MSBuild tools)

### Compile
1. Open `CEasyUO.csproj` in Visual Studio and choose **Build > Build Solution** or run:
```
msbuild CEasyUO.csproj /p:Configuration=Release
```
2. Copy the `bin/CEasyUO/CEasyUO.exe` produced by the build into your `ClassicUO/data/plugins/CEasyUO` folder.

## This project is not yet complete or in a usable state for end users.

# Really this will not work for you yet, This code is here simply incase someone wants to take over the project.
Script parsing is mostly all done, though a few bugs are probably still lurking when dealing with lots of nested if/else and subs.
A few functions are hooked up, ie Event macro 17, 22, 13, 15
Most variables are hooked up.

### TODO
Hook up remaining events/functions
UI Improvments
Script parser improvments.

## Functionality Changes
#### #GUMPSERIAL and #GUMPTYPE #LGUMPBUTTON new variables for gumps.

#### Mobile Health bars do not show via #ContType, Use #LTARGETTYPE


## New commands

### Gump Handling

#### event gump wait {timeout}
Waits until timeout( default 10 seconds) or a gump appears

#### event gump last
Repeats the last gump input action

#### event gump button {index}
Responds to the current gump with the specified index


### Context Menus

#### event contextmenu {serial} {index}
Triggers a context menu response at the specified zero based index on the specified serial


## Depreceated commands

#### Menu
#### Click

## Depreceated Variables

#### #NEXTCPOSX/Y Gone 
#### #CONTPOSX #GUMPOSX replaces much of this functionality but GUMP handling should move to using the new events.
#### #CONTPOSY #GUMPOSY replaces much of this functionality but GUMP handling should move to using the new events.
#### #CONTSIZEX/Y have been replaced with #GUMPSIZEX/Y
These only update when a new gump opens, and do not update when you change focus in game.



