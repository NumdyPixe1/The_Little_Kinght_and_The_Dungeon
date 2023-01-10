using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpPlayer : MonoBehaviour
{
    public GameManager gameManager;//เรียกใช้ Script GameManager
    public Animator animator;
    [SerializeField] private static int Hp = 3;

    //private float hpRate = 0.3f;
    //private float nextAttackbyEnemyTime;
    public Image[] heart;
    private void Start()
    {
        Hp = heart.Length;

    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Enemy")
        {
            Hp--;
            //Destroy(heart[Hp].gameObject);
            heart[Hp].gameObject.SetActive(false);
        }

        // if (Hp < 3)
        // {
        //     if (other.gameObject.tag == "Health")
        //     {
        //         Hp++;
        //         Destroy(other.gameObject);
        //         heart[1].gameObject.SetActive(true);
        //     }
        // }
        // if (Hp < 2)
        // {
        //     if (other.gameObject.tag == "Health")
        //     {
        //         Hp++;
        //         Destroy(other.gameObject);
        //         heart[2].gameObject.SetActive(true);
        //     }

        // }
        // if (Hp < 1)
        // {
        //     if (other.gameObject.tag == "Health")
        //     {
        //         Hp++;
        //         Destroy(other.gameObject);
        //         heart[3].gameObject.SetActive(true);
        //     }
        // }


        if (other.gameObject.tag == "Lava")
        {
            Hp = Hp - 3;
            Destroy(heart[0].gameObject);
            Destroy(heart[1].gameObject);
            Destroy(heart[2].gameObject);
        }

    }
    //if (Time.time >= nextAttackbyEnemyTime)

    private void Update()
    {

        if (Hp == 0)
        {
            gameManager.GameOver();
            animator.SetTrigger("IsDead");
            GetComponent<Player_Movement>().enabled = false;//ปิด Script Player_Movement
        }

    }
    // void PlayerGetHit()
    // {

    // }
    // void Update()
    // {
    //     nextAttackbyEnemyTime = Time.time + hpRate;
    // }
    // }
}

