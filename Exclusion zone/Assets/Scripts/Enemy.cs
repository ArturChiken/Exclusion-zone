using TMPro;
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
        playerPos = FindFirstObjectByType<Player>().GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        FindPlayer();
    }

    private void FindPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.fixedDeltaTime);

        FlipSprite(playerPos.position);
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

    public void SetPlayerPos(Transform playerPos)
    {
        this.playerPos = playerPos;
    }

    public Transform GetPlayerPos()
    {
        return playerPos;
    }

    private void FlipSprite(Vector3 targetPosition)
    {
        // Если игрок слева (X меньше чем у врага)
        if (targetPosition.x < transform.position.x)
        {
            // Поворот налево (0 по Y)
            transform.localScale = new Vector3(1, 1.5f, 1);
        }
        // Если игрок справа (X больше чем у врага)
        else if (targetPosition.x > transform.position.x)
        {
            // Поворот направо (180 по Y)
            transform.localScale = new Vector3(-1, 1.5f, 1);
        }
    }
}
