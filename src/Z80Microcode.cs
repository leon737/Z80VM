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

namespace Z80VM
{
    public partial class Z80
    {

        #region Add & Adc

        public void opAddA(Operand op)
        {
            rA = alu.opAdd8(rA, alu.Read8BitOperandValue(op)); // !!!!!!!!!!!
        }

        public void opAdcA(Operand op) 
        {
            rA = alu.opAdc8(rA, alu.Read8BitOperandValue(op));
        }

        public void opAdd16(Operand a, Operand b)
        {
            alu.WriteOperandValue(a, alu.opAdd16(alu.Read16BitOperandValue(a), alu.Read16BitOperandValue(b)));
        }

        public void opAdc16(Operand a, Operand b)
        {
            alu.WriteOperandValue(a, alu.opAdc16(alu.Read16BitOperandValue(a), alu.Read16BitOperandValue(b)));
        }
        
        #endregion

        #region And, Or, Xor, Neg

        public void opAndA(Operand op)
        {
            rA =  alu.opAnd8(rA, alu.Read8BitOperandValue(op));
        }

        public void opOrA(Operand op)
        {
            rA = alu.opOr8(rA, alu.Read8BitOperandValue(op));
        }

        public void opXorA(Operand op)
        {
            rA = alu.opXor8(rA, alu.Read8BitOperandValue(op));
        }

        public void opNegA()
        {
            byte t = rA;
            t = alu.opSub8(0, t);
            rA = t;
        }

        #endregion

        #region Bit manipulations

        public void opBit(byte b, Operand r)
        {
            alu.opBit8(b, alu.Read8BitOperandValue(r));
        }

        public void opSet(byte b, Operand r)
        {
            alu.WriteOperandValue(r, alu.opBitSet8(b, alu.Read8BitOperandValue(r)));
        }

        public void opSetId(byte b, Operand r, Operand Id)
        {
            byte result = alu.opBitSet8(b, alu.Read8BitOperandValue(Id));
            if (r.Register != Registers.HL)
                alu.WriteRegister(r.Register, result);
            alu.WriteOperandValue(Id, result);
        }
        
        public void opRes(byte b, Operand r)
        {
            alu.WriteOperandValue(r, alu.opBitRes8(b, alu.Read8BitOperandValue(r)));
        }

        public void opResId(byte b, Operand r, Operand Id)
        {
            byte result = alu.opBitRes8(b, alu.Read8BitOperandValue(Id));
            if (r.Register != Registers.HL)
                alu.WriteRegister(r.Register, result);
            alu.WriteOperandValue(Id, result);
        }

        #endregion

        #region Ccf & Scf

        public void opCcf()
        {       
            fl3 = (rA & Z80.f3) != 0;
            fl5 = (rA & Z80.f5) != 0;
            flH = flC;
            flN = false;
            flC = !flC;
        }

        public void opScf()
        {
            fl3 = (rA & Z80.f3) != 0;
            fl5 = (rA & Z80.f5) != 0;
            flC = true;
            flN = false;
            flH = false;
        }

        #endregion

        #region Compare

        public void opCpA(Operand op)
        {
            alu.opCp8(rA, alu.Read8BitOperandValue(op));
        }
        #endregion

        #region Complement

        public void opCplA()
        {
            rA = alu.opCpl8(rA);
        }

        #endregion

        #region Sub & Sbc

        public void opSubA(Operand op)
        {
            rA = alu.opSub8(rA, alu.Read8BitOperandValue(op));
        }

        public void opSbcA(Operand op)
        {
            rA = alu.opSbc8(rA, alu.Read8BitOperandValue(op));
        }

        public void opSbc16(Operand a, Operand b)
        {
            alu.WriteOperandValue(a, alu.opSbc16(alu.Read16BitOperandValue(a), alu.Read16BitOperandValue(b)));
        }

        #endregion

        #region DAA
        public void opDaa()
        {
            rA = alu.opDaa8(rA);
        }
        #endregion

        #region Inc & Dec

        public void opInc8(Operand op)
        {
            alu.WriteOperandValue(op, alu.opInc8(alu.Read8BitOperandValue(op)));
        }

