using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Luminosity.IO;

public class ButtonModifier : MonoBehaviour
{
    public string ID;
    public int direction;
    ScanSettings settings;

    // Start is called before the first frame update
    void Start()
    {
        if(direction == 1)
        {
            changeButtonText(InputManager.GetAction("Default", ID).Bindings[0].Positive);
        }

        if (direction == 0)
        {
            changeButtonText(InputManager.GetAction("Default", ID).Bindings[0].Negative);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        settings = new ScanSettings
        {
            ScanFlags = ScanFlags.Key,
            // If the player presses this key the scan will be canceled.
            CancelScanKey = KeyCode.Escape,
            // If the player doesn't press any key within the specified number
            // of seconds the scan will be canceled.
            Timeout = 10
        };
    }

    public void changeButtonText(KeyCode key)
    {
        string text = key.ToString();
        this.gameObject.GetComponentInChildren<Text>().text = text;
    }
    

    public void inputKeyID(string keyName)
    {
        InputManager.StartInputScan(settings, result =>
        {
            InputAction inputAction = InputManager.GetAction("Default", keyName);
            if (direction == 1)
            {
                inputAction.Bindings[0].Positive = result.Key;
            }
            if (direction == 0)
            {
                inputAction.Bindings[0].Negative = result.Key;
            }
            changeButtonText(result.Key);
            return true;
        });
    }
}
