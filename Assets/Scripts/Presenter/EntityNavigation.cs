using System;
using UnityEngine;
using UnityEngine.AI;
using TribeToSurvive.Model;

[RequireComponent(typeof(NavMeshAgent))]
public class EntityNavigation : MonoBehaviour
{
    private NavMeshAgent _agent;
    private bool _arrivedToDestination = false;
    private Entity _model;

    private void OnEnable()
    {
        _model.GotDestination += SetDestination;
    }

    private void OnDisable()
    {
        _model.GotDestination -= SetDestination;
    }

    public void Initialize(ISceneObject model)
    {
        _agent = GetComponent<NavMeshAgent>();
        
        if (model is Entity)
            _model = model as Entity;
        else
            throw new InvalidCastException();

        enabled = true;
    }

    private void Update()
    {
        CheckPathStatus();
    }

    private void SetDestination(UnityEngine.Vector3 destination)
    {
        _agent.SetDestination(destination);
        _arrivedToDestination = false;
    }

    private void CheckPathStatus()
    {
        if(_arrivedToDestination == false && _agent.pathStatus == NavMeshPathStatus.PathComplete)
        {
            _arrivedToDestination = true;
            _model.Arrive();
        }
    }
}