        public void opDec8(Operand op)
        {
            alu.WriteOperandValue(op, alu.opDec8(alu.Read8BitOperandValue(op)));
        }

        public void opInc16(Operand op)
        {
            alu.WriteOperandValue(op, alu.opInc16(alu.Read16BitOperandValue(op)));
        }

        public void opDec16(Operand op)
        {
            alu.WriteOperandValue(op, alu.opDec16(alu.Read16BitOperandValue(op)));
        }

        #endregion

        #region Exchange

        public void opExAfAf()
        {
            alu.opExAfAf();
        }

        public void opExx()
        {
            alu.opExx();
        }

        public void opEx(Operand op1, Operand op2)
        {
            ushort t = alu.Read16BitOperandValue(op1);
            alu.WriteOperandValue(op1, alu.Read16BitOperandValue(op2));
            alu.WriteOperandValue(op2, t);
        }
        #endregion

        #region Rotate Bits

        public void opRl(Operand op)
        {
            byte a = alu.opRl8(alu.Read8BitOperandValue(op));
            alu.WriteOperandValue(op, a);
            flS = (a & Z80.fS) != 0;
            fl3 = (a & Z80.f3) != 0;
            fl5 = (a & Z80.f5) != 0;
            flN = false;
            flZ = (a == 0);
            flH = false;
            flPV = alu.TestParity(a);
        }

        public void opRlA()
        {
            byte a = alu.opRl8(rA);
            rA = a;
            fl3 = (a & Z80.f3) != 0;
            fl5 = (a & Z80.f5) != 0;
            flN = false;
            flH = false;
        }

        public void opRlId(Operand op, Operand op2)
        {
            opRl(op2);
            if (op.Register != Registers.HL)
                alu.WriteRegister(op.Register, alu.Read8BitOperandValue(op2));
        }

        public void opRlc(Operand op)
        {
            byte a = alu.opRlc8(alu.Read8BitOperandValue(op));
            alu.WriteOperandValue(op, a);
            flS =  (a & Z80.fS) != 0;
            fl3 =  (a & Z80.f3) != 0;
            fl5 =  (a & Z80.f5) != 0;
            flN = false;
            flZ = (a == 0);
            flH = false;
            flPV =  alu.TestParity(a);
        }

        public void opRlcA()
        {
            byte a = alu.opRlc8(rA);
            rA = a;
            fl3 = (a & Z80.f3) != 0;
            fl5 = (a & Z80.f5) != 0;
            flN = false;
            flH = false;
        }

        public void opRlcId(Operand op, Operand op2)
        {
            opRlc(op2);
            if (op.Register != Registers.HL)
                alu.WriteRegister(op.Register, alu.Read8BitOperandValue(op2));
        }
        
        public void opRr(Operand op)
        {
            byte a = alu.opRr8(alu.Read8BitOperandValue(op));
            alu.WriteOperandValue(op, a);
            flS =(a & Z80.fS) != 0;
            fl3 =  (a & Z80.f3) != 0;
            fl5 =  (a & Z80.f5) != 0;
            flN = false;
            flZ = (a == 0);
            flH = false;
            flPV = alu.TestParity(a);
        }

        public void opRrA()
        {
            byte a = alu.opRr8(rA);
            rA = a;
            fl3 = (a & Z80.f3) != 0;
            fl5 = (a & Z80.f5) != 0;
            flN = false;
            flH = false;
        }

        public void opRrId(Operand op, Operand op2)
        {
            opRr(op2);
            if (op.Register != Registers.HL)
                alu.WriteRegister(op.Register, alu.Read8BitOperandValue(op2));
        }        

        public void opRrc(Operand op)
        {
            byte a = alu.opRrc8(alu.Read8BitOperandValue(op));
            alu.WriteOperandValue(op, a);
            flS = (a & Z80.fS) != 0;
            fl3 = (a & Z80.f3) != 0;
            fl5 =  (a & Z80.f5) != 0;
            flN = false;
            flZ =  (a == 0);
            flH = false;
            flPV = alu.TestParity(a);
        }

