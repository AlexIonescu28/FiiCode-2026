using UnityEngine;
using UnityEngine.UI; // necesar pentru UI

public class bossHP : MonoBehaviour
{
    public int maxHP = 3;
    private int currentHP;

    private bool canBeDamaged = false;

    [Header("UI Elements (optional)")]
    public Text hpText;        // pentru text
    public Slider hpSlider;    // pentru bară de viață

    void Start()
    {
        currentHP = maxHP;

        // Inițializare UI dacă există
        if (hpText != null)
            hpText.text = "HP: " + currentHP;

        if (hpSlider != null)
        {
            hpSlider.maxValue = maxHP;
            hpSlider.value = currentHP;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Trap"))
        {
            canBeDamaged = true;
            UnityEngine.Debug.Log("Boss-ul este vulnerabil!");
        }
    }

    public void TakeDamage(int dmg)
    {
        if (!canBeDamaged)
        {
            UnityEngine.Debug.Log("Boss-ul este invulnerabil!");
            return;
        }

        currentHP -= dmg;
        UnityEngine.Debug.Log("Boss HP: " + currentHP);

        // Actualizare UI
        if (hpText != null)
            hpText.text = "HP: " + currentHP;

        if (hpSlider != null)
            hpSlider.value = currentHP;

        canBeDamaged = false;

        if (currentHP <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        UnityEngine.Debug.Log("Boss-ul a murit!");
        Destroy(gameObject);
    }
}