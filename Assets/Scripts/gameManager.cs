using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.Mathematics;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public GameObject ball;
    bool start;
    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        start = false;
 //       ball.GetComponent<Rigidbody2D>().isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (!start)
            {
                start = true;
                ball.GetComponent<Rigidbody2D>().isKinematic = false;
            }

            Destroy(Instantiate(explosion,touchPos, Quaternion.identity),0.3f);

        }
    }
}
