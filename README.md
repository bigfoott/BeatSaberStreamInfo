![title](https://bigft.io/u/i/XLd7l.png)

Output BeatSaber game data to an external overlay to be used on stream.

## Setup

Add the .dll to the Plugins folder of your game and launch the game. Default settings will be created in `UserData/modprefs.ini`.

## Configuration

**`OverlayEnabled`** - (0 or 1)

**`RefreshRate`** - In miliseconds,  however 100 (default) is nearly instant. Lower numbers may cause lag.

**`TextColor`** - Use color names from [this image](https://docs.microsoft.com/en-us/dotnet/media/art-color-table.png).

**`BackgroundColor`** - Use color names from [this image](https://docs.microsoft.com/en-us/dotnet/media/art-color-table.png).

**`UseBackgroundImage`** - (0 or 1) To set the image, put "image.png" in `UserData/StreamInfo`.

**`AlignX`** - For each section (except health). Can be `left`, `right`, or `center`.

## Usage

Right click anywhere to open a dialog box to view these options **OR** press the shortcut for each:

Press **`L`** to toggle locking the elements in the overlay. Click and drag to move them around.

Press **`R`** to reload the window. This reloads config settings and will fix any issues with the background image stretching.

Accessible only via the right click menu, reset all positions to default.