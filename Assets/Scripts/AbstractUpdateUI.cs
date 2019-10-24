using UnityEngine;
using UnityEngine.UI;

public class AbstractUpdateUI : MonoBehaviour
{
    static Text text;

    void Start()
    {
        text = GetComponent<Text>();    
    }

    public static void UpdateDaysToResupply(int DaysTillResupply)
    {
        text.text = "Days To Resupply: " + DaysTillResupply.ToString();
    }
}
