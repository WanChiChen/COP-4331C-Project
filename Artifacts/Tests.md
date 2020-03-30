|Tested Class|Test Method Name|What is tested|Pass Criteria|
|------------|----------------|--------------|-------------|
|PlayerHealth|PlayerCanBeDamaged|Player health is lowered by appropriate amount upon taking damage|Player health = initial playerhealth - damage taken|
|PlayerHealth|PlayerCanDie|Player dies upon health being 0 or lower|health.isAlive() returns false|
|PlayerMovement|CorrectPlayerVelocity|Player velocity is corresponds to input controls|Player velocity = input * base speed|
|RoomSpawner|Manual Test|A level is generated|A level appears on the game screen when the game scene is entered|
|RoomSpawner|Manual Test|Generated level integrity|The generated level is fully navigateable|
|RoomSystem|Manual Test|Exit at the end of the level|An exit portal is generated at the furthest room from the beginning|
|ExitScript|Manual Test|New level up clearing current one|When the exit portal is touched, a new scene is generated with a new level|
|ItemDatabase|testGetItemByID|Item database returns an item when given an ID.|Item != NULL|
|ItemDatabase|testGetItemByString|Item database returns an item when given a string.|Item != NULL|
|ItemDatabase|testItemID|Item database returns an item with the given ID.|Item ID = input ID|
|ItemDatabase|testItemTitle|Item database returns an item with the given title.|Item Title = input title|
|ItemDatabase|testItemAttributes|Item database attributes can be retrieved correctly.|Item attribute value = expected value|
|Equipment|testInitializeEquipment|Tests that an equipment item is able to initialized.|Equipment != NULL|
|Equipment|testCorrectAttributes|Tests equipment attribute values are stored and retrieved correctly.|Equipment attribute value = expected value|
|PlayerEquip|testCorrectHealthModification|Tests that equipment health modifier attribute modifies player health correctly when equipped.|Player health = starting health + equipment health modifier|
|PlayerEquip|testCorrectSpeedModification|Tests that equipment speed modifier attribute modifies player speed correctly when equipped.|Player speed = starting speed + equipment speed modifier|
|SceneControl|Manual Test|Tests that application closes when QuitGame() is called.|Game application is no longer running|
|SceneControl|Manual Test|Tests that application changes to main menu when LoadMainMenu is called.|Current game scene is the main menu scene|
|UIManager|Manual Test|Tests that game environnment is frozen when game is paused.|Game environment is completely frozen.|
|UIManager|Manual Test|Tests that pause menu appears when the game is paused.|Pause menu is visible in the application.|
|Ability|testInitializeAbility|Tests that an ability object can be initalized. | testAbility != NULL|
|Ability|testDuplicateAbility|Tests that an ability object can be initialized from an existing ability object| testAbility != NULL|
|PlayerAbility|testCorrectStartingHealthModification|Tests that player correctly receives starting health modification upon learning an ability| initialHealth + healthModifier = finalHealth|
|PlayerAbility|testCorrectCurrentHealthModification|Tests that player correctly receives current health modification upon learning an ability| initialHealth + healthModifier = finalHealth|
|PlayerAbility|testCorrectSpeedModification|Tests that player correctly receives speed modification upon learning an ability|initialSpeed + speedModifier = finalSpeed|
|PlayerAbility|testCorrectDamageModification|Tests that player correctly receives damage modification upon learning an ability|initialDamage + damageModifier = finalDamage|
|PlayerAbility|testActiveAbility|Tests that an ability can be used and correctly modifies any necessary player stats| initial health + healthModifier = finalHealth|
|PlayerAbility|testActiveAbilityInitialUsability|Tests that an ability can be used upon being learned|initialUsability == 1|
|PlayerAbility|testActiveAbilityUnusableOnCooldown|Tests that an ability cannot be used when it is on cooldown|finalUsability == 0|
|PlayerAbility|testActiveAbilityUsableAfterCooldown|Tests that an ability can be used after cooldown expires|finalUsability == 1
1|
|UIAbility|Manual Test| Tests that abilities learned by player not on cooldown are displayed on hotbar | Learned ability sprites are visible in original form|
|UIAbility|Manual Test| Tests that abilities learned by player that are on cooldown have that status shown in the UI | Learned ability sprites on cooldown have red overlay|
|UIAbility|Manual Test| Tests that abilities yet to be learned by player have that status shown in the UI | Unlearned ability sprites have red overlay|

