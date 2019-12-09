// Copyright (c) MOSA Project. Licensed under the New BSD License.

// This code was generated by an automated template.

using Mosa.Compiler.Framework.IR;

namespace Mosa.Compiler.Framework.Transform.Auto.IR.Rewrite
{
	/// <summary>
	/// LoadZeroExtend8x64AddressFold
	/// </summary>
	public sealed class LoadZeroExtend8x64AddressFold : BaseTransformation
	{
		public LoadZeroExtend8x64AddressFold() : base(IRInstruction.LoadZeroExtend8x64)
		{
		}

		public override bool Match(Context context, TransformContext transformContext)
		{
			if (!context.Operand1.IsVirtualRegister)
				return false;

			if (!context.Operand2.IsResolvedConstant)
				return false;

			if (context.Operand2.ConstantUnsigned64 != 0L)
				return false;

			if (context.Operand1.Definitions.Count != 1)
				return false;

			if (context.Operand1.Definitions[0].Instruction != IRInstruction.AddressOf)
				return false;

			if (!IsParameter(context.Operand1.Definitions[0].Operand1))
				return false;

			return true;
		}

		public override void Transform(Context context, TransformContext transformContext)
		{
			var result = context.Result;

			var t1 = context.Operand1.Definitions[0].Operand1;

			context.SetInstruction(IRInstruction.LoadParamZeroExtend8x64, result, t1);
		}
	}
}
