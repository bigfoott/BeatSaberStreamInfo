Output BeatSaber game data to an external overlay to be used on stream.

## Setup

Add the .dll to the Plugins folder of your game and launch the game. Default settings will be created in `UserData/modprefs.ini`.

## Configuration

**`OverlayEnabled`** - Either 0 or 1, for disabled and enabled.

**`RefreshRate`** - In miliseconds,  however 100 (default) is nearly instant. Lower numbers may cause lag.

**`TextColor`** - Use color names from [this image](https://docs.microsoft.com/en-us/dotnet/media/art-color-table.png).

**`BackgroundColor`** - Use color names from [this image](https://docs.microsoft.com/en-us/dotnet/media/art-color-table.png).

**`UseBackgroundImage`** - (0 or 1) To set the image, put "image.png" in `UserData/StreamInfo`.

## Usage

Press **`L`** to toggle locking the elements in the overlay. Click and drag to move them around.

Press **`R`** to reload the window. This reloads config settings and will fix any issues with the background image stretching.