using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExperience : MonoBehaviour
{
    public int exp; //player's current experience points
    public int level; //player's current level
    public int expThreshold; //exp needed to reach next level
    public int skillPoints; //players can spend points on new abilities

    // Start is called before the first frame update
    void Awake()
    {
        exp = 0;
        level = 1;
        expThreshold = 100;
        skillPoints = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // adds collected exp to player's exp
    public void collectExperience(int amount)
    {
        exp += amount;
        if (exp >= expThreshold)
        {
            levelUp();
        }
    }

    // called when player exp increases past current threshold
    public void levelUp()
    {
        while(exp > expThreshold)
        {
            exp -= expThreshold;
            level++;
            expThreshold = (int)((double)expThreshold * 1.2);
            skillPoints++;
        }

        if (exp < 0)
            exp = 0;
    }
}
