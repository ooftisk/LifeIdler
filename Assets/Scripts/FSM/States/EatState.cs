using UnityEngine;
using R3;

public class EatState : HerbivoreBaseState
{
    public EatState(HerbivoreFSM fsm, HerbivoreAnimal animal) : base(fsm, animal)
    {
        
    }

    public override void Enter()
    {
        DisposeOnEnter();
        
        var eatState = Observable.NextFrame();
        eatState.Take(1)
            .Subscribe(_ =>
            {
                animal.TargetFood.FoodAmount -= 1;
                animal.TargetFood.EatEffect.Play();
                animal.Hunger += 60;
                animal.TargetFood = null;
                fsm.ChangeState(new DecisionState(fsm, animal));
            }).AddTo(disposable);
    }

    public override void Exit()
    {
        DisposeOnExit();
        
    }
}
