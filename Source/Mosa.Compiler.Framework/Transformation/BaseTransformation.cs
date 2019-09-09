﻿// Copyright (c) MOSA Project. Licensed under the New BSD License.

using Mosa.Compiler.Common;
using Mosa.Compiler.Framework.IR;
using System;
using System.Collections.Generic;

namespace Mosa.Compiler.Framework.Transformation
{
	public abstract class BaseTransformation
	{
		#region Properties

		public BaseInstruction Instruction { get; private set; }
		public List<BaseInstruction> Instructions { get; private set; }

		public string Name { get; }

		#endregion Properties

		#region Data Fields

		protected int OperandFiltersCount;
		protected OperandFilter[] OperandFilters = new OperandFilter[10];

		#endregion Data Fields

		#region Constructors

		protected BaseTransformation()
		{
			Name = ExtractName();
			TransformationDirectory.Add(this);
		}

		public BaseTransformation(BaseInstruction instruction)
			: this()
		{
			Instruction = instruction;
		}

		public BaseTransformation(List<BaseInstruction> instructions)
			: this()
		{
			Instructions = instructions;
		}

		public BaseTransformation(BaseInstruction instruction, OperandFilter operand1 = null, OperandFilter operand2 = null, OperandFilter operand3 = null, OperandFilter operand4 = null, OperandFilter operand5 = null, OperandFilter operand6 = null)
			: this(instruction)
		{
			AddFilter(1, operand1);
			AddFilter(2, operand2);
			AddFilter(3, operand3);
			AddFilter(4, operand4);
			AddFilter(5, operand5);
			AddFilter(6, operand6);
		}

		public BaseTransformation(List<BaseInstruction> instructions, OperandFilter operand1 = null, OperandFilter operand2 = null, OperandFilter operand3 = null, OperandFilter operand4 = null)
			: this(instructions)
		{
			AddFilter(1, operand1);
			AddFilter(2, operand2);
			AddFilter(3, operand3);
			AddFilter(4, operand4);
		}

		#endregion Constructors

		public void AddFilter(int index, OperandFilter filter)
		{
			if (filter == null)
				return;

			OperandFiltersCount = Math.Max(index - 1, OperandFiltersCount);
			OperandFilters[index - 1] = filter;
		}

		#region Internals

		private string ExtractName()
		{
			string name = GetType().FullName;

			int offset1 = name.IndexOf('.');
			int offset2 = name.IndexOf('.', offset1);
			int offset3 = name.IndexOf('.', offset2);
			int offset4 = name.IndexOf('.', offset3);

			return name.Substring(offset4 + 1);
		}

		#endregion Internals

		public bool ValidateInstruction(Context context)
		{
			if (context.IsEmpty)
				return false;

			return context.Instruction == Instruction;
		}

		public virtual bool Match(Context context, TransformContext transformContext)
		{
			// Default - built in match

			if (OperandFiltersCount == 0)
				return true;

			// operand counts must match
			if (OperandFiltersCount != context.OperandCount)
				return false;

			if (OperandFiltersCount >= 1 && !OperandFilters[0].Compare(context.Operand1))
				return false;

			if (OperandFiltersCount >= 2 && !OperandFilters[1].Compare(context.Operand2))
				return false;

			if (OperandFiltersCount >= 3 && !OperandFilters[2].Compare(context.Operand3))
				return false;

			for (int i = 3; i < OperandFiltersCount; i++)
			{
				if (!OperandFilters[i].Compare(context.GetOperand(i)))
					return false;
			}

			return false;
		}

		public abstract void Transform(Context context, TransformContext transformContext);

		protected static bool ValidateSSAForm(Operand operand)
		{
			return operand.Definitions.Count == 1;
		}

		protected static BaseInstruction GetMove(Operand operand)
		{
			if (operand.IsR4)
				return IRInstruction.MoveFloatR4;
			else if (operand.IsR8)
				return IRInstruction.MoveFloatR8;
			else if (operand.Is64BitInteger)
				return IRInstruction.MoveInt64;
			else
				return IRInstruction.MoveInt32;
		}

