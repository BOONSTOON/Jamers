using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class CollisionsCount : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnEnable()
    {
        PlayerMovement.gettinTapped += UpdateUI;
    }
    public void OnDisable()
    {
        PlayerMovement.gettinTapped -= UpdateUI;
    }

    public void UpdateUI()
    {
        Debug.Log("I faka ya mada");

    }
}
