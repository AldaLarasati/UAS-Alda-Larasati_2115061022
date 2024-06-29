using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Event_Confirmation : MonoBehaviour
{
    [System.Serializable] 
    public class Events {
        public UnityEvent onTrue, onFalse;
    }
    [System.Serializable] 
    class Attribute {
        public TextMeshProUGUI description;
    }
    [System.Serializable] 
    class Properties {
        [TextArea(5, 10)] public string description;
    }

    [SerializeField] Attribute attribute;
    [SerializeField] Properties properties;
    public Events events;

    bool value;

    void OnValidate()
    {
        Initialize();
    }

    void Initialize() 
    {
        if (attribute.description)
        {
            attribute.description.text = properties.description.Trim();
        }
    }

    public void SetDescription(string value)
    {
        properties.description = value;
        Initialize();
    }

    public void True() 
    {
        //events.onTrue.Invoke();
        value = true;
    }

    public void False() 
    {
        //events.onFalse.Invoke();
        value = false;
    }

    public void Off() 
    {
        if (value) events.onTrue.Invoke();
        else events.onFalse.Invoke();
    }
}
