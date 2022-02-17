using UnityEngine;

public class GetShootForceService : IGetShootForceService
{
    public Vector3 GetForceVector3(Vector3 startPosition)
    {
        float x = -startPosition.x;
        float r = Random.Range(x, 0);
        return new Vector3(r, 15, 40);
    }
}