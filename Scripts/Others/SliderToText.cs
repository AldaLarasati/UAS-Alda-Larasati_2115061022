using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SliderToText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] Slider slider;

    void Awake()
    {
        if (!slider) return;

        slider.onValueChanged.AddListener(Change);
        Change(slider.value);
    }

    public void Change(float value) 
    {
        if (!text) return;
        var val = Mathf.Lerp(0, 100, value);
        text.text = val.ToString("f0");
    }

    void OnDestroy()
    {
        if (!slider) return;

        slider.onValueChanged.RemoveListener(Change);
    }
}
