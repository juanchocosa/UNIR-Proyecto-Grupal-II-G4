using UnityEngine;
using UnityEngine.SceneManagement;

public class AlarmManager : MonoBehaviour
{
    public static AlarmManager Instance { get; private set; }

    [Header("Alarm Settings")]
    public int maxAlarmCount = 3;
    public float cooldownBetweenTriggers = 1f;

    private int currentAlarmCount = 0;
    private float cooldownTimer = 0f;

    void Awake()
    {
        // Singleton pattern
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
    }

    void Update()
    {
        if (cooldownTimer > 0f)
            cooldownTimer -= Time.deltaTime;
    }

    public void AddAlarm(int amount)
    {
        if (cooldownTimer > 0f)
            return;

        currentAlarmCount += amount;
        cooldownTimer = cooldownBetweenTriggers;

        Debug.Log("🔺 Alarma: " + currentAlarmCount + "/" + maxAlarmCount);

        if (currentAlarmCount >= maxAlarmCount)
        {
            TriggerAlarm();
        }
    }

    private void TriggerAlarm()
    {
        Debug.Log("🚨 ALARMA — Reseteo de escena");
        currentAlarmCount = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
