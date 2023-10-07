using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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
    //Extra movement adjustments when not grounded.
    private float _airControl = 0.5f;
    //private float _movVal = 0.0f;

    private float _xVal = 0.0f;
    private Vector2 _movementVector = new Vector2();
    //Force put into jumps. SerializeField is same thing as before.
    [SerializeField] private float _jumpForce = 30.0f;

    private Animator _ani;

    public GameObject originalBullet;
    [SerializeField] private Transform _bulletSpawn;
    public float bulletSpeed = 10.0f;

    // Start is called before the first frame update
    private void Start()
    {
        //Interacts with Rigidbody.
        _rb2D = GetComponent<Rigidbody2D>();
        _ani = GetComponent<Animator>();


    }

    // Update is called once per frame
    private void Update()
    {
        _xVal = Input.GetAxis("Horizontal");
        //Jump stuff.
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            _ani.SetTrigger("Jump");
            _rb2D.velocity = new Vector2(_rb2D.velocity.x, 0.0f);
            _rb2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }


        if (Input.GetKeyDown(KeyCode.F) && _ani.GetBool("ShootDone"))
        {
            _ani.SetTrigger("Shoot");
        }
    }
    //If on ground: Permit jumping. If not: No.
    private bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.CircleCast(transform.position, 0.5f, Vector2.down, 0.6f);

        if (hit.collider != null)
        {
            return true;
        }


        return false;
    }

    private void FixedUpdate()
    {
        if (IsGrounded())
        {
            _movementVector.x = _xVal * _movementForce;

            if (Mathf.Abs(_xVal) > 0.1f)
            {
                _ani.SetBool("stop", false);
            }
            else
            {
                _ani.SetBool("stop", true);
            }
        }
        else
        {
            _movementVector.x = _xVal * _movementForce * _airControl;
            _ani.SetBool("stop", true);
        }

        _rb2D.AddForce(_movementVector);

    }
    public void ShootBullet()
    {
        GameObject bullet = Instantiate(originalBullet, _bulletSpawn.position, _bulletSpawn.rotation);

        bullet.GetComponent<Rigidbody2D>().velocity = Vector2.right * bulletSpeed;

        Destroy(bullet, 5.0f);
    }

}