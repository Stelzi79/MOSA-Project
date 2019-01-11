// Copyright (c) MOSA Project. Licensed under the New BSD License.

// This code was generated by an automated template.

using Mosa.Compiler.Framework;

namespace Mosa.Platform.x64.Instructions
{
	/// <summary>
	/// Mov32
	/// </summary>
	/// <seealso cref="Mosa.Platform.x64.X64Instruction" />
	public sealed class Mov32 : X64Instruction
	{
		public override int ID { get { return 438; } }

		internal Mov32()
			: base(1, 1)
		{
		}

		public override void Emit(InstructionNode node, BaseCodeEmitter emitter)
		{
			System.Diagnostics.Debug.Assert(node.ResultCount == 1);
			System.Diagnostics.Debug.Assert(node.OperandCount == 1);

			if (node.Operand1.IsCPURegister)
			{
				emitter.OpcodeEncoder.SuppressByte(0x40);
				emitter.OpcodeEncoder.AppendNibble(0b0100);
				emitter.OpcodeEncoder.AppendBit(0b0);
				emitter.OpcodeEncoder.Append3Bits(node.Result.Register.RegisterCode);
				emitter.OpcodeEncoder.AppendBit(0b0);
				emitter.OpcodeEncoder.AppendBit((node.Operand1.Register.RegisterCode >> 3) & 0x1);
				emitter.OpcodeEncoder.AppendByte(0x8B);
				emitter.OpcodeEncoder.Append2Bits(0b11);
				emitter.OpcodeEncoder.Append3Bits(node.Result.Register.RegisterCode);
				emitter.OpcodeEncoder.Append3Bits(node.Operand1.Register.RegisterCode);
				return;
			}

			if (node.Operand1.IsConstant)
			{
				emitter.OpcodeEncoder.SuppressByte(0x40);
				emitter.OpcodeEncoder.AppendNibble(0b0100);
				emitter.OpcodeEncoder.AppendBit(0b0);
				emitter.OpcodeEncoder.AppendBit(0b0);
				emitter.OpcodeEncoder.AppendBit(0b0);
				emitter.OpcodeEncoder.AppendBit((node.Result.Register.RegisterCode >> 3) & 0x1);
				emitter.OpcodeEncoder.AppendByte(0xC7);
				emitter.OpcodeEncoder.Append2Bits(0b11);
				emitter.OpcodeEncoder.Append3Bits(0b000);
				emitter.OpcodeEncoder.Append3Bits(node.Result.Register.RegisterCode);
				emitter.OpcodeEncoder.Append32BitImmediate(node.Operand1);
				return;
			}

			throw new Compiler.Common.Exceptions.CompilerException("Invalid Opcode");
		}
	}
}
