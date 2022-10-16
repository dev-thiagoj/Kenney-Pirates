using UnityEngine;

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
        transform.position += direction * speed * Time.deltaTime;
    }

    void ChooseDirection()
    {
        float directionX = Random.Range(-1, 1.1f);
        var directionY = Random.Range(-1, 1.1f);

        var _direction = new Vector3(directionX, directionY, 0);
        direction = _direction;
        RandomSpeed();
    }

    void RandomSpeed()
    {
        float _speed = Random.Range(.1f, .3f);
        int _direction = Random.Range(-1, 2);
        
        if(_direction == 0)
        {
            RandomSpeed();
        }

        float finalSpeed = _speed * _direction;
        speed = finalSpeed;
    }
}
