using UnityEngine;

public class EnemyUpDown : MonoBehaviour
{
    [SerializeField] private float movementDistanceY;
    [SerializeField] private float speedY;
    [SerializeField] private float damageY;
    private bool movingUp;
    private float upEdge;
    private float downEdge;

    private void Awake()
    {
        upEdge = transform.position.y + movementDistanceY;
        downEdge = transform.position.y - movementDistanceY;

        print(upEdge);
        print(downEdge);
    }

    private void Update()
    {
        if (movingUp)
        {
            if (transform.position.y < upEdge)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + speedY * Time.deltaTime, transform.position.z);
            }
            else
                movingUp = false;
        }
        else
        {
            if (transform.position.y > downEdge)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - speedY * Time.deltaTime, transform.position.z);
            }
            else
                movingUp = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Health>().TakeDamage(damageY);
        }
    }
}
