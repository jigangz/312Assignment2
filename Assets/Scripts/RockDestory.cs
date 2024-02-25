using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockDestroy : ToolHit
{
    public GameObject lampPrefab; 
    public bool isSpecial = false; 

    public override void Hit()
    {
        if (isSpecial)
        {
            
            Instantiate(lampPrefab, transform.position, Quaternion.identity);
        }
        
        Destroy(gameObject);
    }
}
