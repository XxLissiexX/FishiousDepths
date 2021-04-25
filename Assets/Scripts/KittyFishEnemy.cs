using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KittyFishEnemy : MonoBehaviour
{

    public float _kittySpeed = 2.0f;

 

    enum Direction
    {
        Left,
        Right
    }

    Direction _kittyDirection;

    float timeRemaining = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        _kittyDirection = Direction.Left;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRemaining > 0)
        {
            if (_kittyDirection == Direction.Left)
            {
                transform.position += Vector3.left * _kittySpeed * Time.deltaTime;

            }
           
            if (_kittyDirection == Direction.Right)
            {
                transform.position += Vector3.right * _kittySpeed * Time.deltaTime;
            }

      

            timeRemaining -= Time.deltaTime;
        }

        else
        {
            ChangeDirection();
            timeRemaining = 1.0f;
        }
    }
    void ChangeDirection()
    {

        if (_kittyDirection == Direction.Left)
        {
            _kittyDirection = Direction.Right;
        }
  
        else if (_kittyDirection == Direction.Right)
        {
            _kittyDirection = Direction.Left;
        }

    }
}
