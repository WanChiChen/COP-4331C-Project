using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    void Awake()
    {
        GameObject objs = this.gameObject;

        DontDestroyOnLoad(this.gameObject);
    }
}