        public void opRrcA()
        {
            byte a = alu.opRrc8(rA);
            rA = a;
            fl3 = (a & Z80.f3) != 0;
            fl5 = (a & Z80.f5) != 0;
            flN = false;
            flH = false;
        }

        public void opRrcId(Operand op, Operand op2)
        {
            opRrc(op2);
            if (op.Register != Registers.HL)
                alu.WriteRegister(op.Register, alu.Read8BitOperandValue(op2));
        }

        public void opRld()
        {
            byte a = rA;
            byte t = alu.Read8BitMemory(rHL);
            alu.opRld8(ref a, ref t);
            rA = a;
            alu.WriteMemory(rHL, t);
        }

        public void opRrd()
        {
            byte a = rA;
            byte t = alu.Read8BitMemory(rHL);
            alu.opRrd8(ref a, ref t);
            rA = a;
            alu.WriteMemory(rHL, t);
        }

        public void opSla(Operand op)
        {
            byte a = alu.opSla8(alu.Read8BitOperandValue(op));
            alu.WriteOperandValue(op, a);
            flS = (a & Z80.fS) != 0;
            fl3 = (a & Z80.f3) != 0;
            fl5 = (a & Z80.f5) != 0;
            flZ = (a == 0);
            flPV = alu.TestParity(a);
            flN = false;
            flH = false;
        }

        public void opSlaId(Operand op, Operand op2)
        {
            opSla(op2);
            if (op.Register != Registers.HL)
                alu.WriteRegister(op.Register, alu.Read8BitOperandValue(op2));
        }

        public void opSls(Operand op)
        {
            byte a = alu.opSls8(alu.Read8BitOperandValue(op));
            alu.WriteOperandValue(op, a);
            flS = (a & Z80.fS) != 0;
            fl3 = (a & Z80.f3) != 0;
            fl5 = (a & Z80.f5) != 0;
            flZ = (a == 0);
            flPV = alu.TestParity(a);
            flN = false;
            flH = false;
        }

        public void opSlsId(Operand op, Operand op2)
        {
            opSls(op2);
            if (op.Register != Registers.HL)
                alu.WriteRegister(op.Register, alu.Read8BitOperandValue(op2));
        }

        public void opSra(Operand op)
        {
            byte a = alu.opSra8(alu.Read8BitOperandValue(op));
            alu.WriteOperandValue(op, a);
            flS = (a & Z80.fS) != 0;
            fl3 = (a & Z80.f3) != 0;
            fl5 = (a & Z80.f5) != 0;
            flZ = (a == 0);
            flPV = alu.TestParity(a);
            flN = false;
            flH = false;
        }

        public void opSraId(Operand op, Operand op2)
        {
            opSra(op2);
            if (op.Register != Registers.HL)
                alu.WriteRegister(op.Register, alu.Read8BitOperandValue(op2));
        }

        public void opSrl(Operand op)
        {
            byte a = alu.opSrl8(alu.Read8BitOperandValue(op));
            alu.WriteOperandValue(op, a);
            flS = (a & Z80.fS) != 0;
            fl3 = (a & Z80.f3) != 0;
            fl5 = (a & Z80.f5) != 0;
            flZ = (a == 0);
            flPV = alu.TestParity(a);
            flN = false;
            flH = false;
        }

        public void opSrlId(Operand op, Operand op2)
        {
            opSrl(op2);
            if (op.Register != Registers.HL)
                alu.WriteRegister(op.Register, alu.Read8BitOperandValue(op2));
        }
        #endregion

        #region Load data

        public void opLd8(Operand op1, Operand op2)
        {
            alu.WriteOperandValue(op1, alu.Read8BitOperandValue(op2));
        }

        public void opLd16(Operand op1, Operand op2)
        {
            alu.WriteOperandValue(op1, alu.Read16BitOperandValue(op2));
            if (op1.Register == Registers.HL)
            {
                if (rHL == 0x5cd5 && op2.UShortValue == 0x5c65)
                    Console.WriteLine(1);
            }
        }

