# Program Organization

# Major Classes

# Data Design
This section does not apply to our project, as we are not using any databases. Our product is runs purely on a local level.

# Business Rules

Business Rule ID | Rule
----------------- | -----
000 | Each user will have their data stored independently.
001 | Users will be able to create, save, delete, and load new/existing game save files.
002 | A save file cannot adjust the game data for a separate save file.
003 | Users can only load or delete their own save files, and cannot create or save files for another user.
004 | Users will be able to adjust key-binding, sound, and game options.
005 | Users can only adjust their own game settings and options.

# User Interface Design

Upon opening the application, the user will will encounter the main menu screen. From the main menu, the user can start a new game, load or delete an existing game, change game settings and options, or close the application.

When the user chooses to change game settings and options, the main menu will transition to an options screen, where the user will be presented with a list of adjustable settings. At the bottom of the options screen will be buttons to allows the user to save current settings, revert to default settings, or return to the main menu.

When the user creates or loads a game file, the application will transition to a game screen. The game screen consists of a top-down view of the game overlayed by the in-game user interface. This UI will display the player's current health and resources, current level, and current game progress. It will also have buttons to open the player's inventory and talent tree. Doing so will pause the game and open an in-game pop-up of chosen option. Pressing a certain button within the game screen will pause the game and open an in-game menu. From here, the player can choose to save the game, load another game file, change options, exit to the main menu, or return to the game screen.

TO DO: ADD UI SCREENS

# Resource Management

Resources used by the application will be primarily game assets, such as backgrounds, sprites, fonts, and animations. The game should generaly have a fairly minimal impact on the user's system performance, as the graphics used are two-dimensional and comparably low resolution to most modern applications. An exception to the prior statement could occur in levels with a high enemy or animation density, during which lower-end systems may be unable to support smooth framerates due to the increased graphics load. 

Level generation will occur during the game, as the user traverses the dungeon. The game will initially generate a number of rooms around the user, and will generate more as the user gets closer to the "edge" of the currently generated rooms. The game will save the state of the room when the user exits it, and will only load the rooms that border the room the user is currently in. This will prevent the game from exponentially requiring more resources as the user progresses while minimizing loading times. 

# Security

Game assets will be stored in the installation directory chosen by the user, defaulting to a system level (such as \ProgramFiles on Windows machines). 

User assets such as game settings and save files will be stored in the current user's directory. The application will only be able to access user data within that directory. Local user permissions will be enforced.

# Performance

# Scalability

# Interoperability

# Internationalization/Localization

# Input/Output

# Error Processing

# Fault Tolerance

# Architectural Feasibility

# Overengineering

# Build-vs-Buy Decisions

# Reuse

# Change Strategy
