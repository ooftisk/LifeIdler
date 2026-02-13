using R3;
using UnityEngine;

public abstract class BaseState
{
    protected FSM fsm;
    protected Animal animal;
    protected CompositeDisposable disposable;

    public BaseState(FSM fsm, Animal animal)
    {
        this.fsm = fsm;
        this.animal = animal;
    }

    public virtual void Enter()
    {
        
    }
    
    public virtual void Exit()
    {
        
    }
    
    protected void DisposeOnEnter()
    {
        disposable?.Dispose();
        disposable = new CompositeDisposable();
    }

    protected void DisposeOnExit()
    {
        disposable?.Dispose();
        disposable = null;
    }
}
