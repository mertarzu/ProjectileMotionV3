using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class ObjectPooler : MonoBehaviour 
{
 
    public List<Ball> PooledObjects = new List<Ball>();
    Ball sample;

    public void Initialize(Ball sample, int amountToPool)
    {
        this.sample = sample;
       
        for(int i=0; i< amountToPool; i++)
        {
            PooledObjects.Add(Create());
        }
    }

    public Ball Create()
    {
        Ball tempGameObject = GameObject.Instantiate(sample);
        tempGameObject.gameObject.SetActive(false);
        return tempGameObject;
       
    }

    public Ball GetPooledObject()
    {
        Ball result = PooledObjects.Where(i => i.IsTaken == false).FirstOrDefault();
        return result;
    }
    public void AddPooledObject()
    {
        PooledObjects.Add(Create());
    }
}
