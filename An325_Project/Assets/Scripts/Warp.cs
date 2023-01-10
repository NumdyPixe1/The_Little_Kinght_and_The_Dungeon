using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class Warp : MonoBehaviour
{
    public GameObject speech;
    [SerializeField] private bool isWarp;
    //public TMP_Text f_Text;
    private void OnTriggerEnter2D(Collider2D other)//เมื่อเข้าใน BoxCollider2D
    {
        if (other.gameObject.tag == "Player")
        {
            speech.SetActive(true);
            //animatorText.
            //f_Text.gameObject.SetActive(true);
            isWarp = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) //เมื่อออกจาก BoxCollider2D
    {
        if (other.gameObject.tag == "Player")
        {
            speech.SetActive(false);
            //f_Text.gameObject.SetActive(false);
            isWarp = false;
        }
    }

    void Update()
    {
        if (Input.GetKey("f") && isWarp == true || Input.GetButton("Fire1") && isWarp == true)//เมื่อกด F และ isWarp เป็นจริง
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);//เปลี่ยนฉาก
        }
    }
}
