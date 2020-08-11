using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICombat 
{
    int hp { get; set; }
    int damage { get; set; }


    int CauseDamage(ICombat opponent);


}
