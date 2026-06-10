using UnityEngine;

public class TriggerArea : MonoBehaviour
{
    public bool isPlayerHere = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerHere = true;
            Debug.Log("Player entered! isPlayerHere = true");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerHere = false;
            Debug.Log("Player exited! isPlayerHere = false");
        }
    }
}