public interface IThrowableObjectsPool
{
    public IThrowableObject GetThrowableObject();
    public void AddThrowableObject(IThrowableObject throwableObject);
}