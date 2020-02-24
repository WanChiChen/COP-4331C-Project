|Tested Class|Test Method Name|What is tested|Pass Criteria|
|------------|----------------|--------------|-------------|
|PlayerHealth|PlayerCanBeDamaged|Player health is lowered by appropriate amount upon taking damage|Player health = initial playerhealth - damage taken|
|PlayerHealth|PlayerCanDie|Player dies upon health being 0 or lower|health.isAlive() returns false|
|PlayerMovement|CorrectPlayerVelocity|Player velocity is corresponds to input controls|Player velocity = input * base speed|
|RoomSpawner|Manual Test|A level is generated|A level appears on the game screen when the game scene is entered|
|RoomSpawner|Manual Test|Generated level integrity|The generated level is fully navigateable|
|RoomSystem|Manual Test|Exit at the end of the level|An exit portal is generated at the furthest room from the beginning|
|ExitScript|Manual Test|New level up clearing current one|When the exit portal is touched, a new scene is generated with a new level|
