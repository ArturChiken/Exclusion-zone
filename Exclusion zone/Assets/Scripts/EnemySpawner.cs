using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyArray;

    public float firstCooldown;
    public float cooldown;

    private void Start()
    {
        InvokeRepeating("ZombieSpawn", firstCooldown, cooldown);
    }

    private void ZombieSpawn()
    {
        int random = Random.Range(0, enemyArray.Length);

        Instantiate(enemyArray[random], transform.position, Quaternion.identity);
        Debug.Log($"{random}");
    }
}
