using UnityEngine;



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
    }
}
