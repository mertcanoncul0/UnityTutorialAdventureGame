using UnityEngine;
using UnityEngine.UIElements;

public class UIHandler : MonoBehaviour
{
    private VisualElement _healthBar;
    public static UIHandler instance { get; private set; }

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        UIDocument uiDocument = GetComponent<UIDocument>();
        _healthBar = uiDocument.rootVisualElement.Q<VisualElement>("HealthBar");
        SetHealthValue(1f);
    }


    public void SetHealthValue(float percentage)
    {
        _healthBar.style.width = Length.Percent(100 * percentage);
    }
}
