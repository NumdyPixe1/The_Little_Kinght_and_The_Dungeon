using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;
    public int maxHp = 50;
    int currentHp;

    void Start()
    {
        animator = GetComponent<Animator>();
        currentHp = maxHp;
    }
    public void TakeDamage(int damage)
    {
        currentHp -= damage;
        animator.SetTrigger("IsHurt");
        if (currentHp == 0)
        {
            this.GetComponent<Collider2D>().enabled = false;
            animator.SetBool("IsDead", true);
            StartCoroutine(secondDeath(0.5f));

        }
    }
    IEnumerator secondDeath(float secondDeath)
    {
        yield return new WaitForSeconds(secondDeath);
        Destroy(this.gameObject);

    }
    void Update()
    {

    }
}
