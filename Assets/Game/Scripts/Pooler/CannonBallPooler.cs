using System.Collections.Generic;
using UnityEngine;

public class CannonBallPooler : MonoBehaviour
{
    public static CannonBallPooler Instance;
    public List<GameObject> pooledBalls;
    public GameObject cannonBall;
    public int poolAmount;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        pooledBalls = new List<GameObject>();

        for (int i = 0; i < poolAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(cannonBall);
            obj.SetActive(false);
            pooledBalls.Add(obj);
            obj.transform.SetParent(this.transform);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledBalls.Count; i++)
        {
            if (!pooledBalls[i].activeInHierarchy)
            {
                return pooledBalls[i];
            }
        }

        return null;
    }
}
