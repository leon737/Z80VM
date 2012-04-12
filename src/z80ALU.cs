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

namespace Z80VM
{
    public partial class Z80 {
        public class Z80ALU
        {
            Z80 proc;

            public Z80ALU(Z80 proc) { this.proc = proc; }

            #region Read & Write Registers
            public byte Read8BitRegister(Registers r)
            {
                switch (r)
                {
                    case Registers.A:   return proc.rA;
                    case Registers.B:   return proc.rB;
                    case Registers.C:   return proc.rC;
                    case Registers.D:   return proc.rD;
                    case Registers.E:   return proc.rE;
                    case Registers.F:   return proc.rF;
                    case Registers.I:   return proc.rI;
                    case Registers.M:   return proc.rM;
                    case Registers.R:   return proc.rR;
                    case Registers.H:   return proc.rH;
                    case Registers.L:   return proc.rL;
                    case Registers.HX:  return proc.rHX;
                    case Registers.HY:  return proc.rHY;
                    case Registers.LX:  return proc.rLX;
                    case Registers.LY:  return proc.rLY;
                    default:
                        throw new InvalidOperandSizeException(r.ToString() + " is not 8 bit register");
                }
            }

            public ushort Read16BitRegister(Registers r)
            {
                switch (r)
                {
                    case Registers.BC:  return proc.rBC;
                    case Registers.DE:  return proc.rDE;
                    case Registers.HL:  return proc.rHL;
                    case Registers.IX:  return proc.rIX;
                    case Registers.IY:  return proc.rIY;
                    case Registers.PC:  return proc.rPC;
                    case Registers.SP:  return proc.rSP;
                    case Registers.AF:  return proc.rAF;
                    default:
                        throw new InvalidOperandSizeException(r.ToString() + " is not 16 bit register");
                }
            }

            public void WriteRegister(Registers r, byte value)
            {
                switch (r)
                {
                    case Registers.A:   proc.rA = value; break;
                    case Registers.B:   proc.rB = value; break;
                    case Registers.C:   proc.rC = value; break;
                    case Registers.D:   proc.rD = value; break;
                    case Registers.E:   proc.rE = value; break;
                    case Registers.F:   proc.rF = value; break;
                    case Registers.I:   proc.rI = value; break;
                    case Registers.M:   proc.rM = value; break;
                    case Registers.R:   proc.rR = value; break;
                    case Registers.H:   proc.rH = value; break;
                    case Registers.L:   proc.rL = value; break;
                    case Registers.HX:  proc.rHX = value; break;
                    case Registers.HY:  proc.rHY = value; break;
                    case Registers.LX:  proc.rLX = value; break;
                    case Registers.LY:  proc.rLY = value; break;
                    default:
                        throw new InvalidOperandSizeException(r.ToString() + " is not 8 bit register");
                }
            }

            public void WriteRegister(Registers r, ushort value)
            {
                switch (r)
                {
                    case Registers.BC:  proc.rBC = value; break;
                    case Registers.DE:  proc.rDE = value; break;
                    case Registers.HL:  proc.rHL = value; break;
                    case Registers.IX:  proc.rIX = value; break;
                    case Registers.IY:  proc.rIY = value; break;
                    case Registers.PC:  proc.rPC = value; break;
                    case Registers.SP:  proc.rSP = value; break;
                    case Registers.AF:  proc.rAF = value; break;
                    default:
                        throw new InvalidOperandSizeException(r.ToString() + " is not 16 bit register");
                }
            }

            #endregion

            #region Read & Write Memory
            public byte Read8BitMemory(ushort addr) { return proc.model.MemoryManager.ReadByte(addr); }

            public ushort Read16BitMemory(ushort addr) { return proc.model.MemoryManager.ReadWord(addr); }

            public void WriteMemory(ushort addr, byte value) { proc.model.MemoryManager.Write(addr, value); }

            public void WriteMemory(ushort addr, ushort value) { proc.model.MemoryManager.Write(addr, value); }

            #endregion

