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

    public InterruptObject useObject;
    public Transform spawnPoint;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            PlayerHeals(healAmount);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Interrupt();
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
        if (hp-damage > 0)
        {
            hp -= damage;
        }
        else
        {
            DeathScreen();
        }
    }

    public void DeathScreen()
    {
        Debug.Log("DEAD");
        if (spawnPoint != null)
        {
            gameObject.transform.position = spawnPoint.position;
        }

        hp = maxHp;
    }

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

    public void Interrupt()
    {
        Debug.Log(useObject.name);
        Debug.Log(useObject.text);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Проверяем, что столкнулись НЕ с TriggerArea
        if (collision.gameObject.layer == 7)
            return; // Игнорируем попадание в TriggerArea

        if (collision.gameObject.TryGetComponent(out EnemyBullet bullet))
        {
            PlayerDamage(bullet.damage);
            Destroy(bullet.gameObject);
        }
    }

    public void MinusIQ(int down)
    {
        if (iq - down >= 0)
        {
            iq -= down;
        }
        else
        {
            iq = 0;
        }
    }

    public void PlusIQ(int up)
    {
        if (iq + up <= 100)
        {
            iq += up;
        }
        else
        {
            iq = 100;
        }
    }
}
