using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextButton : MonoBehaviour
{
    [System.Serializable] 
    class Attribute {
        public Image layout;
        public TextMeshProUGUI[] text;
        public Image icon;
        public GameObject withoutIcon, withIcon;
    }
    [System.Serializable]
    class Properties {
        public Color backgroundColor = Color.green;
        public Color textColor = Color.white;
        public Sprite icon;
        public Color iconColor = Color.white;
        public bool followTextName = true;
    }

    [SerializeField] Attribute attribute;
    [SerializeField] Properties properties;

    void OnValidate()
    {
        Initialize();
    }

    void Initialize() 
    {
        var layout = attribute.layout;
        var text = attribute.text;
        var sprite = properties.icon;
        var icon = attribute.icon;

        if (layout)
        {
            layout.color = properties.backgroundColor;
        }
        if (text.Length > 0)
        {
            foreach (var item in text)
            {
                item.color = properties.textColor;
                if (properties.followTextName) item.text = gameObject.name;
            }
        }
        var iconStatus = sprite && icon;
        if (iconStatus)
        {
            icon.sprite = sprite;
            icon.color = properties.iconColor;
        }
        attribute.withoutIcon.SetActive(!iconStatus);
        attribute.withIcon.SetActive(iconStatus);
    }
}
