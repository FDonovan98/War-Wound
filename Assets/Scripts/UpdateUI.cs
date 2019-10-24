using UnityEngine;
using UnityEngine.UI;

public class UpdateUI : MonoBehaviour
{
    public Text text;

    public void UpdateDaysToResupply(int DaysTillResupply)
    {
        text.text = "Days To Resupply: " + DaysTillResupply.ToString();
    }
}