            #region Read & Write Operands
            public byte Read8BitOperandValue(Operand operand)
            {
                switch (operand.AddressingMode)
                {
                    case OperandAddressingMode.Immediate:
                        return operand.ByteValue;
                    case OperandAddressingMode.Register:
                        return Read8BitRegister(operand.Register);
                    case OperandAddressingMode.Indirect:
                        return Read8BitMemory(Read16BitRegister(operand.Register));
                    case OperandAddressingMode.IndexImmediate:
                        return Read8BitMemory((ushort)(Read16BitRegister(operand.IndexRegister) + (sbyte)(operand.ByteValue)));
                    case OperandAddressingMode.ImmediateIndirect:
                        return Read8BitMemory(operand.UShortValue);
                    default:
                        throw new InvalidOperandSizeException("Operand is not 8 bit value");
                }
            }

            public ushort Read16BitOperandValue(Operand operand)
            {
                switch (operand.AddressingMode)
                {
                    case OperandAddressingMode.ImmediateExt:
                        return operand.UShortValue;
                    case OperandAddressingMode.Register:
                        return Read16BitRegister(operand.Register);
                    case OperandAddressingMode.Indirect:
                        return Read16BitMemory(Read16BitRegister(operand.Register));
                    case OperandAddressingMode.IndexImmediate:
                        return Read16BitMemory((ushort)(Read16BitRegister(operand.IndexRegister) + (sbyte)(operand.ByteValue)));
                    case OperandAddressingMode.Relative:
                        return (ushort)(proc.rPC + (sbyte)operand.ByteValue);
                    case OperandAddressingMode.ImmediateIndirect:
                        return Read16BitMemory(operand.UShortValue);
                    default:
                        throw new InvalidOperandSizeException("Operand is not 16 bit value");
                }
            }

            public void WriteOperandValue(Operand operand, byte value)
            {
                switch (operand.AddressingMode)
                {
                    case OperandAddressingMode.Register:
                        WriteRegister(operand.Register, value);
                        break;
                    case OperandAddressingMode.Indirect:
                        WriteMemory(Read16BitRegister(operand.Register), value);
                        break;
                    case OperandAddressingMode.IndexImmediate:
                        WriteMemory((ushort)(Read16BitRegister(operand.IndexRegister) + (sbyte)(operand.ByteValue)), value);
                        break;
                    case OperandAddressingMode.ImmediateIndirect:
                        WriteMemory(operand.UShortValue, value);
                        break;
                    default:
                        throw new InvalidAddressingModeException();
                }
            }

            public void WriteOperandValue(Operand operand, ushort value)
            {
                switch (operand.AddressingMode)
                {
                    case OperandAddressingMode.Register:
                        WriteRegister(operand.Register, value);
                        break;
                    case OperandAddressingMode.Indirect:
                        WriteMemory(Read16BitRegister(operand.Register), value);
                        break;
                    case OperandAddressingMode.IndexImmediate:
                        WriteMemory((ushort)(Read16BitRegister(operand.IndexRegister) + (sbyte)(operand.ByteValue)), value);
                         break;
                     case OperandAddressingMode.ImmediateIndirect:
                         WriteMemory(operand.UShortValue, value);
                         break;
                    default:
                        throw new InvalidAddressingModeException();
                }
            }
            #endregion

            #region Auxiliary routines
            public ushort MakeUshort(byte hibyte, byte lobyte)
            {
                return (ushort)(((int)hibyte) << 8 | (int)lobyte);
            }

            public void SplitUshort (ushort value, ref byte hibyte, ref byte lobyte) 
            {
                hibyte = GetHiByte(value);
                lobyte = GetLoByte(value);
            }

            public byte GetHiByte(ushort value)
            {
                return (byte)((value >> 8) & 0xFF);
            }

            public byte GetLoByte(ushort value)
            {
                return (byte)(value & 0xFF);
            }

            byte SetBit(byte value, int bit, bool bitValue)
            {
                return bitValue?SetBit(value, bit):ResetBit(value, bit);
            }

            byte SetBit(byte value, int bit)
            {
                return (byte)(value | (1 << bit));
            }

