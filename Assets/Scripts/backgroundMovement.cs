using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using TMPro;
using UnityEngine;

public class backgroundMovement : MonoBehaviour
{

    float length, startpos;

    public GameObject cam;
    public float parallex;


    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position.y;
        length = GetComponent<SpriteRenderer>().bounds.size.y;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float temp = (cam.transform.position.y * (1 - parallex));
        float distance = cam.transform.position.y * parallex;
        transform.position = new Vector3(transform.position.x, startpos+distance, transform.position.z);

        if (temp > startpos + length)
            startpos += length;
        else if
            (temp < startpos - length) startpos -= length;

    }
}
