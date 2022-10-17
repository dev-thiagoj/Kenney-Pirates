using UnityEngine;

public class CrewMovement : MonoBehaviour
{
    [SerializeField] float speed;
    Vector3 direction;

    private void Start()
    {
        ChooseDirection();
    }

    void FixedUpdate()
    {
        transform.position += speed * Time.deltaTime * direction;
    }

    void ChooseDirection()
    {
        float directionX = Random.Range(-1, 1.1f);
        float directionY = Random.Range(-1, 1.1f);

        Vector3 _direction = new Vector3(directionX, directionY, 0);
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
