namespace Assets.Scripts.StateMachine.Base
{
    public abstract class BaseState<TContext> where TContext : StateContext
    {
        private IStateSwitcher<TContext> _stateSwitcher;
        private TContext _context;

        public BaseState(IStateSwitcher<TContext> stateSwitcher, TContext context) 
        { 
            _stateSwitcher = stateSwitcher;
            _context = context;
        }

        protected IStateSwitcher<TContext> StateSwitcher => _stateSwitcher;
        protected TContext Context => _context;

        public virtual void Start() { }

        public virtual void Stop() { }

        public virtual void Update() { }
    }
}
