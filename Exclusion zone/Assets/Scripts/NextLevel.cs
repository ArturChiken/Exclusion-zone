using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public int scene;
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("1");
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            Debug.Log("2");
            if (scene == 0)
            {
                SceneManager.LoadScene("City");
            }
            else if (scene == 1)
            {
                SceneManager.LoadScene("Cab");
            }
            else if (scene == 2)
            {
                SceneManager.LoadScene("Doors");
            }
        }
    }
}