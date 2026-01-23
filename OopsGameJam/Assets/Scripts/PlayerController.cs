using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System.Collections;
using Unity.VisualScripting;



public class PlayerController : MonoBehaviour
{
    //movement variables
    public float Move;
    public float speed;
    public float jump;
    public bool isJumping;
    bool facingRight = true;

    //health variables
    public int currentHealth;
    public int maxHealth;
    public Slider slider;

    //damage variables
    public int damageDealt;

    //dash variables
    private bool canDash = true;
    public bool isDashing;
    public bool isLethalDashing;
    public float dashingPower;
    public float dashingTime;
    public float dashingCooldown;

    //audiosources
    public AudioSource dashNoise;
    public AudioSource slimeHurt;

    //anims
    
    
    
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
        if (isDashing || isLethalDashing)
        {
            return;
        }

        Move = Input.GetAxis("Horizontal");

        rb.linearVelocity = new Vector2(Move * speed, rb.linearVelocity.y);

        //DASHING
        if (Input.GetKeyDown(KeyCode.Tab) && isJumping == false)
        {
            StartCoroutine(SpecialDash());
            dashNoise.Play();
            

        }
        

        if (Input.GetKeyDown(KeyCode.Q) && isJumping == false)
        {
            StartCoroutine(Dash());
            dashNoise.Play();
            
        }
        

        //JUMPING
        if (Input.GetKeyDown(KeyCode.Space) && isJumping == false)
        {
            rb.AddForce(new Vector2(rb.linearVelocity.x, jump));
            
        }
        

        //FLIP
        if (Move > 0 && !facingRight)
        {
            Flip();
        }

        if (Move < 0 && facingRight)
        {
            Flip();
        }

    }

    //function that damages the player when they collide with objects that have the enemy or hazard tag
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        slider.value = currentHealth;
        slimeHurt.Play();



        if (currentHealth <= 0)
        {
            SceneManager.LoadScene("Lose");
        }
    }

    public void CollectHealth(int amount)
    {
        currentHealth += amount;
        slider.value = currentHealth;
    }

    

    

    //Coroutine for normal dash
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

    //coroutine for special dash
    private IEnumerator SpecialDash()
    {
        canDash = false;
        isLethalDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.linearVelocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        yield return new WaitForSeconds(dashingTime);
        rb.gravityScale = originalGravity;
        isLethalDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            canDash = true;
        }

        /*if (other.gameObject.CompareTag("Enemy") && (isLethalDashing == true))
        {
            enemyHealth.TakeDamageFromPlayer(damageDealt);
        }*/

        if (other.gameObject.CompareTag("Win"))
        {
            SceneManager.LoadScene("Win");
        }

    }

    



    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
            canDash = false;
        }

        
    }

    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight;
    }



    

}
