using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public float fallSpeed;
    private Rigidbody rb;
    public bool hasEnergy;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(-1, -0.5f, 0) * fallSpeed;
        transform.Find("Energy_membrane").gameObject.SetActive(false);
    }

    private void Update()
    {
        if (gameObject.transform.position.y < 0)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if(!hasEnergy)
            {
                hasEnergy = true;
                transform.Find("Energy_membrane").gameObject.SetActive(true);
            }
            rb.velocity = Vector3.zero;
            Debug.Log(hasEnergy);
        }
    }
}
