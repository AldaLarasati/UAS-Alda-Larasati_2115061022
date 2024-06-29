using UnityEngine;

public class ExternalLink : MonoBehaviour
{
    [SerializeField, TextArea(minLines:3, maxLines:5)] string link;

    public void Open() 
    {
        Application.OpenURL(link);
    }
}
