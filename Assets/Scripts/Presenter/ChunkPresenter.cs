using System.Collections;
using System.Collections.Generic;
using TribeToSurvive.Model;
using UnityEngine;

public class ChunkPresenter : Presenter
{
    public override void Initialize(ISceneObject model)
    {
        base.Initialize(model);
        enabled = false;
    }
}
