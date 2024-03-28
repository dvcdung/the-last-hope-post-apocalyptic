using UnityEngine;

public class ItemController : MonoBehaviour
{
    private HealthButton healthButton;
    private EnergyButton energyButton;
    private OxygenButton oxygenButton;

    private void Start()
    {
        healthButton = FindObjectOfType<HealthButton>();
        energyButton = FindObjectOfType<EnergyButton>();
        oxygenButton = FindObjectOfType<OxygenButton>();
    }

    public void PickUpItem()
    {
        if (gameObject.CompareTag("Health"))
        {
            Debug.Log("Health picked up!");
            healthButton.AddHealth();
        }
        else if (gameObject.CompareTag("Energy"))
        {
            Debug.Log("Energy picked up!");
            energyButton.AddEnergy();
        }
        else if (gameObject.CompareTag("Oxygen"))
        {
            Debug.Log("Oxygen picked up!");
            oxygenButton.AddOxygen();
        }

        Destroy(gameObject);
    }
}
