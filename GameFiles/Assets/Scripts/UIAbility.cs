using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIAbility : UISkill
{
    public int index;
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerAbilities = player.GetComponent<PlayerAbilities>();
        abilityImage = this.gameObject.GetComponent<Image>();
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Ability Bar clicked!");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public override void showAbility(Ability ability)
    {
        this.ability = ability;
        if (this.ability != null)
        {
            abilityImage.color = Color.white;
            abilityImage.sprite = this.ability.icon;
        }
        else
        {
            abilityImage.color = Color.clear;
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        if(playerAbilities.usableAbilities[index] == 0)
        {
            updateAbility(ability, 0);
        }
        if (playerAbilities.usableAbilities[index] == 1)
        {
            updateAbility(ability, 1);
        }
    }

   public void updateAbility(Ability ability, int flag)
    {
        this.ability = ability;
        if (flag == 0)
        {
            abilityImage.color = Color.red;
        }
        if(flag == 1)
        {
            abilityImage.color = Color.white;
        }
    }
}
