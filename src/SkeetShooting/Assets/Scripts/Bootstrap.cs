using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private GameObject _skeetPrefab;
    [SerializeField] private UISkeetShootingMediator _mediator;
    private Timer _timer;
    
    void Start()
    {
        IGetShootForceService shootForceService = new GetShootForceService();
        IThrowableObjectStartPositionService positionService = new ThrowableStartPositionService();
        IThrowableObjectsPool throwableObjectsPool = new DefaultPool();
        IThrowableObjectsFactory skeetFactory = new SkeetFactory(_skeetPrefab);

        IThrowableObject skeet = skeetFactory.GetThrowableObject();
        skeet.SetPosition(new Vector3(0, -5, 0));
        throwableObjectsPool.AddThrowableObject(skeet);

        _timer = new Timer();
        
        ShootService shootService = new ShootService( shootForceService, positionService, throwableObjectsPool, _timer);
        
        _mediator.Initialize(shootService);
        
        ThrowableObjectDestroyService throwableDestroyService = new ThrowableObjectDestroyService(throwableObjectsPool, _mediator);
        ThrowableObjectSubscribeService throwableSubscribeService = new ThrowableObjectSubscribeService(throwableDestroyService, _timer);
        throwableSubscribeService.SubscribeDestroyEvent(skeet);
        
        
    }


    void Update()
    {
        _timer.UpdateTime();
    }
}