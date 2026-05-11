using UnityEngine;

[CreateAssetMenu(fileName = "WindowData", menuName = "UI/Window Data")]
public class WindowData : ScriptableObject
{
    [Header("General")]
    public string title;

    [TextArea]
    public string description;

    public Sprite icon;

    [Header("Config")]
    [Range(0, 100)]
    public int volume = 50;

    public bool fullscreen = true;

    [Header("Stats")]
    public int hp = 100;

    public int mana = 50;
}