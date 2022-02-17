using UnityEngine;

public class ThrowableStartPositionService : IThrowableObjectStartPositionService
{
    private Vector3 _left = new Vector3(-20,5,-50);
    private Vector3 _right = new Vector3(20,5,-50);
    public Vector3 GetStartPosition()
    {
        int r = Random.Range(0, 10);

        Debug.Log(r);
        if (r < 5 )
            return _left;
        else
            return _right;
    }
}