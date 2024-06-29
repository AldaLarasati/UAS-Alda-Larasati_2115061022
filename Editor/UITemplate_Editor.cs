using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class UITemplate_Editor : Editor
{
    const int priority = 100;
    static string rootPath = "Prefabs";

    static void InstantiateItem(string path)
    {
        var selection = Selection.activeTransform;
        var data = Resources.Load<GameObject>(path);
        var item = PrefabUtility.InstantiatePrefab(data) as GameObject;
        if (selection) 
        {
            item.transform.SetParent(selection);
            if (item.TryGetComponent(out RectTransform rect))
            {
                var original = data.GetComponent<RectTransform>();
                rect.localPosition = original.localPosition;
                rect.localEulerAngles = original.localEulerAngles;
                rect.sizeDelta = original.sizeDelta;
            }
            else
            {
                item.transform.localPosition = data.transform.localPosition;
                item.transform.localEulerAngles = data.transform.localEulerAngles;
                item.transform.localScale = data.transform.localScale;
            }
        }
        Undo.RegisterCreatedObjectUndo(item, "Create " + item.name);
        Selection.activeObject = item;
    }

    static void CheckEventSystem() 
    {
        var eventSystem = Resources.FindObjectsOfTypeAll<EventSystem>();
        if (eventSystem.Length == 0)
        {
            var item = new GameObject("EventSystem");
            item.AddComponent<EventSystem>();
            item.AddComponent<StandaloneInputModule>();
        }
    }

    [MenuItem("GameObject/KenTank/UI Template/Canvas/Horizontal Canvas", false, priority)]
    static void CreateHorizontalCanvas()
    {
        InstantiateItem($"{rootPath}/Canvas/Horizontal Canvas");
        CheckEventSystem();
    }
    [MenuItem("GameObject/KenTank/UI Template/Canvas/Vertical Canvas", false, priority)]
    static void CreateVerticalCanvas()
    {
        InstantiateItem($"{rootPath}/Canvas/Vertical Canvas");
        CheckEventSystem();
    }

    [MenuItem("GameObject/KenTank/UI Template/Button/Text Button", false, priority)]
    static void CreateTextButton()
    {
        InstantiateItem($"{rootPath}/Buttons/Text Button");
    }
    [MenuItem("GameObject/KenTank/UI Template/Button/Icon Button", false, priority)]
    static void CreateIconButton()
    {
        InstantiateItem($"{rootPath}/Buttons/Icon Button");
    }

    [MenuItem("GameObject/KenTank/UI Template/Windows/Window", false, priority)]
    static void CreateWindow()
    {
        InstantiateItem($"{rootPath}/Windows/Window");
    }
    [MenuItem("GameObject/KenTank/UI Template/Windows/Notification Window", false, priority)]
    static void CreateNotifWin()
    {
        InstantiateItem($"{rootPath}/Windows/Notification Window");
    }
    [MenuItem("GameObject/KenTank/UI Template/Windows/Confirmation Window", false, priority)]
    static void CreateConfWin()
    {
        InstantiateItem($"{rootPath}/Windows/Confirmation Window");
    }

    [MenuItem("GameObject/KenTank/UI Template/Options/Group Item", false, priority)]
    static void CreateGroupToggle()
    {
        InstantiateItem($"{rootPath}/Options/Group");
    }
    [MenuItem("GameObject/KenTank/UI Template/Options/Toggle", false, priority)]
    static void CreateTogle()
    {
        InstantiateItem($"{rootPath}/Options/Toggle");
    }
    [MenuItem("GameObject/KenTank/UI Template/Options/Dropdown", false, priority)]
    static void CreateDropdown()
    {
        InstantiateItem($"{rootPath}/Options/Dropdown");
    }
    [MenuItem("GameObject/KenTank/UI Template/Options/Input", false, priority)]
    static void CreateInput()
    {
        InstantiateItem($"{rootPath}/Options/Input");
    }
    [MenuItem("GameObject/KenTank/UI Template/Options/Slider", false, priority)]
    static void CreateSlider()
    {
        InstantiateItem($"{rootPath}/Options/Slider");
    }
}