		#region Filter Methods

		protected static bool AreSame(Operand operand1, Operand operand2)
		{
			if (operand1.IsVirtualRegister && operand1.IsVirtualRegister && operand1 == operand2)
				return true;

			if (operand1.IsCPURegister && operand1.IsCPURegister && operand1 == operand2)
				return true;

			if (operand1.IsResolvedConstant && operand2.IsResolvedConstant)
			{
				if (operand1.IsInteger && operand1.ConstantUnsigned64 == operand2.ConstantUnsigned64)
					return true;

				if (operand1.IsR4 && operand1.IsR4 && operand1.ConstantDouble == operand2.ConstantDouble)
					return true;

				if (operand1.IsR8 && operand1.IsR8 && operand2.ConstantFloat == operand2.ConstantFloat)
					return true;
			}

			return false;
		}

		protected static bool IsResolvedConstant(Operand operand)
		{
			return operand.IsResolvedConstant;
		}

		protected static bool IsPowerOfTwo32(Operand operand)
		{
			return BitTwiddling.IsPowerOfTwo(operand.ConstantUnsigned32);
		}

		protected static bool IsPowerOfTwo64(Operand operand)
		{
			return BitTwiddling.IsPowerOfTwo(operand.ConstantUnsigned64);
		}

		#endregion Filter Methods

		#region Expression Methods

		protected static uint To32(Operand operand)
		{
			return operand.ConstantUnsigned32;
		}

		protected static ulong To64(Operand operand)
		{
			return operand.ConstantUnsigned64;
		}

		protected static int ToSigned32(Operand operand)
		{
			return operand.ConstantSigned32;
		}

		protected static long ToSigned64(Operand operand)
		{
			return operand.ConstantSigned64;
		}

		protected static uint To32(ulong value)
		{
			return (uint)value;
		}

		protected static ulong To64(ulong value)
		{
			return value;
		}

		protected static double ToDouble(double value)
		{
			return value;
		}

		protected static float ToFloat(float value)
		{
			return value;
		}

		protected static ulong Add(ulong a, ulong b)
		{
			return a + b;
		}

		protected static ulong Sub(ulong a, ulong b)
		{
			return a - b;
		}

		protected static ulong UnsignedMultiple(ulong a, ulong b)
		{
			return a * b;
		}

		protected static ulong UnsignedDivide(ulong a, ulong b)
		{
			return a / b;
		}

		protected static ulong UnsignedMod(ulong a, ulong b)
		{
			return a % b;
		}

		protected static long SignedMultiple(long a, long b)
		{
			return a * b;
		}

		protected static long SignedDivide(long a, long b)
		{
			return a / b;
		}

		protected static long SignedMod(long a, long b)
		{
			return a % b;
		}

		protected static uint GetPowerOfTwo(ulong value)
		{
			return BitTwiddling.GetPowerOfTwo(value);
		}

		protected static uint GetPowerOfTwo(Operand operand)
		{
			return GetPowerOfTwo(operand.ConstantUnsigned64);
		}

		#endregion Expression Methods

		#region SignExtend Helpers

		protected static uint SignExtend8x32(byte value)
		{
			return ((value & 0x80) == 0) ? value : (value | 0xFFFFFF00);
		}

		protected static uint SignExtend16x32(ushort value)
		{
			return ((value & 0x8000) == 0) ? value : (value | 0xFFFF0000);
		}

		protected static ulong SignExtend8x64(byte value)
		{
			return ((value & 0x80) == 0) ? value : (value | 0xFFFFFFFFFFFFFF00ul);
		}

		protected static ulong SignExtend16x64(ushort value)
		{
			return ((value & 0x8000) == 0) ? value : (value | 0xFFFFFFFFFFFF0000ul);
		}

		protected static ulong SignExtend32x64(uint value)
		{
			return ((value & 0x80000000) == 0) ? value : (value | 0xFFFFFFFF00000000ul);
		}

		#endregion SignExtend Helpers
	}
}