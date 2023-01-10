using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Player_Movement : MonoBehaviour
{
    //Joystick Movement
    public FloatingJoystick floatingJoystick;
    float horizontalMove = 0f;

    //public ParticleSystem dust;
    [SerializeField] private bool grounded = true;

    //Jump
    public float gravityScale = 5;
    public float fallingGravityScale = 20;
    [SerializeField] private float jumpSpeed = 20f;
    [SerializeField] private bool jump;
    [SerializeField] private float jumpRate = 0.7f;
    [SerializeField] private float nextJumpTime;//

    //Attack
    public Transform attackPoint;//จุดโจมตี
    public float attackRange = 1.16f;//รัศมีของการโจมตี
    public LayerMask enemyLayers;//ชื่อ Layer ที่เราจะโจมตี
    public int attackDamage = 10;//ค่า damge
    [SerializeField] private float attackRate = 0.3f;
    [SerializeField] private float nextAttackTime;//

    [SerializeField] private float speed = 10f;
    [SerializeField] private bool crouch = false;

    Animator animator;
    Rigidbody2D rb2D;
    public GameManager gameManager;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        //Joystick Movement
        if (floatingJoystick.Horizontal != 0)
        {
            horizontalMove = floatingJoystick.Horizontal * speed;
        }
        else
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * speed;
        }

        if (SystemInfo.deviceType == DeviceType.Handheld)
        {
            if (floatingJoystick.Vertical < 0)
            {
                crouch = true;
            }
            else if (floatingJoystick.Vertical >= 0)
            {
                crouch = false;
            }
        }

        animator.SetBool("Isgrounded", true);
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        //Walk
        if (horizontalMove < -0.1f && !crouch)//ไปขวา
        {

            transform.Translate(Vector2.right * speed * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 180);

        }
        else if (horizontalMove > 0.1f && !crouch)//ไปซ้าย
        {

            transform.Translate(Vector2.right * speed * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 0);

        }

        //Attack
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown("e") || Input.GetButtonDown("Fire1"))//กด e จะเป็นการโจมตี
            {
                animator.SetTrigger("IsAttack");
                jump = false;
                Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);//รัศมีการโจมตี, Layer ชื่อ EnemyLay
                nextAttackTime = Time.time + attackRate;

                foreach (Collider2D enemy in hitEnemies)//(เอา hitEnemies มาวนลูปใน Collider2D ชื่อตัวแปร enemy)
                {
                    enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
                    // Debug.Log("Hit" + enemy.name);//enemy.(ชื่อ Object ที่เราตั้งไว้)
                }
            }
        }

        //Jump
        if (Time.time >= nextJumpTime)
        {
            if (Input.mousePosition.y > Screen.width / 2)
            {
                if (Input.GetButton("Fire1") && grounded)
                {
                    animator.SetBool("IsJump", true);
                    rb2D.velocity = Vector2.up * jumpSpeed;//โดด
                    jump = true;
                    crouch = false;
                    nextJumpTime = Time.time + jumpRate;
                }
            }
            if (Input.GetButtonDown("Jump") && grounded)
            {
                animator.SetBool("IsJump", true);
                rb2D.velocity = Vector2.up * jumpSpeed;//โดด
                jump = true;
                crouch = false;
                nextJumpTime = Time.time + jumpRate;

            }
            if (rb2D.velocity.y >= 0)//ระหว่างโดด = velocity มากกว่าหรือเท่ากับ 0
            {
                rb2D.gravityScale = gravityScale;
            }
            else if (rb2D.velocity.y < 0)//ระหว่างหล่น
            {
                animator.SetBool("IsJump", false);
                rb2D.gravityScale = fallingGravityScale;
                jump = false;
            }
        }

        //Crouch 
        if (Input.mousePosition.y > Screen.width / 6)
        {
            if (Input.GetButtonDown("Fire1") && !crouch)
            {
                animator.SetBool("IsCrouch", true);
                crouch = true;
            }
            else if (Input.GetButtonUp("Fire1"))
            {
                animator.SetBool("IsCrouch", false);
                crouch = false;
            }
        }

        if (Input.GetKeyDown("c") && !crouch)
        {
            animator.SetBool("IsCrouch", true);
            crouch = true;

        }
        else if (Input.GetKeyUp("c"))
        {
            animator.SetBool("IsCrouch", false);
            crouch = false;
        }

    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    // void createDust()
    // {
    //     dust.Play();
    // }






































}





