using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidControl : MonoBehaviour
{
    public GameObject asteroid;
    public float speed;
    public float angleDegree;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawn()
    {
        float randomY = transform.position.y;
        randomY = Random.Range(randomY - 2f, randomY + 2f);
        var a = Instantiate(asteroid, new Vector3(transform.position.x, randomY), Quaternion.identity);
        float randomAngleDegree = Random.Range(angleDegree - 10, angleDegree + 10);
        float radians = randomAngleDegree * Mathf.PI / 180;
        a.GetComponent<Rigidbody2D>().velocity = new Vector2(speed * Mathf.Cos(radians), speed * Mathf.Sin(radians));
        Destroy(a, 3f);

    }
}
