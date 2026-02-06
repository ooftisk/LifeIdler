using UnityEngine;

public class HerbivoreFSM : MonoBehaviour
{
    public HerbivoreBaseState currentState;
    private HerbivoreAnimal _animal;

    private void Start()
    {
        _animal = GetComponent<HerbivoreAnimal>();
        ChangeState(new DecisionState(this, _animal));
    }

    public void ChangeState(HerbivoreBaseState newState)
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
