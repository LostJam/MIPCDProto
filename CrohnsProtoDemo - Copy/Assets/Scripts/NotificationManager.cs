using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotificationManager : MonoBehaviour
{
    // Dictionary that should only contain the requested features after start

    public static void RegisterNotif(GameObject gameObject)
    {
        activeFeaturesObjs.Add(gameObject);
        Debug.Log("added to notifs " + gameObject.name);
    }

    [SerializeField]
    public bool above;
    public bool below;
    public bool free;
    public bool arrow;
    public bool error;

    public static Dictionary<string, bool> checkedFeatures = new Dictionary<string, bool>();
    public static List<GameObject> activeFeaturesObjs = new List<GameObject>();

    void Awake()
    {
        Application.targetFrameRate = -1;
        // checkedFeatures.InsertRange(checkedFeatures.Count, new Dictionary {  above, below, free, arrow, error});
        checkedFeatures.Add ("above", above);
        checkedFeatures.Add("below", below);
        checkedFeatures.Add("free", free);
        checkedFeatures.Add("arrow", arrow);
        checkedFeatures.Add("error", error);

        foreach (var item in checkedFeatures)
        {
            Debug.Log(item.Key + " " + item.Value.ToString());
        }

    }

}
