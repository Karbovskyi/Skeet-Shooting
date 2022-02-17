using UnityEngine;

public class GetShootForceService : IGetShootForceService
{
    public Vector3 GetForceVector3(Vector3 startPosition)
    {
        return new Vector3(-startPosition.x, 10, 10);
    }
}