using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private List<Sprite> _healthSprites;
    [SerializeField] private int _health;
    private SpriteRenderer _sr;

    private void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
        SetSprite();
    }

    private void SetSprite()
    {
        _sr.sprite = _healthSprites[Mathf.Clamp(_health-1, 0 ,_healthSprites.Count)];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            _health--;

            if(_health <= 0)
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Movement>().Death();
            }
            Destroy(collision.gameObject);
            SetSprite();
        }
    }
}
