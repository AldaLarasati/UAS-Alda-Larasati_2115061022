using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Event_Toggle : MonoBehaviour
{
    [System.Serializable]
    class Attribute {
        public Transform pod;
        public Image layout;
    }
    [System.Serializable]
    class Properties {
        public Color enableColor = new Color(0, 0.6226415f, 0.258375f, 1), disableColor = new Color(0.6886792f, 0.235227f, 0.1916607f, 1);
    }
    [System.Serializable] 
    public class Events {
        public UnityEvent<bool> onChanged;
    }

    [SerializeField] Attribute attribute;
    [SerializeField] Properties properties;
    public bool value = true;
    public Events events;

    Color target => value ? properties.enableColor : properties.disableColor;
    Vector3 intialPos, enablePos, disablePos;
    Vector3 targetPos => value ? enablePos : disablePos;

    void Awake()
    {
        intialPos = attribute.pod.localPosition;
        enablePos = intialPos;
        disablePos = new Vector3(-intialPos.x, intialPos.y, intialPos.z);
    }

    public void Initialize(bool value)
    {
        this.value = value;
        if (attribute.layout.color != target) attribute.layout.color = Color.Lerp(attribute.layout.color, target, 1);
        if (attribute.pod.localPosition != targetPos) attribute.pod.localPosition = Vector3.Lerp(attribute.pod.localPosition, targetPos, 1);
    }

    void Update()
    {
        float deltatime = Time.unscaledDeltaTime * 10;
        if (attribute.layout.color != target) attribute.layout.color = Color.Lerp(attribute.layout.color, target, deltatime);
        if (attribute.pod.localPosition != targetPos) attribute.pod.localPosition = Vector3.Lerp(attribute.pod.localPosition, targetPos, deltatime);
    }

    public void SetValue(bool value)
    {
        this.value = value;
        events.onChanged.Invoke(value);
    }

    public void Toggle()
    {
        SetValue(!value);
    }
}
