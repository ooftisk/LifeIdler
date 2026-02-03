using UnityEngine;
using R3;
using UnityEditor;
using UnityEngine.SceneManagement;

public class PatrolState : HerbivoreBaseState
{
    
    private Vector2 targetPosition;
    private Vector2 alfaPosition;
    
    
    public PatrolState(HerbivoreFSM fsm, HerbivoreAnimal animal, Vector3 targetPoint) : base(fsm, animal)
    {
        alfaPosition = targetPoint;
    }
    
    public override void Enter()
    {
        DisposeOnEnter();

        if (alfaPosition != Vector2.zero)
        {
            targetPosition = alfaPosition + Random.insideUnitCircle;
        }
        else
        {
            targetPosition = (Vector2)animal.transform.position + Random.insideUnitCircle;
        }
        
        var moveToPoint = Observable.EveryUpdate();

        moveToPoint.TakeWhile(_ => Vector2.Distance(animal.transform.position, targetPosition) > 0.1f)
            .Subscribe(_ => MoveToPoint(),
                onCompleted: _ =>
                {
                    animal.ReduceHunger();
                    fsm.ChangeState(new DecisionState(fsm, animal));
                })
            .AddTo(disposable);
        
    }

    public override void Exit()
    {
        DisposeOnExit();
    }

    private void MoveToPoint() // MoveToPoint - двигаться к точке
    {
        Vector2 direction = (targetPosition - (Vector2)animal.transform.position).normalized;
        animal.transform.Translate(direction * animal.Speed * Time.deltaTime);
    }
}
