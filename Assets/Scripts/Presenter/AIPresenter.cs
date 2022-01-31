using UnityEngine;
using UnityEngine.AI;
using TribeToSurvive.Model;

[RequireComponent(typeof(NavMeshAgent))]
public abstract class AIPresenter : MonoBehaviour
{
    private Entity _model;
    private NavMeshAgent _agent;

    public void Initialize(Entity model)
    {
        _model = model;
        enabled = true;
    }

    private void OnEnable()
    {
        _model.GotDestination += SetDestination;
    }

    private void OnDisable()
    {
        _model.GotDestination -= SetDestination;
        _model.Destroying -= OnDestroying;
    }

    private void Update()
    {
        
    }

    private void SetDestination(UnityEngine.Vector3 destination)
    {
        _agent.SetDestination(destination);
    }

    private void OnDestroying()
    {
        Destroy(gameObject);
    }

    protected void DestroyCompose()
    {
        _model.Destroy();
    }
}
