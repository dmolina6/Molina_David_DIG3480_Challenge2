using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rb2d;
    public float speed;
    public float jumpforce;
    private int count;
    private int lives;
    public Text CountText;
    public Text WinText;
    public Text Lives;
    private bool secondstage = false;    
    public AudioClip musicClip;
    public AudioSource musicSource;
    Animator anim;
    private bool facingRight;

    void Start()
    {
        facingRight = true;
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        count = 0;
        lives = 3;
        SetCountText();
        WinText.text = "";
        Lives.text = "3";
    }

    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            anim.SetInteger("State", 1);
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            anim.SetInteger("State", 0);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            anim.SetBool("Jump", true);
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            anim.SetBool("Jump", false);
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(moveHorizontal, 0, 0);
        rb2d.AddForce(movement * speed);
        Flip(moveHorizontal);
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                rb2d.AddForce(new Vector2(0, jumpforce), ForceMode2D.Impulse);
            }
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);                        
            lives = lives - 1;
            SetLivesText();
        }
    }

    void SetCountText()
    {
        CountText.text = "Count: " + count.ToString();
        if (count >= 4 && secondstage == !true)
        {            
            secondstage = true;
            count = 0;
            lives = 3;
            Lives.text = "3";
            transform.position = new Vector2(100.0f, 0.0f);
        }
       else if (count >= 4 && secondstage == true)
        {
            WinText.text = "You Win";
            musicSource.clip = musicClip;
            musicSource.Play();
        }
    }

    void SetLivesText()
    {
        Lives.text = "Lives: " + lives.ToString();
        if (lives == 0 && gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            WinText.text = "You Lose";
        }
    }

    private void Flip(float horizontal)
    {
        if(horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
        {
            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }

}
