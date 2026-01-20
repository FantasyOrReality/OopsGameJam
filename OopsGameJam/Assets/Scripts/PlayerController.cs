using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System.Collections;



public class PlayerController : MonoBehaviour
{
    //movement variables
    public float Move;
    public float speed;
    public float jump;
    public bool isJumping;

    //health variables
    public int currentHealth;
    public int maxHealth;
    public Slider slider;

    //dash variables
    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 50f;
    private float dashingTime = 0.5f;
    private float dashingCooldown = 2f;
    
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
        if (isDashing)
        {
            return;
        }

        Move = Input.GetAxis("Horizontal");

        rb.linearVelocity = new Vector2(Move * speed, rb.linearVelocity.y);

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            StartCoroutine(Dash());
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector2(rb.linearVelocity.x, jump));
        }

        
        
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

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.linearVelocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        yield return new WaitForSeconds(dashingTime);
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }

    
   
}
