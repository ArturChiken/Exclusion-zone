using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;
    public float speed;

    private void Start()
    {
        Invoke("BulletDestroy", 5f);
    }

    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void BulletDestroy()
    {
        Destroy(gameObject);
    }
}
