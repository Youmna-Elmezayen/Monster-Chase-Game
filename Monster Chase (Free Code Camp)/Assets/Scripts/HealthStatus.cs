using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthStatus : MonoBehaviour
{
    [SerializeField]
    private int _health;
    [SerializeField]
    private Text statusText;
    public static bool isAlive;

    private int maxHealth = 100;
    [SerializeField]
    private Text healthStatus;

    private void Start()
    {
        _health = maxHealth;
        isAlive = true;
    }

    public void TakeDamage()
    {
        _health -= 25;
        healthStatus.text = "" + _health;
        if (_health <= 50)
        {
            healthStatus.color = Color.yellow;
            if(_health == 25)
            {
                healthStatus.color = Color.red;
            }
        }

        if (_health <= 0)
        {
            isAlive = false;
        }
    }
}
