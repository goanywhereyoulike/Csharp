using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagable 
{
    int hp { get; set; }
    int TakeHit(int dam);
}
