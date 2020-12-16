using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    public Camera camera1;

    public float moveSpeed, rotateSpeed;
    private Rigidbody2D rb;
    private Vector3 direction;

    public static CharacterControl instance;

    bool right;
    float height;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        height = transform.position.y - 2;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -3);
        right = true;
        rightSprite();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameManager.instance.start && (collision.collider.tag == "asteroid" || collision.collider.tag == "ballTrigger")) 
        {
            rb.constraints = RigidbodyConstraints2D.None;
            rb.gravityScale = 0;
            rb.AddForce(collision.contacts[0].normal * 30); 
            gameManager.instance.start = false;
            gameManager.instance.endGame();
            soundManager.instance.collision();
        }
    }

    void rightSprite()
    {
        var a = transform.localScale;
        a.x = -0.3f;
        transform.localScale = a;

        var b = transform.eulerAngles;
        b.z = -20;
        transform.eulerAngles = b;
        right = true;
    }

    void leftSprite()
    {
        var a = transform.localScale;
        a.x = 0.3f;
        transform.localScale = a;
        
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

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -15, 15), Mathf.Clamp(rb.velocity.y, -15, 15));

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
    }
}
