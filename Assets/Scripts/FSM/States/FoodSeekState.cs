
using R3;
using R3.Triggers;
using UnityEngine;


public class FoodSeekState : HerbivoreBaseState
{
    
    public FoodSeekState(HerbivoreFSM fsm, HerbivoreAnimal animal) : base(fsm, animal)
    {
        
    }

    public override void Enter()
    {
        DisposeOnEnter();

        var moveToFood = Observable.NextFrame();
        moveToFood.Take(1)
            .Subscribe(_ =>
            {
                FindNearest();
                
                if (animal.TargetFood != null)
                {
                    fsm.ChangeState(new DecisionState(fsm, animal));
                }
            }).AddTo(disposable);
        
    }

    public override void Exit()
    {
       DisposeOnExit(); 
    }

    private void FindNearest()
    {
        animal.TargetFood = null;
        
        foreach (var food in animal.NearFood)
        {
            float distance = Vector2.Distance(animal.transform.position, food.transform.position);

            if (distance < animal.SeekRange && food.FoodAmount > 0)
            {
                animal.TargetFood = food;
            }
        }
        
    }
}
