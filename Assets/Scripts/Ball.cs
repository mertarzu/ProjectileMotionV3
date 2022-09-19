using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour,IPooledObject
{
    [SerializeField] ProjectileMotion projectileMotion;

    public bool IsTaken => projectileMotion.IsProjectile;

    public void Dismiss()
    {
        gameObject.SetActive(false);
    }

    public void ProjectileMotion(Transform startTransform, Transform finalTransform, float maxHeight, float time)
     {
       projectileMotion.Navigate(startTransform, finalTransform, maxHeight, time);
       SetActive();
    }

    public void SetActive()
    {
        gameObject.SetActive(true);
    }
}
