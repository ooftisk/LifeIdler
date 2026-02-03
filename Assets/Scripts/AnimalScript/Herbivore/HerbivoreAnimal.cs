using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HerbivoreAnimal : Animal
{
    public BaseHerbivoreFood TargetFood;
    public List<BaseHerbivoreFood> NearFood;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<BaseHerbivoreFood>(out var food))
        {
            if (NearFood.Count >= 3)
            {
                NearFood.RemoveAt(0); 
            }
            NearFood.Add(food);
        }
    }
}
