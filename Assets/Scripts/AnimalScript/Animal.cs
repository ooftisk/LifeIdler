using System.Collections.Generic;
using R3;
using R3.Triggers;
using UnityEngine;

public abstract class Animal : MonoBehaviour
{
    public enum AnimalType
        {
            Alfa,
            Normal,
			Baby
        }
    
    //Animal Stats
    public float Speed;
    public float SeekRange;
    public float HungerRate;
    
    public float Age;
    public float Hunger;
    public float Stamina;
    public float ReproductionRate;
    public float SleepRate;
    
    public Transform AlfaPosition;
    
    
    public void ReduceHunger()
    {
           Hunger -= HungerRate;
    }
}
