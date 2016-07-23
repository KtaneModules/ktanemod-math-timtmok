using System;
using UnityEngine;

public class NeedyMathModule : MathModule
{
	public TextMesh MathDisplay;
	public TextMesh MathDisplayAnswer;

	void Awake()
	{
		GetComponent<KMNeedyModule>().OnNeedyActivation += OnNeedyActivation;
		GetComponent<KMNeedyModule>().OnNeedyDeactivation += OnNeedyDeactivation;
		GetComponent<KMNeedyModule>().OnTimerExpired += OnTimerExpired;
		Init();
	}

	protected void OnNeedyDeactivation()
	{
		MathDisplay.text = string.Empty;
		MathDisplayAnswer.text = string.Empty;
	}

	protected void OnNeedyActivation()
	{
		Puzzle = MathFactory.Instance.GenerateQuestion();
		SetDisplay();
	}

	protected override void Init()
	{
		base.Init();
		OnAnswerUpdate += SetAnswerDisplay;
	}

	private void SetAnswerDisplay()
	{
		var sign = Sign == 1 ? "" : "-";
		MathDisplayAnswer.text = sign + Answer;
	}

	private void SetDisplay()
	{
		var questionText = Puzzle.Operand1 + MathPuzzle.GetOperationString(Puzzle.Operator) + Puzzle.Operand2;
		MathDisplay.text = questionText;
	}

	protected override void Solve()
	{
		if (Puzzle.CheckAnswer(Answer, Sign))
		{
			Debug.Log("Pass!");
			MathDisplay.text = string.Empty;
			GetComponent<KMNeedyModule>().HandlePass();
		}
		else
		{
			Debug.Log("Strike!");
			GetComponent<KMNeedyModule>().HandleStrike();
		}

		Answer = string.Empty;
		Sign = 1;
		SetAnswerDisplay();

		Puzzle = MathFactory.Instance.GenerateQuestion();
	}

	protected void OnTimerExpired()
	{
		GetComponent<KMNeedyModule>().HandleStrike();
	}
}