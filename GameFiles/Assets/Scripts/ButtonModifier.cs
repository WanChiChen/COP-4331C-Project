using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonModifier : MonoBehaviour
{
    KeyBindings binds;
    GameObject keyBindings;
    public int ID;
    // Start is called before the first frame update
    void Start()
    {
        changeButtonText(binds.keyCodes[ID]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        keyBindings = GameObject.Find("Key Bindings");
        binds = keyBindings.GetComponent<KeyBindings>();
        
    }

    public void changeButtonText(KeyCode key)
    {
        string text = key.ToString();
        this.gameObject.GetComponentInChildren<Text>().text = text;
        binds.changeKey(ID, key);
    }

    public void inputKey(int key)
    {
        switch (key)
        {
            case 0:
                changeButtonText(KeyCode.A);
                break;
            case 1:
                changeButtonText(KeyCode.B);
                break;
            case 2:
                changeButtonText(KeyCode.C);
                break;
            case 3:
                changeButtonText(KeyCode.D);
                break;
        }

        

    }
}
