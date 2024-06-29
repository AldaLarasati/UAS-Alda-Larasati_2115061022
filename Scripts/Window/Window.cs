using UnityEngine;
using UnityEngine.Events;

public class Window : MonoBehaviour
{
    [System.Serializable] 
    public class Events {
        public UnityEvent onEnable, onDisable;
    }

    [SerializeField] Animator animator;
    public Events events;

    public static Window currentActive;

    public void Open() 
    {
        transform.SetAsLastSibling();
        gameObject.SetActive(true);
        if (animator) animator.SetBool("Open", true);
    }

    public void Close() 
    {
        if (animator) animator.SetBool("Open", false);
        currentActive = null;
    }

    public void Off() 
    {
        gameObject.SetActive(false);
    }

    void OnEnable()
    {
        events.onEnable.Invoke();
        currentActive = this;
    }

    void OnDisable()
    {
        if (animator) animator.SetBool("Open", true);
        events.onDisable.Invoke();
    }
}
