using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public int damage;
    public float speed = 5f;

    private Vector2 direction;

    private void Start()
    {
        Destroy(gameObject, 5f); // Автоудаление через 5 секунд
    }

    private void Update()
    {
        // Движение в заданном направлении
        transform.Translate(direction * speed * Time.deltaTime);
    }

    public void SetDirection(Vector2 newDirection)
    {
        direction = newDirection.normalized;

        // Поворачиваем спрайт в направлении движения
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Наносим урон игроку
            Player player = collision.GetComponent<Player>();
            if (player != null)
            {
                player.PlayerDamage(damage);
            }
            Destroy(gameObject);
        }
    }
}