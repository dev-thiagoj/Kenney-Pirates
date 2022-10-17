using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrewInstantiate : MonoBehaviour
{
    [SerializeField] List<GameObject> crewMembersList;
    [SerializeField] Health health;

    private void OnValidate()
    {
        if (health == null) 
            health = GetComponent<Health>();
    }

    #region Actions
    void OnEnable()
    {
        Actions.performDeathExplosion += StartCoroutine;
    }

    void OnDisable()
    {
        Actions.performDeathExplosion -= StartCoroutine;
    }
    #endregion

    Quaternion ChooseRotation()
    {
        float rotationZ = Random.Range(-90f, 90f);
        Quaternion rotation = new Quaternion(0, 0, rotationZ, 0);
        return rotation;
    }

    GameObject ChooseCrewMember()
    {
        int index = Random.Range(0, crewMembersList.Count);
        GameObject member = crewMembersList[index];
        return member;
    }

    public void StartCoroutine()
    {
        if(!health.isAlive) 
            StartCoroutine(CrewInstantiateCoroutine());
    }

    IEnumerator CrewInstantiateCoroutine()
    {
        for (int i = 0; i < crewMembersList.Count; i++)
        {
            Instantiate(ChooseCrewMember(), transform.position, ChooseRotation(), transform);
            yield return new WaitForSeconds(.1f);
        }
    }
}
