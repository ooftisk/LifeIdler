using System;
using UnityEngine;
using R3;


public class BaseFood : MonoBehaviour
{
    public enum FoodType
    {
        Herbivore,
        Carnivore
    }
    
    [SerializeField]private float FoodAmount;
    [SerializeField]private ParticleSystem EatEffect;
    [SerializeField]private FoodType foodType;
    [SerializeField] private float MaxFood;
    [SerializeField] private float TimeToRegenFood;
    [SerializeField] private float FoodRegen;

    private void Start()
    {
        Observable.Interval(TimeSpan.FromSeconds(TimeToRegenFood))
            .Where(_ => FoodAmount < MaxFood)
            .Subscribe(_ =>
            {
                FoodAmount += FoodRegen;

                if (FoodAmount >= MaxFood)
                {
                    FoodAmount = MaxFood;
                }
                
                //пися в попе
            }).AddTo(this);
    }
    public void PlayEatEffect()
    {
        EatEffect.Play();
    }

    public FoodType GetFoodType()
    {
        return foodType;
    }
    public float GetFoodAmount()
    {
        return FoodAmount;
    }
    public void DecreaseFoodAmount(float amount)
    {
        FoodAmount -= amount;
        if (FoodAmount < 0)
        {
            FoodAmount = 0;
        }
    }
}
