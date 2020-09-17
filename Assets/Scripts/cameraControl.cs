using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class cameraControl : MonoBehaviour
{

    public GameObject ball;

    float offset;
    public float lerpRate;


    // Start is called before the first frame update
    void Start()
    {
        offset = ball.transform.position.y - transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        follow();
    }


    void follow()
    {
        float pos = transform.position.y;
        float targetPos = ball.transform.position.y - offset;
        if (targetPos >= pos)
        {
            pos = Mathf.Lerp(pos, targetPos, lerpRate * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, pos, transform.position.z);
        }
    }
}
