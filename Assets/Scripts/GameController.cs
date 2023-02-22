using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GameController : MonoBehaviour
{
    public GameObject kunai, log;
    public GameObject kunaisLeft;
    public static bool ScreenTapped = false;
    private Vector3 _origin;
    public static int KunaiCount;
    private List<GameObject> _kunaiCounterList;
    private Sprite _kunaiLeftSprite_2;
    private SpriteRenderer _kunaiLeftSpriteRenderer;
    private string _kunaiLeftSpritePath;

    private void Awake()
    {
        SetKunaiCount();
    }

    void Start()
    {
        _origin = new Vector3(3.37f, -2.75f, -1f);
        
        KunaiCount = 5;
        _kunaiCounterList = new List<GameObject>();
        CreateKunaiCounter(KunaiCount);

        _kunaiLeftSpritePath = "Sprites/Kunais_Left_2";
        _kunaiLeftSprite_2 = Resources.Load<Sprite>(_kunaiLeftSpritePath);
    }

    // Update is called once per frame
    void Update()
    {
        InstantiateKunai();
        GameOver();
        GameWon();
    }

    private void InstantiateKunai()
    {
        if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) || Input.GetKeyDown(KeyCode.Space))
        {
            ScreenTapped = true;
            
            if (KunaiCount >= 0)
            {
                KunaiCount--;   
                _kunaiCounterList[KunaiCount].GetComponent<SpriteRenderer>().sprite = _kunaiLeftSprite_2;
            }
            
            if (KunaiCount >= 1)
            {
                Instantiate(kunai, _origin, new Quaternion(0f, 0f, 0f, 0f));
            }
        }
    }
    
    private void GameOver()
    {
        if (KunaiController.IsGameOver)
        {
            Time.timeScale = 0f;
        }
    }

    private void GameWon()
    {
        
        if (KunaiController.IsGameWon)
        {
            //Timer(1);
            KunaiController.IsGameWon = false;
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private IEnumerable<WaitForSeconds> Timer(int seconds)
    {
        yield return new WaitForSeconds(seconds);
    }

    private void CreateKunaiCounter(int count)
    {
        float yStartPosition = -5f;
        float yOffset = 0.5f;
        float xOffset = Camera.main.ScreenToWorldPoint(
            new Vector3(Screen.width, 0f, 0f)).x 
                        - (kunaisLeft.GetComponent<SpriteRenderer>().sprite.bounds.size.x) / 2f;

        for (int i = 0; i < count; i++)
        {
            GameObject tmp = Instantiate(kunaisLeft, new Vector3(xOffset, yStartPosition, -5f), new Quaternion(0f, 0f, 0f, 0f));
            _kunaiCounterList.Add(tmp);
            yStartPosition += yOffset;
        }
    }

    private void SetKunaiCount()
    {
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 0:
                KunaiCount = 3;
                break;
            case 1:
                KunaiCount = 4;
                break;
            default:
                KunaiCount = 5;
                break;
        }
    }
}
