using UnityEngine;
using System.Collections;

public class ExampleNeedyModule : MonoBehaviour
{
    public KMSelectable SolveButton;
    public KMSelectable AddTimeButton;

<<<<<<< HEAD
    float timeRemaining;

=======
>>>>>>> 269498d64dd5143303ee2574f4f1ec320083d6f7
    void Awake()
    {
        GetComponent<KMNeedyModule>().OnNeedyActivation += OnNeedyActivation;
        GetComponent<KMNeedyModule>().OnNeedyDeactivation += OnNeedyDeactivation;
        SolveButton.OnInteract += Solve;
        AddTimeButton.OnInteract += AddTime;
        GetComponent<KMNeedyModule>().OnTimerExpired += OnTimerExpired;
    }

    protected bool Solve()
    {
        GetComponent<KMNeedyModule>().OnPass();

        return false;
    }

    protected void OnNeedyActivation()
    {

    }

    protected void OnNeedyDeactivation()
    {

    }

    protected void OnTimerExpired()
    {
        GetComponent<KMNeedyModule>().OnStrike();
    }

    protected bool AddTime()
    {
        float time = GetComponent<KMNeedyModule>().GetNeedyTimeRemaining();
        if (time > 0)
        {
            GetComponent<KMNeedyModule>().SetNeedyTimeRemaining(time + 5f);
        }

<<<<<<< HEAD
		GetComponent<KMNeedyModule>().HandleStrike();

=======
>>>>>>> 269498d64dd5143303ee2574f4f1ec320083d6f7
        return false;
    }
}