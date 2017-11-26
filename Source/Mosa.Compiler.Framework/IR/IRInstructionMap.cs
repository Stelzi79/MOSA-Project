﻿// Copyright (c) MOSA Project. Licensed under the New BSD License.

// This code was generated by an automated template.

using System.Collections.Generic;

namespace Mosa.Compiler.Framework.IR
{
	/// <summary>
	/// IR Instruction Map
	/// </summary>
	public static class IRInstructionMap
	{
		public static readonly Dictionary<string,BaseIRInstruction> Map = new Dictionary<string, BaseIRInstruction>() {
			{ "AddFloatR4", IRInstruction.AddFloatR4 },
			{ "AddFloatR8", IRInstruction.AddFloatR8 },
			{ "AddressOf", IRInstruction.AddressOf },
			{ "AddSigned", IRInstruction.AddSigned },
			{ "AddUnsigned", IRInstruction.AddUnsigned },
			{ "ArithmeticShiftRight", IRInstruction.ArithmeticShiftRight },
			{ "BlockEnd", IRInstruction.BlockEnd },
			{ "BlockStart", IRInstruction.BlockStart },
			{ "Break", IRInstruction.Break },
			{ "Call", IRInstruction.Call },
			{ "CallDirect", IRInstruction.CallDirect },
			{ "CallDynamic", IRInstruction.CallDynamic },
			{ "CallInterface", IRInstruction.CallInterface },
			{ "CallStatic", IRInstruction.CallStatic },
			{ "CallVirtual", IRInstruction.CallVirtual },
			{ "CompareFloatR4", IRInstruction.CompareFloatR4 },
			{ "CompareFloatR8", IRInstruction.CompareFloatR8 },
			{ "CompareInteger", IRInstruction.CompareInteger },
			{ "CompareIntegerBranch", IRInstruction.CompareIntegerBranch },
			{ "ConversionFloatR4ToFloatR8", IRInstruction.ConversionFloatR4ToFloatR8 },
			{ "ConversionFloatR4ToInteger", IRInstruction.ConversionFloatR4ToInteger },
			{ "ConversionFloatR8ToFloatR4", IRInstruction.ConversionFloatR8ToFloatR4 },
			{ "ConversionFloatR8ToInteger", IRInstruction.ConversionFloatR8ToInteger },
			{ "ConversionIntegerToFloatR4", IRInstruction.ConversionIntegerToFloatR4 },
			{ "ConversionIntegerToFloatR8", IRInstruction.ConversionIntegerToFloatR8 },
			{ "DivFloatR4", IRInstruction.DivFloatR4 },
			{ "DivFloatR8", IRInstruction.DivFloatR8 },
			{ "DivSigned", IRInstruction.DivSigned },
			{ "DivUnsigned", IRInstruction.DivUnsigned },
			{ "Epilogue", IRInstruction.Epilogue },
			{ "ExceptionEnd", IRInstruction.ExceptionEnd },
			{ "ExceptionStart", IRInstruction.ExceptionStart },
			{ "FilterEnd", IRInstruction.FilterEnd },
			{ "FilterStart", IRInstruction.FilterStart },
			{ "FinallyEnd", IRInstruction.FinallyEnd },
			{ "FinallyStart", IRInstruction.FinallyStart },
			{ "Flow", IRInstruction.Flow },
			{ "Gen", IRInstruction.Gen },
			{ "GotoLeaveTarget", IRInstruction.GotoLeaveTarget },
			{ "IntrinsicMethodCall", IRInstruction.IntrinsicMethodCall },
			{ "IsInstanceOfType", IRInstruction.IsInstanceOfType },
			{ "IsInstanceOfInterfaceType", IRInstruction.IsInstanceOfInterfaceType },
			{ "Jmp", IRInstruction.Jmp },
			{ "Kill", IRInstruction.Kill },
			{ "KillAll", IRInstruction.KillAll },
			{ "KillAllExcept", IRInstruction.KillAllExcept },
			{ "LoadCompound", IRInstruction.LoadCompound },
			{ "LoadFloatR4", IRInstruction.LoadFloatR4 },
			{ "LoadFloatR8", IRInstruction.LoadFloatR8 },
			{ "LoadInteger", IRInstruction.LoadInteger },
			{ "LoadSignExtended", IRInstruction.LoadSignExtended },
			{ "LoadZeroExtended", IRInstruction.LoadZeroExtended },
			{ "LoadParameterCompound", IRInstruction.LoadParameterCompound },
			{ "LoadParameterFloatR4", IRInstruction.LoadParameterFloatR4 },
			{ "LoadParameterFloatR8", IRInstruction.LoadParameterFloatR8 },
			{ "LoadParameterInteger", IRInstruction.LoadParameterInteger },
			{ "LoadParameterSignExtended", IRInstruction.LoadParameterSignExtended },
			{ "LoadParameterZeroExtended", IRInstruction.LoadParameterZeroExtended },
			{ "LogicalAnd", IRInstruction.LogicalAnd },
			{ "LogicalNot", IRInstruction.LogicalNot },
			{ "LogicalOr", IRInstruction.LogicalOr },
			{ "LogicalXor", IRInstruction.LogicalXor },
			{ "MemorySet", IRInstruction.MemorySet },
			{ "MoveCompound", IRInstruction.MoveCompound },
			{ "MoveFloatR4", IRInstruction.MoveFloatR4 },
			{ "MoveFloatR8", IRInstruction.MoveFloatR8 },
			{ "MoveInteger", IRInstruction.MoveInteger },
			{ "MoveSignExtended", IRInstruction.MoveSignExtended },
			{ "MoveZeroExtended", IRInstruction.MoveZeroExtended },
			{ "MulFloatR4", IRInstruction.MulFloatR4 },
			{ "MulFloatR8", IRInstruction.MulFloatR8 },
			{ "MulSigned", IRInstruction.MulSigned },
			{ "MulUnsigned", IRInstruction.MulUnsigned },
			{ "NewArray", IRInstruction.NewArray },
			{ "NewObject", IRInstruction.NewObject },
			{ "NewString", IRInstruction.NewString },
			{ "Nop", IRInstruction.Nop },
			{ "Phi", IRInstruction.Phi },
			{ "Prologue", IRInstruction.Prologue },
			{ "RemFloatR4", IRInstruction.RemFloatR4 },
			{ "RemFloatR8", IRInstruction.RemFloatR8 },
			{ "RemSigned", IRInstruction.RemSigned },
			{ "RemUnsigned", IRInstruction.RemUnsigned },
			{ "SetReturn", IRInstruction.SetReturn },
			{ "SetLeaveTarget", IRInstruction.SetLeaveTarget },
			{ "ShiftLeft", IRInstruction.ShiftLeft },
			{ "ShiftRight", IRInstruction.ShiftRight },
			{ "StableObjectTracking", IRInstruction.StableObjectTracking },
			{ "StoreCompound", IRInstruction.StoreCompound },
			{ "StoreFloatR4", IRInstruction.StoreFloatR4 },
			{ "StoreFloatR8", IRInstruction.StoreFloatR8 },
			{ "StoreInteger", IRInstruction.StoreInteger },
			{ "StoreParameterCompound", IRInstruction.StoreParameterCompound },
			{ "StoreParameterFloatR4", IRInstruction.StoreParameterFloatR4 },
			{ "StoreParameterFloatR8", IRInstruction.StoreParameterFloatR8 },
			{ "StoreParameterInteger", IRInstruction.StoreParameterInteger },
			{ "SubFloatR4", IRInstruction.SubFloatR4 },
			{ "SubFloatR8", IRInstruction.SubFloatR8 },
			{ "SubSigned", IRInstruction.SubSigned },
			{ "SubUnsigned", IRInstruction.SubUnsigned },
			{ "Switch", IRInstruction.Switch },
			{ "Throw", IRInstruction.Throw },
			{ "TryEnd", IRInstruction.TryEnd },
			{ "TryStart", IRInstruction.TryStart },
			{ "UnstableObjectTracking", IRInstruction.UnstableObjectTracking },
			{ "Rethrow", IRInstruction.Rethrow },
			{ "GetVirtualFunctionPtr", IRInstruction.GetVirtualFunctionPtr },
			{ "MemoryCopy", IRInstruction.MemoryCopy },
			{ "Box", IRInstruction.Box },
			{ "Box32", IRInstruction.Box32 },
			{ "Box64", IRInstruction.Box64 },
			{ "BoxR4", IRInstruction.BoxR4 },
			{ "BoxR8", IRInstruction.BoxR8 },
			{ "Unbox", IRInstruction.Unbox },
			{ "Unbox32", IRInstruction.Unbox32 },
			{ "Unbox64", IRInstruction.Unbox64 },
			{ "To64", IRInstruction.To64 },
			{ "Split64", IRInstruction.Split64 },
		};
	}
}