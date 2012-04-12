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
    public partial class Z80
    {
        public void ExecuteId(Registers Id)
        {
            byte opcode = Fetch();

            switch (opcode)
            {
                case 9:  //ADD ID,BC
                    opAdd16(ComposeRegister(Id), ComposeRegister(Registers.BC));
                    break;
                case 25: //ADD ID,DE
                    opAdd16(ComposeRegister(Id), ComposeRegister(Registers.DE));
                    break;
                case 41: //ADD ID,ID
                    opAdd16(ComposeRegister(Id), ComposeRegister(Id));
                    break;
                case 57: //ADD ID,SP
                    opAdd16(ComposeRegister(Id), ComposeRegister(Registers.SP));
                    break;
                case 33: //LD ID,nn
                    opLd16(ComposeRegister(Id), FetchImmediateWord());
                    break;
                case 34: //LD (nn),ID
                    opLd16(ComposeImmediateIndirectWord(), ComposeRegister(Id));
                    break;
                case 42: //LD ID,(nn)
                    opLd16(ComposeRegister(Id), ComposeImmediateIndirectWord());
                    break;
                case 35: //INC ID
                    opInc16(ComposeRegister(Id));
                    break;
                case 43: //DEC ID
                    opDec16(ComposeRegister(Id));
                    break;
                case 36: //INC IDH
                    opInc8(ComposeRegisterHi(Id));
                    break;
                case 44: //INC IDL
                    opInc8(ComposeRegisterLo(Id));
                    break;
                case 52: //INC (ID+d)
                    opInc8(ComposeIndexIndirect(Id));
                    break;
                case 37: //DEC IDH
                    opDec8(ComposeRegisterHi(Id));
                    break;
                case 45: //DEC IDL
                    opDec8(ComposeRegisterLo(Id));
                    break;
                case 53: //DEC (ID+d)
                    opDec8(ComposeIndexIndirect(Id));
                    break;
                case 38: //LD IDH,n
                    opLd8(ComposeRegisterHi(Id), FetchImmediateByte());
                    break;
                case 46: //LD IDL,n
                    opLd8(ComposeRegisterLo(Id), FetchImmediateByte());
                    break;
                case 54: //LD (ID+d),n
                    opLd8(ComposeIndexIndirect(Id), FetchImmediateByte());
                    break;
                case 68: //LD B,IDH
                    opLd8(ComposeRegister(Registers.B), ComposeRegisterHi(Id));
                    break;
                case 69: //LD B,IDL
                    opLd8(ComposeRegister(Registers.B), ComposeRegisterLo(Id));
                    break;
                case 70: //LD B,(ID+d)
                    opLd8(ComposeRegister(Registers.B), ComposeIndexIndirect(Id));
                    break;
                case 76: //LD C,IDH
                    opLd8(ComposeRegister(Registers.C), ComposeRegisterHi(Id));
                    break;
                case 77: //LD C,IDL
                    opLd8(ComposeRegister(Registers.C), ComposeRegisterLo(Id));
                    break;
                case 78: //LD C,(ID+d)
                    opLd8(ComposeRegister(Registers.C), ComposeIndexIndirect(Id));
                    break;
                case 84: //LD D,IDH
                    opLd8(ComposeRegister(Registers.D), ComposeRegisterHi(Id));
                    break;
                case 85: //LD D,IDL
                    opLd8(ComposeRegister(Registers.D), ComposeRegisterLo(Id));
                    break;
                case 86: //LD D,(ID+d)
                    opLd8(ComposeRegister(Registers.D), ComposeIndexIndirect(Id));
                    break;
                case 92: //LD E,IDH
                    opLd8(ComposeRegister(Registers.E), ComposeRegisterHi(Id));
                    break;
                case 93: //LD E,IDL
                    opLd8(ComposeRegister(Registers.E), ComposeRegisterLo(Id));
                    break;
                case 94: //LD E,(ID+d)
                    opLd8(ComposeRegister(Registers.E), ComposeIndexIndirect(Id));
                    break;
                case 96: //LD IDH,B
                    opLd8(ComposeRegisterHi(Id), ComposeRegister(Registers.B));
                    break;
                case 97: //LD IDH,C
                    opLd8(ComposeRegisterHi(Id), ComposeRegister(Registers.C));
                    break;
                case 98: //LD IDH,D
                    opLd8(ComposeRegisterHi(Id), ComposeRegister(Registers.D));
                    break;
                case 99: //LD IDH,E
                    opLd8(ComposeRegisterHi(Id), ComposeRegister(Registers.E));
                    break;
                case 100:  //LD IDH,IDH
                    //execute_id := 9;
                    break;
                case 101:  //LD IDH,IDL
                    opLd8(ComposeRegisterHi(Id), ComposeRegisterLo(Id));
                    break;
                case 102:  //LD H,(ID+d)
                    opLd8(ComposeRegister(Registers.H), ComposeIndexIndirect(Id));
                    break;
                case 103:  //LD IDH,A
                    opLd8(ComposeRegisterHi(Id), ComposeRegister(Registers.A));
                    break;
                case 104:  //LD IDL,B
                    opLd8(ComposeRegisterLo(Id), ComposeRegister(Registers.B));
                    break;
                case 105:  //LD IDL,C
                    opLd8(ComposeRegisterLo(Id), ComposeRegister(Registers.C));
                    break;
                case 106:  //LD IDL,D
                    opLd8(ComposeRegisterLo(Id), ComposeRegister(Registers.D));
                    break;
                case 107:  //LD IDL,E
                    opLd8(ComposeRegisterLo(Id), ComposeRegister(Registers.E));
                    break;
                case 108:  //LD IDL,IDH
                    opLd8(ComposeRegisterLo(Id), ComposeRegisterHi(Id));
                    break;
                case 109:  //LD IDL,IDL
                    //execute_id := 9;
                    break;
                case 110:  //LD L,(ID+d)
                    opLd8(ComposeRegister(Registers.L), ComposeIndexIndirect(Id));
                    break;
                case 111:  //LD IDL,A
                    opLd8(ComposeRegisterLo(Id), ComposeRegister(Registers.A));
                    break;
                case 112:  //LD (ID+d),B
                    opLd8(ComposeIndexIndirect(Id), ComposeRegister(Registers.B));
                    break;
                case 113:  //LD (ID+d),C
                    opLd8(ComposeIndexIndirect(Id), ComposeRegister(Registers.C));
                    break;
                case 114:  //LD (ID+d),D
                    opLd8(ComposeIndexIndirect(Id), ComposeRegister(Registers.D));
                    break;
                case 115:  //LD (ID+d),E
                    opLd8(ComposeIndexIndirect(Id), ComposeRegister(Registers.E));
                    break;
                case 116:  //LD (ID+d),H
                    opLd8(ComposeIndexIndirect(Id), ComposeRegister(Registers.H));
                    break;
                case 117:  //LD (ID+d),L
                    opLd8(ComposeIndexIndirect(Id), ComposeRegister(Registers.L));
                    break;
                case 119:  //LD (ID+d),A
                    opLd8(ComposeIndexIndirect(Id), ComposeRegister(Registers.A));
                    break;
                case 124:  //LD A,IDH
                    opLd8(ComposeRegister(Registers.A), ComposeRegisterHi(Id));
                    break;
                case 125:  //LD A,IDL
                    opLd8(ComposeRegister(Registers.A), ComposeRegisterLo(Id));
                    break;
                case 126:  //LD A,(ID+d)
                    opLd8(ComposeRegister(Registers.A), ComposeIndexIndirect(Id));
                    break;
                case 132:  //ADD A,IDH
                    opAddA(ComposeRegisterHi(Id));
                    break;
                case 133:  //ADD A,IDL
                    opAddA(ComposeRegisterLo(Id));
                    break;
                case 134:  //ADD A,(ID+d)
                    opAddA(ComposeIndexIndirect(Id));
                    break;
                case 140:  //ADC A,IDH
                    opAdcA(ComposeRegisterHi(Id));
                    break;
                case 141:  //ADC A,IDL
                    opAdcA(ComposeRegisterLo(Id));
                    break;
                case 142:  //ADC A,(ID+d)
                    opAdcA(ComposeIndexIndirect(Id));
                    break;
                case 148:  //SUB IDH
                    opSubA(ComposeRegisterHi(Id));
                    break;
                case 149:  //SUB IDL
                    opSubA(ComposeRegisterLo(Id));
                    break;
                case 150:  //SUB (ID+d)
                    opSubA(ComposeIndexIndirect(Id));
                    break;
                case 156:  //SBC A,IDH
                    opSbcA(ComposeRegisterHi(Id));
                    break;
                case 157:  //SBC A,IDL
                    opSbcA(ComposeRegisterLo(Id));
                    break;
                case 158:  //SBC A,(ID+d)
                    opSbcA(ComposeIndexIndirect(Id));
                    break;
                case 164:  //AND IDH
                    opAddA(ComposeRegisterHi(Id));
                    break;
                case 165:  //AND IDL
                    opAndA(ComposeRegisterLo(Id));
                    break;
                case 166:  //AND (ID+d)
                    opAndA(ComposeIndexIndirect(Id));
                    break;
                case 172:  //XOR IDH
                    opXorA(ComposeRegisterHi(Id));
                    break;
                case 173:  //XOR IDL
                    opXorA(ComposeRegisterLo(Id));
                    break;
                case 174:  //XOR (ID+d)
                    opXorA(ComposeIndexIndirect(Id));
                    break;
                case 180:  //OR IDH
                    opOrA(ComposeRegisterHi(Id));
                    break;
                case 181:  //OR IDL
                    opOrA(ComposeRegisterLo(Id));
                    break;
                case 182:  //OR (ID+d)
                    opOrA(ComposeIndexIndirect(Id));
                    break;
                case 188:  //CP IDH
                    opCpA(ComposeRegisterHi(Id));
                    break;
                case 189:  //CP IDL
                    opCpA(ComposeRegisterLo(Id));
                    break;
                case 190:  //CP (ID+d)
                    opCpA(ComposeIndexIndirect(Id));
                    break;
                case 203:  //prefix CB
                    Operand op1 = ComposeIndexIndirect(Id);
                    byte op = Fetch();
                    ExecuteIdCb(op, op1);
                    break;
                case 225:  //POP ID
                    opPop16(ComposeRegister(Id));
                    break;
                case 227:  //EX (SP),ID
                    opEx(ComposeRegisterIndirect(Registers.SP), ComposeRegister(Id));
                    break;
                case 229:  //PUSH ID
                    opPush16(ComposeRegister(Id));
                    break;
                case 233:  //JP ID
                    opJp(ComposeRegister(Id));
                    break;
                case 249:  //LD SP,ID
                    opLd16(ComposeRegister(Registers.SP), ComposeRegister(Id));
                    break;
                default:
                    throw new InvalidOpcodeException("Execute ID", opcode);
            }
        }
    }
}
