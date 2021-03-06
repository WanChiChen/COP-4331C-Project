# Requirements

|Requirement ID |User Story ID|Requirement|Acceptance Criteria|Effort|Priority|Status|
|---------------|--------------|----------|-------------------|------|--------|------|
|1	| 001|The application shall be able to be successfully launched.|User is able to launch the application.|3|Necessary| Working|
|2  | 015|The game shall have a main menu.|User is able to transition to other screens from the main menu.|4|Necessary|Working|
|3  | 014|The game shall be able to save your progress.| User is able to save current game progress to the system storage.|4|Necessary|Planned|
|4  | 014|The user shall be able to load saved game files.| User is able to open a previously saved game file.|4|Necessary|Planned|
|5  | 016|The game shall have an options menu to change key bindings and settings.|User can change game settings and key bindings|3|Important|Planned|
|6  | 011|The game shall generate levels as the user progresses through the game.|New levels are created as the user plays the game.|4| Necessary| Working|
|7  | 011|The levels shall be generated based on tracked user statistics (distance from enemies, damage taken, items/skill used, etc.).|User playstyle changes causes levels to generate differently.|6|Necessary|In Progress.|
|8  | 011|The game shall use modular rooms that will be assembled together for each level.|Levels are assembeled from a list of pre-designed rooms.|3|Necessary|Working|
|9  | 012|The game shall increase in difficulty as the user progresses.|Enemy health, attack, and/or generation rate increases as user progresses through the game|3|Important|Planned|
|10 | 004|The user shall be able to collect items.|User can collect items in their inventory.|4|Necessary|Planned|
|11 | 008|The user shall be select from multiple pre-designed classes.|User can choose from classes with different abilities when creating the game.|5|Important|Planned|
|12 | 006|The user shall be able to manage items and equipment from an inventory screen.| The user can open the inventory to manage collected items.|4|Necessary|Planned|
|13 | 008|User selectable classes shall have abilitites and attributes unique to each class.|Class abilites have different statistics and usable abilities.|4|Important|Planned|
|14 | 018|The game shall have a skill tree that can be unlocked by earning XP.|User can use XP to obtain new abilities.|3|Necessary|Planned|
|15 | 017|The game shall have XP that can be earned by defeating enemies.|User can collect XP from defeated enemies.|3|Necessary|Planned|
|16 | 019|The game shall have a variety of enemies that can be encountered.|Enemies will have different stats and abilities.|5|Necessary|Planned|
|17 | 020|Enemies shall be able to drop items.|Enemies shall drop items collectable by the users.|3|Necessary|Planned|
|18 | 005|The user shall be able to traverse within and between rooms.|User can move player sprite between rooms|4|Necessary|Working|
|19 | 009|The user shall be able to attack enemies and objects.|User can damage other game entities.|4|Necessary|Working|
|20 | 025|The user shall be able to pause the game| User can freeze the state of the game environment.|3|Necessary| Planned|
|21 | 026|The user shall be able to access a menu to save the game and change options after pausing a game.| User can access main menu screens from the pause menu.|4|Necessary|Planned|
|22 |  024|The user shall be able to exit the application. | User can close the application.|2|Necessary|Working|
|23 |  013|The user shall be able to take damage.|User health is lowered by damage amount when attacked.|4|Necessary|Working|
|24 |  028|The user shall be directed to a "game over" screen upon death.|Application switches to "game over" scene upon user health reaching 0 and dying.|2|Necessary|Planned|
|25 |  018|The user shall be able to view the skills they have acquired.|Obtained skills are visible on the skill tree.|2|Important|Working|
|26 |  018|The user shall be able to interact with game environment normally while the skill tree and inventory are opened.|Game environment continues running while skill tree or inventory is open. | 2| Important| Working|
|27 |  028|The user shall be able to view which abilities are off cooldown and available for use.| Ability user interface reflects status of available abilities.| 3| Necessary| Planned|
|28 | 030| The user shall be able to choose which learned abilities are actively available for use.|Ability user interface allows user to swap between learned abilities that are available for use. | 3 | Necessary | Planned|
|29 | 016| The game's keybindings and user options shall be stored locally and read at runtime. | Game options are saved to local system and are able to saved/loaded during runtime. | Necessary | 1 | Necessary | Planned|
