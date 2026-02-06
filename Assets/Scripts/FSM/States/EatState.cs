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
                if (animal.TargetFood != null)
                {
                    animal.TargetFood.DecreaseFoodAmount(1f);
                    animal.TargetFood.PlayEatEffect();
                    animal.Hunger += 60;
                    animal.TargetFood = null;
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
