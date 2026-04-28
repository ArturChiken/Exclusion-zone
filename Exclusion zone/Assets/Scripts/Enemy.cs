using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hp;
    public int damage;
    public float speed;
    public float cooldown = 5f;

    private Transform playerPos;

    private void Start()
    {
        playerPos = FindObjectOfType<Player>().GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        FindPlayer();
    }

    private void FindPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Bullet bullet))
        {
            TakeDamage(bullet);
            Destroy(bullet.gameObject);
        }
    }

    public void TakeDamage(Bullet bullet)
    {
        if (hp > 0)
        {
            hp -= bullet.damage;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
