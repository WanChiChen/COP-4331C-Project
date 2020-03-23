using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBindings : MonoBehaviour
{
    //changeable key bindings
    const int numKeys = 12;
    public KeyCode[] keyCodes = new KeyCode[numKeys];

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        defaultBindings();
    }

    void defaultBindings()
    {
        keyCodes[0] = KeyCode.W; //up
        keyCodes[1] = KeyCode.S; //down
        keyCodes[2] = KeyCode.A; //left
        keyCodes[3] = KeyCode.D; //right
        keyCodes[4] = KeyCode.P; //pause
        keyCodes[5] = KeyCode.I; //inventory
        keyCodes[6] = KeyCode.Mouse0; //fire
        keyCodes[7] = KeyCode.Alpha1; //ability1
        keyCodes[8] = KeyCode.Alpha2; //ability2
        keyCodes[9] = KeyCode.Alpha3; //ability3
        keyCodes[10] = KeyCode.Alpha4; //ability4
        keyCodes[11] = KeyCode.Alpha5; //ability5
    }

    public void changeKey(int keyID, KeyCode key)
    {
        keyCodes[keyID] = key;
        Debug.Log("key " + keyID + " has been changed to " + key);
    }

    

    
    /*public void inputKeyID(int keyID)
    {
        Event e;
        bool repeat = true;
        while (repeat)
        {
            e = Event.current;
            Debug.Log("Detected key code: " + e.keyCode);
            if (e.isKey)
            {
                changeKey(keyID, e.keyCode);
                repeat = false;
            }
        }
        
    }*/


}
