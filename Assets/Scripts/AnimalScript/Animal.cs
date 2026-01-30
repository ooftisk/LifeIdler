using System.Collections.Generic;
using R3;
using R3.Triggers;
using UnityEngine;

public abstract class Animal : MonoBehaviour
{
    //Animal Stats
    public float Speed;
    public float AlertRange; //Maybe need to rename(Range of seeing other animal)
    public float HungerRate;
    public float Health;
    
    public float Age;
    public float Hunger;
    public float Stamina;
    public float ReproductionRate;
    public float SleepRate;

    public bool IsAlfa;
    public Transform AlfaPosition;
}
