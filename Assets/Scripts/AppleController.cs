using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleController : MonoBehaviour
{
    // Start is called before the first frame update
    private int _appleCount;
    private GameObject _leftSplit, _rightSplit;
    private SpriteRenderer _spriteRenderer, _leftSplitSpriteRenderer, _rightSplitSpriteRenderer;
    private Rigidbody2D _leftSplitRigidbody2D, _rightSplitRigidbody2D;
    
    void Start()
    {
        _appleCount = PlayerPrefs.GetInt("AppleCount", 0);

        _leftSplit = transform.GetChild(0).gameObject;
        _rightSplit = transform.GetChild(1).gameObject;
        
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _leftSplitSpriteRenderer = _leftSplit.GetComponent<SpriteRenderer>();
        _rightSplitSpriteRenderer = _rightSplit.GetComponent<SpriteRenderer>();
        
        _leftSplitRigidbody2D = _leftSplit.GetComponent<Rigidbody2D>();
        _rightSplitRigidbody2D = _rightSplit.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        //Layer 6 is the kunai layer, using tag would conflict with the onTriggerEnter method of KunaiController
        if (col.gameObject.layer == 6)
        {
            Debug.Log("Kunai triggered apple");
            _appleCount++;
            PlayerPrefs.SetInt("AppleCount", _appleCount);
            AnimateSplit();
            StartCoroutine(DestroyApple(1));
        }
    }

    private void AnimateSplit()
    {
        Debug.Log("Animating split");
        _spriteRenderer.enabled = false;
        _leftSplitSpriteRenderer.enabled = true;
        _rightSplitSpriteRenderer.enabled = true;
        
        transform.DetachChildren();
        
        _leftSplitRigidbody2D.AddForce(new Vector2(-50f, -200f));
        _rightSplitRigidbody2D.AddForce(new Vector2(50f, -200f));
    }

    private IEnumerator DestroyApple(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(_leftSplit);
        Destroy(_rightSplit);
        Destroy(gameObject);
    }
}