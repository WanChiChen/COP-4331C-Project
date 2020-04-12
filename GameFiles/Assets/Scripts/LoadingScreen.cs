using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingScreen : MonoBehaviour
{
    GameObject screenObject;

    // Start is called before the first frame update
    void Start()
    {
        screenObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        screenObject = GameObject.Find("LoadingScreen");
    }

    public IEnumerator hideScreen()
    {
        screenObject.SetActive(true);
        yield return new WaitForSecondsRealtime(5);
        screenObject.SetActive(false);
    }
}
