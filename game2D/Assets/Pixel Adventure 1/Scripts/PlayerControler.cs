using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerControler : MonoBehaviour
{
    [SerializeField] float speed, jumpForce, x, y;
    [SerializeField] bool isJump, isDJump, pass;

    Animator animator;
    public Animator check;
    Rigidbody2D rig;
    public Text pointsHUD;

    public static int points = 0;
    public static int apples = 0;
    public int a = 0;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();
        Pause.isPlayer = true;
    }
    void Update()
    {
        if (Pause.isPlayer)
        {
            Move();
            Jump();
            PassarNivel();
            pointsHUD.text = $"Total de maças: {points}";
        }
        Animations();
    }

    
    void Move()
    {
        x = Input.GetAxisRaw("Horizontal") * speed;
        y = rig.velocity.y;

        rig.velocity = new Vector2 (x, y);

        if (rig.velocity.x > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            
        }
        else if (rig.velocity.x < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }
    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (!isJump)
            {
                rig.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                isDJump = true;
            }
            else if (isDJump)
            {
                rig.AddForce(new Vector2(0, jumpForce * 1.5f), ForceMode2D.Impulse);
                isDJump = false;
            }
        }
    }
    void Animations()
    {
        if (rig.velocity.x != 0 && !isJump) // run
        {
            animator.SetFloat("Anim", 0.25f);
        }
        else if (isDJump && rig.velocity.y > 0) //jump
        {
            animator.SetFloat("Anim", 0.5f);
        }
        else if (!isDJump && rig.velocity.y > 0)
        {
            animator.SetFloat("Anim", 0.75f);
        }
        else if (rig.velocity.y < 0)
        {
            animator.SetFloat("Anim", 1f);
        }
        else if (rig.velocity.x == 0 && rig.velocity.y == 0)
        {
            animator.SetFloat("Anim", 0f);
        }
    }

    void PassarNivel()
    {
        a = apples;
        if (points == apples)
        {
            check.SetBool("End", true);
            pass = true;
            
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isJump = false;
          
        }
        if (collision.gameObject.layer == 7 && pass)
        {
            SceneManager.LoadScene("Fase2");
            Debug.Log("teste");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isJump = true;
        }

        
    }





}
