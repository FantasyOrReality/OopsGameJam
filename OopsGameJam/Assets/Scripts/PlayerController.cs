using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class PlayerController : MonoBehaviour
{
    public float Move;
    public float speed;
    public int currentHealth;
    public int maxHealth;
    public Slider slider;
    
    Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        slider.maxValue = maxHealth;
        slider.value = currentHealth;
        
    }

    // Update is called once per frame
    void Update()
    {
        Move = Input.GetAxis("Horizontal");

        rb.linearVelocity = new Vector2(Move * speed, rb.linearVelocity.y);

        
    }

    //function that damages the player when they collide with objects that have the enemy or hazard tag
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        slider.value = currentHealth;


        if (currentHealth <= 0)
        {
            SceneManager.LoadScene("Lose");
        }
    }

    public void Dash()
    {
        
    }
   
}
