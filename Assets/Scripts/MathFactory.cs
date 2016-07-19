using UnityEngine;

public class MathFactory
{
	private static MathFactory _instance;
	private const int Max = 100;
	private const int Min = 0;

	public static MathFactory Instance
	{
		get { return _instance ?? (_instance = new MathFactory()); }
	}

	public MathPuzzle GenerateQuestion()
	{
		var puzzle = new MathPuzzle
		{
			Operand1 = Random.Range(Min, Max),
			Operand2 = Random.Range(Min, Max),
			Operator = MathPuzzle.GetOperation(Random.Range(0, 2))
		};

		return puzzle;
	}
}