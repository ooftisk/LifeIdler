
using R3;
using R3.Triggers;
using UnityEngine;


public class FoodSeekState : BaseState
{
    
    public FoodSeekState(FSM fsm, Animal animal) : base(fsm, animal)
    {
        
    }

    public override void Enter()
    {
        DisposeOnEnter();
        FindNearest();
        
        if (animal.TargetFood == null)
        {
            fsm.ChangeState(new PatrolState(fsm, animal));
            return;
        }
        
        var moveToFood = Observable.EveryUpdate();
            moveToFood.TakeWhile(_ => animal.TargetFood != null && Vector2.Distance(animal.transform.position, animal.TargetFood.transform.position) > 0.2f)
            .Subscribe(_ => MoveToFood(), 
                onCompleted: _ =>
                {
                    fsm.ChangeState(new EatState(fsm, animal));
                }).AddTo(disposable);
    }

    public override void Exit()
    {
       DisposeOnExit(); 
    }

    private void FindNearest() //Поиск ближайшей точки с едой
    {
        animal.TargetFood = null;
        
        foreach (var food in animal.NearFood)
        {
            float distance = Vector2.Distance(animal.transform.position, food.transform.position);

            if (distance < animal.SeekRange && food.GetFoodAmount() > 0 && food.GetFoodType() == BaseFood.FoodType.Herbivore)
            {
                animal.TargetFood = food;
            }
        }
    }

    private void MoveToFood() // Идти до точки с едой
    {
        Vector2 direction = (animal.TargetFood.transform.position - animal.transform.position).normalized;
        animal.transform.Translate(direction * animal.Speed * Time.deltaTime);
    }
}
