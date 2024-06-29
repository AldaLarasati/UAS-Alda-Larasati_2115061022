using UnityEngine;

public class ARManagement : MonoBehaviour
{
    public static string activeAR = "";

    [System.Serializable] 
    class AR {
        public string id;
        public GameObject target;
    }

    [SerializeField] AR[] ar;

    void Awake()
    {
        foreach (var item in ar)
        {
            //if (item.target) item.target.SetActive(item.id.ToLower() == activeAR.ToLower());
        }
    }
}
