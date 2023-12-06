using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Rigidbody2D player;

    [SerializeField] private Vector3 offset;
    [SerializeField] private float damping;

    private Vector3 vel = Vector3.zero;
    void Start()
    {
        if(player == null)
        {
            Debug.LogError("Camera has no reference to Player.");
        }
        else
        {
            gameObject.transform.position = new Vector3(player.position.x, player.position.y, gameObject.transform.position.z); ;
        }
    }

    private void FixedUpdate()
    {
        Vector3 movePosition = new Vector3(player.position.x + offset.x, player.position.y + offset.y, gameObject.transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, movePosition, ref vel, damping);
    }
}
