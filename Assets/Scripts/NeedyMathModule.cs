using UnityEngine;
using Random = UnityEngine.Random;

public class NeedyMathModule : MonoBehaviour
{
	public KMSelectable[] Buttons;
	public GameObject MathDisplay;
	private string _answer;

	private enum Operation
	{
		Addition = 0,
		Subtraction
	}

	void Awake()
	{
		GetComponent<KMNeedyModule>().OnTimerExpired += OnTimerExpired;
		Init();
		SetQuestion();
	}

	private void Init()
	{
		foreach (var button in Buttons)
		{
			button.OnInteract += delegate () {
				_answer += button.GetComponent<TextMesh>().text;
				return false;
			};
		}
	}

	private void SetQuestion()
	{
		var op1 = Random.Range(0, 99);
		var op2 = Random.Range(0, 99);
		var operation = Random.Range(0, 1);

		string operationText;

		switch (operation)
		{
			case (int) Operation.Addition:
				operationText = "+";
				break;
			case (int) Operation.Subtraction:
				operationText = "-";
				break;
			default:
				Debug.LogError("Unknown operation type");
				operationText = "?";
				break;
		}

		MathDisplay.GetComponent<TextMesh>().text = string.Format("{0} {1} {2}", op1, operationText, op2);
	}

	protected bool Solve()
	{
		GetComponent<KMNeedyModule>().OnPass();

		return false;
	}

	protected void OnTimerExpired()
	{
		GetComponent<KMNeedyModule>().OnStrike();
	}
}