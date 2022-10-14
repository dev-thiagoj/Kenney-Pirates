using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CrewMovement : MonoBehaviour
{
    float speed;
    Vector3 direction;

    private void Start()
    {
        ChooseDirection();
    }

    void FixedUpdate()
    {
        //transform.DOMove(ChooseDirection(), .5f * Time.deltaTime);
        transform.position += direction * speed * Time.deltaTime;
    }

    void ChooseDirection()
    {
        var directionX = Random.Range(-1, 1);
        var directionY = Random.Range(-1, 1);

        var _direction = new Vector3(directionX, directionY, 0);
        direction = _direction;
        RandomSpeed();
    }

    void RandomSpeed()
    {
        float _speed = Random.Range(.1f, .3f);
        int _direction = Random.Range(-1, 2);
        float finalSpeed = _speed * _direction;
        speed = finalSpeed;
    }
}
