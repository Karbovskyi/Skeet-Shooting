using UnityEngine;

public interface IRaycastThrowable
{
    public bool InCast { get; }
    public RaycastHit Hit { get; }
    public void Cast();
}