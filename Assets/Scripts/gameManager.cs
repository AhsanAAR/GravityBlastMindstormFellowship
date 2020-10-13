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
        ball.GetComponent<Rigidbody2D>().isKinematic = true;
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
            var instance = Instantiate(explosion, touchPos, Quaternion.identity);
            var effector = instance.GetComponent<PointEffector2D>();
            Destroy(effector, 0.1f);
            Destroy(instance, 0.4f);
        }
    }
}
