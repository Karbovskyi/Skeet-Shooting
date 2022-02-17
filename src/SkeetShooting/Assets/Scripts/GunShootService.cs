using UnityEngine;

public class GunShootService
{
    private Timer _timer;
    private RaycastThrowable _raycastThrowable;

    float startTime;
    float xTime;
    private bool onInCast;

    public GunShootService(Timer timer, RaycastThrowable raycastThrowable)
    {
        _timer = timer;
        _raycastThrowable = raycastThrowable;
    }
    
    public void Update()
    {
        if (_raycastThrowable.inCast)
        {
            if (onInCast == false)
            {
                startTime = _timer.GetTime();
                Debug.Log( "StartTimr " + startTime);
                xTime = 1;
                onInCast = true;
            }

            xTime += -Time.deltaTime;

            if (xTime <= 0)
            {
                Debug.Log("DestroyThrowable");
            }
        }
        else
        {
            onInCast = false;
        }
    }
}