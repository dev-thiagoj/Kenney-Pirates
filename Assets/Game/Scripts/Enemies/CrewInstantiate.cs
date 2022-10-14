using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrewInstantiate : MonoBehaviour
{
    [SerializeField] List<GameObject> crewMembersList;
    [SerializeField] Health health;

    private void OnValidate()
    {
        if (health == null) health = GetComponent<Health>();
    }

    void OnEnable()
    {
        Actions.performDeathExplosion += StartCoroutine;
    }

    void OnDisable()
    {
        Actions.performDeathExplosion -= StartCoroutine;
    }

    Quaternion ChooseRotation()
    {
        var rotationZ = Random.Range(-90, 90);

        var rotation = new Quaternion(0, 0, rotationZ, 0);
        return rotation;
    }

    GameObject ChooseCrewMember()
    {
        var index = Random.Range(0, crewMembersList.Count);
        var member = crewMembersList[index];
        return member;
    }

    [NaughtyAttributes.Button]
    public void StartCoroutine()
    {
        if(!health.isAlive) StartCoroutine(CrewInstantiateCoroutine());
    }

    IEnumerator CrewInstantiateCoroutine()
    {
        for (int i = 0; i < crewMembersList.Count; i++)
        {
            var crew = Instantiate(ChooseCrewMember(), transform.position, ChooseRotation(), transform);

            yield return new WaitForSeconds(.1f);
        }

    }
}
