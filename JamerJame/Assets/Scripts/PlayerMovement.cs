using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    private const float VERY_SMALL = 0.0001f;

    public InputMaster controls;

    public delegate void MyDelegate();
    public static MyDelegate gettinTapped;

    // privates that we want to see in editor  //

    [SerializeField] private float dir = 0.0f;          // Input value: -1 to 1
    [SerializeField] private float maxVel;              // value for clamping velocity
    [SerializeField] private float forceMag;            // magnitude of the applied force
    [SerializeField] private float jumpVel;             // magnitude of the jump vel

    [SerializeField] private float decel;               // rate of decceleration after releasing input


    [SerializeField] private bool falling = false;
    [SerializeField] private float fallingThreshold;    // must be negative

    private Rigidbody2D rb;

    private void Awake()
    {
        BindControls();
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();


    }
    public void FixedUpdate()
    {
        // am i falling?
        if (rb.velocity.y <= fallingThreshold) falling = true;


        rb.AddForce(new Vector2(forceMag * dir, 0));
        CapVelocity();
        SlowDown();

    }


    #region PHYSICS
    private void UpdateVelocity(float dir_) { dir = dir_; }

    private void CapVelocity()
    {
        if (rb.velocity.x > maxVel)
        {
            rb.velocity = new Vector2(maxVel, rb.velocity.y);
        }
        if (rb.velocity.x < -maxVel)
        {
            rb.velocity = new Vector2(-maxVel, rb.velocity.y);
        }
    }

    private void SlowDown()
    {
        if (Mathf.Abs(rb.velocity.x) <= VERY_SMALL)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            return;
        }

        if (Mathf.Abs(dir) <= 0.5f) // 0.5 minimum input value for joystick
        {
            // no more input?
            // force in the opposite direction to velocity
            rb.AddForce(new Vector2(Mathf.Abs(rb.velocity.x) / -rb.velocity.x * decel, 0));
        }
    }

    private void Jump()
    {
        if (!falling)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpVel);
            falling = true;

        }
    }

    #endregion PHYSICS

    #region COLLISIONS

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Environment"))
        {
            // hit the ground, reset jump
            falling = false;

        }
        if (collision.gameObject.CompareTag("Enemy"))
        {

            gettinTapped?.Invoke();     //check if anything is inside gettinTapped delegate; if so, invoke
        }
    }


    #endregion COLLISIONS

    #region CONTROLS

    private void BindControls()
    {
        // instantiate new InputMaster object

        controls = new InputMaster();

        // whenever Move is performed (a and d keys) it will call UpdateVelocity
        controls.Player.Move.performed += ctx => UpdateVelocity(ctx.ReadValue<float>());
        controls.Player.Jump.performed += _ => Jump();
    }

    private void OnEnable()
    {
        controls.Enable();
        gettinTapped += TakeDamage; //store TakeDamage function in gettinTapped Delegate
    }
    private void OnDisable()
    {
        controls.Disable();
    }

#endregion CONTROLS

    public void TakeDamage()
    {
        Debug.Log("Collided");      //test collision
    }
}