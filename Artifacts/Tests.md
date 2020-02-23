|Tested Class|Test Method Name|What is tested|Pass Criteria|
|------------|----------------|--------------|-------------|
|PlayerHealth|PlayerCanBeDamaged|Player health is lowered by appropriate amount upon taking damage|Player health = initial playerhealth - damage taken|
|PlayerHealth|PlayerCanDie|Player dies upon health being 0 or lower|health.isAlive() returns false|
|PlayerMovement|CorrectPlayerVelocity|Player velocity is corresponds to input controls|Player velocity = input * base speed|
