using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Coin : MonoBehaviour
{

    public static int coin = 0;//รับคะแนนเป็นตัวเลข //static 
    public TMP_Text textScore;//ตัว text
    void Update()
    {
        textScore.text = ("" + coin);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Coin")
        {
            coin = coin + 1;
            Destroy(other.gameObject);

        }
    }
}