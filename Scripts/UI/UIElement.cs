using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class UIElement : MonoBehaviour
{
    [SerializeField] float fadeDuration = 0.5f;

    CanvasGroup canvasGroup;

    float _time;
    bool _active;
    Vector3 _initialPos;
    Vector3 _offsetPos;
    AnimationCurve curve = AnimationCurve.EaseInOut(0, 0, 1, 1);

    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        _initialPos = transform.localPosition;
        _offsetPos = _initialPos + Vector3.up * -80;
    }

    void OnEnable()
    {
        canvasGroup.alpha = 0;
        SetActive(true);
    }

    void Update()
    {
        if (_time > 0)
        {
            _time -= Time.deltaTime;
            float t = curve.Evaluate(Mathf.InverseLerp(fadeDuration, 0, _time));
            canvasGroup.alpha = Mathf.Lerp(_active ? 0 : 1, _active ? 1 : 0, t);
            transform.localPosition = Vector3.Lerp(_active ? _offsetPos : _initialPos, _active ? _initialPos : _offsetPos, t);
            if (_time <= 0 && !_active) gameObject.SetActive(false);
        }
    }

    public void SetActive(bool value) 
    {
        _time = fadeDuration;
        _active = value;
        if (value) gameObject.SetActive(true);
    }
}
