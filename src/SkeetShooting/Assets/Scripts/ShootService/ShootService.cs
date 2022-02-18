using UnityEngine;

public class ShootService : IThrowableObjectShootService
{
    private IGetShootForceService _getShootForceService;
    private IThrowableObjectStartPositionService _throwableObjectStartPositionService;
    private IThrowableObjectsPool _throwableObjectsPool;
    private Timer _timer;


    public ShootService(
        IGetShootForceService getShootForceService, 
        IThrowableObjectStartPositionService throwableObjectStartPositionService, 
        IThrowableObjectsPool throwableObjectsPool, Timer timer)
    {
        _getShootForceService = getShootForceService;
        _throwableObjectStartPositionService = throwableObjectStartPositionService;
        _throwableObjectsPool = throwableObjectsPool;
        _timer = timer;
    }
    
    public void Shoot()
    {
        Vector3 position = _throwableObjectStartPositionService.GetStartPosition();
        Vector3 shootForce = _getShootForceService.GetForceVector3(position);
        
        IThrowableObject throwableObject = _throwableObjectsPool.GetThrowableObject();
        throwableObject.SetPosition(position);
        throwableObject.Throw(shootForce);
        
        _timer.Reset();
        _timer.IsActive = true;
    }
}



