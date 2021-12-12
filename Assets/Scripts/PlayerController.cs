using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rb;
    private Animator anim;
    private enum State {idle, Running, jumping, falling, hurt}
    private State state = State.idle;
    private Collider2D coll;

    [SerializeField] private LayerMask Ground;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private bool powerUp = false;    
    [SerializeField] private float hurtForce = 10f;
    [SerializeField] private AudioSource cherrySound;
    [SerializeField] private AudioSource footstepSound;
    [SerializeField] private AudioSource jumplSound;



    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
        PermamentUI.perm.healthAmount.text = PermamentUI.perm.health.ToString();
        // cherryText = FindObjectOfType<TextMeshProUGUI>();
        // healthAmount = FindObjectOfType<TextMeshProUGUI>();
    }

    private void Update()
    {
        if (state != State.hurt) {
            Movement();
        }
        AnimationState();
        anim.SetInteger("state", (int)state);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Collectable") {
            cherrySound.Play();
            Destroy(collision.gameObject);
            PermamentUI.perm.cherries += 1;
            PermamentUI.perm.cherryText.text = PermamentUI.perm.cherries.ToString();
        }

        if (collision.tag == "PowerUp") {
            Destroy(collision.gameObject);
            jumpForce = 45f;
            GetComponent<SpriteRenderer>().color = Color.red;
            StartCoroutine(ResetPower());
        }
    }

    

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Enemy") {

            Enemy enemy = other.gameObject.GetComponent<Enemy>();

            if (state == State.falling) {
                enemy.JumpedOn();
                Jump();
                
            }
            
            else
            {
                state = State.hurt;

                HealthUpdate();

                if (other.gameObject.transform.position.x > transform.position.x)
                {
                    rb.velocity = new Vector2(-hurtForce, rb.velocity.y);
                }
                else
                {
                    rb.velocity = new Vector2(hurtForce, rb.velocity.y);
                }
            }
        }
    }

    private void HealthUpdate()
    {
        PermamentUI.perm.health -= 1;
        PermamentUI.perm.healthAmount.text = PermamentUI.perm.health.ToString();
        if (PermamentUI.perm.health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void Movement()
    {
        float hDirection = Input.GetAxis("Horizontal");

        if (hDirection < 0)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            transform.localScale = new Vector2(1, 1);
        }

        else if (hDirection > 0)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            transform.localScale = new Vector2(-1, 1);
        }
        if (Input.GetButtonDown("Jump") && coll.IsTouchingLayers(Ground))
        {
            Jump();
        }
    }

    private void Jump() {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        state = State.jumping;
    }

    private void AnimationState() {

        if (state == State.jumping) {
            if (rb.velocity.y < .2f) {
                state = State.falling;
            }
        }

        else if (state == State.falling) {
            if (coll.IsTouchingLayers(Ground)) {
                state = State.idle;
            }
        }

        else if (state == State.hurt) {
            if (Mathf.Abs(rb.velocity.x) < .1f) {
                state = State.idle;
            }
        }

        else if (Mathf.Abs(rb.velocity.x) > 2f) {

            state = State.Running;
        }

        else {
            state = State.idle;
        }
    }

    private void FootStep() {
        footstepSound.Play();
        }

    private void JumpSound() {
        jumplSound.Play();
    }

    private IEnumerator ResetPower() {
        yield return new WaitForSeconds(5);
        jumpForce = 20f;
        GetComponent<SpriteRenderer>().color = Color.white;
    }

}