﻿/*
 * (c) 2008 MOSA - The Managed Operating System Alliance
 *
 * Licensed under the terms of the New BSD License.
 *
 * Authors:
 *  Simon Wollwage (<mailto:kintaro@think-in-co.de>)
 */

using System;
using Mosa.Runtime.CompilerFramework;

namespace Mosa.Platforms.x86.CPUx86
{
    /// <summary>
    /// Intermediate representation of the arithmetic shift right instruction.
    /// </summary>
	public sealed class SalInstruction : TwoOperandInstruction
    {
        #region Data Members
        private static readonly OpCode RegMem = new OpCode(new byte[] { 0xD3 }, 4);
        private static readonly OpCode RegMemConstant = new OpCode(new byte[] { 0xC1 }, 4);
        #endregion

        #region Methods

		/// <summary>
		/// Computes the op code.
		/// </summary>
		/// <param name="destination">The destination operand.</param>
		/// <param name="source">The source operand.</param>
		/// <param name="third">The third operand.</param>
		/// <returns></returns>
        protected override OpCode ComputeOpCode(Operand destination, Operand source, Operand third)
        {
			if ((destination is RegisterOperand || destination is MemoryOperand) && (source is ConstantOperand)) return RegMemConstant;
			if (destination is RegisterOperand || destination is MemoryOperand) return RegMem;
            throw new ArgumentException(@"No opcode for operand type.");
        }

        /// <summary>
        /// Returns a string representation of the instruction.
        /// </summary>
        /// <returns>
        /// A string representation of the instruction in intermediate form.
        /// </returns>
        public override string ToString(Context context)
        {
            return String.Format(@"X86.sal {0}, {1} ;  {0} >>= {1}", context.Operand1, context.Operand2);
        }

		/// <summary>
		/// Allows visitor based dispatch for this instruction object.
		/// </summary>
		/// <param name="visitor">The visitor object.</param>
		/// <param name="context">The context.</param>
		public override void Visit(IX86Visitor visitor, Context context)
		{
			visitor.Sal(context);
		}

        #endregion // Methods
    }
}
