using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScroll : MonoBehaviour
{


    public float _scrollSpeed = 0.0000005f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float derpspeed = _scrollSpeed* Time.deltaTime;

        transform.Translate(0, -derpspeed, 0);
    }
}
