using UnityEngine;

public class Alkash : Enemy
{
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        Transform playerPos = FindFirstObjectByType<Player>().GetComponent<Transform>();
        SetPlayerPos(playerPos);
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        FindPlayer(); 
    }

    private void FindPlayer()
    {
        Vector3 targetPosition = GetPlayerPos().position;
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.fixedDeltaTime);

        FlipSprite(targetPosition);
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
