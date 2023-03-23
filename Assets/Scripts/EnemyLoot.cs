using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLoot : MonoBehaviour
{
    [SerializeField] [Range(0,100)] int chanceToDrop;
    [SerializeField] bool willDropXP;

    [SerializeField] int smallXPChance;
    [SerializeField] int mediumXPChance;
    [SerializeField] int HighXPChance;

    [SerializeField] GameObject[] XPPickupArray;

    private void OnEnable()
    {
        int result = Random.Range(0, 100);

        if (result <= chanceToDrop)
        {
            willDropXP = true;
        }
    }

    private int DecideWhichXPToDrop()
    {
        int result = Random.Range(0, 100);

        if (result <= smallXPChance) { return 0; }
        else if (result > smallXPChance && result < mediumXPChance) { return 1; }
        else if (result > mediumXPChance && result <= HighXPChance) { return 2; }
        else { return 0; }
    }

    public void DropXP()
    {
        if (willDropXP == true)
        {
            int chosenXPIndex = DecideWhichXPToDrop();
            Instantiate(XPPickupArray[chosenXPIndex], transform.position, Quaternion.identity);
        }
    }
}
