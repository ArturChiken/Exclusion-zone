using UnityEngine;

public class ZombieAttack : MonoBehaviour
{
    public Enemy enemy;

    private bool canAttack = true;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player) && canAttack)
        {
            player.PlayerDamage(enemy.damage);
            canAttack = false;
            Invoke("CooldownReset", enemy.cooldown);
        }
    }

    private void CooldownReset()
    {
        canAttack = true;
    }
}
