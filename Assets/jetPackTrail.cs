using UnityEngine;

public class jetPackTrail : MonoBehaviour
{
    public GameObject character;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float v = character.GetComponent<Rigidbody2D>().velocity.y;
        if (v > 0)
        {
            var scale = transform.localScale;
            scale.y = v / 10 * 0.4f;
            scale.y = Mathf.Lerp(transform.localScale.y, scale.y,10f);
            transform.localScale = scale;
        }
        else
        {
            var scale = transform.localScale;
            scale.y = 0;
            transform.localScale = scale;
        }
    }
}

