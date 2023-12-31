using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderHero : MonoBehaviour
{
    private bool isDead = false;
    private Rigidbody2D rb2d;
    public float upForce = 200f;
    PolygonCollider2D poly2d;
    private Animator anim;
    AudioSource sounds;
    public AudioClip Jump;
    public AudioClip Die;
    public AudioClip score;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        poly2d = GetComponent<PolygonCollider2D>();
        anim = GetComponent<Animator>();
        sounds = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead == false)
        {
            if (Input.GetMouseButtonUp(0))
            {
                rb2d.velocity = Vector3.zero;
                rb2d.AddForce(new Vector2(0, upForce));
                anim.SetTrigger("Jump");
                playSound(Jump);
                
            }
            
        }
    }
    void OnCollisionEnter2D (Collision2D collision)
    {
        isDead = true;
        poly2d.offset = new Vector2(0, 1.50f);
        anim.SetTrigger("Die");
        gameController.instance.SpiderDied();
        rb2d.velocity = Vector2.zero;
        playSound(Die);
    }

    public void playSound(AudioClip clip)
    {
        sounds.PlayOneShot(clip);
    }

}