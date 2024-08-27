namespace ComponentPattern
{
    public interface IComponent<T>
    {
        public void Init(T component);
    }

    public interface IEntityComponent : IComponent<Entity> { }
}