        public void opLdAI()
        {
            flS = (rI & Z80.fS) != 0;
            fl3 = (rI & Z80.f3) != 0;
            fl5 = (rI & Z80.f5) != 0;
            flZ = (rI == 0);
            flPV = IFF2;
            flH = false;
            flN = false;

            rA = rI;
        }

        public void opLDAR()
        {
            rRTemp = (byte)(rRTemp & 0x7F);
            rA = (byte)((rR & 0x80) | rRTemp);
            flS = (rA & Z80.fS) != 0;
            fl3 = (rA & Z80.f3) != 0;
            fl5 = (rA & Z80.f5) != 0;
            flZ = (rA == 0);
            flPV = IFF2;
            flH = false;
            flN = false;
        }
        #endregion

        #region Push & Pop
   
        public void opPop16(Operand op)
        {
            alu.WriteOperandValue(op, alu.opPop16());
        }

        public void opPush16(Operand op)
        {
            alu.opPush16(alu.Read16BitOperandValue(op));
        }

        public void opPopPC()
        {
            rPC = alu.opPop16();
            if (alu.Read8BitMemory(rPC) == 118) // HALT
                rPC++;
        }

        public void opPushPC()
        {
            alu.opPush16(rPC);
        }

        #endregion

        #region In & Out

        public void opInBC(Operand op)
        {
            byte value = alu.opIn8(rBC);
            alu.WriteOperandValue(op, value);
            flS = (value & Z80.fS) != 0;
            fl3 = (value & Z80.f3) != 0;
            fl5 = (value & Z80.f5) != 0;
            flZ = (value == 0);
            flPV = alu.TestParity(value);
            flN = false;
            flH = false;
        }

        public void opInb(Operand addr, Operand value)
        {
            alu.WriteOperandValue(value, alu.opIn8(alu.Read16BitOperandValue(addr)));
        }

        public void opInb(Operand addr)
        {
            alu.opIn8(alu.Read16BitOperandValue(addr));
        }

        public void opInbA(Operand addr)
        {
            ushort a = alu.MakeUshort(rA, alu.Read8BitOperandValue(addr));
            rA = alu.opIn8(a);
        }

        public void opOutb(Operand addr, Operand value)
        {
            alu.opOut8(alu.Read16BitOperandValue(addr), alu.Read8BitOperandValue(value));
        }

        public void opOutb(Operand addr)
        {
            alu.opOut8(alu.Read16BitOperandValue(addr), 0);
        }

        public void opOutbA(Operand addr)
        {
            ushort a = alu.MakeUshort(rA, alu.Read8BitOperandValue(addr));
            alu.opOut8(a, rA);
        }

        #endregion

        #region Ret

        public void opRetn()
        {
            IFF1 = IFF2;
            opPopPC();
        }

        public void opReti()
        {
            IFF1 = IFF2;
            opPopPC();
        }

        public void opRet()
        {
            opPopPC();
        }

        public void opRetnz()
        {
            if (!flZ)
                opRet();
        }

        public void opRetz()
        {
            if (flZ)
                opRet();
        }

        public void opRetnc()
        {
            if (!flC)
                opRet();
        }

        public void opRetc()
        {
            if (flC)
                opRet();
        }

        public void opRetpe()
        {
            if (!flPV)
                opRet();
        }

        public void opRetpo()
        {
            if (flPV)
                opRet();
        }

        public void opRetp()
        {
            if (!flS)
                opRet();
        }

        public void opRetm()
        {
            if (flS)
                opRet();
        }

        #endregion

        #region Interrupt Mode
        public void opIm0()
        {
            alu.IM = 0;
        }

        public void opIm1()
        {
            alu.IM = 1;
        }

        public void opIm2()
        {
            alu.IM = 2;
        }
        #endregion

        #region LDI, CPI, INI, OUTI
        public void opLdi()
        {
            alu.WriteMemory(rDE, alu.Read8BitMemory(rHL));
            rDE++;
            rHL++;
            rBC--;
            flPV = rBC != 0;
            flH = false;
            flN = false;
        }

