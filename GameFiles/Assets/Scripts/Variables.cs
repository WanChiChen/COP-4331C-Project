// Store variables that persist through scenes
public static class Variables
{
    private static int gameLevel = 0;

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
}
