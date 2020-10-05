using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class cameraControl : MonoBehaviour
{

    public GameObject ball;
    public GameObject leftSpawner;
    public GameObject rightSpawner;
    public GameObject walls;

    float ballOffset;
    float spawnerOffset;
    float wallsOffset;
    public float lerpRate;
    


    // Start is called before the first frame update
    void Start()
    {
        spawnerOffset = leftSpawner.transform.position.y - transform.position.y;
        wallsOffset = walls.transform.position.y - transform.position.y;
        ballOffset = ball.transform.position.y - transform.position.y;
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
            leftSpawner.transform.position = new Vector3(leftSpawner.transform.position.x, pos + spawnerOffset, 0);
            rightSpawner.transform.position = new Vector3(rightSpawner.transform.position.x, pos + spawnerOffset, 0);
            walls.transform.position = new Vector3(walls.transform.position.x, pos + wallsOffset, 0);
        }
    }
}
