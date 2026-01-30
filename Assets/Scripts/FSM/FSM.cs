using UnityEngine;

public class FSM : MonoBehaviour
{
    [HideInInspector] public BaseState currentState;
    private Animal _animal;

    private void Start()
    {
        _animal = GetComponent<Animal>();
        ChangeState(new PatrolState(this, _animal, Vector3.zero));
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
