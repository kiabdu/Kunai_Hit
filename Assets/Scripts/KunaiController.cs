using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KunaiController : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private float _kunaiForce = 600f;
    public static bool IsGameOver = false;

    void Start()
    {
        _rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        ThrowKunai();
    }

    private void ThrowKunai()
    {
        if (GameController.ScreenTapped)
        {
            //Debug.Log("Screen tapped: " + GameController.ScreenTapped);
            _rigidbody2D.AddForce(new Vector2(0f, _kunaiForce));
            //will be set to true by GameController every time the screen is tapped
            GameController.ScreenTapped = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Log"))
        {
            gameObject.transform.parent = col.gameObject.transform;
            gameObject.tag = "Kunai";
            Destroy(gameObject.GetComponent<Rigidbody2D>());
            Destroy(gameObject.GetComponent<KunaiController>());
        } else if (col.gameObject.CompareTag("Kunai"))
        {
            IsGameOver = true;
        }
    }
}
