using UnityEngine;

public class InterruptObject : MonoBehaviour
{
    public string name;
    public string text;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            player.useObject = this;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            player.useObject = null;
        }
    }
}
