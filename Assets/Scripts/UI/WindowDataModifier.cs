using UnityEngine;

public class WindowDataModifier : MonoBehaviour
{
    [SerializeField] private WindowData data;

    [SerializeField] private WindowView view;

    #region Volume

    public void IncreaseVolume()
    {
        data.volume += 10;

        if (data.volume > 100)
            data.volume = 100;

        view.RefreshUI();
    }

    public void DecreaseVolume()
    {
        data.volume -= 10;

        if (data.volume < 0)
            data.volume = 0;

        view.RefreshUI();
    }

    #endregion

    #region HP

    public void AddHP()
    {
        data.hp += 10;

        view.RefreshUI();
    }

    public void RemoveHP()
    {
        data.hp -= 10;

        if (data.hp < 0)
            data.hp = 0;

        view.RefreshUI();
    }

    #endregion

    public void ToggleFullscreen()
    {
        data.fullscreen = !data.fullscreen;

        Debug.Log("Fullscreen: " + data.fullscreen);

        view.RefreshUI();
    }
}