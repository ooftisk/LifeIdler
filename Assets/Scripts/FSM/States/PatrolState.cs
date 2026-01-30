using UnityEngine;
using R3;
using UnityEditor;
using UnityEngine.SceneManagement;

public class PatrolState : BaseState
{
    
    private Vector2 targetPosition;
    private Vector2 alfaPosition;
    
    
    public PatrolState(FSM fsm, Animal animal, Vector3 alfaPoint) : base(fsm, animal)
    {
        alfaPosition = alfaPoint;
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
                    fsm.ChangeState(new DecisionState(fsm, animal));
                })
            .AddTo(disposable);
        
    }

    public override void Exit()
    {
        DisposeOnExit();
    }

    private void MoveToPoint()
    {
        Vector2 direction = (targetPosition - (Vector2)animal.transform.position).normalized;
        animal.transform.Translate(direction * animal.Speed * Time.deltaTime);
        Debug.Log("Moving");
    }
}
