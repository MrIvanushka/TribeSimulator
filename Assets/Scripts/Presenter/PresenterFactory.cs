using System.Collections.Generic;
using UnityEngine;
using TribeToSurvive.Model;

public class PresenterFactory : MonoBehaviour
{
    [SerializeField] private Presenter _chunkTemplate;
    [SerializeField] private Presenter _unitTemplate;
    [SerializeField] private Presenter _beastTemplate;
    [SerializeField] private Presenter _treeTemplate;
    [SerializeField] private Presenter _rockTemplate;

    public void CreateTemplate(ISceneObject sceneObject)
    {
        CreateTemplate((dynamic)sceneObject);
    }

    private void CreateTemplate(Chunk chunk)
    {
        CreatePresenter(_chunkTemplate, chunk);

        foreach (var sceneObject in chunk.Objects)
        {
            CreateTemplate(sceneObject);
        }
    }

    private void CreateTemplate(Unit unit)
    {
        CreatePresenter(_unitTemplate, unit);
    }

    private void CreateTemplate(Beast beast)
    {
        CreatePresenter(_beastTemplate, beast);
    }

    private void CreateTemplate(TribeToSurvive.Model.Tree tree)
    {
        CreatePresenter(_treeTemplate, tree);
    }

    private void CreateTemplate(Rock rock)
    {
        CreatePresenter(_rockTemplate, rock);
    }

    private void CreatePresenter(Presenter template, ISceneObject sceneObject)
    {
        Presenter presenter = Instantiate(template, sceneObject.Position, Quaternion.identity);
        presenter.Initialize(sceneObject);
    }
}
