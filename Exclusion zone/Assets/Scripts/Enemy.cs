using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hp;
    public int damage;
    public float speed;

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
