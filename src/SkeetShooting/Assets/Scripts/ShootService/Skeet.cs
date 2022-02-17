using System;
using UnityEngine;

public class Skeet : MonoBehaviour, IThrowableObject
{
    [SerializeField] private GameObject _skeetGameObject;
    [SerializeField] private ParticleSystem _destroyParticle;
    [SerializeField] private ParticleSystem _flyParticle;

    [SerializeField] private ThrowableFallDetector throwableFallDetector;
    
    public event IThrowableObject.ThrowableObjectDestroy ThrowableDestroy;

    private Rigidbody myRigidBody;

    public void Start()
    {
        throwableFallDetector._throwable = this;
        myRigidBody = gameObject.GetComponent<Rigidbody>();
    }

    public void Throw(Vector3 force)
    {
        PrepareSkeet();
        
        myRigidBody.isKinematic = false;
        myRigidBody.AddForce(force, ForceMode.Impulse);
    }

    public void DestroyThrowableObject()
    {
        _destroyParticle.Play();
        
        _skeetGameObject.SetActive(false);
        _flyParticle.Stop();
        
        myRigidBody.isKinematic = true;

        ThrowableDestroy?.Invoke(this);
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