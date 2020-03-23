using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        
        if (Input.GetKeyDown(KeyCode.T)) //default skill tree key
        {
            canvas.gameObject.SetActive(!canvas.gameObject.activeSelf);
        }
    }
}
