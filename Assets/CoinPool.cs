using System.Collections.Generic;
using UnityEngine;

public class CoinPool : MonoBehaviour
{
    public GameObject coinPrefab; // Prefab ของเหรียญ
    public int poolSize = 10;     // จำนวนเหรียญใน Pool
    private List<GameObject> coins;

    void Start()
    {
        // สร้าง Pool ของเหรียญ
        coins = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject coin = Instantiate(coinPrefab);
            coin.SetActive(false); // ปิดการใช้งานเหรียญในตอนเริ่มเกม
            coins.Add(coin); // เก็บเหรียญในลิสต์
        }
    }

    public GameObject GetPooledCoin()
    {
        // ค้นหาเหรียญที่ไม่ถูกใช้งานใน Pool
        foreach (var coin in coins)
        {
            if (!coin.activeInHierarchy)
            {
                coin.SetActive(true); // เปิดใช้งานเหรียญ
                return coin;
            }
        }
        return null; // ถ้าไม่มีเหรียญที่ไม่ถูกใช้งานใน Pool
    }

    public void ReturnCoinToPool(GameObject coin)
    {
        coin.SetActive(false); // ปิดการใช้งานเหรียญและส่งกลับไปที่ Pool
    }
}
