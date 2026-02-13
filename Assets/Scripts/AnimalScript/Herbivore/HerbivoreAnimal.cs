using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HerbivoreAnimal : Animal
{
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<BaseFood>(out var food))
        {
            if (food.GetFoodType() == BaseFood.FoodType.Herbivore)
            {
                if (NearFood.Count >= 3)
                {
                    NearFood.Dequeue(); 
                }
                NearFood.Enqueue(food);
            }
        }
    }
}
