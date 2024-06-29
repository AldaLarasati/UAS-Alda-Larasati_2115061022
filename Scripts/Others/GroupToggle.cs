using UnityEngine;
using UnityEngine.UI;

public class GroupToggle : MonoBehaviour
{
    [SerializeField] RectTransform viewport;
    [SerializeField] bool show = true;
    [SerializeField] float duration = 0.2f;
    
    Vector2 initSize;
    float time;

    bool once = true;
    void Start()
    {
        if (once)
        {
            LayoutRebuilder.ForceRebuildLayoutImmediate(viewport);
            LayoutRebuilder.ForceRebuildLayoutImmediate(transform.parent.GetComponent<RectTransform>());
            initSize = viewport.sizeDelta;
            Destroy(viewport.GetComponent<ContentSizeFitter>());
            once = false;
        }

        viewport.sizeDelta = show ? initSize : new Vector2(initSize.x, 0);
    }

    public void Show(bool value) 
    {
        show = value;
        time = 0;
    }

    public void Toggle() 
    {
        Show(!show);
    }

    void Update()
    {
        if (time <= 1) 
        {
            time += Time.unscaledDeltaTime / duration;
            viewport.sizeDelta = Vector2.Lerp(viewport.sizeDelta, show ? initSize : new Vector2(initSize.x, 0), time);
        }
    }
}
