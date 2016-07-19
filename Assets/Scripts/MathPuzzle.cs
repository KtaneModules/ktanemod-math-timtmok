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
}