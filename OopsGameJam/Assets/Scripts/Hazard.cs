using UnityEngine;


public class Hazard : MonoBehaviour
{

    public int damage = 1;
    public PlayerController playerHealth;
    
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerHealth = collision.gameObject.GetComponent<PlayerController>();
            
            playerHealth.TakeDamage(damage);
        }
    }
}
