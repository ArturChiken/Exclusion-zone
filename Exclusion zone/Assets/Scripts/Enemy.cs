using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hp;
    public int damage;
    public float speed;
    public float cooldown = 5f;

    public int iqDown;

    private Transform playerPos;
    private int triggerLayerIndex;

    private void Start()
    {
        triggerLayerIndex = 7;// LayerMask.NameToLayer("Test"); // Или "Test"
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
        // Проверяем, что столкнулись НЕ с TriggerArea
        if (collision.gameObject.layer == triggerLayerIndex)
            return; // Игнорируем попадание в TriggerArea

        if (collision.gameObject.TryGetComponent(out Bullet bullet) && !collision.gameObject.TryGetComponent(out EnemyBullet eBullet))
        {
            TakeDamage(bullet);
            Destroy(bullet.gameObject);
        }
    }

    public void TakeDamage(Bullet bullet)
    {
        if (hp-bullet.damage > 0)
        {
            hp -= bullet.damage;
        }
        else
        {
            Player player = FindFirstObjectByType<Player>();
            player.MinusIQ(iqDown);

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
