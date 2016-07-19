using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class EmojiMath : MonoBehaviour
{
	private const int Minus = 10;
	private const int Enter = 11;

	public KMSelectable[] Buttons;
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

	private MathPuzzle _puzzle;
	private string _answer;
	private int _sign = 1;

	void Start()
	{
		Init();
	}

	private void Init()
	{
		_puzzle = MathFactory.Instance.GenerateQuestion();

		SetDisplay();
		SetUpNumberButtons();
		SetUpMinusButton();
		SetUpEnterButton();
	}

	private void SetUpMinusButton()
	{
		Buttons[Minus].OnInteract += delegate
		{
			_sign *= -1;
			return false;
		};
	}

	private void SetUpEnterButton()
	{
		Buttons[Enter].OnInteract += delegate
		{
			int rightAnswer;
			switch (_puzzle.Operator)
			{
				case MathPuzzle.Operation.Addition:
					rightAnswer = _puzzle.Operand1 + _puzzle.Operand2;
					break;
				case MathPuzzle.Operation.Subtraction:
					rightAnswer = _puzzle.Operand1 - _puzzle.Operand2;
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}

			rightAnswer *= _sign;

			if (rightAnswer == int.Parse(_answer))
			{
				GetComponent<KMBombModule>().HandlePass();
			}
			else
			{
				GetComponent<KMBombModule>().HandleStrike();
			}

			_answer = string.Empty;

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
				_answer += button.GetComponentInChildren<TextMesh>().text;
				return false;
			};
		}
	}

	private void SetDisplay()
	{
		var convertedOperand1 = ConvertOperand(_puzzle.Operand1);
		var convertedOperand2 = ConvertOperand(_puzzle.Operand2);
		var operation = MathPuzzle.GetOperationString(_puzzle.Operator);

		DisplayText.text = convertedOperand1 + operation + convertedOperand2;
//		                   + "\n" + _puzzle.Operand1 + operation + _puzzle.Operand2;
	}

	private string ConvertOperand(int operand)
	{
		var convertedDigits = new List<string>();

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