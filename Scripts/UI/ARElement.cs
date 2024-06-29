using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ARElement : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI nameUI;
    [SerializeField] RawImage imageUI;

    [Header("Properties")]
    [SerializeField] new string name;
    [SerializeField] Texture2D image;

    void OnValidate()
    {
        if (nameUI) nameUI.text = name.Trim().ToUpper();
        if (imageUI) imageUI.texture = image;
    }

    public void StartAR()
    {
        ARManagement.activeAR = name.ToLower();
        SceneManagement.LoadScene("AR");
    }
}
