using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NewDay : MonoBehaviour
{
    private int[] NewArrivals = { };
    private int[] LeavingPatients = { };

    public int[] CurrentPatients = { };

    //private void AddNewPatientsToList(int[] NewPatients)
    //{
    //    NewArrivals = GenerateNewPatients();
    //}

    private void RemoveOldPatientsFromList(AbstractWoundedClass[] wounded)
    {
        for(int i = 0; i < CurrentPatients.Length; i++)
        {
            if(!wounded[CurrentPatients[i]].HasBed || wounded[CurrentPatients[i]].Dead)
            {
                if(i != CurrentPatients.Length - 1)
                {
                    for(int j = 0; j < CurrentPatients.Length - 1; j++)
                    {
                        CurrentPatients[i] = CurrentPatients[i + 1];      
                    }     
                } else
                {
                    Array.Resize(ref CurrentPatients, CurrentPatients.Length - 1);
                }
                
            }
        }
    }

    private void Start()
    {
        
    }
    void OnMouseDown()
    {
        //RemoveOldPatientsFromList(wounded);
        //AddNewPatientsToList();
    }
}


