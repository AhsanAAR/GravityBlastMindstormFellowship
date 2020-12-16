using UnityEngine;

public class randomAsteroid : MonoBehaviour
{

    public float radius;
    public float speed;

    public static randomAsteroid instance;

    public GameObject[] asteroidList;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "collision")
        {
            spawn();
        }
    }

    void spawn()
    {
        GameObject selection = asteroidList[Random.Range(0, asteroidList.Length - 1)];
        var instance = Instantiate(selection, new Vector3(transform.position.x,transform.position.y),Quaternion.identity);
        instance.GetComponentInChildren<asteroidRotation>().rotateSpeed = Random.Range(-20, 20);
        instance.GetComponentInChildren<Rigidbody2D>().velocity = new Vector2(Random.Range(-speed, speed), Random.Range(-speed, speed));
        var newPos = transform.position;
        newPos.x = Random.Range(-2.5f,2.5f);
        newPos.y += Random.Range(radius - 0.5f, radius + 0.5f);
        transform.position = newPos;

        scoreManager.instance.incrementScore();
    }

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
