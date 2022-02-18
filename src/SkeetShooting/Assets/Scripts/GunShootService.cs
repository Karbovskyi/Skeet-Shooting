using UnityEngine;

public class GunShootService
{
    private Timer _timer;
    private RaycastThrowable _raycastThrowable;
    private UISkeetShootingMediator _mediator;
    private IGetDestroyTimeService _destroyTimeService;

    float startTime;
    float xTime;
    private bool onInCast;

    private float progressBarValue;
    
    public GunShootService(Timer timer, RaycastThrowable raycastThrowable, UISkeetShootingMediator mediator, IGetDestroyTimeService destroyTimeService)
    {
        _timer = timer;
        _raycastThrowable = raycastThrowable;
        _mediator = mediator;
        _destroyTimeService = destroyTimeService;
    }
    
    public void Update()
    {
        if (_raycastThrowable.inCast)
        {
            if (onInCast == false)
            {
                startTime = _timer.GetTime();
                Debug.Log( "StartTimr " + startTime);
                xTime = _destroyTimeService.GetTimeX(startTime);
                onInCast = true;
            }

            xTime += -Time.deltaTime;

            progressBarValue += Time.deltaTime / xTime;
            
            if (xTime <= 0)
            {
                _raycastThrowable.hit.transform.GetComponent<IThrowableObject>().DestroyThrowableObject();
                progressBarValue = 0;
            }

            _mediator.UpdateProgressBar(progressBarValue);
        }
        else
        {
            if (onInCast)
            {
                progressBarValue = 0;
                _mediator.UpdateProgressBar(progressBarValue);
                onInCast = false;
            }
        }
    }
}


public class GetDestroyTimeService : IGetDestroyTimeService
{

    public float GetTimeX(float startTime)
    {
        if (startTime < 1)
        {
            return 0.25f;
        }
        if (startTime < 2)
        {
            return 0.5f;
        }
        if (startTime < 3)
        {
            return 0.75f;
        }
        if (startTime < 4)
        {
            return 1f;
        }

        return 1.2f;
    }
    
}

public interface IGetDestroyTimeService
{
    public float GetTimeX(float startTime);
}