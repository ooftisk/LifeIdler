using R3;
using UnityEngine;

public abstract class HerbivoreBaseState
{
    protected HerbivoreFSM fsm;
    protected HerbivoreAnimal animal;
    protected CompositeDisposable disposable;

    public HerbivoreBaseState(HerbivoreFSM fsm, HerbivoreAnimal animal)
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
