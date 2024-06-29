using System.Collections;
using UnityEngine;

public class GroupElement : MonoBehaviour
{
    [SerializeField] float delayPerElement = 0.2f;

    GameObject[] child;

    void Awake()
    {
        Init();
    }

    void Init()
    {
        child = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            child[i] = transform.GetChild(i).gameObject;
        }
    }

    void OnEnable()
    {
        foreach (var item in child)
        {
            item.SetActive(false);
        }
        SetActive(true);
    }

    public void SetActive(bool value) 
    {
        IEnumerator animation() 
        {
            foreach (var item in child)
            {
                item.SetActive(value);
                yield return new WaitForSeconds(delayPerElement);
            }
        }

        StartCoroutine(animation());
    }
}
