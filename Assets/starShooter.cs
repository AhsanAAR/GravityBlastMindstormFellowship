using UnityEngine;

public class starShooter : MonoBehaviour
{
    public GameObject cam;
    public GameObject star;



    private float speed;
    private float angleDegree;
    private float time;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("makeStar",1f);
    }


    void makeStar()
    {
        //var instance = Instantiate(star, new Vector3(transform.position.x, transform.position.y), Quaternion.identity);
        //instance.transform.parent = cam.transform;


        float randomY = Random.Range(-3, 3);
        float randomX = Random.Range(-2f, 2f);
        speed = Random.Range(10f, 15f);
        angleDegree = Random.Range(-180, 0);
        time = Random.Range(2, 7);


        var instance = Instantiate(star, new Vector3(cam.transform.position.x + randomX, cam.transform.position.y + randomY), Quaternion.identity);
        //instance.transform.parent = cam.transform;
        float randomAngleDegree = Random.Range(angleDegree - 10, angleDegree + 10);
        float radians = randomAngleDegree * Mathf.PI / 180;
        instance.GetComponent<Rigidbody2D>().velocity = new Vector2(speed * Mathf.Cos(radians), speed * Mathf.Sin(radians));
        Destroy(instance, 1.5f);
        Invoke("makeStar", time);


        //float randomY = transform.position.y;
        //randomY = Random.Range(randomY - 2f, randomY + 2f);
        //var instance = Instantiate(star, new Vector3(transform.position.x, randomY), Quaternion.identity);
        ////instance.transform.parent = cam.transform;
        //float randomAngleDegree = Random.Range(angleDegree - 10, angleDegree + 10);
        //float radians = randomAngleDegree * Mathf.PI / 180;
        //instance.GetComponent<Rigidbody2D>().velocity = new Vector2(speed * Mathf.Cos(radians), speed * Mathf.Sin(radians));
        //Destroy(instance, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
