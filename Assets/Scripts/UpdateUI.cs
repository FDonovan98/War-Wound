using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpdateUI : MonoBehaviour
{
    public TextMeshProUGUI Resupply;
    public TextMeshProUGUI NewWoundedCount;
    public TextMeshProUGUI TotalWoundedCount;
    public GameObject PatientOne;
    private TextMeshProUGUI[] PatientOneProperties;

    private enum PatientTextElements 
        {
            PatientName,
            PatientAge,
            PatientBio,
            PatientNationality,
            MinorWounds,
            MajorWounds,
            CriticalWounds
        };

    void Start() 
    {
        PatientOneProperties = PatientOne.GetComponentsInChildren<TextMeshProUGUI>();

    }

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

    private void DispNewPatients(AbstractWoundedClass[] wounded, List<int> NewWounded)
    {
        
        PatientOneProperties[(int)PatientTextElements.PatientName].text = wounded[NewWounded[0]].Name;
        PatientOneProperties[(int)PatientTextElements.PatientAge].text = wounded[NewWounded[0]].Age.ToString();
        PatientOneProperties[(int)PatientTextElements.PatientNationality].text = wounded[NewWounded[0]].Nationality;
        PatientOneProperties[(int)PatientTextElements.MinorWounds].text = wounded[NewWounded[0]].Count[0].ToString();
        PatientOneProperties[(int)PatientTextElements.MajorWounds].text = wounded[NewWounded[0]].Count[1].ToString();
        PatientOneProperties[(int)PatientTextElements.CriticalWounds].text = wounded[NewWounded[0]].Count[2].ToString();

    }

    public void UpdateAll(int DaysToResupply, List<int> NewWounded, List<int> TotalWounded, AbstractWoundedClass[] wounded)
    {
        DispDaysToResupply(DaysToResupply);
        DispNumberOfNewWounded(NewWounded.Count);
        DispNumberOfTotalWounded(TotalWounded.Count);
        DispNewPatients(wounded, NewWounded);
    }
}