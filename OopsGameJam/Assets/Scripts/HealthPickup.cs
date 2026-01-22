using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public PlayerController playerHealth;
    public int heal = 1;
    public GameObject health;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerHealth = collision.gameObject.GetComponent<PlayerController>();

            playerHealth.CollectHealth(heal);
            Destroy(health);
        }
    }
}
