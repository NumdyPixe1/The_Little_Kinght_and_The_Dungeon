using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BlinkingText : MonoBehaviour
{
    public float minTime = 0.8f;//(เวลาขั้นต่ำ) ยิ่งตัวเลขน้อย ยิ่งกระพริบเร็ว
    public float maxTime = 0.8f;//(เวลาขั้นสุด)

    private TMP_Text textFlicker;//ตัวText
    public float timer;

    void Start()
    {
        textFlicker = GetComponent<TMP_Text>();
        timer = Random.Range(minTime, maxTime);
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)//timer น้อยหรือเท่ากับ 0
        {
            textFlicker.enabled = !textFlicker.enabled;
            timer = Random.Range(minTime, maxTime);
        }
    }

}
