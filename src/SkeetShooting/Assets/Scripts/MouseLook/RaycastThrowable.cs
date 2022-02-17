﻿using UnityEngine;

public class RaycastThrowable : MonoBehaviour
{
    public bool inCast;

    public void Update()
    {
        Cast();
    }
    
    public void Cast()
    {
        RaycastHit hit;

        //Debug.DrawRay(transform.position,transform.forward *200, Color.red) ;

        if (Physics.SphereCast(transform.position, 2f, transform.forward, out hit, 200))
        {
            Debug.Log(hit.transform.name);
            inCast = true;

        }
        else
        {
            inCast = false;
        }
    }
    
}