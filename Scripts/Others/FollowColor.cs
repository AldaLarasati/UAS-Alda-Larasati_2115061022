using UnityEngine;
using UnityEngine.UI;

public class FollowColor : MonoBehaviour
{
    [SerializeField] Image[] self;
    [SerializeField] Image target;

    void OnValidate()
    {
        Initialize();
    }

    void Initialize() 
    {
        if (self.Length > 0 && target) 
        {
            foreach (var item in self)
            {
                item.color = new Color(target.color.r, target.color.g, target.color.b, 1);
            }
        }
    }
}
