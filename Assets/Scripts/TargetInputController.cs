using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetInputController : MonoBehaviour
{
    public Action<Vector3> OnTriggerInput; 
    [SerializeField] LayerMask unitMask;
    bool isGameActive;

    void Update()
    {
        if (isGameActive)
        {
            CheckTarget();
        }       
    }

    void CheckTarget()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, unitMask))
            { 
                if (OnTriggerInput != null)
                {
                    OnTriggerInput(hit.point + new Vector3(0, .5f, 0));
                }          
            }
        }          
    }

    public void Initialize()
    {
        isGameActive = true;
      
    }
}
