using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KunaiController : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    
    void Start()
    {
        _rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        ThrowKunai();
    }

    private void ThrowKunai()
    {
        if (GameController.ScreenTapped)
        {
            //Debug.Log("Screen tapped: " + GameController.ScreenTapped);
            _rigidbody2D.AddForce(new Vector2(0f, 200f));
            GameController.ScreenTapped = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Log"))
        {
            //TODO:play log animation on collision
            gameObject.transform.parent = col.gameObject.transform;
            Destroy(gameObject.GetComponent<Rigidbody2D>());
            Destroy(gameObject.GetComponent<KunaiController>());
        } else if (col.gameObject.CompareTag("Kunai"))
        {
            
        }
    }
}
