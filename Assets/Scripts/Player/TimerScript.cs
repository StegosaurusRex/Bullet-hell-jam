using UnityEngine;
using TMPro;

public class TimerScript : MonoBehaviour
{
    public float startTime = 900f; // 15 minutes in seconds
    private float currentTime;
    public TextMeshProUGUI timerText;
    PlayerHP playerHP;
    void Start()
    {
        currentTime = startTime;
        playerHP = GameObject.FindObjectOfType<PlayerHP>();
    }

    void Update()
    {
        if (currentTime >= 0f)
        {
            currentTime -= Time.deltaTime;
            int minutes = Mathf.FloorToInt(currentTime / 60f);
            int seconds = Mathf.FloorToInt(currentTime % 60f);
            timerText.text = string.Format("{0:00}:{1:00}" , minutes , seconds);
        }
        else
        {
            
            playerHP.PlayerDeath();
            // Timer has run out
            Debug.Log("Time's up!");
        }
    }
}