using UnityEngine;

public class EnemyDownUp : MonoBehaviour
{
    [SerializeField] private float movementDistanceY;
    [SerializeField] private float speedY;
    [SerializeField] private float damageY;
    private bool movingDown;
    private float upEdge;
    private float downEdge;

    private void Awake()
    {
        upEdge = transform.position.y + movementDistanceY;
        downEdge = transform.position.y - movementDistanceY;

    }

    private void Update()
    {
        if (movingDown)
        {
            if (transform.position.y > downEdge)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - speedY * Time.deltaTime, transform.position.z);
            }
            else
                movingDown = false;
        }
        else
        {
            if (transform.position.y < upEdge)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + speedY * Time.deltaTime, transform.position.z);
            }
            else
                movingDown = true;
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
