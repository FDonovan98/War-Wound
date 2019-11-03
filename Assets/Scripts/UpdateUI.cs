using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpdateUI : MonoBehaviour
{
    public TextMeshProUGUI resupply;
    public TextMeshProUGUI newWoundedCount;
    public TextMeshProUGUI totalWoundedCount;
    public GameObject patientInfoContainer;
    private List<GameObject> patientDisplays;
    private List<TextMeshProUGUI[]> patientProperties;
    
    public int patientDisplaySize; 
    public int patientPropertiesSize; 

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
        Transform[] children = patientInfoContainer.GetComponents<Transform>();
        patientProperties = new List<TextMeshProUGUI[]>();
        patientDisplays = new List<GameObject>();

        foreach(Transform patientBox in children)
        {
            patientDisplays.Add(patientBox.gameObject);
        }
        for (int i = 0; i < patientDisplays.Count; i++)
        {
            patientProperties.Add(patientDisplays[i].GetComponentsInChildren<TextMeshProUGUI>());
        }

        patientDisplaySize = patientDisplays.Count;
        patientPropertiesSize = patientProperties.Count;
    }

    private void DispDaysToResupply(int daysToResupply)
    {
        resupply.text = "Days To resupply: " + daysToResupply.ToString();
    }

    private void DispNumberOfNewWounded(int numNewWounded)
    {
        newWoundedCount.text = "New wounded: " + numNewWounded.ToString();
    }

    private void DispNumberOfTotalWounded(int numTotalWounded)
    {
        totalWoundedCount.text = "All wounded: " + numTotalWounded.ToString();
    }

    private void DispNewPatients(AbstractWoundedClass[] wounded, List<int> newWounded)
    {
        for (int i = 0; i < newWounded.Count; i++)
        {
            TextMeshProUGUI[] CurrentBox = patientProperties[i];
            CurrentBox[(int)PatientTextElements.PatientName].text = wounded[newWounded[i]].name;
            CurrentBox[(int)PatientTextElements.PatientAge].text = wounded[newWounded[i]].age.ToString();
            CurrentBox[(int)PatientTextElements.PatientNationality].text = wounded[newWounded[i]].nationality;
            CurrentBox[(int)PatientTextElements.MinorWounds].text = wounded[newWounded[i]].count[0].ToString();
            CurrentBox[(int)PatientTextElements.MajorWounds].text = wounded[newWounded[i]].count[1].ToString();
            CurrentBox[(int)PatientTextElements.CriticalWounds].text = wounded[newWounded[i]].count[2].ToString();
        }
        

    }

    public void UpdateAll(int daysToResupply, List<int> newWounded, List<int> totalWounded, AbstractWoundedClass[] wounded)
    {
        DispDaysToResupply(daysToResupply);
        DispNumberOfNewWounded(newWounded.Count);
        DispNumberOfTotalWounded(totalWounded.Count);
        DispNewPatients(wounded, newWounded);
    }
}