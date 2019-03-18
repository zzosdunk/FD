using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyScript : MonoBehaviour {

    public float startSpeed = 10f;
    string currentScene;

    [HideInInspector]
    public float speed;

    public float startHealth = 100;
    private float health;

    public int worth = 50;
    public GameObject enemyDie;

    private bool isDead = false;

    [Header("Unity Stuff")]
    public Image healthBar;

    void Start()
    {
        currentScene = SceneManager.GetActiveScene().name;
        speed = startSpeed;
        health = startHealth;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        healthBar.fillAmount = health / startHealth;

        if (health <= 0 && !isDead)
        {
            Die();
        }
    }

    public void Slow(float pct) //slowing the enemy as a Laser virgin
    {
        speed = startSpeed * (1f - pct);
    }

    void Die()
    {
        isDead = true;

        PlayerStats.Money += worth;

        GameObject effect = (GameObject)Instantiate(enemyDie, transform.position, Quaternion.identity);
        Destroy(effect, 5f);

        if (currentScene == "Level04" || currentScene == "Level05" || currentScene == "Level06" || currentScene == "Level07" || currentScene == "Level08" || currentScene == "Level09")
        {
            WaveSpawner.enemiesAlive--;
            
        } else if (currentScene == "Level01" || currentScene == "Level02" || currentScene == "Level03")
        {
            WaveSpawner_easy.enemiesAlive--;
            
        }
        Destroy(gameObject);

    }

    

}
