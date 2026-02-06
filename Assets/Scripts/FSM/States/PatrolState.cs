using UnityEngine;
using R3;
using UnityEditor;
using UnityEngine.SceneManagement;

public class PatrolState : HerbivoreBaseState
{
    
    private Vector2 targetPosition;
    
    public PatrolState(HerbivoreFSM fsm, HerbivoreAnimal animal) : base(fsm, animal)
    {
        
    }
    
    public override void Enter()
    {
        DisposeOnEnter();
        GetPositionToMove();
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
    
    private void GetPositionToMove()
    {
        Vector2 randomPoint = Random.insideUnitCircle;
        Vector2 animalPosition = animal.transform.position;
        
        if (animal.AnimalType == Animal.AnimalType.Alfa)
        {
            targetPosition = animalPosition + randomPoint;
        }

        if (animal.AnimalType == Animal.AnimalType.Normal)
        {
            if (animal.AlfaPosition != null && Vector2.Distance(animal.transform.position, animal.AlfaPosition.position) > 3f) //How far away alfa
            {
                targetPosition = (Vector2)animal.AlfaPosition.transform.position + randomPoint;
            }
            else
            {
                targetPosition = animalPosition + randomPoint;
            }
        }

        if (animal.AnimalType == Animal.AnimalType.Baby)
        {
            // Waiting for baby implement
        }
    }
    
    private void MoveToPoint()
    {
        Vector2 direction = (targetPosition - (Vector2)animal.transform.position).normalized;
        animal.transform.Translate(direction * animal.Speed * Time.deltaTime);
    }

}
