using UnityEngine;

public abstract class MathModule : MonoBehaviour
{
	private const int Minus = 10;
	private const int Enter = 11;
	protected string Answer = string.Empty;
	protected int Sign = 1;
	protected MathPuzzle Puzzle;
	protected AnswerUpdate OnAnswerUpdate;

	protected delegate void AnswerUpdate();

	public KMSelectable[] Buttons;

	protected virtual void Init()
	{
		Puzzle = MathFactory.Instance.GenerateQuestion();
		Debug.Log(Puzzle.Operand1 + MathPuzzle.GetOperationString(Puzzle.Operator) + Puzzle.Operand2);

		SetUpNumberButtons();
		SetUpMinusButton();
		SetUpEnterButton();
	}

	private void SetUpEnterButton()
	{
		Buttons[Enter].OnInteract += delegate
		{
			Solve();
			OnAnswerUpdate();
			return false;
		};
	}

	protected abstract void Solve();

	private void SetUpMinusButton()
	{
		Buttons[Minus].OnInteract += delegate
		{
			Sign *= -1;
			OnAnswerUpdate();
			return false;
		};
	}

	private void SetUpNumberButtons()
	{
		for (var i = 0; i < 10; i++)
		{
			var button = Buttons[i];
			button.OnInteract += delegate
			{
                Answer += button.GetComponentInChildren<TextMesh>().text;
				OnAnswerUpdate();
				return false;
			};
		}
	}
}