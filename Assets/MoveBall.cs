using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Moveball : MonoBehaviour
{
    Rigidbody rb;
    public int ballspeed = 0;
    public int jumpspeed = 0;
    private bool istouching = false;
    public TextMeshProUGUI textUI;
    private int currentScore = 0;

    public CoinPool coinPool; // อ้างอิงถึง CoinPool script
    public int sizeOfCoins = 10;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // ดึงเหรียญจาก CoinPool มาใช้ในเกม
        for (int i = 0; i < sizeOfCoins; i++)
        {
            GameObject coin = coinPool.GetPooledCoin();
            if (coin != null)
            {
                coin.transform.position = new Vector3(Random.Range(-3f, 3f), Random.Range(1f, 3f), 0f);
            }
        }
    }

    void Update()
    {
        // แสดงคะแนน
        textUI.text = "Score: " + currentScore.ToString();

        // ควบคุมการเคลื่อนที่ของลูกบอล (เพิ่ม W, A, S, D และลูกศร)
        Vector3 moveDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            moveDirection.x = -1;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            moveDirection.x = 1;
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            moveDirection.z = 1;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            moveDirection.z = -1;
        }

        rb.AddForce(moveDirection * ballspeed, ForceMode.Force);

        // การกระโดด
        if (Input.GetKeyDown(KeyCode.Space) && istouching)
        {
            rb.AddForce(new Vector3(0f, jumpspeed, 0f), ForceMode.Impulse);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            istouching = false;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            istouching = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectables"))
        {
            CollectCoin(other.gameObject);
        }
    }

    private void CollectCoin(GameObject coin)
    {
        // เพิ่มคะแนน
        currentScore++;

        // เล่นเสียงเมื่อเก็บเหรียญ
        AudioSource coinAudio = coin.GetComponent<AudioSource>();
        if (coinAudio != null)
        {
            coinAudio.Play();
        }

        // เปลี่ยนตำแหน่งของเหรียญทันทีให้พร้อมสำหรับการเก็บใหม่
        RespawnCoin(coin);
    }

    private void RespawnCoin(GameObject coin)
    {
        // ตั้งตำแหน่งใหม่ของเหรียญทันทีโดยไม่ต้องปิดการใช้งาน
        coin.transform.position = new Vector3(Random.Range(-3f, 3f), Random.Range(1f, 3f), 0f);
        Debug.Log("Respawned Coin");
    }
}
