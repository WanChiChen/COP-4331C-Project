using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillCanvas : MonoBehaviour
{
    public List<UISkill> uiAbilities = Variables.uiSkills;
    public GameObject slotPrefab;
    public Transform slotPanel;
    public PlayerAbilities playerAbilities;
    public int slotNum = 16; //number of learnable abilities

    public AbilityDatabase db;

    private void Awake()
    {
        playerAbilities = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAbilities>();
    }

    // Start is called before the first frame update
    private void Start()
    {
        for (int i = 0; i < slotNum; i++)
        {
            GameObject instance = Instantiate(slotPrefab);
            instance.transform.SetParent(slotPanel);
            uiAbilities.Add(instance.GetComponentInChildren<UISkill>());
            db.BuildDatabase();
            uiAbilities[i].showAbility(db.getAbility(i + 1));
            if(Variables.GameLevel > 0)
            {
                if (playerAbilities.abilities.Find(searchAbility => searchAbility.id == uiAbilities[i].ability.id) != null)
                {
                    uiAbilities[i].abilityImage.color = Color.red;
                }
            }
        }
    }
}
