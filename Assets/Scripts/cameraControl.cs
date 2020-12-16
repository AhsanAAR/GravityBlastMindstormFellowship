using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEditor;
using UnityEngine;

public class cameraControl : MonoBehaviour
{

    public GameObject ball;
    public Camera myCam;
    public GameObject leftWall;
    public GameObject rightWall;


    float ballOffset;
    public float lerpRate;

    BoxCollider2D left;
    BoxCollider2D right;

    // Start is called before the first frame update
    void Start()
    {
        left = leftWall.GetComponent<BoxCollider2D>();
        right = rightWall.GetComponent<BoxCollider2D>();

        Vector3 min = myCam.ViewportToWorldPoint(new Vector3(0, 0.5f, myCam.nearClipPlane));
        Vector3 max = myCam.ViewportToWorldPoint(new Vector3(1, 0.5f, myCam.nearClipPlane));

        //min.x -= left.size.x / 2;
        //max.x += right.size.x / 2;

        leftWall.transform.position = min;
        rightWall.transform.position = max;


        ballOffset = ball.transform.position.y - transform.position.y ;
    }

    // Update is called once per frame
    void Update()
    {
        follow();
    }


    void follow()
    {
        float pos = transform.position.y;
        float targetPos = ball.transform.position.y - ballOffset;
        if (targetPos >= pos)
        {
            pos = Mathf.Lerp(pos, targetPos, lerpRate * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, pos, transform.position.z);
        }
    }
}
