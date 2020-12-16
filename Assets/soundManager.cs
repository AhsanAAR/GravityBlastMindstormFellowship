using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManager : MonoBehaviour
{
    public static soundManager instance;

    public AudioSource sfxSource;
    public AudioSource bgSource;

    public AudioClip explosionSound;
    public AudioClip collisionSound;


    static AudioSource bgInstance;
    static AudioSource sfxInstance;
    // Start is called before the first frame update

    public void explode()
    {
        //audioSource.transform.position = ball.transform.position;
        sfxInstance.PlayOneShot(explosionSound);
    }

    public void collision()
    {
        //audioSource.transform.position = ball.transform.position;
        sfxInstance.PlayOneShot(collisionSound);
    }

    private void Awake()
    {
        if (instance == null)
        {
            bgInstance = Instantiate(bgSource);
            sfxInstance = Instantiate(sfxSource);

            instance = this;
            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(bgInstance.gameObject);
            DontDestroyOnLoad(sfxInstance.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
