using UnityEngine;

public class Skeet : MonoBehaviour, IThrowableObject
{
    [SerializeField] private GameObject _skeetGameObject;
    [SerializeField] private ParticleSystem _destroyParticle;
    [SerializeField] private ParticleSystem _flyParticle;

    public void Throw(Vector3 force)
    {
        PrepareSkeet();
        gameObject.GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);
    }

    public void DestroyThrowableObject()
    {
        _destroyParticle.Play();
        
        _skeetGameObject.SetActive(false);
        _flyParticle.Stop();
    }

    public void SetPosition(Vector3 position)
    {
        transform.position = position;
    }

    private void PrepareSkeet()
    {
        _skeetGameObject.SetActive(true);
        _flyParticle.Play();
    }
}