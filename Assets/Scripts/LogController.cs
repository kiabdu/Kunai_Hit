using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogController : MonoBehaviour
{
    private float _rotationSpeed = 100f;
    private Animator _animator;
    
    void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        transform.Rotate(new Vector3(0f, 0f, _rotationSpeed * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Kunai") && !KunaiController.IsGameOver)
        {
            _animator.Play("LogHitAnimation");
        }
    }
}
