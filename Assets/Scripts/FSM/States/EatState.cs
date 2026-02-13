using UnityEngine;
using R3;

public class EatState : BaseState
{
    public EatState(FSM fsm, Animal animal) : base(fsm, animal)
    {
        
    }

    public override void Enter()
    {
        DisposeOnEnter();
        
        var eatState = Observable.NextFrame();
        eatState.Take(1)
            .Subscribe(_ =>
            {
                if (animal.TargetFood != null)
                {
                    animal.TargetFood.DecreaseFoodAmount(animal.FoodPerBite * 0.5f);
                    animal.TargetFood.PlayEatEffect();
                    animal.Hunger += animal.FoodPerBite;
                    animal.TargetFood = null;
                    
                    if (animal.Hunger > 100)
                    {
                        animal.Hunger = 100;
                    }
                    
                    fsm.ChangeState(new DecisionState(fsm, animal));
                }
                else
                {
                    Debug.Log("Bug in EatState");
                }
            }).AddTo(disposable);
    }

    public override void Exit()
    {
        DisposeOnExit();
    }
}
