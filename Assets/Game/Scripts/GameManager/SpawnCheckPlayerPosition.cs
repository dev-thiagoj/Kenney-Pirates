using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCheckPlayerPosition : MonoBehaviour
{
    public bool canSpawn;

    private void Awake()
    {
        canSpawn = true;
    }
}
