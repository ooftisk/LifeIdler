using R3;
using R3.Triggers;
using UnityEngine;

public class DecisionState : HerbivoreBaseState
{
    public DecisionState(HerbivoreFSM fsm, HerbivoreAnimal animal) : base(fsm, animal)
    {
        
    }
    
    public override void Enter()
    {
        DisposeOnEnter();
        
        Observable.EveryValueChanged(this, _ => animal.Hunger)
            .Where(hunger => hunger <= 40f)
            .Subscribe(_ =>
            {
                Observable.NextFrame()
                    .Subscribe(_ =>
                    {
                        TryFindFood();
                    }).AddTo(disposable);
               
            }).AddTo(disposable);
        
        var patrolState = Observable.NextFrame();
        patrolState.Take(1)
            .Subscribe(_ =>
            {
                if (animal.IsAlfa)
                {
                    fsm.ChangeState(new PatrolState(fsm, animal, Vector2.zero));
                }
                
                if (animal.AlfaPosition != null && Vector2.Distance(animal.transform.position, animal.AlfaPosition.position) > 3f)
                {
                    fsm.ChangeState(new PatrolState(fsm, animal, animal.AlfaPosition.position));
                }
                else
                {
                    fsm.ChangeState(new PatrolState(fsm, animal, Vector2.zero));
                }
            }).AddTo(disposable);
    }
    
    public override void Exit()
    {
        DisposeOnExit();
    }

    private void TryFindFood()
    {
        if (animal.TargetFood == null)
        {
            fsm.ChangeState(new FoodSeekState(fsm, animal));
        }
        else
        {
            if (Vector2.Distance(animal.transform.position, animal.TargetFood.transform.position) <= 0.6f)
            {
                fsm.ChangeState(new EatState(fsm, animal));
            }
            else
            {
                fsm.ChangeState(new PatrolState(fsm, animal, (Vector2)animal.TargetFood.transform.position + Random.insideUnitCircle * 0.5f));
            }
        }
    }
}
