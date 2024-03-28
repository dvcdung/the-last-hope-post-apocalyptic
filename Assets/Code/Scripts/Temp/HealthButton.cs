using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HealthButton : MonoBehaviour
{
    public TextMeshProUGUI quantityText;
    public Slider healthSlider;
    private int maxHealth = 100;
    private int currentHealth = 20;
    public int healthPotionCount = 0;

    private void Start()
    {
        healthSlider.value = currentHealth;
        UpdateUI();
    }

    public void AddHealth()
    {
        healthPotionCount++;
        UpdateCUI();
    }
    private void UpdateCUI()
    {
        quantityText.text = healthPotionCount.ToString();
    }
    public void UseHealth()
    {
        if (healthPotionCount >= 1)
        { 
            currentHealth += 10;
            currentHealth = Mathf.Min(currentHealth, maxHealth);
            healthPotionCount--;
        }
        UpdateUI();
        UpdateCUI();

    }

    private void UpdateUI()
    {
        healthSlider.value = currentHealth;
    }
}