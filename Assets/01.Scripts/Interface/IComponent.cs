namespace ComponentPattern
{
    public interface IComponent<T>
    {
        public void Init(T component);
    }

    public interface IPlayerComponent : IComponent<Player> { }

    public interface IEnemyComponent : IComponent<Player> { }
}