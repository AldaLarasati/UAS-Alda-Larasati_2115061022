using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IconButton : MonoBehaviour
{
    [System.Serializable] 
    class Attribute {
        public Image layout;
        public Image icon;
    }
    [System.Serializable]
    class Properties {
        public Color backgroundColor = Color.green;
        public Sprite icon;
        public Color iconColor = Color.white;
        public float iconSize = 1;
        public Vector3 iconOffset;
        public bool flipIcon;
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
        var sprite = properties.icon;
        var icon = attribute.icon;

        if (layout)
        {
            layout.color = properties.backgroundColor;
        }

        var iconStatus = sprite && icon;
        if (iconStatus)
        {
            icon.sprite = sprite;
            icon.color = properties.iconColor;
            icon.transform.localScale = Vector2.one * properties.iconSize;
            icon.transform.localEulerAngles = Vector3.up * (properties.flipIcon ? 180 : 0);
            icon.transform.localPosition = new Vector3(properties.flipIcon ? -properties.iconOffset.x : properties.iconOffset.x, properties.iconOffset.y, properties.iconOffset.z);
        }
        attribute.icon.gameObject.SetActive(iconStatus);
    }
}
