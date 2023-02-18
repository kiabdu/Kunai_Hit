using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GameController : MonoBehaviour
{
    public GameObject kunai, log;
    public static bool ScreenTapped = false;
    private Vector3 _origin;
    
    void Start()
    {
        _origin = new Vector3(0f, -2.75f, -1f);
    }

    // Update is called once per frame
    void Update()
    {
        InstantiateKunai();
        GameOver();
    }

    private void InstantiateKunai()
    {
        if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) || Input.GetKeyDown(KeyCode.Space))
        {
            ScreenTapped = true;
            Instantiate(kunai, _origin, new Quaternion(0f, 0f, 0f, 0f));
        }
    }
    
    private void GameOver()
    {
        if (KunaiController.IsGameOver)
        {
            Time.timeScale = 0f;
        }
    }
}
