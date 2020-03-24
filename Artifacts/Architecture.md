# Program Organization

### Context Level Diagram

<img src = "/images/ContextView.png" width="1000" >

The user plays the game and manages any game information by interacting with the Game Application. The Game Application responds to any user inputs and obtains the data required for those responses by obtaining it from stored assets in the user's local computer file system. 

### Container Level Diagram

<img src = "/images/ContainerView.png" width="1000" >

Within the Game Application context are two main containers the user will interact with: the menu container and the game environment container. The game environment is responsible for any interactions the user will have with the game itself, such as playing the game and managing game related information such as inventory. The menu container is responsible for all user interactions that will affect how the user plays the game, such as settings, creating new game data, saving and loading save data, and entering/exiting the game.

### Main Menu Component Level Diagram

<img src = "/images/MenuComponentView.png" width="1000" >

Within the main menu container, the user will interact with three main components, the create game screen, the load game screen, and the options screen. The create game screen will allow the user to adjust the settings for the new game they wish to create, then bring the user to game environment. The load game screen will allow the user to load into the game environment at a previously saved point; the load game screen obtains the save data from the local system. The options screen will allow the user to change key bindings and UI-related game settings.

### Game Environment Component Level Diagram

<img src = "/images/EnvironmentComponentView.png" width="1000" >

Within the game environment, the user will interact with three components aside from the game itself. The inventory screen will allow the user to view or edit their inventory. The talent tree screen will allow the user to view or choose new skills/abilities. The in-game menu will present a slimmed-down version of the main menu, allowing the user to pause, save, load a different game, or quit to the main menu.

Component | Relevant User Stories | Description |
----------|-----------------------|-------------|
Create Game Screen| 0014 | Allows user to pick a character name, class, and generate a new game.|
Load Game Screen | 0014 | Allows user to select from a previously saved game and continue where they left off.|
Options Screen | 0016 | Allows user to edit key-bindings, sound options, and control options. | 
Talent Tree Screen | 0018 | Allows users to view and edit chosen talents and abilities. |
Inventory Screen | 0003, 0006, 0020 | Allows users to view and organize inventory and equip items. |
In-game Menu Screen | 0014, 0015, 0016 | Allows users to load into another game, save the current game, change options, or exit to the main menu. |

# Major Classes

### Class Diagram 

<img src = "/images/ClassDiagram-3.PNG" width="1000" >

Class | Relevant User Stories | Description |
----------|-----------------------|-------------|
Entity| 0002 | Any interactable object with a sprite.|
Objects| 0002 | Any inanimate entity.|
Active Entities| 0002 | Any entity that can move, attack, or exhibit some behavior.|
Item| 0003, 0004, 0006, 0007, 0020 | Any entity collectible by the player.|
Player| 0001, 0002, 0003, 0004, 0005, 0006, 0007, 0008, 0010, 0013, 0017, 0018, 0020| What the user controls within the game environment.|
Enemy| 0009, 0011, 0012, 0017, 0019, 0020| Any entity hostile to the player entity.|
Equipment| 0006 | Any item that can be equipped by the player.|
Usable Item| 0006, 0007 | Any item that can be used by the player.|
Boss| 0009, 0011, 0012, 0017, 0019, 0020 | Any enemies that have more abilities than default attacks.|
NeuralNetwork| 0011 | Creates and Operates a network of AINodes
AINode| 0011 | Stores an output which is calculated based on weighted connections to other AINodes.|

# Data Design
Our application will store all data locally. All game assets (such as sounds, sprites, and the built application) will be stored in the install directory. The game will also create a folder in a user-specific directory to store data (such as the documents folder on windows), to allow the user to view/modify the data without interfering with the data of other users on the local machine. The data stored within this folder will be user options (keybindings, sound settings, game settings, and anything else set within the options screen) and save file data. The former will be left as a text file to to allow for user modification, while the latter will be encrypted to prevent potential data corruption via modification. Upon launch, the game will read the options file to load the current user options and write any modifications when the user saves new settings. Save file data will be read when the user selects that specific file to load into the game environment, and will be written when the user saves their game.

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

<img src = "/images/UI Diagram.png" width="1000" >

Upon opening the application, the user will will encounter the main menu screen. From the main menu, the user can start a new game, load or delete an existing game, change game settings and options, or close the application.

<img src = "/images/UI Screens/Main Menu.png" width="1000" >

When the user chooses to change game settings and options, the main menu will transition to an options screen, where the user will be presented with a list of adjustable settings. At the bottom of the options screen will be buttons to allows the user to save current settings, revert to default settings, or return to the main menu.

<img src = "/images/UI Screens/Options.png" width="1000" >

When the user creates or loads a game file, the application will transition to a game screen. The game screen consists of a top-down view of the game overlayed by the in-game user interface. This UI will display the player's current health and resources, current level, and current game progress. It will also have buttons to open the player's inventory and talent tree. Doing so will pause the game and open an in-game pop-up of chosen option. 

<img src = "/images/UI Screens/GameUI.png" width="1000" >

Pressing a certain button within the game screen will pause the game and open an in-game menu. From here, the player can choose to save the game, load another game file, change options, exit to the main menu, or return to the game screen.

<img src = "/images/UI Screens/Paused.png" width="1000" >

