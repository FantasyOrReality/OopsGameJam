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
    Rigidbody2D enemyRb;
    public float speed = 2f;

    public AudioSource robotDeath;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        
        enemyRb = GetComponent<Rigidbody2D>();
        enemyHealth = enemyMaxHealth;


    }

    // Update is called once per frame
    void Update()
    {

        
    }


    /*public void TakeDamageFromPlayer(int amount)
    {
        enemyHealth -= amount;
        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }*/

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(playerDash.isLethalDashing && collision.gameObject.CompareTag("Player"))
        {
            enemyHealth = enemyHealth - playerDash.damageDealt;
            if (enemyHealth <= 0)
            {
                robotDeath.Play();
                Destroy(gameObject);
            }
        }
    }



}
