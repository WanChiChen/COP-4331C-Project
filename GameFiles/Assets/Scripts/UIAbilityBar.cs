using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIAbilityBar : MonoBehaviour
{
    GameObject player;
    PlayerAbilities abilities;
    PlayerProgressTracker progress;
    public List<UIAbility> uiAbilities = new List<UIAbility>();
    public GameObject slotPrefab;
    public Transform slotPanel;

    const int numAbilities = 9;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        abilities = player.GetComponent<PlayerAbilities>();
        progress = GameObject.Find("PlayerProgressTracker").GetComponent<PlayerProgressTracker>();
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
            uiAbilities[i].ability = null;
            uiAbilities[i].showAbility(null);
            abilities.barAbilities = Variables.barAbilities;
            abilities.cooldowns = Variables.cooldowns;
            abilities.usableAbilities = Variables.usableAbilities;
            if (abilities.barAbilities[i] != null)
            {
                uiAbilities[i].showAbility(abilities.barAbilities[i]);
                uiAbilities[i].ability = abilities.barAbilities[i];
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int findEmptySlot()
    {
        
        for (int i = 0; i < numAbilities; i++)
        {
            //Debug.Log(uiAbilities);
            if (uiAbilities[i].ability == null)
            {
                return i;
            }
        }
        return -1;
    }
}
