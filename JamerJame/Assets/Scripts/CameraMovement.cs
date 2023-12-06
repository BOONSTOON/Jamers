using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Rigidbody2D player;
    void Start()
    {
        if(player == null)
        {
            Debug.LogError("Camera has no reference to Player.");
        }
    }

    private void FixedUpdate()
    {
        
    }
}
