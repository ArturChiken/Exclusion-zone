using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    public Player player;

    public Slider slider;
    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(float health)
    {
        slider.value = health;
    }

    private void Update()
    {
        SetHealth(player.hp);
    }
}
