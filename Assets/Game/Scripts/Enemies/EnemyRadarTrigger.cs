using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRadarTrigger : MonoBehaviour
{
    public bool triggered = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            triggered = true;
        }
    }

    private void Update()
    {
        Debug.Log(triggered);
    }
}
