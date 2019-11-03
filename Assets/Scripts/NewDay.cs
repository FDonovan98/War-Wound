using UnityEngine;
using System.Collections.Generic;

public class NewDay : AbstractReadWoundedData
{
    private List<int> newArrivals;
    private List<int> leavingPatients;
    public List<int> currentPatients = new List<int>();
    private int maxNumberOfPatients = 6;

    private static int maxBeds = 10;
    private int availableBeds = maxBeds;

    private AbstractWoundedClass[] wounded;

    private int numberOfDeaths = 0;
    private int weightedDeathScore = 10;
    private int allowedNumberOfDeaths = 20;

    private AbstractSupplies currentSupplies;
    private AbstractSupplies resupply;
    private static int resupplyDelay = 7;
    private int daysUntilResupply = resupplyDelay;

    UpdateUI updateUI;

    private void AddNewPatientsToList()
    {
        wounded = AbstractGenerateNewPatients.GenerateNewPatients(weightedDeathScore, maxNumberOfPatients, ref wounded, out newArrivals);
        currentPatients.AddRange(newArrivals);
    }

    private void RemoveOldPatientsFromList()
    {
        for(int i = 0; i < currentPatients.Count; i++)
        {
            if(!wounded[currentPatients[i]].hasBed || wounded[currentPatients[i]].dead)
            {
                currentPatients.RemoveAt(i);        
            }
        }
    }

    private void RemoveDeadWounded()
    {
        for(int i = 0; i < wounded.Length; i++)
        {
            if (wounded[i].dead)
            {
                wounded = (AbstractWoundedClass[])AbstractRemoveItemFromArray.RemoveItem(wounded, i);
                numberOfDeaths++;
                //Score is increased more when a higher rank dies. Used for scaling difficulty
                weightedDeathScore += wounded.Rank;
            }
        }
    }

    private bool CheckFailureConditions(int allowedNumberOfDeaths)
    {
        if(numberOfDeaths > allowedNumberOfDeaths)
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
        resupply = new AbstractSupplies(1, 1, 1);
        currentSupplies = new AbstractSupplies(5, 5, 5);

        GameObject Canvas = GameObject.Find("Canvas");
        updateUI = Canvas.GetComponent<UpdateUI>();

        Debug.Log(wounded[0].count[0] + " " + wounded[0].count[1] + " " + wounded[0].count[2]);
    }

    public void OnButtonPress()
    {
        RemoveOldPatientsFromList();
        AddNewPatientsToList();
        RemoveDeadWounded();
        if (CheckFailureConditions(allowedNumberOfDeaths))
        {
            //Function EndGame should send user to fail screens
            //EndGame();
        } else
        {
            if(daysUntilResupply == 0)
            {
                currentSupplies = AbstractResupply.DoResupply(currentSupplies, resupply);
                daysUntilResupply = resupplyDelay;
            }  else
            {
                daysUntilResupply--;
            }         
        }
       
        updateUI.UpdateAll(daysUntilResupply, newArrivals, currentPatients, wounded);

        //Debug code to print all the current patients wounds
        //for(int i = 0; i < currentPatients.count; i++)
        //{
        //    Debug.Log(wounded[currentPatients[i]].count[0] + " " + wounded[currentPatients[i]].count[1] + " " + wounded[currentPatients[i]].count[2]);
        //}
      
    }
}