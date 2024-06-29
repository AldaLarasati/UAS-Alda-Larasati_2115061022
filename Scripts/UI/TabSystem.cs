using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TabSystem : MonoBehaviour
{
    [System.Serializable] 
    class Tab {
        public Button nav;
        public GameObject Content;
    }

    [SerializeField] Tab[] tabs;
    [SerializeField] int defaultPage = 0;

    [Header("Properties")]
    [SerializeField] Color activeTabColor;
    [SerializeField] Color normalTabColor;

    void Awake()
    {
        for (int i = 0; i < tabs.Length; i++)
        {
            var index = i;
            tabs[i].nav.onClick.AddListener(() => {ActiveTab(index);});
        }
    }

    void OnEnable()
    {
        ActiveTab(defaultPage);
    }

    public void ActiveTab(int index) 
    {
        int v = Mathf.Clamp(index, 0, tabs.Length-1);
        for (int i = 0; i < tabs.Length; i++)
        {
            var tab = tabs[i];
            tab.Content.SetActive(i == v);
            var text = tab.nav.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            text.color = i == v ? activeTabColor : normalTabColor;
            text.fontStyle = i == v ? FontStyles.Bold : FontStyles.Normal;
        }
    }
}
