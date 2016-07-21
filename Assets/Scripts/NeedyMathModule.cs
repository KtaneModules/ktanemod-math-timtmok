using UnityEngine;

public class NeedyMathModule : MathModule
{
	public TextMesh MathDisplay;

	void Awake()
	{
		GetComponent<KMNeedyModule>().OnTimerExpired += OnTimerExpired;
		Init();
	}

	protected override void Init()
	{
		base.Init();
		SetDisplay();
	}

	private void SetDisplay()
	{
		var questionText = Puzzle.Operand1 + MathPuzzle.GetOperationString(Puzzle.Operator) + Puzzle.Operand2;
		MathDisplay.text = questionText;
	}

	protected override void Solve()
	{
		if (Puzzle.CheckAnswer(Answer, Sign))
			GetComponent<KMNeedyModule>().OnPass();
		else
			GetComponent<KMNeedyModule>().OnStrike();

		Answer = string.Empty;
		Sign = 1;

		Puzzle = MathFactory.Instance.GenerateQuestion();
		SetDisplay();
	}

	protected void OnTimerExpired()
	{
		GetComponent<KMNeedyModule>().OnStrike();
	}
}