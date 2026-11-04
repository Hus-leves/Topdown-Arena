using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour, IDamagable
{
    public float maxHealth = 100f;
    public float health;
    public Image hpImage;


    public void Start()
    {
        health = maxHealth;
        if (hpImage == null)
        {
            GameObject hp = GameObject.FindGameObjectWithTag("HpImage");
            hpImage = hp.GetComponent<Image>();
        }
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health >= maxHealth)
            health = maxHealth;
        hpImage.fillAmount = health / maxHealth;
        if (health <= 0f)
        {
            SceneManager.LoadScene("Gameover");
        }
    }
}
