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
        _timer = new Timer();
        IGetShootForceService shootForceService = new GetShootForceService();
        IThrowableObjectStartPositionService positionService = new ThrowableStartPositionService();
        IThrowableObjectsPool throwableObjectsPool = new DefaultPool();
        IThrowableObjectsFactory skeetFactory = new SkeetFactory(_skeetPrefab);
        IGetDestroyTimeService getDestroyTimeService = new GetDestroyTimeService();
        IThrowableObjectShootService shootService = new ShootService( shootForceService, positionService, throwableObjectsPool, _timer);
        ThrowableObjectDestroyService throwableDestroyService = new ThrowableObjectDestroyService(throwableObjectsPool, _mediator);
        ThrowableObjectSubscribeService throwableSubscribeService = new ThrowableObjectSubscribeService(throwableDestroyService, _timer);
        _gunShootService = new GunShootService(_timer, _raycastThrowable, _mediator, getDestroyTimeService);
        
        IThrowableObject skeet = skeetFactory.GetThrowableObject();
        skeet.SetPosition(new Vector3(0, -5, 0));
        throwableObjectsPool.AddThrowableObject(skeet);
        throwableSubscribeService.SubscribeDestroyEvent(skeet);
        
        _mediator.Initialize(shootService);
    }


    void Update()
    {
        _timer.UpdateTime();
        _gunShootService.Update();
    }
}