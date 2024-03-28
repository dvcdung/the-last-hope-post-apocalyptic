using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OxygenButton : MonoBehaviour
{
    public TextMeshProUGUI quantityText;
    public Slider oxygenSlider;
    private int maxOxygen = 100;
    private int currentOxygen = 50;
    public int oxygenCount = 0;

    private void Start()
    {
        oxygenSlider.value = currentOxygen;
        UpdateUI();
    }
    private void UpdateCUI()
    {
        quantityText.text = oxygenCount.ToString();
    }
    public void AddOxygen()
    {
        oxygenCount++;
        UpdateCUI();
    }

    public void UseOxygen()
    {
        if (oxygenCount >= 1)
        {
            currentOxygen += 20;
            currentOxygen = Mathf.Min(currentOxygen, maxOxygen);
            oxygenCount--;
        }
            UpdateUI();
            UpdateCUI();
    }

    private void UpdateUI()
    {
        oxygenSlider.value = currentOxygen;
    }
}
