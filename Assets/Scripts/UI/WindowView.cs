using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WindowView : MonoBehaviour
{
    [Header("Data")]
    public WindowData data;

    [Header("UI")]
    [SerializeField] private TMP_Text titleText;
    [SerializeField] private TMP_Text descriptionText;

    [SerializeField] private TMP_Text volumeText;
    [SerializeField] private TMP_Text hpText;

    [SerializeField] private Image iconImage;

    private void OnEnable()
    {
        RefreshUI();
    }

    public void RefreshUI()
    {
        if (data == null)
            return;

        titleText.text = data.title;

        descriptionText.text = data.description;

        if (volumeText != null)
            volumeText.text = "Volume: " + data.volume;

        if (hpText != null)
            hpText.text = "HP: " + data.hp;

        if (iconImage != null)
            iconImage.sprite = data.icon;
    }
}