using UnityEngine;

public interface IThrowableObject
{
   public void Throw(Vector3 force);
   public void DestroyThrowableObject();
   

   public void SetPosition(Vector3 position);
}