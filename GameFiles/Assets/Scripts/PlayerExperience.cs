using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerExperience : MonoBehaviour
{
    public int exp; //player's current experience points
    public int level; //player's current level
    public int expThreshold; //exp needed to reach next level
    public int skillPoints; //players can spend points on new abilities
    public int totalSkillPoints; //total skill points obtained

    public Slider expSlider;
    public Text expText;
    public Text skillText;

    
    void Awake()
    {
        
    }

    // Start is called before the first frame update
    private void Start()
    {
        exp = 0;
        level = 1;
        expThreshold = 100;
        skillPoints = 1;
        totalSkillPoints = skillPoints;
        updateText();
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
        updateText();
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
            totalSkillPoints++;
        }

        if (exp < 0)
            exp = 0;
    }

    public void updateText()
    {
        expText.text = ("Level: " + level + " EXP: " + exp + " / " + expThreshold);
        expSlider.maxValue = expThreshold;
        expSlider.value = exp;
        skillText.text = ("Points Available: " + skillPoints + "\nPoints Obtained: " + totalSkillPoints);
    }
}
