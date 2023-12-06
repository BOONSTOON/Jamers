using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    private const float VERY_SMALL = 0.0001f;

    public InputMaster controls;
    


    // privates that we want to see in editor
    [SerializeField] private float dir;
    [SerializeField] private float maxVel;
    [SerializeField] private float forceMag;

    [SerializeField] private float decel;

    private Rigidbody2D rb;

    private void Awake()
    {
        // instantiate new InputMaster object

        controls = new InputMaster();

        // whenever Move is performed (a and d keys) it will call UpdateVelocity
        controls.Player.Move.performed += ctx => UpdateVelocity(ctx.ReadValue<float>());
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    public void UpdateVelocity(float dir_)
    {
        dir = dir_;
    }

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
        if(Mathf.Abs(rb.velocity.x) <= VERY_SMALL) return;
        
        if(Mathf.Abs(dir) <= VERY_SMALL)
        {
            // no more input?
            // force in the opposite direction to velocity
            rb.AddForce(new Vector2(Mathf.Abs(rb.velocity.x) / -rb.velocity.x * decel, 0));
        }
    }


    public void FixedUpdate()
    {
        rb.AddForce(new Vector2(forceMag * dir, 0));
        CapVelocity();
        SlowDown();
    }



    private void OnEnable()
    {
        controls.Enable();
    }
    private void OnDisable()
    {
        controls.Disable();
    }
}
