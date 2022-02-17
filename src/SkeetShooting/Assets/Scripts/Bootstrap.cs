using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private GameObject _skeetPrefab;
    
    void Start()
    {
        IGetShootForceService shootForceService = new GetShootForceService();
        IThrowableObjectStartPositionService positionService = new ThrowableStartPositionService();
        IThrowableObjectsPool throwableObjectsPool = new DefaultPool();
        IThrowableObjectsFactory skeetFactory = new SkeetFactory(_skeetPrefab);

        var skeet = skeetFactory.GetThrowableObject();
        throwableObjectsPool.AddThrowableObject(skeet);
        
        ShootService shootService = new ShootService( shootForceService, positionService, throwableObjectsPool );
        
        shootService.Shoot();
    }
}
