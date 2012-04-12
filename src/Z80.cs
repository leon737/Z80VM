/* 
    Z80 Virtual Machine
    Copyright (C) 2008 - 2012 Leonid Gordo

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.Collections.Generic;

namespace Z80VM
{

    public struct stack_item
    {
        public ushort sp;
        public ushort caller_pc;
        public ushort target_pc;
        public ushort what;
    }

    public enum Registers
    {
        A, B, C, D, E, HL, BC, DE, IX, IY, SP, PC, I, R, M, F, AF, H, L, HX, LX, HY, LY
    }

    public enum Flags
    {
        C = 0,N = 1,PV = 2,f3 = 3,H = 4,f5 = 5,Z = 6,S = 7
    }

    public partial class Z80:System.MarshalByRefObject 
    {


        public void Test()
        {
            byte a, b;
            a = alu.opSra8(0x80);
        }


        #region Constructor
        public Z80(Z80Model model)
        {
            this.model = model;
            alu = new Z80ALU(this);
            initParity();
        }
        #endregion

        #region Local variables
        // system components model
        public Z80Model model;

        // ALU
        public Z80ALU alu;
        
        // general registers
        byte rA, rB, rC, rD, rE;
        // alternate registers
        byte rA_, rB_, rC_, rD_, rE_;
        // special registers
        ushort rHL, rHL_;

        // index registers
        ushort rIX, rIY;

        // stack pointer and program counter
        ushort rSP, rPC;

        // interrupt registers and flip-flops, and refresh registers
        byte rI, rR, rM, rRTemp;
        bool IFF1, IFF2;

        // interrupt mode
        int iM;

        // flags
        byte rF, rF_;

        public const int fC = 0x01;
        public const int fN = 0x02;
        public const int fPV = 0x04;
        public const int f3 = 0x08;
        public const int fH = 0x10;
        public const int f5 = 0x20;
        public const int fZ = 0x40;
        public const int fS = 0x80;

        #endregion

        #region Precalculated parity

        private bool[] _parity = new bool[256];

        public void initParity () 
        {
            int lCounter;
		    byte j;
		    bool p;
            for (lCounter = 0; lCounter < 256; lCounter++)
            {
                p = true;
                for (j = 0; j < 8; j++)
                    if ((lCounter & ((int)(Math.Pow(2, j)))) != 0) p = !p;
                _parity[lCounter] = p;
            }
        }

        #endregion

        #region Registers accessors

        public ushort rBC
        {
            get { return alu.MakeUshort(rB, rC); }
            set {
                rB = (byte)((value >> 8) & 0xFF);
                rC = (byte)(value & 0xFF);
            }
        }

        public ushort rDE
        {
            get { return alu.MakeUshort(rD, rE); }
            set
            {
                rD = (byte)((value >> 8) & 0xFF);
                rE = (byte)(value & 0xFF);
            }
        }

        public ushort rAF
        {
            get { return alu.MakeUshort(rA, rF); }
            set
            {
                rA = (byte)((value >> 8) & 0xFF);
                rF = (byte)(value & 0xFF);
            }
        }

        public byte rH
        {
            get { return (byte)((rHL >> 8) & 0xFF); }
            set {
                rHL = (ushort)(rHL & 0xFF | (value << 8));
            }
        }

        public byte rL
        {
            get { return (byte)(rHL & 0xFF); }
            set
            {
                rHL = (ushort)(rHL & 0xFF00 | value);
            }
        }


        public byte rHX
        {
            get { return (byte)((rIX >> 8) & 0xFF); }
            set
            {
                rIX = (ushort)(rIX & 0xFF | (value << 8));
            }
        }

        public byte rLX
        {
            get { return (byte)(rIX & 0xFF); }
            set
            {
                rIX = (ushort)(rIX & 0xFF00 | value);
            }
        }

        public byte rHY
        {
            get { return (byte)((rIY >> 8) & 0xFF); }
            set
            {
                rIY = (ushort)(rIY & 0xFF | (value << 8));
            }
        }

        public byte rLY
        {
            get { return (byte)(rIY & 0xFF); }
            set
            {
                rIY = (ushort)(rIY & 0xFF00 | value);
            }
        }
        #endregion

        #region Flags accessors
        public bool flC
        {
            get { return alu.TestFlag(Flags.C); }
            set { alu.SetFlag(Flags.C, value); }
        }

        public bool flN
        {
            get { return alu.TestFlag(Flags.N); }
            set { alu.SetFlag(Flags.N, value); }
        }

        public bool flPV
        {
            get { return alu.TestFlag(Flags.PV); }
            set { alu.SetFlag(Flags.PV, value); }
        }

        public bool fl3
        {
            get { return alu.TestFlag(Flags.f3); }
            set { alu.SetFlag(Flags.f3, value); }
        }

        public bool flH
        {
            get { return alu.TestFlag(Flags.H); }
            set { alu.SetFlag(Flags.H, value); }
        }

        public bool fl5
        {
            get { return alu.TestFlag(Flags.f5); }
            set { alu.SetFlag(Flags.f5, value); }
        }

        public bool flZ
        {
            get { return alu.TestFlag(Flags.Z); }
            set { alu.SetFlag(Flags.Z, value); }
        }

        public bool flS
        {
            get { return alu.TestFlag(Flags.S); }
            set { alu.SetFlag(Flags.S, value); }
        }

        #endregion

        public Stack<stack_item> stackCheck = new Stack<stack_item>();

        private ushort pppp = 0;       

        #region Fetch And Compose Operands Instructions

        public byte Fetch () 
        {
            return model.MemoryManager.ReadByte(rPC++);
        }

        public Operand FetchRelative () 
        {
            Operand op = new Operand();
            op.AddressingMode= OperandAddressingMode.Relative;
            op.ByteValue = model.MemoryManager.ReadByte(rPC++);
            return op;
        }

        public Operand FetchImmediateByte()
        {
            Operand op = new Operand();
            op.AddressingMode = OperandAddressingMode.Immediate;
            op.OperandSize = 2;
            op.ByteValue = model.MemoryManager.ReadByte(rPC++);
            return op;
        }

        public Operand FetchImmediateWord()
        {
            Operand op = new Operand();
            op.AddressingMode = OperandAddressingMode.ImmediateExt;
            op.OperandSize = 4;
            op.UShortValue = model.MemoryManager.ReadWord(rPC);
            rPC += 2;
            return op;
        }

        public Operand ComposeImmediateIndirectWord () 
        {
            Operand op = FetchImmediateWord();
            op.AddressingMode = OperandAddressingMode.ImmediateIndirect;
            return op;
        }

        public Operand ComposeRegister(Registers r)
        {
            Operand op = new Operand();
            op.AddressingMode = OperandAddressingMode.Register;
            op.Register = r;
            return op;
        }

         public Operand ComposeRegisterHi(Registers r)
        {
            Operand op = new Operand();
            op.AddressingMode = OperandAddressingMode.Register;
            if (r == Registers.IX) 
                op.Register = Registers.HX;
            else
                op.Register = Registers.HY;
            return op;
        }

        public Operand ComposeRegisterLo(Registers r)
        {
            Operand op = new Operand();
            op.AddressingMode = OperandAddressingMode.Register;
            if (r == Registers.IX) 
                op.Register = Registers.LX;
            else
                op.Register = Registers.LY;
            return op;
        }

        public Operand ComposeRegisterIndirect(Registers r)
        {
            Operand op = new Operand();
            op.AddressingMode = OperandAddressingMode.Indirect;
            op.Register = r;
            return op;
        }

        public Operand ComposeIndexIndirect (Registers r) 
        {
            Operand op = FetchImmediateByte();
            op.AddressingMode = OperandAddressingMode.IndexImmediate;
            op.IndexRegister = r;
            return op;
        }

        #endregion

        int interruptCounter = 0;
        
        public void Interrupt()
        {
            if (bHalt) return;
            interruptCounter++;

            if (interruptCounter % 16 == 0)
                Program.video.RefreshFlashChars();

            if (IFF1 == false) return;
            switch (iM)
            {
                case 0:
                case 1:
                    opPushPC();
                    rPC = 56;
                    break;
            }

        }

        bool bHalt = false;

        public void Reset()
        {
            this.rPC = 0;
            this.rSP = 0xFFFF;
            this.rAF = 0;
            opDi();
            bHalt = false;
        }

        public void Halt()
        {
            bHalt = true;
        }

        public void Resume()
        {
            bHalt = false;
        }

     
    }
}
