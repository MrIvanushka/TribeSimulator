using UnityEngine;
using TribeToSurvive.Model;

public abstract class Presenter : MonoBehaviour
{
    private ISceneObject _model;

    public ISceneObject Model => _model;

    public virtual void Initialize(ISceneObject model)
    {
        _model = model;
        enabled = true;
    }

    private void OnEnable()
    {
        _model.Destroying += OnDestroying;
    }

    private void OnDisable()
    {
        _model.Destroying -= OnDestroying;
    }

    private void Start()
    {
        //just to get a toggle in inspector
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