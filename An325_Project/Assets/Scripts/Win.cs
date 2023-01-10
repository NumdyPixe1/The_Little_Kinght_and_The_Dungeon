using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    public GameManager gameManager;

    private void OnTriggerEnter2D(Collider2D other)//เมื่อเข้าใน BoxCollider2D
    {

        if (other.gameObject.tag == "Win")
        {
            GetComponent<Player_Movement>().enabled = false;
            Destroy(other.gameObject);
            gameManager.Win();
        }
    }


    void Update()
    {



    }
}

