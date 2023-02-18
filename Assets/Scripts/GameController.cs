using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GameController : MonoBehaviour
{
    public GameObject kunai, log;
    public GameObject kunaisLeft;
    public static bool ScreenTapped = false;
    private Vector3 _origin;
    private int _kunaiCount;
    private List<GameObject> _kunaiCounterList;
    private Sprite _kunaiLeftSprite_2;
    private SpriteRenderer _kunaiLeftSpriteRenderer;
    private string _kunaiLeftSpritePath;

    void Start()
    {
        _origin = new Vector3(0f, -2.75f, -1f);
        
        _kunaiCount = 5;
        _kunaiCounterList = new List<GameObject>();
        CreateKunaiCounter(_kunaiCount);

        _kunaiLeftSpritePath = "Sprites/Kunais_Left_2";
        _kunaiLeftSprite_2 = Resources.Load<Sprite>(_kunaiLeftSpritePath);
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
            _kunaiCount--;
            _kunaiCounterList[_kunaiCount].GetComponent<SpriteRenderer>().sprite = _kunaiLeftSprite_2;
        }
    }
    
    private void GameOver()
    {
        if (KunaiController.IsGameOver)
        {
            Time.timeScale = 0f;
        }
    }

    private void CreateKunaiCounter(int count)
    {
        float yStartPosition = -5f;
        float yOffset = 0.5f;
        
        for (int i = 0; i < count; i++)
        {
            GameObject tmp = Instantiate(kunaisLeft, new Vector3(-3f, yStartPosition, -5f), new Quaternion(0f, 0f, 0f, 0f));
            _kunaiCounterList.Add(tmp);
            yStartPosition += yOffset;
        }
    }
}
