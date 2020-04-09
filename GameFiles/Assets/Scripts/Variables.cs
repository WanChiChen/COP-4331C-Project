// Store variables that persist through scenes
public static class Variables
{
    private static int gameLevel = 0;
    private static int playerDamageTaken = 0;
    private static float currentDPS = 0;
    private static float highestDPS = 0;

    public static int GameLevel
    {
        get
        {
            return gameLevel;
        }
        set
        {
            gameLevel = value;
        }
    }

    public static int PlayerDamageTaken
    {
        get
        {
            return playerDamageTaken;
        }
        set
        {
            playerDamageTaken = value;
        }
    }

    public static float CurrentDPS
    {
        get
        {
            return currentDPS;
        }
        set
        {
            currentDPS = value;
        }
    }

    public static float HighestDPS
    {
        get
        {
            return highestDPS;
        }
        set
        {
            highestDPS = value;
        }
    }
}

