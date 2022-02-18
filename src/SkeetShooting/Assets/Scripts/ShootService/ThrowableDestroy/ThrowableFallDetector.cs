using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableFallDetector : MonoBehaviour
{
    public IThrowableObject _throwable;
    
    public void OnCollisionEnter(Collision collision)
    {
        _throwable.DestroyThrowableObject();
    }
}
