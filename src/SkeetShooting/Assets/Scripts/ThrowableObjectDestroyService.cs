public class ThrowableObjectDestroyService
{
    private IThrowableObjectsPool _pool;
    private UISkeetShootingMediator _mediator;

    public ThrowableObjectDestroyService(IThrowableObjectsPool pool, UISkeetShootingMediator mediator)
    {
        _pool = pool;
        _mediator = mediator;
    }

    public void AddToPool(IThrowableObject tObject)
    {
        _pool.AddThrowableObject(tObject);
        _mediator.ActivateShootButton();
    }
}