using System;
using System.Collections.Generic;
using R3;
using R3.Triggers;
using UnityEngine;
using Random = UnityEngine.Random;

public abstract class Animal : MonoBehaviour
{
    public enum EAnimalType
    {
        Alfa,
        Normal,
        Baby
    }
    public enum EAnimalSex
    {
        Male,
        Female
    }
    
    //Animal Config
    public AnimalConfig AnimalConfig;
    
    public float Speed;
    public int SeekRange;
    public float HungerRate;
    public int FoodPerBite;
    
    //Animal Stats
    public float Age;
    public float Hunger;
    
    
    
    public Transform AlfaPosition;
    
    public BaseFood TargetFood;
    public Queue<BaseFood> NearFood = new();
    public EAnimalType AnimalType;
    public EAnimalSex AnimalSex;
    
    
    [Header("Components")]
    [SerializeField] private SpriteRenderer SpriteRenderer;
    private void Start()
    {
        SetupAnimal();
    }
    public void ReduceHunger()
    {
           Hunger -= HungerRate;
    }

    private void SetupAnimal()
    {
        //Basic setup for mutation, still need to think about it
        Speed = AnimalConfig.Speed + AnimalConfig.SpeedMutation();
        SeekRange = AnimalConfig.SeekRange + AnimalConfig.SeekRangeMutation();
        HungerRate = AnimalConfig.HungerRate + AnimalConfig.HungerRateMutation();
        FoodPerBite = AnimalConfig.FoodPerBite + AnimalConfig.FoodPerBiteMutation();
        
        //If values less than min values set the min value + Round float values
        Speed = Mathf.Max(Speed, AnimalConfig.MinSpeed);
        Speed = (float)Math.Round(Speed, 2);
        SeekRange = Mathf.Max(SeekRange, AnimalConfig.MinSeekRange);
        HungerRate = Mathf.Max(HungerRate, AnimalConfig.MinHungerRate);
        HungerRate = (float)Math.Round(HungerRate, 2);
        FoodPerBite = Mathf.Max(FoodPerBite, AnimalConfig.MinFoodPerBite);

        if (AnimalType == EAnimalType.Baby)
        {
            SpriteRenderer.sprite = AnimalConfig.AnimalSprite.BabySprite[Random.Range(0, AnimalConfig.AnimalSprite.BabySprite.Length)];
        }
        else
        {
            if (AnimalSex == EAnimalSex.Male)
            {
                SpriteRenderer.sprite = AnimalConfig.AnimalSprite.MaleSprite[Random.Range(0, AnimalConfig.AnimalSprite.MaleSprite.Length)];
            }
            if (AnimalSex == EAnimalSex.Female)
            {
                SpriteRenderer.sprite = AnimalConfig.AnimalSprite.FemaleSprite[Random.Range(0, AnimalConfig.AnimalSprite.FemaleSprite.Length)];
            }
        }
    }
}
