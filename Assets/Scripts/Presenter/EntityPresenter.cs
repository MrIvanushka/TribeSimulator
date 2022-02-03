using UnityEngine;
using TribeToSurvive.Model;

[RequireComponent(typeof(EntityNavigation))]
public class EntityPresenter : Presenter
{

    public override void Initialize(ISceneObject model)
    {
        base.Initialize(model);
        GetComponent<EntityNavigation>().Initialize(model);
    }
}
