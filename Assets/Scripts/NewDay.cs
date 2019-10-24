using UnityEngine;
using System.Collections.Generic;

public class NewDay : AbstractReadWoundedData
{
    private List<int> NewArrivals;
    private List<int> LeavingPatients;
    public List<int> CurrentPatients = new List<int>();
    private int MaxNumberOfPatients = 6;

    private AbstractWoundedClass[] wounded;

    private int NumberOfDeaths = 0;
    private int WeightedDeathScore = 10;
    private int AllowedNumberOfDeaths = 20;

    private AbstractSupplies CurrentSupplies;
    private AbstractSupplies Resupply;
    private static int ResupplyDelay = 7;
    private int DaysUntilResupply = ResupplyDelay;

    private void AddNewPatientsToList()
    {
        wounded = AbstractGenerateNewPatients.GenerateNewPatients(WeightedDeathScore, MaxNumberOfPatients, ref wounded, out NewArrivals);
        CurrentPatients.AddRange(NewArrivals);
    }

    private void RemoveOldPatientsFromList()
    {
        for(int i = 0; i < CurrentPatients.Count; i++)
        {
            if(!wounded[CurrentPatients[i]].HasBed || wounded[CurrentPatients[i]].Dead)
            {
                CurrentPatients.RemoveAt(i);        
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
                //Score is increased more when a higher rank dies. Used for scaling difficulty
                WeightedDeathScore += wounded.Rank;
            }
        }
    }

    private bool CheckFailureConditions(int AllowedNumberOfDeaths)
    {
        if(NumberOfDeaths > AllowedNumberOfDeaths)
        {
            return true;
        } else
        {
            return false;
        }
    }

    void Start()
    {
        wounded = ReadInWounded();
        Resupply = new AbstractSupplies(1, 1, 1);
        CurrentSupplies = new AbstractSupplies(5, 5, 5);

        Debug.Log(wounded[0].Count[0] + " " + wounded[0].Count[1] + " " + wounded[0].Count[2]);
    }

    public void OnButtonPress()
    {
        RemoveOldPatientsFromList();
        AddNewPatientsToList();
        RemoveDeadWounded();
        if (CheckFailureConditions(AllowedNumberOfDeaths))
        {
            //Function EndGame should send user to fail screens
            //EndGame();
        } else
        {
            if(DaysUntilResupply == 0)
            {
                CurrentSupplies = AbstractResupply.DoResupply(CurrentSupplies, Resupply);
                DaysUntilResupply = ResupplyDelay;
            }  else
            {
                DaysUntilResupply--;
            }         
        }

        GameObject Canvas = GameObject.Find("Canvas");
        UpdateUI UpdateUI = Canvas.GetComponent<UpdateUI>();
        UpdateUI.UpdateDaysToResupply(DaysUntilResupply);

        //Debug.Log(CurrentSupplies.Count[0] + " " + DaysUntilResupply);
        for(int i = 0; i < CurrentPatients.Count; i++)
        {
            Debug.Log(wounded[CurrentPatients[i]].Count[0] + " " + wounded[CurrentPatients[i]].Count[1] + " " + wounded[CurrentPatients[i]].Count[2]);
        }
      
    }
}


