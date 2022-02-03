using TribeToSurvive.Model;
using UnityEngine;

public class UnitPresenter : EntityPresenter
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<BeastPresenter>(out BeastPresenter presenter))
        {
            Die();
        }
    }

    private void Die()
    {

    }
}
