using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector2 moveInput;

    public int maxHp;
    public int hp;
    public float speed;
    [Range(0, 100)]
    public int iq;

    public int medKits;
    public int healAmount;
    public int food;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            PlayerHeals(healAmount);
        }
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

    public void PlayerGetsMedkit()
    {
        medKits++;
    }

    public void PlayerHeals(int heal)
    {
        if (medKits >= 1)
        {
            if (hp + heal <= maxHp)
            {
                hp += heal;
                medKits--;
                Debug.Log($"{hp}, 1");
            }
            else if (hp == maxHp)
            {
                hp = maxHp;
                Debug.Log($"{hp}, 2");
            }
            else
            {
                hp = maxHp;
                medKits--;
                Debug.Log($"{hp}, 3");
            }
        }
    }
}
