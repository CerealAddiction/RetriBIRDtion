using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBackground : MonoBehaviour
{
    public float foregroundMovementSpeed = 3.0f;
    public float lenghtOfObject = 25.0f;
    public int amountOfObjects = 2;

    void Update()
    {
        transform.Translate(Vector2.down * foregroundMovementSpeed * Time.deltaTime);

        if(transform.position.y > lenghtOfObject && foregroundMovementSpeed > 0)
        {
            transform.Translate(-Vector2.down * amountOfObjects * lenghtOfObject);
        }
        else if (transform.position.y < -lenghtOfObject)
        {
            transform.Translate(Vector2.down * lenghtOfObject * amountOfObjects);
        }
    }
}
