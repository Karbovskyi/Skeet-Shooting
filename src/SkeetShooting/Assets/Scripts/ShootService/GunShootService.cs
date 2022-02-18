using UnityEngine;

public class GunShootService
{
    private Timer _timer;
    private IRaycastThrowable _raycastThrowable;
    private UISkeetShootingMediator _mediator;
    private IGetDestroyTimeService _destroyTimeService;

    float startTime;
    float xTime;
    private bool onInCast;

    private float progressBarValue;
    
    public GunShootService(Timer timer, IRaycastThrowable raycastThrowable, UISkeetShootingMediator mediator, IGetDestroyTimeService destroyTimeService)
    {
        _timer = timer;
        _raycastThrowable = raycastThrowable;
        _mediator = mediator;
        _destroyTimeService = destroyTimeService;
    }
    
    public void Update()
    {
        if (_raycastThrowable.InCast)
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
                _raycastThrowable.Hit.transform.GetComponent<IThrowableObject>().DestroyThrowableObject();
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