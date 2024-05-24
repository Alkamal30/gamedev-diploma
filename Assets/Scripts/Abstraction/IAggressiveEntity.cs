namespace Assets.Scripts.Abstraction
{
    public interface IAggressiveEntity
    {
        void DamageWithAggression(IEntity source, int value);
    }
}
