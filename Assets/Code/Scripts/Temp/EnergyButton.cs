using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnergyButton : MonoBehaviour
{
    public TextMeshProUGUI quantityText;
    public Slider energySlider;
    private int maxEnergy = 100;
    private int currentEnergy = 50; 
    public int energyDrinkCount = 0;

    private void Start()
    {
        energySlider.value = currentEnergy;
        UpdateUI();
    }

    public void AddEnergy()
    {
        energyDrinkCount++;
        UpdateCUI();
    }
    private void UpdateCUI()
    {
        quantityText.text = energyDrinkCount.ToString();
    }
    public void UseEnergy()
    {
        if (energyDrinkCount >= 1)
        {
            currentEnergy += 20;
            currentEnergy = Mathf.Min(currentEnergy, maxEnergy);
            energyDrinkCount--;
        }
            UpdateUI();
            UpdateCUI();
    }


    private void UpdateUI()
    {
        energySlider.value = currentEnergy;
    }
}
