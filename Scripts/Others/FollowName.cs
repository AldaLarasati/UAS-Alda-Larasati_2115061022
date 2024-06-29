using TMPro;
using UnityEngine;

public class FollowName : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI[] self = new TextMeshProUGUI[0];
    [SerializeField] GameObject target;

    void Initialize() 
    {
        if (self.Length > 0 && target) 
        {
            foreach (var item in self)
            {
                item.text = target.name.Trim();
            }
        }
    }

    void OnValidate()
    {
        Initialize();
    }
}
