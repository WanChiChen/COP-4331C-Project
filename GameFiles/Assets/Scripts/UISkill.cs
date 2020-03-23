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
        if(exp.skillPoints > 0)
        {
            playerAbilities.learnAbility(this.ability);
            exp.skillPoints--;
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
    }
}
