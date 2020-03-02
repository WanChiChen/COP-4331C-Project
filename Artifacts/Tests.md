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
