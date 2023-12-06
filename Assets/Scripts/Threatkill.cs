using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]


public class Threatkill : MonoBehaviour

{
    private Rigidbody2D _rb2D;
    private Animator _ani;
    private float _mass = 100.0f;

    // Start is called before the first frame update
    void Start()
    {
        //Interacts with Rigidbody.
        _rb2D = GetComponent<Rigidbody2D>();
        _ani = GetComponent<Animator>();

        _mass = _rb2D.mass;

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject);

        }

    }  
    
        private bool _once = false;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !_once)
        {
            _once = true;
            GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreHandler>().AddScore();
        }
    }
}