|Interface Component|Relevant User Stories|Description|
|-------------------|---------------------|-----------|
|Main Menu Screen|000, 014, 015, 016|Allows user to select between creating a new game, loading a game, changing options.
|Options Screen|016|Allows user to adjust game settings and keyboard binds.|
|Game Screen|001, 005, 007, 013, 019, 018|Allows user to play the game and interact with the game environment while viewing game resources.|
|Pause Screen|014, 015, 016, 024, 025, 026| Allows user to pause the game and select between creating a new game, loading a game, changing options, exiting to the main menu, or exiting the application.|



# Resource Management

Resources used by the application will be primarily game assets, such as backgrounds, sprites, fonts, and animations. The game should generaly have a fairly minimal impact on the user's system performance, as the graphics used are two-dimensional and comparably low resolution to most modern applications. An exception to the prior statement could occur in levels with a high enemy or animation density, during which lower-end systems may be unable to support smooth framerates due to the increased graphics load. 

Level generation will occur during the game, as the user traverses the dungeon. The game will initially generate a number of rooms around the user, and will generate more as the user gets closer to the "edge" of the currently generated rooms. The game will save the state of the room when the user exits it, and will only load the rooms that border the room the user is currently in. This will prevent the game from exponentially requiring more resources as the user progresses while minimizing loading times. 

# Security

Game assets will be stored in the installation directory chosen by the user, defaulting to a system level (such as \ProgramFiles on Windows machines). 

User assets such as game settings and save files will be stored in the current user's directory. The application will only be able to access user data within that directory. Local user permissions will be enforced.

# Performance

As a lightweight 2D game, performance should be fast and consistent across modern machines. Framerate drops will be minimized by loading and unloading rooms accordingly, but should only seriously occur in the most animation and graphic heavy levels on lower-end machines. Transition times between rooms should be less than a second due to pre-loading rooms close to the player. Opening sub-menus such as the inventory and the talent tree should occur in less than half of a second. The longest loading times the user will encounter will only be when creating a new game or loading a game due to more information being processed. 

# Scalability

The game will be built in a modular, object-oriented manner, allowing for easy creation of additional content. Enemies, bosses, and rooms are pre-designed as templats and added to a queue for the level generation to randomly select from, so the creation of new designs can be easily added to that queue.  

# Interoperability

This section does not apply to our project, as we are not planning on sharing any data with other services, applications, or devices.

# Internationalization/Localization

Possible internationalization/localization will be handled by importing the appropriate fonts for languages that use different scripts and translating the game's content and interfaces.

# Input/Output

The majority of the input will be user generated, such as keyboard presses to control the in-game character and mouses clicks to select items from the inventory and menu. File input will occur when loading save files. File output will occur when creating and saving save files.

# Error Processing

Error processing will primarily deal with errors from file input/output and missing assets and will be dealt with by notifying the user. These errors will be detected when the game is unable to read or write to game files or load a necessary game asset, and will alert the user with a pop-up window. User errors will be handled through user notification (invalid character name).
Game crashes will be detected and logged appropriately.

# Fault Tolerance

The application will have high tolerance for asset faults and attempt to continue running with invalid/missing assets. The application will have low tolerance for file input and output. If the application is unable to read a save file, it will not attempt to load the file and notify the user with an error. If the application is unable to properly write to a save file, it will not attempt to continue writing and notify the user with an error.

# Architectural Feasibility

This application is technically feasible for the base development of a dungeon crawler game. Game mechanics such as proper collisions, interactions, attacking, health, and level generation are the most feasible. Implementation of a complete AI that can react to the user's playstyle may be less possible, but will still be feasible with a normal algorithm.

This application should be artistically feasible. Assets such as backgrounds, animations, and sprites will be very feasible to create at a functional level, but may not be completely satisfactory or high-level from an artistic lens.

This application is economically feasible, using the free versions of GitHub, Trello, and Unity for product development.

# Overengineering

Possible overengineering could occur by creating too many classes/abilities for the player to choose from and using an over-kill algorithm for level generation. Overengineering should be avoided by focusing specfically on what the user needs to fully enjoy the game without being overloaded by options.

# Build-vs-Buy Decisions

We are choosing to use Unity as our game engine because of its effectiveness in rendering 2D scenes, portability, relative ease of use, economic feasability, and wealth of support and resources. Building our own game engine would require more time and resources than the rest of the game combined.

We wil be building most our game's artistic assets, such as sprites, to unite the game's aesthetics for better user immersion. Some third-party assets may be used for animations, fonts, or icons. 

We are using an [Input Manager](https://github.com/daemon3000/InputManager) by daemon3000 to manage keyboard/mice IO. It adds many helpful features missing from unity's default input manager (such as rebinding input at runtime) that we would otherwise have to rewrite on our own and is free to use under the MIT license.

The only other third party libraries we use are unity's default libraries.


# Reuse

Game assets could be re-used for future projects with similar artistic themes. The level generation algorithm can be modified to fit other genres such as first-person-shooters or open-world rpgs.

# Change Strategy

1.) Identify the requested change.

2.) Discuss the change with group members.

3.) Evaluate high-level impacts.

4.) Evaluate functional impacts.

5.) Modify the affected user stories.

6.) Add to product backlog.
