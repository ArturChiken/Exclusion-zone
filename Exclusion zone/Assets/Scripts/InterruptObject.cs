using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InterruptObject : MonoBehaviour
{
    public new string name;
    public string text;

    private bool wasActivated;
    public int iqToDown;

    public UnityEngine.UI.Image image;
    public GameObject console;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI messageText;

    private void Start()
    {
        HideImage();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            player.useObject = this;
            wasActivated = true;
            UpdateUITexts();
            ShowImage();

            if (!wasActivated)
            {
                player.MinusIQ(iqToDown);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            player.useObject = null;
            HideImage();
        }
    }

    private void ShowImage()
    {
        if (image != null)
        {
            image.gameObject.SetActive(true);
        }
        else if (console != null)
        {
            console.SetActive(true);
        }
    }

    private void HideImage()
    {
        if (image != null)
        {
            image.gameObject.SetActive(false);
        }
        else if (console != null)
        {
            console.SetActive(false);
        }
    }

    private void UpdateUITexts()
    {
        if (nameText != null)
        {
            nameText.text = name;
        }

        if (messageText != null)
        {
            messageText.text = text;
        }
    }
}
