public class ThrowableObjectSubscribeService
{
    private ThrowableObjectDestroyService _destroyService;
    private Timer _timer;

    public ThrowableObjectSubscribeService(ThrowableObjectDestroyService destroyService, Timer timer)
    {
        _destroyService = destroyService;
        _timer = timer;
    }

    public void SubscribeDestroyEvent(IThrowableObject throwableObject)
    {
        throwableObject.ThrowableDestroy += DeactivateTimer;
        throwableObject.ThrowableDestroy += _destroyService.AddToPool;
    }
    
    private void DeactivateTimer(IThrowableObject throwableObject)
    {
        _timer.IsActive = false;
    }
}