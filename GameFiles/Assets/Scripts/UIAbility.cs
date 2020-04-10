using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIAbility : UISkill
{
    public int index;
    private int tempIndex;
    private UIAbility selectedAbility;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerAbilities = player.GetComponent<PlayerAbilities>();
        abilityImage = this.gameObject.GetComponent<Image>();
        selectedAbility = GameObject.Find("SelectedAbility").GetComponent<UIAbility>();
        selectedAbility.showAbility(null);
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        if(this.ability != null)
        {
            if (selectedAbility.ability != null)
            {
                Ability clone = new Ability(selectedAbility.ability);

                selectedAbility.showAbility(this.ability);
                selectedAbility.ability = this.ability;

                ability = clone;
                showAbility(clone);

                playerAbilities.abilities[index] = clone;
                
            }
            else
            {
                selectedAbility.showAbility(this.ability);
                selectedAbility.ability = this.ability;
                
                showAbility(null);
                ability = null;
            }
        }
        else if (selectedAbility.ability != null)
        {
            showAbility(selectedAbility.ability);
            playerAbilities.abilities[index] = selectedAbility.ability;
            ability = selectedAbility.ability;
            selectedAbility.ability = null;
            selectedAbility.showAbility(null);
        }
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
            abilityImage.sprite = null;
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        if(ability != null)
        {
            if (playerAbilities.usableAbilities[index] == 0)
            {
                updateAbility(ability, 0);
            }
            if (playerAbilities.usableAbilities[index] == 1)
            {
                updateAbility(ability, 1);
            }
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
