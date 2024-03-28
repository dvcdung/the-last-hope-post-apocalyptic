using UnityEngine;

public class ItemHover : MonoBehaviour
{
    private Camera mainCamera;
    private RaycastHit hit;
    private bool isHovering = false;
    private Color originalColor;
    public Color highlightColor = Color.yellow;

    void Start()
    {
        mainCamera = Camera.main;
        originalColor = GetComponent<Renderer>().material.color;
    }

    void Update()
    {
        if (Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition), out hit))
        {
            if (hit.collider.gameObject == gameObject)
            {
                isHovering = true;
                Debug.Log(gameObject.tag);
                GetComponent<Renderer>().material.color = highlightColor;
            }
            else
            {
                isHovering = false;
                GetComponent<Renderer>().material.color = originalColor;
            }
        }
        if (isHovering)
        {
            mainCamera.transform.LookAt(transform);
        }
    }
}
