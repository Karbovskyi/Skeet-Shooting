using UnityEngine;

public class SkeetFactory : IThrowableObjectsFactory
{

    private GameObject _skeetPrefab;


    public SkeetFactory(GameObject skeetPrefab)
    {
        _skeetPrefab = skeetPrefab;
    }
    
    
    public IThrowableObject GetThrowableObject()
    {
        GameObject _skeet = Object.Instantiate(_skeetPrefab);
        return _skeet.GetComponent<Skeet>();
    }
}