            byte ResetBit(byte value, int bit)
            {
                return (byte)(value & (~(1 << bit)));
            }

            byte InverseBit(byte value, int bit)
            {
                return (byte)(value ^ (1 << bit));
            }

            bool TestBit(byte value, int bit)
            {
                return (value & (1 << bit))!=0;
            }

            public void SetFlag(Flags flag, bool value)
            {
                proc.rF = SetBit(proc.rF, (int)flag, value);
            }

            public void SetFlag(Flags flag)
            {
                proc.rF = SetBit(proc.rF, (int)flag);
            }

            public void ResetFlag(Flags flag)
            {
                proc.rF = ResetBit(proc.rF, (int)flag);
            }

            public bool TestFlag(Flags flag)
            {
                return TestBit(proc.rF, (int)flag);
            }

            public bool TestParity(byte value)
            {
                return proc._parity[value];
            }
            #endregion

            #region IFF1, IFF2, IM accessors
            public bool IFF1
            {
                get { return proc.IFF1; }
                set { proc.IFF1 = value; }
            }

            public bool IFF2
            {
                get { return proc.IFF2; }
                set { proc.IFF2 = value; }
            }

            public int IM
            {
                get { return proc.iM; }
                set { proc.iM = value; }
            }
            #endregion

            #region Add & Adc

            public byte opAdd8(byte a, byte b)
            {
                int v1 = (int)a;
                int v2 = (int)b;
                int r = v1 + v2;
                byte rb = (byte)r;
                proc.flS = (rb & Z80.fS) != 0;
                proc.fl3 = (rb & Z80.f3) != 0;
                proc.fl5 = (rb & Z80.f5) != 0;
                proc.flH = (((v1 & 0xF) + (v2 & 0xF)) & Z80.fH) != 0;
                proc.flPV = ((v1 ^ ((~v2) & 0xFFFF)) & (v1 ^ rb) & 0x80) != 0;
                proc.flZ = (rb == 0);
                proc.flN = false;
                proc.flC = (r & 0x100) != 0;
                return rb;
            }

            public byte opAdc8(byte a, byte b)
            {
                int c = proc.flC ? 1 : 0;
                int v1 = (int)a;
                int v2 = (int)b;
                int r = v1 + v2 + c;
                byte rb = (byte)r;
                proc.flS = (rb & Z80.fS) != 0;
                proc.fl3 = (rb & Z80.f3) != 0;
                proc.fl5 = (rb & Z80.f5) != 0;
                proc.flH = (((v1 & 0xF) + (v2 & 0xF) + c) & Z80.fH) != 0;
                proc.flPV = ((v1 ^ ((~v2) & 0xFFFF)) & (v1 ^ rb) & 0x80) != 0;
                proc.flZ = (rb == 0);
                proc.flN = false;
                proc.flC = (r & 0x100) != 0;
                return rb;
            }

            public ushort opAdd16(ushort a, ushort b)
            {
                int v1 = (int)a;
                int v2 = (int)b;
                int r = v1 + v2;
                ushort rw = (ushort)r;
                proc.fl3 = (rw & (Z80.f3 * 256)) != 0;
                proc.fl5 = (rw & (Z80.f5 * 256)) != 0;
                proc.flH = (((v1 & 0xFFF) + (v2 & 0xFFF)) & 0x1000) != 0;
                proc.flN = false;
                proc.flC = (r & 0x10000) != 0;
                return rw;
            }
            
            public ushort opAdc16(ushort a, ushort b)
            {
                int c = proc.flC ? 1 : 0;
                int v1 = (int)a;
                int v2 = (int)b;
                int r = v1 + v2 + c;
                ushort rw = (ushort)r;
                proc.flS = (rw & (Z80.fS * 256)) != 0;
                proc.fl3 = (rw & (Z80.f3 * 256)) != 0;
                proc.fl5 = (rw & (Z80.f5 * 256)) != 0;
                proc.flH = (((v1 & 0xFFF) + (v2 & 0xFFF) + c) & 0x1000) != 0;
                proc.flPV = ((v1 ^ ((~v2) & 0xFFFF)) & (v1 ^ rw) & 0x8000) != 0;
                proc.flZ = (rw == 0);
                proc.flN = false;
                proc.flC = (r & 0x10000) != 0;
                return rw;
            }
            #endregion

