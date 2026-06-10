using UnityEngine;
using System.Collections;

public class StayableEnemy : Enemy
{
    public GameObject shootArea;
    public GameObject enemyBulletPrefab;

    public bool seePlayer = false;
    public bool canShoot = false;

    [Header("Shooting Settings")]
    public float shootCooldown = 1.5f;
    public int bulletCount = 5;
    public float coneAngle = 45f;
    public float bulletSpread = 30f;

    private TriggerArea ta;
    private float lastShootTime;
    private Transform shootPoint;

    private void Start()
    {
        ta = GetComponentInChildren<TriggerArea>();

        Transform playerPos = FindFirstObjectByType<Player>().GetComponent<Transform>();
        SetPlayerPos(playerPos);

        if (shootArea != null)
        {
            shootPoint = shootArea.transform;
        }
        else
        {
            shootPoint = transform;
        }

        lastShootTime = -shootCooldown;
    }

    private void FixedUpdate()
    {
        seePlayer = ta.isPlayerHere;
        FindPlayer();

        if (seePlayer && Time.time >= lastShootTime + shootCooldown)
        {
            ShootPlayer();
            lastShootTime = Time.time;
        }
    }

    private void FindPlayer()
    {
        if (seePlayer)
        {
            Vector3 targetPosition = GetPlayerPos().position;
            FlipSprite(targetPosition);
        }
    }

    private void ShootPlayer()
    {
        Debug.Log("Shooting in cone!");

        Vector2 directionToPlayer = (GetPlayerPos().position - shootPoint.position).normalized;

        ShootConePattern(directionToPlayer);
    }

    private void ShootConePattern(Vector2 baseDirection)
    {
        float startAngle = -coneAngle / 2;
        float angleStep = coneAngle / (bulletCount - 1);

        for (int i = 0; i < bulletCount; i++)
        {
            float currentAngle = startAngle + (angleStep * i);

            Vector2 shootDirection = RotateVector(baseDirection, currentAngle);

            GameObject bullet = Instantiate(enemyBulletPrefab, shootPoint.position, Quaternion.identity);

            EnemyBullet enemyBullet = bullet.GetComponent<EnemyBullet>();
            if (enemyBullet != null)
            {
                enemyBullet.damage = damage;
                enemyBullet.SetDirection(shootDirection);
            }
        }
    }
    private Vector2 RotateVector(Vector2 vector, float angleDegrees)
    {
        float angleRadians = angleDegrees * Mathf.Deg2Rad;
        float cos = Mathf.Cos(angleRadians);
        float sin = Mathf.Sin(angleRadians);

        return new Vector2(
            vector.x * cos - vector.y * sin,
            vector.x * sin + vector.y * cos
        );
    }

    private void FlipSprite(Vector3 targetPosition)
    {
        if (targetPosition.x < transform.position.x)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (targetPosition.x > transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}