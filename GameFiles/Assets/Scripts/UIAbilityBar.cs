using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIAbilityBar : MonoBehaviour
{
    GameObject player;
    PlayerAbilities abilities;
    public List<UIAbility> uiAbilities = new List<UIAbility>();
    public GameObject slotPrefab;
    public Transform slotPanel;

    const int numAbilities = 5;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        abilities = player.GetComponent<PlayerAbilities>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
        for (int i = 0; i < numAbilities; i++)
        {
            GameObject instance = Instantiate(slotPrefab);
            instance.transform.SetParent(slotPanel);
            uiAbilities.Add(instance.GetComponentInChildren<UIAbility>());

            uiAbilities[i].index = i;
            
            if(abilities.abilities[i] != null)
            {
                uiAbilities[i].showAbility(abilities.abilities[i]);
            }
            else
            {
                uiAbilities[i].showAbility(null);
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
