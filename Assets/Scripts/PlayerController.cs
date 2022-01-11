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
    public GameObject firepoint;

    public int rotate = 0;

    [SerializeField] private LayerMask Ground;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private bool powerUp = false;    
    [SerializeField] private float hurtForce = 10f;
    [SerializeField] private AudioSource cherrySound;
    [SerializeField] private AudioSource footstepSound;
    [SerializeField] private AudioSource jumplSound;



    public Manager manager;


    public bool _Lewo = false;
    public bool _Prawo = false;



    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (state != State.hurt) {
            Movement();
        }
        AnimationState();
        anim.SetInteger("state", (int)state);


        if (_Lewo)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            transform.localScale = new Vector2(1, 1);
        }

        if (_Prawo)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            transform.localScale = new Vector2(-1, 1);

        }
    }
    

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Collectable") {
            cherrySound.Play();
            Destroy(collision.gameObject);

            manager.addcherry();
        }

        if (collision.tag == "PowerUp") {
            Destroy(collision.gameObject);
            jumpForce = 45f;
            GetComponent<SpriteRenderer>().color = Color.red;
            manager.ammo++;
            manager.ammoAmount.text = manager.ammo.ToString();
            StartCoroutine(ResetPower());
        }

    }

    

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Enemy") 
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
        if (other.gameObject.tag == "Trap")
        {
                state = State.hurt;

                HealthUpdate2();

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

    private void HealthUpdate()
    {
        manager.sethealth(20);
    }

    private void HealthUpdate2()
    {
        manager.sethealth(10);
    }

    private void Movement()
    {
        float hDirection = Input.GetAxis("Horizontal");
        int rotateDirection = 1; //-1 -> lewo | 1 -> prawo

        if (hDirection < 0 )
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            transform.localScale = new Vector2(1, 1);
            if(rotateDirection != -1){
                firepoint.transform.Rotate(0f, 180f, 0);
                rotateDirection = -1;
            }
        }
        else if (hDirection > 0 )
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            transform.localScale = new Vector2(-1, 1);
            if(rotateDirection != 1){
                firepoint.transform.Rotate(0f, 0f, 0);
                rotateDirection = 1;
            }
        }
        if (Input.GetButtonDown("Jump") && coll.IsTouchingLayers(Ground))
        {
            Jump();
        }

    }

    public void Jump() 
    {
        if(coll.IsTouchingLayers(Ground))
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

    public void LeftButtonDown()
    {
        _Lewo = true;

    }

    public void RightButtonDown()
    {
        _Prawo = true;
    }

    public void DirectionRelease()
    {
        _Lewo = false;
        _Prawo = false;
    }

    private IEnumerator ResetPower() {
        yield return new WaitForSeconds(5);
        jumpForce = 20f;
        GetComponent<SpriteRenderer>().color = Color.white;
    }

}