using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GameController : MonoBehaviour
{
    public GameObject kunai, log;
    public static bool ScreenTapped = false;
    
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        InstantiateKunai();
    }

    private void InstantiateKunai()
    {
        if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) || Input.GetKeyDown(KeyCode.Space))
        {
            ScreenTapped = true;
            Instantiate(kunai);
        }
    }
}
