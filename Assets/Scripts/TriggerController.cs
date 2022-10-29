using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerController : MonoBehaviour
{
    
    
    [SerializeField]
    private bool _isDamage;
    
    private void OnTriggerEnter(Collider other)
    {
        if (_isDamage)
        {
            GameManager.Instanse.SetDamage(1);
        }
        else
        {
            GameManager.Instanse.UpdateLevel();
        }
    }
}