            #region Sub & Sbc

            public byte opSub8(byte a, byte b)
            {
                int va = (int)a;
                int vb = (int)b;
                int wans = a - b;
                byte ans = (byte)wans;
                proc.flS = (ans & Z80.fS) != 0;
                proc.fl3 = (ans & Z80.f3) != 0;
                proc.fl5 = (ans & Z80.f5) != 0;
                proc.flN = true;
                proc.flZ = (ans == 0);
                proc.flC = (wans & 0x100) != 0;
                proc.flH = (((a & 0xF) - (b & 0xF)) & Z80.fH) != 0;
                proc.flPV = ((a ^ b) & (a ^ ans) & 0x80) != 0;
                return ans;
            }

            public byte opSbc8(byte a, byte b)
            {
                int va = (int)a;
                int vb = (int)b;
                int c = TestFlag(Flags.C) ? 1 : 0;

                int wans = va - vb - c;
                byte ans = (byte)wans;
                proc.flS = (ans & Z80.fS) != 0;
                proc.fl3 = (ans & Z80.f3) != 0;
                proc.fl5 = (ans & Z80.f5) != 0;
                proc.flN = true;
                proc.flZ = (ans == 0);
                proc.flC = (wans & 0x100) != 0;
                proc.flPV = ((a ^ b) & (a ^ ans) & 0x80) != 0;
                proc.flH = (((a & 0xF) - (b & 0xF)) & Z80.fH) != 0;
                return ans;
            }

            public ushort opSbc16(ushort a, ushort b)
            {
                int va = (int)a;
                int vb = (int)b;
                int c = TestFlag(Flags.C) ? 1 : 0;

                int lans = a - b - c;
                ushort ans = (ushort)lans;
                proc.flS = (ans & (Z80.fS * 256)) != 0;
                proc.fl3 = (ans & (Z80.f3 * 256)) != 0;
                proc.fl5 = (ans & (Z80.f5 * 256)) != 0;
                proc.flN = true;
                proc.flZ = (ans == 0);
                proc.flC = (lans & 0x10000) != 0;
                proc.flPV = ((a ^ b) & (a ^ ans) & 0x8000) != 0;
                proc.flH = (((a & 0xFFF) - (b & 0xFFF)) & 0x1000) != 0;
                return ans;
            }

            #endregion

            #region And, Or, Xor
            public byte opAnd8(byte a, byte b) 
            {
                byte r = (byte)(a & b);
                proc.flS =  (r & Z80.fS) != 0;
                proc.fl3 =  (r & Z80.f3) != 0;
                proc.fl5 =  (r & Z80.f5) != 0;
                proc.flH = true;
                proc.flPV =  TestParity(r);
                proc.flZ =  (r == 0);
                proc.flN = false;
                proc.flC = false;
                return r;
            }

            public byte opOr8(byte a, byte b)
            {
                a = (byte)(a | b);
                proc.flS = (a & Z80.fS) != 0;
                proc.fl3 = (a & Z80.f3) != 0;
                proc.fl5 = (a & Z80.f5) != 0;
                proc.flH = false;
                proc.flPV = TestParity(a);
                proc.flZ = (a == 0);
                proc.flN = false;
                proc.flC = false;
                return a;
            }

            public byte opXor8(byte a, byte b)
            {
                a = (byte)(a ^ b);
                proc.flS = (a & Z80.fS) != 0;
                proc.fl3 = (a & Z80.f3) != 0;
                proc.fl5 = (a & Z80.f5) != 0;
                proc.flH = false;
                proc.flPV = TestParity(a);
                proc.flZ = (a == 0);
                proc.flN = false;
                proc.flC = false;
                return a;
            }           

            #endregion

            #region Bit manupulations

