using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathChecker : MonoBehaviour
{
    public GameObject myObject;
    public GameObject[] enemies;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (AllEnemiesDead())
        {
            SpriteRenderer spriteRenderer = myObject.GetComponent<SpriteRenderer>();
            spriteRenderer.enabled = true;
        }
    }

    private bool AllEnemiesDead()
    {
        foreach (GameObject enemy in enemies)
        {
            if (enemy.gameObject.activeSelf)
            {
                return false;
            }
        }
        return true;
    }
}
