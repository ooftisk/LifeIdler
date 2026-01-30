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
        
        if (animal.IsAlfa)
        {
            Observable.NextFrame()
                .Take(1)
                .Subscribe(_ =>
                {
                    fsm.ChangeState(new PatrolState(fsm, animal, Vector2.zero));
                }).AddTo(disposable);
        }

        var checkDistanceToAlfa = Observable.NextFrame();
        checkDistanceToAlfa.Take(1)
            .Subscribe(_ =>
            {
                if (Vector2.Distance(animal.transform.position, animal.AlfaPosition.position) > 3f)
                {
                    fsm.ChangeState(new PatrolState(fsm, animal, animal.AlfaPosition.position));
                }
                else
                {
                    fsm.ChangeState(new PatrolState(fsm, animal, Vector3.zero));
                }
            }).AddTo(disposable);

    }
    
    public override void Exit()
    {
        DisposeOnExit();
    }
}
