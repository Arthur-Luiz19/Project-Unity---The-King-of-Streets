using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour
{
    [Header("Parallax")]
    private float       length;
    private float       startPos;
    private Transform   cam;
    public  float       parallaxEffects;

    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        cam = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Parallax();
    }

    void Parallax(){

        float rePos = cam.transform.position.x * (1 - parallaxEffects);
        float Distance = cam.transform.position.x * parallaxEffects;

        transform.position = new Vector3(startPos + Distance, transform.position.y, transform.position.z);
        if(rePos > startPos + length){

            startPos += length;
        }
        else if(rePos < startPos - length){

            startPos -= length;
        }
    }
}
