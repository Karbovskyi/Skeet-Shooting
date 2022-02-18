using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private GameObject _skeetPrefab;
    [SerializeField] private UISkeetShootingMediator _mediator;
    [SerializeField] private RaycastThrowable _raycastThrowable;

    private Timer _timer;
    private GunShootService _gunShootService;
    
    
    void Start()
    {
        IGetShootForceService shootForceService = new GetShootForceService();
        IThrowableObjectStartPositionService positionService = new ThrowableStartPositionService();
        IThrowableObjectsPool throwableObjectsPool = new DefaultPool();
        IThrowableObjectsFactory skeetFactory = new SkeetFactory(_skeetPrefab);
        IGetDestroyTimeService getDestroyTimeService = new GetDestroyTimeService();

        IThrowableObject skeet = skeetFactory.GetThrowableObject();
        skeet.SetPosition(new Vector3(0, -5, 0));
        throwableObjectsPool.AddThrowableObject(skeet);

        _timer = new Timer();
        
        ShootService shootService = new ShootService( shootForceService, positionService, throwableObjectsPool, _timer);
        
        _mediator.Initialize(shootService);
        
        ThrowableObjectDestroyService throwableDestroyService = new ThrowableObjectDestroyService(throwableObjectsPool, _mediator);
        ThrowableObjectSubscribeService throwableSubscribeService = new ThrowableObjectSubscribeService(throwableDestroyService, _timer);
        throwableSubscribeService.SubscribeDestroyEvent(skeet);

        _gunShootService = new GunShootService(_timer, _raycastThrowable, _mediator, getDestroyTimeService);

    }


    void Update()
    {
        _timer.UpdateTime();
        _gunShootService.Update();
    }
}