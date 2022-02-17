using UnityEngine;

public class ShootService
{
    private IGetShootForceService _getShootForceService;
    private IThrowableObjectStartPositionService _throwableObjectStartPositionService;
    private IThrowableObjectsPool _throwableObjectsPool;


    public ShootService(
        IGetShootForceService getShootForceService, 
        IThrowableObjectStartPositionService throwableObjectStartPositionService, 
        IThrowableObjectsPool throwableObjectsPool)
    {
        _getShootForceService = getShootForceService;
        _throwableObjectStartPositionService = throwableObjectStartPositionService;
        _throwableObjectsPool = throwableObjectsPool;
    }
    
    public void Shoot()
    {
        Vector3 position = _throwableObjectStartPositionService.GetStartPosition();
        
        Vector3 shootForce = _getShootForceService.GetForceVector3(position);
        
        IThrowableObject throwableObject = _throwableObjectsPool.GetThrowableObject();
        throwableObject.SetPosition(position);
        throwableObject.Throw(shootForce);
    }
}