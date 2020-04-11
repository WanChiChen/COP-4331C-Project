using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillCanvas : MonoBehaviour
{
    public List<UISkill> uiAbilities = new List<UISkill>();
    public GameObject slotPrefab;
    public Transform slotPanel;
    public int slotNum = 16; //number of learnable abilities

    public AbilityDatabase db;

    private void Awake()
    {
        db.BuildDatabase();
        for (int i = 0; i < slotNum; i++)
        {
            
            GameObject instance = Instantiate(slotPrefab);
            instance.transform.SetParent(slotPanel);
            uiAbilities.Add(instance.GetComponentInChildren<UISkill>());

            uiAbilities[i].showAbility(db.getAbility(i+1));
        }
    }

    // Start is called before the first frame update
    
}
