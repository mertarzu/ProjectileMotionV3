using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] ObjectPooler objectPooler;
    [SerializeField] UIController uIController;
    [SerializeField] TargetInputController targetInputController;
    [SerializeField] Transform startTransform;
    [SerializeField] Transform finalTransform;
    bool isFinal;

    [SerializeField] Ball ballPrefab;
    int amountToPool = 1;
    int additionAmountToPool = 2;
    int tempAmountToPool;
    void  onTargetSelected(Vector3 target)
    {
        if (!isFinal)
        {
            startTransform.position = target;
            isFinal = true;
        }
        else
        {
            finalTransform.position = target;
            Ball ballItem = Spawn();
            if (ballItem != null)
            {
                ballItem.ProjectileMotion(startTransform, finalTransform, uIController.MaxHeight, uIController.Time);
            }
                isFinal = false;
        }
      
    }


    public void Initialize()
    {
        targetInputController.OnTriggerInput = onTargetSelected;

        objectPooler.Initialize(ballPrefab, amountToPool);
       
    }


    public Ball Spawn()
    {
        Ball ball = objectPooler.GetPooledObject();

        if (ball == null && tempAmountToPool < additionAmountToPool)
        {
            objectPooler.AddPooledObject();
            ball = objectPooler.GetPooledObject();
            ++tempAmountToPool;
        }

        return ball;


    }
}
