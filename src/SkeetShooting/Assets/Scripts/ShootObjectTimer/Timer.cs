using System;
using UnityEngine;

public class Timer
{
    private float _timer = 0;
    public bool IsActive { get; set; }

    public void UpdateTime()
    {
        if(IsActive)
            _timer += Time.deltaTime;
    }

    public float GetTime()
    {
        return _timer;
    }

    public void Reset()
    {
        
    }
}
