using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquiddyEnemy : MonoBehaviour
{

    public float _squiddySpeed = 3.0f;

    enum Direction
    {
        Left,
        Up,
        Right,
        Down
    }

    Direction _squiddyDirection;

    float _changeDirectionTime = 0.75f;

    float timeRemaining;

    // Start is called before the first frame update
    void Start()
    {
        _squiddyDirection = Direction.Left;
        float timeRemaining = _changeDirectionTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRemaining > 0)
        {
            if (_squiddyDirection == Direction.Left)
            {
                transform.position += Vector3.left * _squiddySpeed * Time.deltaTime;

            }
            if (_squiddyDirection == Direction.Up)
            {
                transform.position += Vector3.up * _squiddySpeed * Time.deltaTime;
            }
            if (_squiddyDirection == Direction.Right)
            {
                transform.position += Vector3.right * _squiddySpeed * Time.deltaTime;
            }

            if (_squiddyDirection == Direction.Down)
            {
                transform.position += Vector3.right * _squiddySpeed * Time.deltaTime;
            }

            timeRemaining -= Time.deltaTime;
        }

        else
        {
            ChangeDirection();
            timeRemaining = _changeDirectionTime; 
        }


    }

    void ChangeDirection()
    {

        if (_squiddyDirection == Direction.Left)
        {
            _squiddyDirection = Direction.Up;
        }
        else if (_squiddyDirection == Direction.Up)
        {
            _squiddyDirection = Direction.Right;
        }
        else if (_squiddyDirection == Direction.Right)
        {
            _squiddyDirection = Direction.Down;
        }
        else if (_squiddyDirection == Direction.Down)
        {
            _squiddyDirection = Direction.Left;
        }
    }
}
