using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Tracking : MonoBehaviour
{
    public Transform target;                                     //set a objects transform to
    Rigidbody2D sexybody;                                        //rigid body of the thing moving toward the target
    private Vector2 distanceDiff;                                //set vectors 
    [SerializeField] private float speedScale = 0.75F;            //make private modifyable from editor
    [SerializeField] private bool zoomies = false;               //if false constant speed else faster with more distance                                                             
                                                                 
    // Start is called before the first frame update
    void Start()
    {
        //assigns sexybody rigid body of gameobgect/entity
        sexybody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //update the position of the booty eater
        updatePoisiton(); 
    }

    void updatePoisiton()
    {
        //get the difference in position between player and game object (gameobject like "this")
        distanceDiff = target.position - gameObject.transform.position;

        //set booty eater velocity with normalized vector
        if (zoomies == false)
            sexybody.velocity = Vector3.Normalize(distanceDiff) * speedScale;
        else
            sexybody.velocity = distanceDiff * speedScale;
    }

}
