using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMotion : MonoBehaviour
{
    float maxHeight = 2;
    float deltaTime;
    float time;
    float timeOfFlight;
    float x;
    float y;
    float angle0;
    float v0;
    float n = 1000;
    Vector3 startPosition;
    Vector3 finalPosition;
    const float gravityConst = 9.8f;
    bool isProjectile;
    public bool IsProjectile => isProjectile;

    private void FixedUpdate()
    {

        if (isProjectile)
        {
            if ((timeOfFlight - time) > 1e-7f)
            {
                x = startPosition.x + v0 * Mathf.Cos(angle0) * time;
                y = startPosition.y + v0 * Mathf.Sin(angle0) * time - .5f * gravityConst * time * time;
                transform.position = new Vector3(x, y, finalPosition.z);
                time += deltaTime;
            }
            else
            {
                isProjectile = false;
                gameObject.SetActive(false);
               
            }         
        }
    }

    public void Navigate(Transform startTransform, Transform finalTransform, float mHeight, float timeModifier)
    {
        transform.position = startPosition;
        startPosition = startTransform.position;
        finalPosition = finalTransform.position;
        maxHeight = mHeight;
        n = timeModifier * 100;    
        angle0 = Mathf.Atan(4 * maxHeight / ((finalPosition.x - startPosition.x)));
        v0 = Mathf.Sqrt(2 * gravityConst * maxHeight) / Mathf.Sin(angle0);
        timeOfFlight = 2 * v0 * Mathf.Sin(angle0) / gravityConst;
        deltaTime = timeOfFlight / n;
        time = 0;
        isProjectile = true;
        
    }

}
