using UnityEngine;

public class asteroidRotation : MonoBehaviour
{
    public float rotateSpeed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "destroy")
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, rotateSpeed * Time.deltaTime));
    }
}
