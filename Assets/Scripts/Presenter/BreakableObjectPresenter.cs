using UnityEngine;
using TribeToSurvive.Model;

[RequireComponent(typeof(BreakableObjectView))]
public abstract class BreakableObjectPresenter : Presenter
{
    private BreakableObjectView _view;
    public new BreakableObject Model => (BreakableObject)base.Model;

    private void Awake()
    {
        _view = GetComponent<BreakableObjectView>();
    }

    private void OnEnable()
    {
        Model.WasBroken += Break;
    }

    private void OnDisable()
    {
        Model.WasBroken -= Break;
    }

    public override void Initialize(ISceneObject model)
    {
        base.Initialize(model);

        if (Model.IsBroken)
            _view.SetBroken();
    }

    private void Break()
    {
        _view.Break();
        enabled = false;
    }
}
