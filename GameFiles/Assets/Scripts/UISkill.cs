using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UISkill : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Ability ability;
    public Image abilityImage;
    public GameObject player;
    public PlayerExperience exp;
    public PlayerAbilities playerAbilities;
    public SkillTooltip toolTip;
    public GameObject toolTipObject;
    public UIAbilityBar bar;

    public virtual void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("ability clicked!");
        if (exp.skillPoints - ability.cost>= 0)
        {
            playerAbilities.learnAbility(this.ability);
            exp.skillPoints -= ability.cost;
            exp.updateText();
            abilityImage.color = Color.red;

            if(ability.type == 1 || ability.type == 2)
            {
                int index = bar.findEmptySlot();
                bar.uiAbilities[index].showAbility(this.ability);
                bar.uiAbilities[index].ability = this.ability;
            }
        }
    }

    public virtual void showAbility(Ability ability)
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
        toolTip = GameObject.Find("SkillToolTipText").GetComponent<SkillTooltip>();
        toolTipObject = GameObject.Find("SkillToolTip");
        bar = GameObject.Find("AbilityBarPanel").GetComponent<UIAbilityBar>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        toolTipObject.SetActive(true);
        if (this.ability != null)
        {
            toolTip.generateToolTip(this.ability);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        toolTipObject.SetActive(false);
    }
}
