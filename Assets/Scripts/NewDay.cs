using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NewDay : AbstractReadWoundedData
{
    private int[] NewArrivals = { };
    private int[] LeavingPatients = { };
    private AbstractWoundedClass[] wounded;

    private int NumberOfDeaths = 0;

    public int[] CurrentPatients = { };

    //private void AddNewPatientsToList(int[] NewPatients)
    //{
    //    NewArrivals = GenerateNewPatients();
    //}

    private void RemoveOldPatientsFromList()
    {
        for(int i = 0; i < CurrentPatients.Length; i++)
        {
            if(!wounded[CurrentPatients[i]].HasBed || wounded[CurrentPatients[i]].Dead)
            {
                CurrentPatients = AbstractRemoveItemFromArray.RemoveItem(CurrentPatients, i);        
            }
        }
    }

    private void RemoveDeadWounded()
    {
        for(int i = 0; i < wounded.Length; i++)
        {
            if (wounded[i].Dead)
            {
                wounded = (AbstractWoundedClass[])AbstractRemoveItemFromArray.RemoveItem(wounded, i);
                NumberOfDeaths++;
            }
        }
    }

    private bool CheckFailureConditions()
    {
        if(NumberOfDeaths > 20)
        {
            return true;
        } else
        {
            return false;
        }
    }

    private void Start()
    {
        wounded = ReadInWounded();
    }
    void OnMouseDown()
    {
        RemoveOldPatientsFromList();
        //AddNewPatientsToList();
        RemoveDeadWounded();
        if(CheckFailureConditions())
        {
            //EndGame;
        }
        
    }
}