        public void opCpi()
        {
            bool c = flC;
            alu.opCp8(rA, alu.Read8BitMemory(rHL));
            rHL++;
            rBC--;
            flPV = rBC != 0;
            flC = c;
        }

        public void opIni()
        {
            alu.WriteMemory(rHL, alu.opIn8(rBC));
            byte b = (byte)(rB - 1);
            rB = b;
            rHL++;
            flZ = b == 0;
            flN = true;
        }

        public void opOuti()
        {
            byte b = (byte)(rB - 1);
            rB = b;
            alu.opOut8(rBC, alu.Read8BitMemory(rHL));
            rHL++;
            flZ = b == 0;
            flN = true;
        }
        #endregion

        #region LDD, CPD, IND, OUTD
        public void opLdd()
        {
            alu.WriteMemory(rDE, alu.Read8BitMemory(rHL));
            rDE--;
            rHL--;
            rBC--;
            flPV = rBC != 0;
            flH = false;
            flN = false;
        }

        public void opCpd()
        {
            bool c = flC;
            alu.opCp8(rA, alu.Read8BitMemory(rHL));
            rHL--;
            rBC--;
            flPV = rBC != 0;
            flC = c;
        }

        public void opInd()
        {
            alu.WriteMemory(rHL, alu.opIn8(rBC));
            byte b = (byte)(rB - 1);
            rB = b;
            rHL--;
            flZ = b == 0;
            flN = true;
        }

        public void opOutd()
        {
            byte b = (byte)(rB - 1);
            rB = b;
            alu.opOut8(rBC, alu.Read8BitMemory(rHL));
            rHL--;
            flZ = b == 0;
            flN = true;
        }
        #endregion

        #region LDIR, CPIR, INIR, OTIR
        public void opLdir2()
        {
            byte b = alu.Read8BitMemory(rHL);
            alu.WriteMemory(rDE, b);

            rHL++;
            rDE++;
            rBC--;
            flH = false;
            flN = false;
            fl3 = (b & Z80.f3) != 0;
            fl3 = (b & Z80.f5) != 0;
            if (rBC != 0)
            {
                rPC -= 2;
                flPV = true;
            }
            else
                flPV = false;
        }

        public void opLdir()
        {
            int count = (int)rBC;
            int dest = (int)rDE;
            int from = (int)rHL;

            do
            {
                alu.WriteMemory((ushort)dest, alu.Read8BitMemory((ushort)from));
                from = (from + 1) & 0xFFFF;
                dest = (dest + 1) & 0xFFFF;
                count--;
            } while (count != 0);

            rPC -= 2;
            flH = false;
            flN = false;
            flPV = true;

            if (count == 0)
            {
                rPC += 2;
                flPV = false;
            }
            rDE = (ushort)dest;
            rHL = (ushort)from;
            rBC = (ushort)count;
        }

        public void opCpir()
        {
            bool c = flC;
            alu.opCp8(rA, alu.Read8BitMemory(rHL));
            rHL++;
            rBC--;
            flC = c;
            c = rBC != 0;
            flPV = c;
            if (flPV && !flZ)
                rPC -= 2;
        }

        public void opInir()
        {
            alu.WriteMemory(rHL, alu.opIn8(rBC));
            byte b = (byte)(rB - 1);
            rB = b;
            rHL++;

            flZ = true;
            flN = true;

            if (b != 0)
                rPC -= 2;
        }

        public void opOtir()
        {
            byte b = (byte)(rB - 1);
            rB = b;
            alu.opOut8(rBC, alu.Read8BitMemory(rHL));
            rHL++;

            flZ = true;
            flN = true;

            if (b != 0)
                rPC -= 2;
        }
        #endregion

        #region LDDR, CPDR, INDR, OTDR
        public void opLddr2()
        {
            byte b = alu.Read8BitMemory(rHL);
            alu.WriteMemory(rDE, b);

            rHL--;
            rDE--;
            rBC--;
            flH = false;
            flN = false;
            fl3 = (b & Z80.f3) != 0;
            fl3 = (b & Z80.f5) != 0;
            if (rBC != 0)
            {
                rPC -= 2;
                flPV = true;
            }
            else
                flPV = false;
        }


