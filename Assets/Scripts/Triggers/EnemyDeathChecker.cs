using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathChecker : MonoBehaviour
{
    public GameObject myObject;
    public GameObject myObject1;

    public float timeToSpawn;
    ToAnotherPlanetTrigger toAnotherPlanetTrigger;
    // Start is called before the first frame update
    void Start()
    {
        toAnotherPlanetTrigger = FindAnyObjectByType<ToAnotherPlanetTrigger>();
    }

    // Update is called once per frame
    void Update()
    {

        if (AllEnemiesDeadFirstLevel())
        {
            myObject.SetActive(false);
        }
        if (AllEnemiesDeadSpaceLevel())
        {
            myObject1.SetActive(false);
        }
        if (SpawnCosmicEnemies())
        {
            StartCoroutine(SpawnSpace());
        }
    }

    private bool AllEnemiesDeadFirstLevel()
    {

        if (toAnotherPlanetTrigger.isFlying == true)
        {
            return true;
        }
        return false;
    }
    private bool AllEnemiesDeadSpaceLevel()
    {

        if (toAnotherPlanetTrigger.isThirdLevel == true)
        {
            return true;
        }
        return false;
    }
    private bool SpawnCosmicEnemies()
    {

        if (toAnotherPlanetTrigger.isFlying == true)
        {
            return true;
        }
        return false;
    }
    IEnumerator SpawnSpace()
    {
        
        yield return new WaitForSeconds(timeToSpawn);
        myObject1.SetActive(true);
    }
}
