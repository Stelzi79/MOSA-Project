﻿/*
 * (c) 2008 MOSA - The Managed Operating System Alliance
 *
 * Licensed under the terms of the New BSD License.
 *
 * Authors:
 *  Phil Garcia (tgiphil) <phil@thinkedge.com>
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

using Mosa.Runtime.Metadata.Signatures;

namespace Mosa.Runtime.CompilerFramework.CIL
{
	/// <summary>
	/// 
	/// </summary>
	public class ArithmeticInstruction : BinaryInstruction
	{
		#region Static data members

		/// <summary>
		/// Generic operand validation table. Not used for add and sub.
		/// </summary>
		private static StackTypeCode[][] _operandTable = new StackTypeCode[][] {
            new StackTypeCode[] { StackTypeCode.Unknown, StackTypeCode.Unknown, StackTypeCode.Unknown, StackTypeCode.Unknown, StackTypeCode.Unknown, StackTypeCode.Unknown, StackTypeCode.Unknown },
            new StackTypeCode[] { StackTypeCode.Unknown, StackTypeCode.Int32,   StackTypeCode.Unknown, StackTypeCode.N,       StackTypeCode.Unknown, StackTypeCode.Unknown, StackTypeCode.Unknown },
            new StackTypeCode[] { StackTypeCode.Unknown, StackTypeCode.Unknown, StackTypeCode.Int64,   StackTypeCode.Unknown, StackTypeCode.Unknown, StackTypeCode.Unknown, StackTypeCode.Unknown },
            new StackTypeCode[] { StackTypeCode.Unknown, StackTypeCode.N,       StackTypeCode.Unknown, StackTypeCode.N,       StackTypeCode.Unknown, StackTypeCode.Unknown, StackTypeCode.Unknown },
            new StackTypeCode[] { StackTypeCode.Unknown, StackTypeCode.Unknown, StackTypeCode.Unknown, StackTypeCode.Unknown, StackTypeCode.F,       StackTypeCode.Unknown, StackTypeCode.Unknown },
            new StackTypeCode[] { StackTypeCode.Unknown, StackTypeCode.Unknown, StackTypeCode.Unknown, StackTypeCode.Unknown, StackTypeCode.Unknown, StackTypeCode.Unknown, StackTypeCode.Unknown },
            new StackTypeCode[] { StackTypeCode.Unknown, StackTypeCode.Unknown, StackTypeCode.Unknown, StackTypeCode.Unknown, StackTypeCode.Unknown, StackTypeCode.Unknown, StackTypeCode.Unknown },
        };

		/// <summary>
		/// Operand validation table for the add instruction.
		/// </summary>
		private static StackTypeCode[][] _addTable = new StackTypeCode[][] {
            new StackTypeCode[] { StackTypeCode.Unknown, StackTypeCode.Unknown, StackTypeCode.Unknown, StackTypeCode.Unknown, StackTypeCode.Unknown, StackTypeCode.Unknown, StackTypeCode.Unknown },
            new StackTypeCode[] { StackTypeCode.Unknown, StackTypeCode.Int32,   StackTypeCode.Unknown, StackTypeCode.N,       StackTypeCode.Unknown, StackTypeCode.Ptr,     StackTypeCode.Unknown },
            new StackTypeCode[] { StackTypeCode.Unknown, StackTypeCode.Unknown, StackTypeCode.Int64,   StackTypeCode.Unknown, StackTypeCode.Unknown, StackTypeCode.Unknown, StackTypeCode.Unknown },
            new StackTypeCode[] { StackTypeCode.Unknown, StackTypeCode.N,       StackTypeCode.Unknown, StackTypeCode.N,       StackTypeCode.Unknown, StackTypeCode.Ptr,     StackTypeCode.Unknown },
            new StackTypeCode[] { StackTypeCode.Unknown, StackTypeCode.Unknown, StackTypeCode.Unknown, StackTypeCode.Unknown, StackTypeCode.F,       StackTypeCode.Unknown, StackTypeCode.Unknown },
            new StackTypeCode[] { StackTypeCode.Unknown, StackTypeCode.Ptr,     StackTypeCode.Unknown, StackTypeCode.Ptr,     StackTypeCode.Unknown, StackTypeCode.Unknown, StackTypeCode.Unknown },
            new StackTypeCode[] { StackTypeCode.Unknown, StackTypeCode.Unknown, StackTypeCode.Unknown, StackTypeCode.Unknown, StackTypeCode.Unknown, StackTypeCode.Unknown, StackTypeCode.Unknown },
        };

		/// <summary>
		/// Operand validation table for the sub instruction.
		/// </summary>
		private static StackTypeCode[][] _subTable = new StackTypeCode[][] {
            new StackTypeCode[] { StackTypeCode.Unknown, StackTypeCode.Unknown, StackTypeCode.Unknown, StackTypeCode.Unknown, StackTypeCode.Unknown, StackTypeCode.Unknown, StackTypeCode.Unknown },
            new StackTypeCode[] { StackTypeCode.Unknown, StackTypeCode.Int32,   StackTypeCode.Unknown, StackTypeCode.N,       StackTypeCode.Unknown, StackTypeCode.Unknown, StackTypeCode.Unknown },
            new StackTypeCode[] { StackTypeCode.Unknown, StackTypeCode.Unknown, StackTypeCode.Int64,   StackTypeCode.Unknown, StackTypeCode.Unknown, StackTypeCode.Unknown, StackTypeCode.Unknown },
            new StackTypeCode[] { StackTypeCode.Unknown, StackTypeCode.N,       StackTypeCode.Unknown, StackTypeCode.N,       StackTypeCode.Unknown, StackTypeCode.Unknown, StackTypeCode.Unknown },
            new StackTypeCode[] { StackTypeCode.Unknown, StackTypeCode.Unknown, StackTypeCode.Unknown, StackTypeCode.Unknown, StackTypeCode.F,       StackTypeCode.Unknown, StackTypeCode.Unknown },
            new StackTypeCode[] { StackTypeCode.Unknown, StackTypeCode.Ptr,     StackTypeCode.Unknown, StackTypeCode.Ptr,     StackTypeCode.Unknown, StackTypeCode.N,       StackTypeCode.Unknown },
            new StackTypeCode[] { StackTypeCode.Unknown, StackTypeCode.Unknown, StackTypeCode.Unknown, StackTypeCode.Unknown, StackTypeCode.Unknown, StackTypeCode.Unknown, StackTypeCode.Unknown },
        };

		#endregion // Static data members

		#region Data members

		/// <summary>
		/// 
		/// </summary>
		protected OpCode _opcode;

		#endregion // Data members

		#region Construction

		/// <summary>
		/// Initializes a new instance of the <see cref="ArithmeticInstruction"/> class.
		/// </summary>
		public ArithmeticInstruction(OpCode opcode)
			: base(1)
		{
			_opcode = opcode;
		}

		#endregion // Construction

		#region ICILInstruction Overrides

		/// <summary>
		/// Decodes the specified instruction.
		/// </summary>
		/// <param name="instruction">The instruction.</param>
		/// <param name="opcode">The opcode of the load.</param>
		/// <param name="decoder">The instruction decoder, which holds the code stream.</param>
		public override void Decode(ref InstructionData instruction, OpCode opcode, IInstructionDecoder decoder)
		{
			// Make sure the opcode is valid
			if (OpCode.Add != opcode && OpCode.Div != opcode && OpCode.Mul != opcode && OpCode.Rem != opcode && OpCode.Sub != opcode)
				throw new ArgumentException(@"Opcode not supported.", @"code");
		}

		/// <summary>
		/// Validates the instruction operands and creates a matching variable for the result.
		/// </summary>
		public override void Validate(ref InstructionData instruction, IMethodCompiler compiler)
		{
			//			base.Validate(compiler);

			StackTypeCode result = StackTypeCode.Unknown;
			switch (_opcode) {
				case OpCode.Add:
					result = _addTable[(int)instruction.Operand1.StackType][(int)instruction.Operand2.StackType];
					break;

				case OpCode.Sub:
					result = _subTable[(int)instruction.Operand1.StackType][(int)instruction.Operand2.StackType];
					break;

				default:
					result = _operandTable[(int)instruction.Operand1.StackType][(int)instruction.Operand2.StackType];
					break;
			}

			if (StackTypeCode.Unknown == result)
				throw new InvalidOperationException(@"Invalid operand types passed to " + _opcode);

			SigType resultType;
			if (result != StackTypeCode.Ptr) {
				resultType = Operand.SigTypeFromStackType(result);
			}
			else {
				// Copy the pointer element type
				PtrSigType op0 = instruction.Operand1.Type as PtrSigType;
				PtrSigType op1 = instruction.Operand2.Type as PtrSigType;
				if (op0 != null)
					resultType = new PtrSigType(op0.CustomMods, op0.ElementType);
				else if (op1 != null)
					resultType = new PtrSigType(op1.CustomMods, op1.ElementType);
				else
					throw new InvalidOperationException();
			}

			instruction.Result = compiler.CreateTemporary(resultType);
		}

		/// <summary>
		/// Returns a <see cref="System.String"/> that represents this instance.
		/// </summary>
		/// <param name="instruction">The instruction.</param>
		/// <returns>
		/// A <see cref="System.String"/> that represents this instance.
		/// </returns>
		public override string ToString(ref InstructionData instruction)
		{
			return ToString();
		}

		#endregion // ICILInstruction Overrides

		#region Operand Overrides

		/// <summary>
		/// Returns a string representation of <see cref="ConstantOperand"/>.
		/// </summary>
		/// <returns>A string representation of the operand.</returns>
		public override string ToString()
		{
			return "CIL " + _opcode.ToString();
		}

		#endregion // Operand Overrides
	}
}
