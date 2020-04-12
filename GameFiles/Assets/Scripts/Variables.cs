using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Luminosity.IO;
using UnityEngine.SceneManagement;
// Store variables that persist through scenes
public static class Variables
{
    private static int gameLevel = 0;
    private static int playerDamageTaken = 0;
    private static float currentDPS = 0f;
    private static float highestDPS = 0f;
    private static float singleTargetDPS = 0f;
    private static float averageDistance = 0f;

    public static List<Item> characterItems = new List<Item>();
    public static List<UIItem> uiItems = new List<UIItem>();
    public static List<Ability> abilitiesList = new List<Ability>();
    public static Ability[] barAbilities = new Ability[16];
    public static List<UIAbility> uiAbilities = new List<UIAbility>();
    public static List<UISkill> uiSkills = new List<UISkill>();
    public static int[] cooldowns = new int[16];
    public static int[] usableAbilities = new int[16];
    public static int damage = 0;
    public static int[] slots = new int[4];
    public static Item[] equippedItems = new Item[4];
    public static int startingHealth = 100;
    public static int currentHealth = 100;
    public static float speed = 4;
    public static int exp = 0;
    public static int level = 1;
    public static int expThreshold = 100;
    public static int skillPoints = 1;
    public static int totalSkillPoints = 1;



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

    public static float SingleTargetDPS
    {
        get
        {
            return singleTargetDPS;
        }
        set
        {
            singleTargetDPS = value;
        }
    }

    public static float AverageDistance
    {
        get
        {
            return averageDistance;
        }
        set
        {
            averageDistance = value;
        }
    }
}

