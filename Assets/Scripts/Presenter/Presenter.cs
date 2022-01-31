using UnityEngine;
using TribeToSurvive.Model;

public class Presenter : MonoBehaviour
{
    private ISceneObject _model;

    public ISceneObject Model => _model;

    public void Initialize(ISceneObject model)
    {
        _model = model;
    }
}