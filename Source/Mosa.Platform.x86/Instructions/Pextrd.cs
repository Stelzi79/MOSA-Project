// Copyright (c) MOSA Project. Licensed under the New BSD License.

// This code was generated by an automated template.

using Mosa.Compiler.Framework;

namespace Mosa.Platform.x86.Instructions
{
	/// <summary>
	/// Pextrd
	/// </summary>
	/// <seealso cref="Mosa.Platform.x86.X86Instruction" />
	public sealed class Pextrd : X86Instruction
	{
		public Pextrd()
			: base(1, 2)
		{
		}

		public override bool ThreeTwoAddressConversion { get { return false; } }

		public override void Emit(InstructionNode node, BaseCodeEmitter emitter)
		{
			System.Diagnostics.Debug.Assert(node.ResultCount == DefaultResultCount || VariableOperands);
			System.Diagnostics.Debug.Assert(node.OperandCount == DefaultOperandCount || VariableOperands);

			StaticEmitters.EmitPextrd(node, emitter);
		}

		// The following is used by the automated code generator.

		public override string __staticEmitMethod { get { return "StaticEmitters.Emit%"; } }
	}
}

