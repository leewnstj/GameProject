using UnityEngine;

public class Bullet : PoolableMono
{
    [SerializeField] private float _timeToDestroy;

    private LayerMask _targetLayer;
    private Rigidbody _rigidCompo;

    private FeedbackPlayer _feedbackPlayer;

    private void Awake()
    {
        _rigidCompo = GetComponent<Rigidbody>();
        _feedbackPlayer = GetComponentInChildren<FeedbackPlayer>();
    }

    public void Setting(LayerMask target)
    {
        _targetLayer = target;
    }

    public void Fire(Vector3 direction)
    {
        _rigidCompo.AddForce(direction, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        _feedbackPlayer.PlayFeedback();

        PoolManager.Push(this);
    }
}