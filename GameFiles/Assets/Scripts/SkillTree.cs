using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Luminosity.IO;

public class SkillTree : MonoBehaviour
{
    public SkillCanvas canvas;


    void Start()
    {
        canvas.gameObject.SetActive(!canvas.gameObject.activeSelf);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (InputManager.GetButtonDown("SkillTree")) 
        {
            canvas.gameObject.SetActive(!canvas.gameObject.activeSelf);
        }
    }
}
