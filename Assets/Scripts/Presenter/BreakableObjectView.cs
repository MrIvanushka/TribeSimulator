using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableObjectView : MonoBehaviour
{
    [SerializeField] private GameObject _activeGraphics;

    public void SetBroken()
    {
        _activeGraphics.SetActive(false);
    }

    public void Break()
    {
        SetBroken();
    }
}
