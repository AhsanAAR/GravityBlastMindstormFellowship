using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starShooter : MonoBehaviour
{
    public GameObject cam;
    public GameObject star;
    public float speed;
    public float angleDegree;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("makeStar",1f,2f);
    }


    void makeStar()
    {
        //var instance = Instantiate(star, new Vector3(transform.position.x, transform.position.y), Quaternion.identity);
        //instance.transform.parent = cam.transform;


        float randomY = transform.position.y;
        randomY = Random.Range(randomY - 2f, randomY + 2f);
        var instance = Instantiate(star, new Vector3(transform.position.x, randomY), Quaternion.identity);
        //instance.transform.parent = cam.transform;
        float randomAngleDegree = Random.Range(angleDegree - 10, angleDegree + 10);
        float radians = randomAngleDegree * Mathf.PI / 180;
        instance.GetComponent<Rigidbody2D>().velocity = new Vector2(speed * Mathf.Cos(radians), speed * Mathf.Sin(radians));
        Destroy(instance, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