            public void opBit8(byte b, byte r)
            {
                bool t = TestBit(r, b);
                proc.flN = false;
                proc.flH = true;
                //proc.fl3 =  (r & Z80.f3) != 0;
                //proc.fl5 =  (r & Z80.f5) != 0;
                proc.flS =  (b == Z80.fS) ? t : false;
                proc.flZ =  !t;
                proc.flPV = !t;
            }

            public byte opBitSet8(byte b, byte r)
            {
                return SetBit(r, b);
            }

            public byte opBitRes8(byte b, byte r)
            {
                return ResetBit(r, b);
            }
            #endregion

            #region Compare
            public void opCp8(byte a, byte b)
            {
                int va = (int)a;
                int vb = (int)b;
                int wans = a - b;
                byte ans = (byte)wans;
                proc.flS =  (ans & Z80.fS) != 0;
                proc.fl3 =  (b & Z80.f3) != 0;
                proc.fl5 =  (b & Z80.f5) != 0;
                proc.flN = true;
                proc.flZ =  (ans == 0);
                proc.flC =  (wans & 0x100) != 0;
                proc.flH =  (((a & 0xF) - (b & 0xF)) & Z80.fH) != 0;
                proc.flPV =  ((a ^ b) & (a ^ ans) & 0x80) != 0;
            }
            #endregion

            #region Complement
            public byte opCpl8(byte a)
            {
                a = (byte)((a ^ 0xFF) & 0xFF);
                proc.fl3 = (a & Z80.f3) != 0;
                proc.fl5 = (a & Z80.f5) != 0;
                proc.flH = true;
                proc.flN = true;
                return a;
            }
            #endregion

            #region DAA

            public byte opDaa8(byte a)
            {
                int incr = 0;
                int ans = (int)a;
                if (proc.flH || ((ans & 0xF) > 0x9))
                    incr |= 0x6;
                if (proc.flC || (ans > 0x9F))
                    incr |= 0x60;
                if ((ans > 0x8F) && ((ans & 0xF) > 9))
                    incr |= 0x60;
                if (ans > 0x99)
                    proc.flC = true;
                if (proc.flN)
                {
                    proc.flH = (((short)(ans & 0xF) - (short)(incr & 0xF)) & Z80.fH) != 0;
                    ans = (ans - incr) & 0xFF;
                }
                else
                {
                    proc.flH = (((short)(ans & 0xF) + (short)(incr & 0xF)) & Z80.fH) != 0;
                    ans = (ans + incr) & 0xFF;
                }
                proc.flS = (ans & Z80.fS) != 0;
                proc.fl3 = (ans & Z80.f3) != 0;
                proc.fl5 = (ans & Z80.f5) != 0;
                proc.flZ = ans == 0;
                proc.flPV = TestParity((byte)ans);
                return (byte)ans;
            }
            #endregion

            #region Inc & Dec

            public byte opInc8(byte a)
            {
                proc.flPV = (a == 0x7F);
                proc.flH = (((a & 0xF) + 1) & Z80.fH) != 0;
                a = (byte)(a + 1);
                proc.flS = (a & Z80.fS) != 0;
                proc.fl3 = (a & Z80.f3) != 0;
                proc.fl5 = (a & Z80.f5) != 0;
                proc.flZ = (a == 0);
                proc.flN = false;
                return a;
            }

            public byte opDec8(byte a)
            {
                proc.flPV = (a == 0x80);
                proc.flH = (((a & 0xF) - 1) & Z80.fH) != 0;
                a = (byte)(a - 1);
                proc.flS = (a & Z80.fS) != 0;
                proc.fl3 = (a & Z80.f3) != 0;
                proc.fl5 = (a & Z80.f5) != 0;
                proc.flZ = (a == 0);
                proc.flN = false;
                return a;
            }

            public ushort opInc16(ushort a)
            {
                return (ushort)(a + 1);
            }

            public ushort opDec16(ushort a)
            {
                return (ushort)(a - 1);
            }

            #endregion

            #region Exchange

            public void opExAfAf()
            {
                byte acc = proc.rA;
                byte flags = proc.rF;
                proc.rA = proc.rA_;
                proc.rF = proc.rF_;
                proc.rA_ = acc;
                proc.rF_ = flags;
            }

