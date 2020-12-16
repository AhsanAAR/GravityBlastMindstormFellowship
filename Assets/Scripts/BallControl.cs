using UnityEngine.SceneManagement;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    public Camera camera1;

    public float moveSpeed, rotateSpeed;
    private Rigidbody2D rb;
    private Vector3 direction;

    bool right;
    float height;

    // Start is called before the first frame update
    void Start()
    {
        height = transform.position.y - 2;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -3);
        right = true;
        rightSprite();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "asteroid")
        {
            rb.constraints = RigidbodyConstraints2D.None;
            rb.gravityScale = 0;
            gameManager.instance.start = false;
            restart();
 //           Invoke("restart", 1);
            
        }
    }

    void rightSprite()
    {
        GetComponent<SpriteRenderer>().flipX = false;
        var b = transform.eulerAngles;
        b.z = -20;
        transform.eulerAngles = b;
        right = true;
    }

    void leftSprite()
    {
        GetComponent<SpriteRenderer>().flipX = true;
        var b = transform.eulerAngles;
        b.z = 20;
        transform.eulerAngles = b;
        right = false;
    }
    
    void changeDirection()
    {
        if (right)
            leftSprite();
        else
            rightSprite();
    }


    void restart()
    {
        Debug.Log("game over game over game overgame over game over");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void FixedUpdate()
    {
        if (!gameManager.instance.start)
        {
            if (transform.position.y < height)
            {
                rb.velocity = new Vector2(0, 4);
                changeDirection();
            }
        }
        else
        {
            var vel = rb.velocity;
            if (vel.x < 0)
                leftSprite();
            else
                rightSprite();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("game over");
        //Debug.Log(Camera.main.transform.position.y);

       

        if (camera1.transform.position.y-4.7 > transform.position.y)
        {
            Debug.Log("game over game over game overgame over game over");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
        }
    }
}
