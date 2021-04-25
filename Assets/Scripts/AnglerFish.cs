using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class AnglerFish : MonoBehaviour
{

    public Sprite AnglerFishSprite;
    public Sprite AnglerFishSprite2;
    public ParticleSystem _particleSystem;


    public int _anglerFishSpeed = 4;
    int _anglerFishHP = 4;
    public bool goalReached = false; 

    Rigidbody2D _anglerFishRigidBody2D;
    SpriteRenderer _anglerFishSpriteRenderer;

    

    Vector3 _cameraPosition;

    void Awake()
    {
        _anglerFishRigidBody2D = GetComponent<Rigidbody2D>();
        _anglerFishSpriteRenderer = GetComponent<SpriteRenderer>();

        _cameraPosition = Camera.main.WorldToViewportPoint(transform.position);
    }

    // Start is called before the first frame update
    void Start()
    {
        //The Angler Fish only controlled or moved by code
        //_anglerFishRigidBody2D.isKinematic = true;

    }

    // Update is called once per frame
    void Update()
    {

        //Check if we are out of the top of the camera's frame.
        _cameraPosition = Camera.main.WorldToViewportPoint(transform.position);
        if (1.0 < _cameraPosition.y)
        {
            Debug.Log("I am above the camera's view.");
            Die();
        }

        //Control AnglerFish Movement with Arrow keys 
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //use the Left/Right Sprite
            _anglerFishSpriteRenderer.sprite = AnglerFishSprite;
            
            //move to the left
            transform.position += Vector3.left * _anglerFishSpeed * Time.deltaTime;

            //flip him to face left
            _anglerFishSpriteRenderer.flipX = true; 
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            //use the Left/Right Sprite
            _anglerFishSpriteRenderer.sprite = AnglerFishSprite;

            // move him right
            transform.position += Vector3.right * _anglerFishSpeed * Time.deltaTime;

            //flip him to face right
            _anglerFishSpriteRenderer.flipX  = false;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            //use the Up/Down Sprite
            _anglerFishSpriteRenderer.sprite = AnglerFishSprite2;

            //move him down
            transform.position += Vector3.down * _anglerFishSpeed * Time.deltaTime;

            //flip him to face down
            _anglerFishSpriteRenderer.flipY = true;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            //use the Up/Down Sprite
            _anglerFishSpriteRenderer.sprite = AnglerFishSprite2;

            //move him up
            transform.position += Vector3.up * _anglerFishSpeed * Time.deltaTime;

            //flip him to face up
            _anglerFishSpriteRenderer.flipY = false;
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        KittyFishEnemy kittyFishEnemy = collision.gameObject.GetComponent<KittyFishEnemy>();
        SquiddyEnemy squiddyEnemy = collision.gameObject.GetComponent<SquiddyEnemy>();
        GoDeeperSign goDeeperSign = collision.gameObject.GetComponent<GoDeeperSign>();

        if (kittyFishEnemy != null)
        {
            _anglerFishSpriteRenderer.color = Color.red;
            _anglerFishHP--;
            if (_anglerFishHP == 0)
            {
                Die();
            }
            else
            {
                StartCoroutine(ResetAfterHit());
            }
        }
        if (squiddyEnemy != null)
        {
            _anglerFishSpriteRenderer.color = Color.red;
            _anglerFishHP -= 2;
            if (_anglerFishHP == 0)
            {
                Die();
            }
            else
            {
                StartCoroutine(ResetAfterHit());
            }
        }
        if (goDeeperSign != null)
        {
            Debug.Log("We hit the go deeper sign");
            goalReached = true;
            StartCoroutine(GoToNextLevel());
        }



    }

    IEnumerator ResetAfterHit()
    {
        yield return new WaitForSeconds(3);
        _anglerFishSpriteRenderer.color = Color.white;
    }
    IEnumerator GoToNextLevel()
    {
        yield return new WaitForSeconds(2);
        goalReached = true;

    }

    IEnumerator ResetAfterDeath()
    {
        yield return new WaitForSeconds(2);
        gameObject.SetActive(false);
    }

    void Die()
    {
        print("We have died");
        _particleSystem.Play();
        StartCoroutine(ResetAfterDeath());
    }
}
