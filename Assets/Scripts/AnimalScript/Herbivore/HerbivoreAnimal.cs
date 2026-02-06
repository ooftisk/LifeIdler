using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HerbivoreAnimal : Animal
{
    public BaseFood TargetFood;
    public List<BaseFood> NearFood;
    public AnimalType AnimalType;
   
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<BaseFood>(out var food))
        {
            if (food.GetFoodType() == BaseFood.FoodType.Herbivore)
            {
                if (NearFood.Count >= 3)
                {
                    NearFood.RemoveAt(0); 
                }
                NearFood.Add(food);
            }
        }
    }
}
