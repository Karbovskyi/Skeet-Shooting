using System.Collections.Generic;
using UnityEngine;

public class DefaultPool : IThrowableObjectsPool
{
    private IThrowableObject[] pool = new IThrowableObject[1];
    
    public IThrowableObject GetThrowableObject()
    {
        IThrowableObject throwable = pool[0];

        if (throwable == null)
            Debug.LogError("ThrowablePool  is Empty");

        pool[0] = null;
        return throwable;
    }
    
    public void AddThrowableObject(IThrowableObject throwableObject)
    {
        pool[0] = throwableObject;
    }
}