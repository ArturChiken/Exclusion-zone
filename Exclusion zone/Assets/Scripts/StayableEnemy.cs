using UnityEngine;

public class StayableEnemy : MonoBehaviour
{
    public int hp;
    public int damage;

    public float cooldown = 5f;
    public bool canShoot = false;

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
        FlipSprite(playerPos.position);
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
