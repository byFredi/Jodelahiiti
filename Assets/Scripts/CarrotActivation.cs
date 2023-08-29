using UnityEngine;

public class ActivateChildOnCollision : MonoBehaviour
{
    // Reference to the child GameObject you want to activate
    public GameObject childComponent;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision is with a GameObject tagged as "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            // Activate the child GameObject
            childComponent.SetActive(true);
        }
    }
}


