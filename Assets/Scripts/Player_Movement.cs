using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(CapsuleCollider2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]

public class Player_Movement : MonoBehaviour
{

    private Rigidbody2D _rb2D;
    //Non force based movement stuff.
    //private float _movementSpeed = 3.0f;
    //How much force is put into movement. SerializeField= U can change shit in unity instead of here.
    [SerializeField] private float _movementForce = 10.0f;
    //private float _movVal = 0.0f;

    private float _xVal = 0.0f;
    private float _yVal = 0.0f;
    private Vector2 _movementVector = new Vector2();

    private Animator _ani;
    private float _mass = 100.0f;

    public GameObject _bulletToSpawn;
    [SerializeField] private Transform _bulletSpawn;
    public float bulletSpeed = 10.0f;

    // Start is called before the first frame update
    private void Start()
    {
        //Interacts with Rigidbody.
        _rb2D = GetComponent<Rigidbody2D>();
        _ani = GetComponent<Animator>();

        _mass = _rb2D.mass;
    }

    // Update is called once per frame
    private void Update()
    {
        _xVal = Input.GetAxis("Horizontal");
        _yVal = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Space) && _ani.GetBool("ShootDone"))
        {
            _ani.SetTrigger("Shoot");
        }
    }

    private void FixedUpdate()
    {
        _movementVector.x = _xVal;
        _movementVector.y = _yVal;

        _movementVector = Vector2.ClampMagnitude(_movementVector, 1.0f);
        _movementVector *= _movementForce * _mass;

        _rb2D.AddForce(_movementVector, ForceMode2D.Impulse);

    }
    public void ShootBullet()
    {
        if (_bulletToSpawn != null)
        {
            GameObject go = Instantiate(_bulletToSpawn, _bulletSpawn.position, _bulletSpawn.rotation);
            go.GetComponent<Rigidbody2D>().velocity = Vector2.up * bulletSpeed;

            Destroy(go, 5.0f);
        }
        else
        {
            Debug.LogError("You didn't put a bullet in the script, nerd");
        }


    }

    public void Death()
    {
        //Destroy(gameObject);
        SceneManager.LoadScene(2); //?????? (l?gg int tillbaka denna, men l?gg tillbaka allt annat)
    }


}