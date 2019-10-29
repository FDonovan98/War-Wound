using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateUI : MonoBehaviour
{
    public Text Resupply;
    public Text NewWoundedCount;
    public Text TotalWoundedCount;

    private void DispDaysToResupply(int DaysToResupply)
    {
        Resupply.text = "Days To Resupply: " + DaysToResupply.ToString();
    }

    private void DispNumberOfNewWounded(int NumNewWounded)
    {
        NewWoundedCount.text = "New wounded: " + NumNewWounded.ToString();
    }

    private void DispNumberOfTotalWounded(int NumTotalWounded)
    {
        TotalWoundedCount.text = "All wounded: " + NumTotalWounded.ToString();
    }

    private void UpdatePatientDisplay(AbstractWoundedClass wounded) {
        
    }

    public void UpdateAll(int DaysToResupply, List<int> NumNewWounded, List<int> NumTotalWounded)
    {
        DispDaysToResupply(DaysToResupply);
        DispNumberOfNewWounded(NumNewWounded.Count);
        DispNumberOfTotalWounded(NumTotalWounded.Count);
    }
}