            public void opExx()
            {
                ushort hl = proc.rHL;
                byte b = proc.rB;
                byte c = proc.rC;
                byte d = proc.rD;
                byte e = proc.rE;
                proc.rHL = proc.rHL_;
                proc.rB = proc.rB_;
                proc.rC = proc.rC_;
                proc.rD = proc.rD_;
                proc.rE = proc.rE_;
                proc.rHL_ = hl;
                proc.rB_ = b;
                proc.rC_ = c;
                proc.rD_ = d;
                proc.rE_ = e;
            }            

            #endregion

            #region Rotate Bits

            public byte opRl8(byte a)
            {
                int ans;
                bool c = (a & 0x80) != 0;
                if (proc.flC)
                    ans = (a * 2) | 1;
                else
                    ans = a * 2;
                proc.flC = c;
                return (byte)ans;
            }

            public byte opRlc8(byte a)
            {
                int ans;
                bool c = (a & 0x80) != 0;
                if (c)
                    ans = (a * 2) | 1;
                else
                    ans = a * 2;
                proc.flC = c;
                return (byte)ans;
            }

            public byte opRr8(byte a)
            {
                int ans;
                bool c = (a & 1) != 0;
                if (proc.flC)
                    ans = (a >> 1) | 0x80;
                else
                    ans = a >> 1;
                proc.flC = c;
                return (byte)ans;
            }

            public byte opRrc8(byte a)
            {
                int ans;
                bool c = (a & 1) != 0;
                if (c)
                    ans = (a >> 1) | 0x80;
                else
                    ans = a >> 1;
                proc.flC = c;
                return (byte)ans;
            }

            public void opRld8(ref byte a, ref byte t)
            {
                int q = (int)t;
                t = (byte)((t * 16) | (a & 0xF));
                a = (byte)((a & 0xF0) | (q >> 4));
                proc.flS = (a & Z80.fS) != 0;
                proc.fl3 = (a & Z80.f3) != 0;
                proc.fl5 = (a & Z80.f5) != 0;
                proc.flN = false;
                proc.flH = false;
                proc.flZ = (a == 0);
                proc.flPV = proc.IFF2;
            }
            
            public void opRrd8(ref byte a, ref byte t)
            {
                int q = (int)t;
                t = (byte)((t >> 4) | (a * 16));
                a = (byte)((a & 0xF0) | (q & 0xF));
                proc.flS = (a & Z80.fS) != 0;
                proc.fl3 = (a & Z80.f3) != 0;
                proc.fl5 = (a & Z80.f5) != 0;
                proc.flN = false;
                proc.flH = false;
                proc.flZ =  (a == 0);
                proc.flPV = proc.IFF2;
            }

            public byte opSla8(byte a)
            {
                bool c = (a & 0x80) != 0;
                a = (byte)((a * 2) & 0xFF);
                proc.flC = c;
                return a;
            }

            public byte opSls8(byte a)
            {
                bool c = (a & 0x80) != 0;
                a = (byte)(((a * 2) | 1) & 0xFF);
                proc.flC = c;
                return a;
            }

            public byte opSra8(byte a)
            {
                bool c = (a & 1) != 0;
                a = (byte)((a >> 1) | (a & 0x80));
                proc.flC = c;
                return a;
            }

            public byte opSrl8(byte a)
            {
                bool c = (a & 1) != 0;
                a = (byte)(a >> 1);
                proc.flC = c;
                return a;
            }

            #endregion

            #region In & Out
            public byte opIn8(ushort addr)
            {
                return proc.model.PortManager.ReadByte(addr);
            }

            public void opOut8(ushort addr, byte value)
            {
                proc.model.PortManager.Write(addr, value);
            }
            #endregion            

            #region Push & Pop
            
            public ushort opPop16()
            {
                ushort v = Read16BitMemory(proc.rSP);
                proc.rSP += 2;
                return v;
            }

            public void opPush16(ushort v)
            {
                proc.rSP -= 2;
                WriteMemory(proc.rSP, v);
            }
            #endregion


        }
    }
}
