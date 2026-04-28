using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector2 moveInput;

    [SerializeField]
    private int maxHp;
    private int hp;
    public float speed;
    [Range(0, 100)]
    public int iq;

    public int medKits;
    public int food;

    private void Start()
    {
        hp = maxHp;

        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        PlayerMove();
    }

    void PlayerMove()
    {
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
        
        rb.MovePosition(rb.position + (moveInput * speed * Time.fixedDeltaTime));
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

    public void PlayerHeals(int heal)
    {
        if (hp + heal <= maxHp)
        {
            hp += heal;
        }
        else
        {
            hp = maxHp;
        }
    }
}
