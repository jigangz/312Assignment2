using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockDestory : ToolHit
{
    // Start is called before the first frame update
  public override void Hit()
    {
        Destroy(gameObject);
    }
}
