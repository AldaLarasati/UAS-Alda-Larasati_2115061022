using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Event_Button : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
{
    [System.Serializable] 
    public class Events {
        public UnityEvent onDown, onUp, onClick, onHold;
    }
    [System.Serializable] 
    class AudioProperties {
        public AudioSource source;
        public AudioClip down, up;
    }

    [SerializeField] Animator animator;
    [SerializeField] AudioProperties audioProperties;
    public Events events;

    PointerEventData pointer = null;

    public void OnPointerDown(PointerEventData data)
    {
        events.onDown.Invoke();
        pointer = data;
        if (animator) animator.SetBool("Down", true);
    }

    public void OnPointerUp(PointerEventData data)
    {
        events.onUp.Invoke();
        pointer = null;
        if (animator) animator.SetBool("Down", false);
    }

    public void OnPointerClick(PointerEventData data)
    {
        events.onClick.Invoke();
    }

    void OnDisable()
    {
        pointer = null;
        if (animator) 
        {
            animator.SetBool("Down", false);
        }
    }

    void Update()
    {
        if (pointer != null)
        {
            events.onHold.Invoke();
        }
    }

    void PlaySound(AudioClip clip) 
    {
        AudioSource source = audioProperties.source;
        
        #if KENTANK_GAMEMANAGER
        if (GameManager.instance.bGMManager.ui) source = GameManager.instance.bGMManager.ui;
        #endif

        if (source && clip)
        {
            source.PlayOneShot(clip);
        }
    }

    void AnimatorPlayDown()
    {
        PlaySound(audioProperties.down);
    }

    void AnimatorPlayUp()
    {
        PlaySound(audioProperties.up);
    }
}
