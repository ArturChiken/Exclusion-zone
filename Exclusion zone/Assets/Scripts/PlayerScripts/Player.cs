using UnityEngine;

public class Player : MonoBehaviour
{
    public int hp;
    public float speed;
    public int iq;

    private void Update()
    {
        PlayerMove();
        PlayerDamage(3);
        Debug.Log($"{hp}");
    }

    void PlayerMove()
    {
        float h = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float v = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        transform.Translate(h, v, 0);
    }

    public void PlayerDamage(int damage)
    {
        if (hp > damage)
        {
            hp -= damage;
        }
        else
        {
            Debug.Log("Умер");
        }
    }
}
