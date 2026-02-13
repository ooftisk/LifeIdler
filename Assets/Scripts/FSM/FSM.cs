using UnityEngine;

public class FSM : MonoBehaviour
{
    public BaseState currentState;
    private Animal _animal;

    private void Start()
    {
        _animal = GetComponent<Animal>();
        ChangeState(new DecisionState(this, _animal));
    }

    public void ChangeState(BaseState newState)
    {
        if (currentState != null)
        {
            currentState.Exit();
        }
        
        currentState = newState;

        if (currentState != null)
        {
            currentState.Enter();
        }
    }
}
