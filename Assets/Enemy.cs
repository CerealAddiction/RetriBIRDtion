using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour  
{
    private Rigidbody2D _rb2D;
    private float _movementSpeed = 30.0f;

    // Start is called before the first frame update
    void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _rb2D.velocity = Vector2.down * _movementSpeed;
    }

    
}
