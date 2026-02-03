using UnityEngine;

public class HerbivoreFSM : MonoBehaviour
{
    public HerbivoreBaseState currentState;
    private HerbivoreAnimal _animal;

    private void Start()
    {
        _animal = GetComponent<HerbivoreAnimal>();
        ChangeState(new PatrolState(this, _animal, Vector3.zero));
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
