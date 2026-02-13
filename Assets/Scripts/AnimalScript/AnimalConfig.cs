using UnityEngine;

[CreateAssetMenu(fileName = "AnimalConfig", menuName = "Configs/Animal Config")]
public class AnimalConfig : ScriptableObject
{
   [System.Serializable]
   public struct SMutationValue
   {
      [Header("Movement")] 
      public float MutationSpeedMin;
      public float MutationSpeedMax;
      [Header("SeekRange")]
      public int MutationSeekRangeMin;
      public int MutationSeekRangeMax;
      [Header("HungerRate")] 
      public float MutationHungerRateMin;
      public float MutationHungerRateMax;
      [Header("FoodPerBite")]
      public int MutationFoodPerBiteMin;
      public int MutationFoodPerBiteMax;
   }

   [System.Serializable]
   public struct SAnimalSprite
   {
      public Sprite[] MaleSprite;
      public Sprite[] FemaleSprite;
      public Sprite[] BabySprite;
   }
   
   
   [Header("Basic Stats")]
   public int Speed;
   public int SeekRange;
   public int HungerRate;
   public int FoodPerBite;

   [Header("Minimal Values")] 
   public float MinSpeed;
   public int MinSeekRange;
   public float MinHungerRate;
   public int MinFoodPerBite;
   
   
   
   public SMutationValue MutationValue;
   public SAnimalSprite AnimalSprite;
   public float SpeedMutation()
   {
      return Random.Range(MutationValue.MutationSpeedMin, MutationValue.MutationSpeedMax);
   }
   
   public int SeekRangeMutation()
   {
      return Random.Range(MutationValue.MutationSeekRangeMin, MutationValue.MutationSeekRangeMax);
   }
   
   public float HungerRateMutation()
   {
      return Random.Range(MutationValue.MutationHungerRateMin, MutationValue.MutationHungerRateMax);
   }

   public int FoodPerBiteMutation()
   {
      return  Random.Range(MutationValue.MutationFoodPerBiteMin, MutationValue.MutationFoodPerBiteMax);
   }
}
