using System;
using UnityEngine;

public class MedKit : MonoBehaviour
{
    [SerializeField]
    private int heal;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            player.PlayerHeals(heal);
            Destroy(gameObject);
        }
    }
}
