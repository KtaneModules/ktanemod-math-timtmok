using System;
using Debug = UnityEngine.Debug;

public class MathPuzzle
{
	public int Operand1;
	public int Operand2;
	public Operation Operator;

	public enum Operation
	{
		Addition = 0,
		Subtraction = 1
	}

	public static string GetOperationString(Operation op)
	{
		switch (op)
		{
			case Operation.Addition:
				return "+";
			case Operation.Subtraction:
				return "-";
			default:
				return "";
		}
	}

	public static Operation GetOperation(int type)
	{
		switch (type)
		{
			case 0:
				return Operation.Addition;
			case 1:
				return Operation.Subtraction;
			default:
				return Operation.Addition;
		}
	}

	public bool CheckAnswer(string answer, int sign)
	{
		int rightAnswer;
		switch (Operator)
		{
			case MathPuzzle.Operation.Addition:
				rightAnswer = Operand1 + Operand2;
				break;
			case MathPuzzle.Operation.Subtraction:
				rightAnswer = Operand1 - Operand2;
				break;
			default:
				throw new ArgumentOutOfRangeException();
		}

		int parsedAnswer;
		try
		{
			parsedAnswer = int.Parse(answer) * sign;
		}
		catch (FormatException e)
		{
			Debug.Log(e.Message);
			return false;
		}

		Debug.Log("Answer: " + parsedAnswer);
		Debug.Log("Correct Answer: " + rightAnswer);

		return rightAnswer == parsedAnswer;
	}
}