        public void opLddr()
        {
            int count = (int)rBC;
            int dest = (int)rDE;
            int from = (int)rHL;

            do
            {
                alu.WriteMemory((ushort)dest, alu.Read8BitMemory((ushort)from));
                from = (from - 1) & 0xFFFF;
                dest = (dest - 1) & 0xFFFF;
                count--;
            } while (count != 0);

            rPC -= 2;
            flH = false;
            flN = false;
            flPV = true;

            if (count == 0)
            {
                rPC += 2;
                flPV = false;
            }
            rDE = (ushort)dest;
            rHL = (ushort)from;
            rBC = (ushort)count;
        }

        public void opCpdr()
        {
            bool c = flC;
            alu.opCp8(rA, alu.Read8BitMemory(rHL));
            rHL++;
            rBC--;
            flC = c;
            c = rBC != 0;
            flPV = c;

            if (flPV && !flZ)
                rPC -= 2;
        }


        public void opIndr()
        {
            alu.WriteMemory(rHL, alu.opIn8(rBC));
            byte b = (byte)(rB - 1);
            rB = b;
            rHL--;

            flZ = true;
            flN = true;

            if (b != 0)
                rPC -= 2;
        }

        public void opOtdr()
        {
            byte b = (byte)(rB - 1);
            rB = b;
            alu.opOut8(rBC, alu.Read8BitMemory(rHL));
            rHL--;

            flZ = true;
            flN = true;

            if (b != 0)
                rPC -= 2;
        }

        #endregion

        #region Jump

        public void opJp(Operand op)
        {
            rPC = alu.Read16BitOperandValue(op);
        }

        public void opDjnz(Operand op)
        {
            rB = alu.opDec8(rB);
            if (rB != 0)
            {
                rPC = alu.Read16BitOperandValue(op);
            }
        }

        public void opJpnz(Operand op)
        {
            if (!flZ)
                opJp(op);
        }

        public void opJpz(Operand op)
        {
            if (flZ)
                opJp(op);
        }

        public void opJpnc(Operand op)
        {
            if (!flC)
                opJp(op);
        }

        public void opJpc(Operand op)
        {
            if (flC)
                opJp(op);
        }

        public void opJpo(Operand op)
        {
            if (!flPV)
                opJp(op);
        }

        public void opJpe(Operand op)
        {
            if (flPV)
                opJp(op);
        }

        public void opJpp(Operand op)
        {
            if (!flS)
                opJp(op);
        }

        public void opJpm(Operand op)
        {
            if (flS)
                opJp(op);
        }

        #endregion

        #region Call

        public void opCall(Operand op)
        {
            opPushPC();
            rPC = alu.Read16BitOperandValue(op);
        }

        public void opCallnz(Operand op)
        {
            if (!flZ)
                opCall(op);
        }

        public void opCallz(Operand op)
        {
            if (flZ)
                opCall(op);
        }

        public void opCallnc(Operand op)
        {
            if (!flC)
                opCall(op);
        }

        public void opCallc(Operand op)
        {
            if (flC)
                opCall(op);
        }

        public void opCallpe(Operand op)
        {
            if (!flPV)
                opCall(op);
        }

        public void opCallpo(Operand op)
        {
            if (flPV)
                opCall(op);
        }

        public void opCallp(Operand op)
        {
            if (!flS)
                opCall(op);
        }

        public void opCallm(Operand op)
        {
            if (flS)
                opCall(op);
        }

        #endregion

        #region Nop
        public void opNop()
        {

        }
        #endregion

        #region Halt

        public void opHalt()
        {
            rPC--;
        }

        #endregion

        #region DI & EI

        public void opDi()
        {
            alu.IFF1 = false;
            alu.IFF2 = false;
        }

        public void opEi()
        {
            alu.IFF1 = true;
            alu.IFF2 = true;
        }

        #endregion

        #region Restart

        public void opRst(ushort op)
        {
            opPushPC();
            rPC = op;
        }

        #endregion

    }

}
