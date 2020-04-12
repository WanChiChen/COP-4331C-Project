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
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        if(this.ability != null)
        {
            if(playerAbilities.usableAbilities[index] == 1)
            {
                if (selectedAbility.ability != null)
                {
                    Ability clone = new Ability(selectedAbility.ability);
                    tempIndex = selectedAbility.index;

                    selectedAbility.showAbility(this.ability);
                    selectedAbility.ability = this.ability;
                    selectedAbility.index = this.index;

                    ability = clone;
                    showAbility(clone);

                    playerAbilities.barAbilities[index] = clone;
                    playerAbilities.usableAbilities[index] = playerAbilities.usableAbilities[tempIndex];
                    playerAbilities.cooldowns[index] = playerAbilities.cooldowns[tempIndex];

                }
                else
                {
                    selectedAbility.showAbility(this.ability);
                    selectedAbility.ability = this.ability;
                    selectedAbility.index = this.index;

                    showAbility(null);
                    ability = null;
                }
            }
        }
        else if (selectedAbility.ability != null)
        {
            showAbility(selectedAbility.ability);
            playerAbilities.barAbilities[index] = selectedAbility.ability;
            playerAbilities.usableAbilities[index] = playerAbilities.usableAbilities[selectedAbility.index];
            playerAbilities.cooldowns[index] = playerAbilities.cooldowns[selectedAbility.index];
            ability = selectedAbility.ability;
            selectedAbility.ability = null;
            selectedAbility.showAbility(null);
            selectedAbility.index = -1;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        selectedAbility.showAbility(null);
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

    public override void OnPointerEnter(PointerEventData eventData)
    {

    }

    public override void OnPointerExit(PointerEventData eventData)
    {

    }
}
