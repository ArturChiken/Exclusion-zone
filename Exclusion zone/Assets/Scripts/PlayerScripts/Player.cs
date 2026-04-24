using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector2 moveInput;

    public int hp;
    public float speed;
    public int iq;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        PlayerMove();
    }

    void PlayerMove()
    {
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
        
        rb.MovePosition(rb.position + (moveInput * speed * Time.deltaTime));
    }

    public void PlayerDamage(int damage)
    {
        if (hp > 0)
        {
            hp -= damage;
        }
        else
        {
            DeathScreen();
        }
    }

    public void DeathScreen() { }
}
