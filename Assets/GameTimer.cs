using TMPro;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    public float timeRemaining = 60f; // จำนวนเวลาที่เหลือในวินาที
    public TextMeshProUGUI timerText;

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            timerText.text = "Time: " + Mathf.FloorToInt(timeRemaining).ToString();
        }
        else
        {
            EndGame();
        }
    }

    void EndGame()
    {
        // ทำสิ่งที่ต้องการเมื่อหมดเวลา เช่น หยุดเกมหรือแสดงคะแนน
        Debug.Log("Time's up!");
    }
}
