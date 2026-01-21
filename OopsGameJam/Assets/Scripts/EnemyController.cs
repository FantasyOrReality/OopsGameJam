using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class EnemyController : MonoBehaviour
{
    public int enemyHealth;
    public int enemyMaxHealth;

    public PlayerController playerDash;
    public GameObject enemy;
    public Rigidbody2D enemyRb;
    public CapsuleCollider2D backAttackSpot;

    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        backAttackSpot = GetComponent<CapsuleCollider2D>();
        enemyHealth = enemyMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void TakeDamageFromPlayer(int amount)
    {
        enemyHealth -= amount;
        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Back"))
        {
            Collider2D col = collision.gameObject.GetComponent<CapsuleCollider2D>();
            if (backAttackSpot.IsTouching(col)) { }
            {
                Debug.Log("Collision");
            }
        }
        
    }

}
