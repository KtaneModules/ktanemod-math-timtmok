using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class EmojiMathModule : MathModule
{
	public TextMesh DisplayText;

	private readonly string[] _emojiNumbers = new string[]
	{
		":)",
		"=(",
		"(:",
		")=",
		":(",
		"):",
		"=)",
		"(=",
		":|",
		"|:"
	};

	void Start()
	{
		DisplayText.text = string.Empty;
		Init();
		GetComponent<KMBombModule>().OnActivate += SetDisplay;
	}

	protected override void Solve()
	{
		if (Puzzle.CheckAnswer(Answer, Sign))
			GetComponent<KMBombModule>().HandlePass();
		else
			GetComponent<KMBombModule>().HandleStrike();

		Answer = string.Empty;
	}

	private void SetDisplay()
	{
		var convertedOperand1 = ConvertOperand(Puzzle.Operand1);
		var convertedOperand2 = ConvertOperand(Puzzle.Operand2);
		var operation = MathPuzzle.GetOperationString(Puzzle.Operator);
		var questionText = convertedOperand1 + operation + convertedOperand2;

		DisplayText.text = questionText;
	}

	private string ConvertOperand(int operand)
	{
		var convertedDigits = new List<string>();

		if (operand == 0)
		{
			return _emojiNumbers[0];
		}

		while (operand > 0)
		{
			var digit = operand % 10;
			convertedDigits.Add(_emojiNumbers[digit]);
			operand = operand / 10;
		}

		convertedDigits.Reverse();

		var builder = new StringBuilder();

		foreach (var convertedDigit in convertedDigits)
		{
			builder.Append(convertedDigit);
		}

		return builder.ToString();
	}
}