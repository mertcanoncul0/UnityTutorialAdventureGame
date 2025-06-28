using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController controller = other.GetComponent<PlayerController>();

        if (controller != null && controller.Health < controller.MaxHealth)
        {
            controller.ChangeHealth(1);
            Destroy(gameObject);
        }
    }
}
