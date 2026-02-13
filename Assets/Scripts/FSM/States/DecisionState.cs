using R3;
using R3.Triggers;
using UnityEngine;

public class DecisionState : BaseState
{
    public DecisionState(FSM fsm, Animal animal) : base(fsm, animal)
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
                        fsm.ChangeState(new FoodSeekState(fsm, animal));
                    }).AddTo(disposable);
            }).AddTo(disposable);
            
        
        
        var patrolState = Observable.NextFrame();
        patrolState.Take(1)
            .Subscribe(_ =>
            {
                fsm.ChangeState(new PatrolState(fsm, animal));
            }).AddTo(disposable);
    }
    
    public override void Exit()
    {
        DisposeOnExit();
    }
    
}
