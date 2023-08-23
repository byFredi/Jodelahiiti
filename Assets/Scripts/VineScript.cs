using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VineScript : MonoBehaviour
{
    Transform currentSwingable;
    ConstantForce2D myConstantForce;

    bool swinging = false;
    

    void Start()
    {
        myConstantForce = GetComponent<ConstantForce2D>();
    }

    void Update()
    {
        if (swinging == true)
        {
            transform.position = currentSwingable.position;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Vine")
        {
            swinging = true;
            currentSwingable = other.transform;
        }
    }

}
