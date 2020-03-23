using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UISkill : MonoBehaviour, IPointerClickHandler
{
    public Ability ability;
    private Image abilityImage;
    GameObject player;
    PlayerExperience exp;
    PlayerAbilities playerAbilities;

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("ability clicked!");
        if (exp.skillPoints > 0)
        {
            playerAbilities.learnAbility(this.ability);
            exp.skillPoints--;
            abilityImage.color = Color.red;
            Debug.Log("ability learned!");
        }
        
    }

    public void showAbility(Ability ability)
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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        exp = player.GetComponent<PlayerExperience>();
        playerAbilities = player.GetComponent<PlayerAbilities>();
        abilityImage = this.gameObject.GetComponent<Image>();
    }
}
