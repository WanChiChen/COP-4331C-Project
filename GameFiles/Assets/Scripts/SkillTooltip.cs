using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillTooltip : MonoBehaviour
{
    private Text toolTip;
    private GameObject toolTipObject;
    // Start is called before the first frame update
    void Awake()
    {
        toolTip = this.gameObject.GetComponent<Text>();
        toolTipObject = GameObject.Find("SkillToolTip");
    }

    private void Start()
    {
        toolTipObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void generateToolTip(Ability ability)
    {
        string stats="";
        string description="";
        string cost = "Cost: " + ability.cost;
        if(ability.type == 0)
        {
            stats = "Base Health Increase: " + ability.modifiers[0] +
                    "\nBase Speed Increase: " + ability.modifiers[1] +
                    "\nBase Damage Increase: " + ability.modifiers[2];
            description = "Passive Ability. " + ability.description;
        }
        if (ability.type == 1)
        {
            stats = "Health Gain/Loss: " + ability.modifiers[0] +
                    "\nDamage Boost/Loss: " + ability.modifiers[1] +
                    "\nCooldown: " + ability.modifiers[2];
            description = "Usable Ability. " + ability.description;
        }   
        if (ability.type == 2)
        {
            stats = "Health Gain/Loss: " + ability.modifiers[0] +
                    "\nDamage Done: " + ability.modifiers[1] +
                    "\nCooldown: " + ability.modifiers[2];
            description = "Attack Ability. " + ability.description;
        }

        toolTip.text = (ability.title + "\n" + description + "\n" + stats + "\n" + cost);

    }
}
