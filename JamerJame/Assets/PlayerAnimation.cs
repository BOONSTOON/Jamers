using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Rigidbody2D rb;

    public Animator animator;
    public PlayerMovement playerMovement;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.x != 0) //if player is moving
            animator.SetFloat("xVelocity",1);
        else
            animator.SetFloat("xVelocity",0);

        if (playerMovement.falling == true)
            animator.SetBool("falling",true);
        else
            animator.SetBool("falling",false);

        if (playerMovement.jumping == true)
            animator.SetBool("jumping",true);
        else
            animator.SetBool("jumping",false);
    }
}
