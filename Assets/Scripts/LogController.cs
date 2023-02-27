using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogController : MonoBehaviour
{
    private float _rotationSpeed = 200f;
    private Animation _animation;
    private ParticleSystem _particleSystem;
    
    void Start()
    {
        _animation = gameObject.GetComponent<Animation>();
        _animation.wrapMode = WrapMode.Once;

        _particleSystem = GameObject.Find("ParticleSystem").GetComponent<ParticleSystem>();
    }

    void Update()
    {
        transform.Rotate(new Vector3(0f, 0f, _rotationSpeed * Time.deltaTime));
        
        if (AppleController.AppleDestroyed)
        {
            StartCoroutine(SlowdownRotation(3));
            AppleController.AppleDestroyed = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Kunai") && !KunaiController.IsGameOver)
        {
            _animation.Play();

            _particleSystem.transform.position = col.gameObject.transform.position;
            _particleSystem.Play();
        }
    }

    private IEnumerator SlowdownRotation(int durationInSeconds)
    {
        _rotationSpeed = 50f;
        yield return new WaitForSeconds(durationInSeconds);
        _rotationSpeed = 200f;
    }
}
