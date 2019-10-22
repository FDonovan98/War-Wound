public class NewDay : AbstractReadWoundedData
{
    private int[] NewArrivals = { };
    private int[] LeavingPatients = { };
    private int[] CurrentPatients = { };

    private AbstractWoundedClass[] wounded;

    private int NumberOfDeaths = 0;
    private int WeightedDeathScore = 0;

    private AbstractSupplies CurrentSupplies;
    private AbstractSupplies Resupply;

    //private void AddNewPatientsToList(int[] NewPatients)
    //{
    //    NewArrivals = GenerateNewPatients(WeightedDeathScore);
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
                //Score is increased more when a higher rank dies. Used for scaling difficulty
                WeightedDeathScore += wounded.Rank;
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
        if (CheckFailureConditions())
        {
            //Function EndGame should send user to fail screens
            //EndGame();
        } else
        {
            CurrentSupplies = AbstractResupply.DoResupply(CurrentSupplies, Resupply);
        }
    }
}


