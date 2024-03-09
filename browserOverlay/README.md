# browserOverlay

This project is a small .NET application which shows a Web Browser without any window decoration or navigation elements.
The main purpose is to create a configurable "kiosk mode" which does not use all of the primary screen.

## Settings

In the working directory must exist a file named "appsettings.json" with the following content:

```json
{
  "url": "https://aka.ms/mfa",
  "height": "200",
  "width": "100%",
  "dockBottom": true,
  "dockTop": false,
  "dockLeft": true,
  "dockRight": false
}
```

You may edit any of these values, of course.

- **url** The URL to be opened
- **height** May be a integer **as string!** for pixel-based values or a integer followed by a "%" to indicate procentual values of the primary screen
- **width** Same as height
- **dockBottom** Pin the window to the bottom of the screen
- **dockTop** Pin the window to the top of the screen
- **dockLeft** Pin the window to the left of the screen
- **dockRight** Pin the window to the right of the screen

The above example JSON opens the ulr https://aka.ms/mfa with a height of 200px, width 100% of the screen, and shows the window docked at the 
bottom of the screen.

## Usage

Start the browserOverlay.exe. For closing the overlay, right click app icon in the taskbar and choose "Close Window" or double click in the window.