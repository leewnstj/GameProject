using UnityEngine;

public abstract class EntityFactory<T> : MonoBehaviour
{
    // 외부에서 호출하는 함수 팩토리내부에서 처리할수있는 모든 처리는 여기서하자.
    public PoolableMono SpawnObject(T type)
    {
        PoolableMono entity = this.Create(type);
        entity.transform.rotation = Quaternion.identity;

        return entity;
    }

    protected abstract PoolableMono Create(T type); //각각의 팩토리에서 재정의 한다.
}