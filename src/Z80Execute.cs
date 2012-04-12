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

        int lne = 0;
        int t = 0;

        public void Execute()
        {
            if (bHalt) return;
            byte opcode = Fetch();
            t++;
            if (t > 50)
            {
                t = 0;
                lne++;
                if (lne > 191) lne = 0;
                Program.video.ScanLinePaint(lne);
            }


            switch (opcode)
            {
                case 0:  //NOP
                    opNop();
                    break;
                case 8:  //EX AF,AF'
                    opExAfAf();
                    break;
                case 16: //DJNZ dis
                    opDjnz(FetchRelative());
                    break;
                case 24: //JR dis
                    opJp(FetchRelative());
                    break;
                case 32: //JR NZ dis
                    opJpnz(FetchRelative());
                    break;
                case 40: //JR Z dis
                    opJpz(FetchRelative());
                    break;
                case 48: //JR NC dis
                    opJpnc(FetchRelative());
                    break;
                case 56: //JR C dis
                    opJpc(FetchRelative());
                    break;
                case 1:  //LD BC,nn
                    opLd16(ComposeRegister(Registers.BC), FetchImmediateWord());
                    break;
                case 9:  //ADD HL,BC
                    opAdd16(ComposeRegister(Registers.HL), ComposeRegister(Registers.BC));
                    break;
                case 17: //LD DE,nn
                    opLd16(ComposeRegister(Registers.DE), FetchImmediateWord());
                    break;
                case 25: //ADD HL,DE
                    opAdd16(ComposeRegister(Registers.HL), ComposeRegister(Registers.DE));
                    break;
                case 33: //LD HL,nn
                    opLd16(ComposeRegister(Registers.HL), FetchImmediateWord());
                    break;
                case 41: //ADD HL,HL
                    opAdd16(ComposeRegister(Registers.HL), ComposeRegister(Registers.HL));
                    break;
                case 49: //LD SP,nn
                    opLd16(ComposeRegister(Registers.SP), FetchImmediateWord());
                    break;
                case 57: //ADD HL,SP
                    opAdd16(ComposeRegister(Registers.HL), ComposeRegister(Registers.SP));
                    break;
                case 2:  //LD (BC),A
                    opLd8(ComposeRegisterIndirect(Registers.BC), ComposeRegister(Registers.A));
                    break;
                case 10: //LD A,(BC)
                    opLd8(ComposeRegister(Registers.A), ComposeRegisterIndirect(Registers.BC));
                    break;
                case 18: //LD (DE),A
                    opLd8(ComposeRegisterIndirect(Registers.DE), ComposeRegister(Registers.A));
                    break;
                case 26: //LD A,(DE)
                    opLd8(ComposeRegister(Registers.A), ComposeRegisterIndirect(Registers.DE));
                    break;
                case 34: //LD (nn),HL
                    opLd16(ComposeImmediateIndirectWord(), ComposeRegister(Registers.HL));
                    break;
                case 42: //LD HL,(nn)
                    opLd16(ComposeRegister(Registers.HL), ComposeImmediateIndirectWord());
                    break;
                case 50: //LD (nn),A
                    opLd8(ComposeImmediateIndirectWord(), ComposeRegister(Registers.A));
                    break;
                case 58: //LD A,(nn)
                    opLd8(ComposeRegister(Registers.A), ComposeImmediateIndirectWord());
                    break;
                case 3:  //INC BC
                    opInc16(ComposeRegister(Registers.BC));
                    break;
                case 11: //DEC BC
                    opDec16(ComposeRegister(Registers.BC));
                    break;
                case 19: //INC DE
                    opInc16(ComposeRegister(Registers.DE));
                    break;
                case 27: //DEC DE
                    opDec16(ComposeRegister(Registers.DE));
                    break;
                case 35: //INC HL
                    opInc16(ComposeRegister(Registers.HL));
                    break;
                case 43: //DEC HL
                    opDec16(ComposeRegister(Registers.HL));
                    break;
                case 51: //INC SP
                    opInc16(ComposeRegister(Registers.SP));
                    break;
                case 59: //DEC SP
                    opDec16(ComposeRegister(Registers.SP));
                    break;
                case 4:  //INC B
                    opInc8(ComposeRegister(Registers.B));
                    break;
                case 12: //INC C
                    opInc8(ComposeRegister(Registers.C));
                    break;
                case 20: //INC D
                    opInc8(ComposeRegister(Registers.D));
                    break;
                case 28: //INC E
                    opInc8(ComposeRegister(Registers.E));
                    break;
                case 36: //INC H
                    opInc8(ComposeRegister(Registers.H));
                    break;
                case 44: //INC L
                    opInc8(ComposeRegister(Registers.L));
                    break;
                case 52: //INC (HL)
                    opInc8(ComposeRegisterIndirect(Registers.HL));
                    break;
                case 60: //INC A
                    opInc8(ComposeRegister(Registers.A));
                    break;
                case 5:  //DEC B
                    opDec8(ComposeRegister(Registers.B));
                    break;
                case 13: //DEC C
                    opDec8(ComposeRegister(Registers.C));
                    break;
                case 21: //DEC D
                    opDec8(ComposeRegister(Registers.D));
                    break;
                case 29: //DEC E
                    opDec8(ComposeRegister(Registers.E));
                    break;
                case 37: //DEC H
                    opDec8(ComposeRegister(Registers.H));
                    break;
                case 45: //DEC L
                    opDec8(ComposeRegister(Registers.L));
                    break;
                case 53: //DEC (HL)
                    opDec8(ComposeRegisterIndirect(Registers.HL));
                    break;
                case 61: //DEC A
                    opDec8(ComposeRegister(Registers.A));
                    break;
                case 6: //LD B,n
                    opLd8(ComposeRegister(Registers.B), FetchImmediateByte());
                    break;
                case 14: //LD C,n
                    opLd8(ComposeRegister(Registers.C), FetchImmediateByte());
                    break;
                case 22: //LD D,n
                    opLd8(ComposeRegister(Registers.D), FetchImmediateByte());
                    break;
                case 30: //LD E,n
                    opLd8(ComposeRegister(Registers.E), FetchImmediateByte());
                    break;
                case 38: //LD H,n
                    opLd8(ComposeRegister(Registers.H), FetchImmediateByte());
                    break;
                case 46: //LD L,n
                    opLd8(ComposeRegister(Registers.L), FetchImmediateByte());
                    break;
                case 54: //LD (HL),n
                    opLd8(ComposeRegisterIndirect(Registers.HL), FetchImmediateByte());
                    break;
                case 62: //LD A,n
                    opLd8(ComposeRegister(Registers.A), FetchImmediateByte());
                    break;
                case 7: //RLCA
                    opRlcA();
                    break;
                case 15: //RRCA
                    opRrcA();
                    break;
                case 23: //RLA
                    opRlA();
                    break;
                case 31: //RRA
                    opRrA();
                    break;
                case 39: //DAA
                    opDaa();
                    break;
                case 47: //CPL
                    opCplA();
                    break;
                case 55: //SCF
                    opScf();
                    break;
                case 63: //CCF
                    opCcf();
                    break;
                case 64: //LD B,B
                    // local_tstates := local_tstates + 4;
                    break;
                case 65: //LD B,C
                    opLd8(ComposeRegister(Registers.B), ComposeRegister(Registers.C));
                    break;
                case 66: //LD B,D
                    opLd8(ComposeRegister(Registers.B), ComposeRegister(Registers.D));
                    break;
                case 67: //LD B,E
                    opLd8(ComposeRegister(Registers.B), ComposeRegister(Registers.E));
                    break;
                case 68: //LD B,H
                    opLd8(ComposeRegister(Registers.B), ComposeRegister(Registers.H));
                    break;
                case 69: //LD B,L
                    opLd8(ComposeRegister(Registers.B), ComposeRegister(Registers.L));
                    break;
                case 70: //LD B,(HL)
                    opLd8(ComposeRegister(Registers.B), ComposeRegisterIndirect(Registers.HL));
                    break;
                case 71: //LD B,A
                    opLd8(ComposeRegister(Registers.B), ComposeRegister(Registers.A));
                    break;
                case 72: //LD C,B
                    opLd8(ComposeRegister(Registers.C), ComposeRegister(Registers.B)); //!!!
                    break;
                case 73: //LD C,C
                    //local_tstates := local_tstates + 4;
                    break;
                case 74: //LD C,D
                    opLd8(ComposeRegister(Registers.C), ComposeRegister(Registers.D));
                    break;
                case 75: //LD C,E
                    opLd8(ComposeRegister(Registers.C), ComposeRegister(Registers.E));
                    break;
                case 76: //LD C,H
                    opLd8(ComposeRegister(Registers.C), ComposeRegister(Registers.H));
                    break;
                case 77: //LD C,L
                    opLd8(ComposeRegister(Registers.C), ComposeRegister(Registers.L));
                    break;
                case 78: //LD C,(HL)
                    opLd8(ComposeRegister(Registers.C), ComposeRegisterIndirect(Registers.HL));
                    break;
                case 79: //LD C,A
                    opLd8(ComposeRegister(Registers.C), ComposeRegister(Registers.A));
                    break;
                case 80: //LD D,B
                    opLd8(ComposeRegister(Registers.D), ComposeRegister(Registers.B));
                    break;
                case 81: //LD D,C
                    opLd8(ComposeRegister(Registers.D), ComposeRegister(Registers.C));
                    break;
                case 82: //LD D,D
                    //local_tstates := local_tstates + 4;
                    break;
                case 83: //LD D,E
                    opLd8(ComposeRegister(Registers.D), ComposeRegister(Registers.E));
                    break;
                case 84: //LD D,H
                    opLd8(ComposeRegister(Registers.D), ComposeRegister(Registers.H));
                    break;
                case 85: //LD D,L
                    opLd8(ComposeRegister(Registers.D), ComposeRegister(Registers.L));
                    break;
                case 86: //LD D,(HL)
                    opLd8(ComposeRegister(Registers.D), ComposeRegisterIndirect(Registers.HL));
                    break;
                case 87: //LD D,A
                    opLd8(ComposeRegister(Registers.D), ComposeRegister(Registers.A));
                    break;
                case 88: //LD E,B
                    opLd8(ComposeRegister(Registers.E), ComposeRegister(Registers.B));
                    break;
                case 89: //LD E,C
                    opLd8(ComposeRegister(Registers.E), ComposeRegister(Registers.C));
                    break;
                case 90: //LD E,D
                    opLd8(ComposeRegister(Registers.E), ComposeRegister(Registers.D));
                    break;
                case 91: //LD E,E
                    //local_tstates := local_tstates + 4;
                    break;
                case 92: //LD E,H
                    opLd8(ComposeRegister(Registers.E), ComposeRegister(Registers.H));
                    break;
                case 93: //LD E,L
                    opLd8(ComposeRegister(Registers.E), ComposeRegister(Registers.L));
                    break;
                case 94: //LD E,(HL)
                    opLd8(ComposeRegister(Registers.E), ComposeRegisterIndirect(Registers.HL));
                    break;
                case 95: //LD E,A
                    opLd8(ComposeRegister(Registers.E), ComposeRegister(Registers.A));
                    break;
                case 96: //LD H,B
                    opLd8(ComposeRegister(Registers.H), ComposeRegister(Registers.B));
                    break;
                case 97: //LD H,C
                    opLd8(ComposeRegister(Registers.H), ComposeRegister(Registers.C));
                    break;
                case 98: //LD H,D
                    opLd8(ComposeRegister(Registers.H), ComposeRegister(Registers.D));
                    break;
                case 99: //LD H,E
                    opLd8(ComposeRegister(Registers.H), ComposeRegister(Registers.E));
                    break;
                case 100:  //LD H,H
                    //local_tstates := local_tstates + 4;
                    break;
                case 101:  //LD H,L
                    opLd8(ComposeRegister(Registers.H), ComposeRegister(Registers.L));
                    break;
                case 102:  //LD H,(HL)
                    opLd8(ComposeRegister(Registers.H), ComposeRegisterIndirect(Registers.HL));
                    break;
                case 103:  //LD H,A
                    opLd8(ComposeRegister(Registers.H), ComposeRegister(Registers.A));
                    break;
                case 104:  //LD L,B
                    opLd8(ComposeRegister(Registers.L), ComposeRegister(Registers.B));
                    break;
                case 105:  //LD L,C
                    opLd8(ComposeRegister(Registers.L), ComposeRegister(Registers.C));
                    break;
                case 106:  //LD L,D
                    opLd8(ComposeRegister(Registers.L), ComposeRegister(Registers.D));
                    break;
                case 107:  //LD L,E
                    opLd8(ComposeRegister(Registers.L), ComposeRegister(Registers.E));
                    break;
                case 108:  //LD L,H
                    opLd8(ComposeRegister(Registers.L), ComposeRegister(Registers.H));
                    break;
                case 109:  //LD L,L
                    //local_tstates := local_tstates + 4;
                    break;
                case 110:  //LD L,(HL)
                    opLd8(ComposeRegister(Registers.L), ComposeRegisterIndirect(Registers.HL));
                    break;
                case 111:  //LD L,A
                    opLd8(ComposeRegister(Registers.L), ComposeRegister(Registers.A));
                    break;
                case 112:  //LD (HL),B
                    opLd8(ComposeRegisterIndirect(Registers.HL), ComposeRegister(Registers.B));
                    break;
                case 113:  //LD (HL),C
                    opLd8(ComposeRegisterIndirect(Registers.HL), ComposeRegister(Registers.C));
                    break;
                case 114:  //LD (HL),D
                    opLd8(ComposeRegisterIndirect(Registers.HL), ComposeRegister(Registers.D));
                    break;
                case 115:  //LD (HL),E
                    opLd8(ComposeRegisterIndirect(Registers.HL), ComposeRegister(Registers.E));
                    break;
                case 116:  //LD (HL),H
                    opLd8(ComposeRegisterIndirect(Registers.HL), ComposeRegister(Registers.H));
                    break;
                case 117:  //LD (HL),L
                    opLd8(ComposeRegisterIndirect(Registers.HL), ComposeRegister(Registers.L));
                    break;
                case 118:  //HALT
                    opHalt();
                    break;
                case 119:  //LD (HL),A
                    opLd8(ComposeRegisterIndirect(Registers.HL), ComposeRegister(Registers.A));
                    break;
                case 120:  //LD A,B
                    opLd8(ComposeRegister(Registers.A), ComposeRegister(Registers.B));
                    break;
                case 121:  //LD A,C
                    opLd8(ComposeRegister(Registers.A), ComposeRegister(Registers.C));
                    break;
                case 122:  //LD A,D
                    opLd8(ComposeRegister(Registers.A), ComposeRegister(Registers.D));
                    break;
                case 123:  //LD A,E
                    opLd8(ComposeRegister(Registers.A), ComposeRegister(Registers.E));
                    break;
                case 124:  //LD A,H
                    opLd8(ComposeRegister(Registers.A), ComposeRegister(Registers.H));
                    break;
                case 125:  //LD A,L
                    opLd8(ComposeRegister(Registers.A), ComposeRegister(Registers.L));
                    break;
                case 126:  //LD A,(HL)
                    opLd8(ComposeRegister(Registers.A), ComposeRegisterIndirect(Registers.HL));
                    break;
                case 127:  //LD A,A
                    //local_tstates := local_tstates + 4;
                    break;
                case 128:  //ADD A,B
                    opAddA(ComposeRegister(Registers.B));
                    break;
                case 129:  //ADD A,C
                    opAddA(ComposeRegister(Registers.C));
                    break;
                case 130:  //ADD A,D
                    opAddA(ComposeRegister(Registers.D));
                    break;
                case 131:  //ADD A,E
                    opAddA(ComposeRegister(Registers.E));
                    break;
                case 132:  //ADD A,H
                    opAddA(ComposeRegister(Registers.H));
                    break;
                case 133:  //ADD A,L
                    opAddA(ComposeRegister(Registers.L));
                    break;
                case 134:  //ADD A,(HL)
                    opAddA(ComposeRegisterIndirect(Registers.HL));
                    break;
                case 135:  //ADD A,A
                    opAddA(ComposeRegister(Registers.A));
                    break;
                case 136:  //ADC A,B
                    opAdcA(ComposeRegister(Registers.B));
                    break;
                case 137:  //ADC A,C
                    opAdcA(ComposeRegister(Registers.C));
                    break;
                case 138:  //ADC A,D
                    opAdcA(ComposeRegister(Registers.D));
                    break;
                case 139:  //ADC A,E
                    opAdcA(ComposeRegister(Registers.E));
                    break;
                case 140:  //ADC A,H
                    opAdcA(ComposeRegister(Registers.H));
                    break;
                case 141:  //ADC A,L
                    opAdcA(ComposeRegister(Registers.L));
                    break;
                case 142:  //ADC A,(HL)
                    opAdcA(ComposeRegisterIndirect(Registers.HL));
                    break;
                case 143:  //ADC A,A
                    opAdcA(ComposeRegister(Registers.A));
                    break;
                case 144:  //SUB B
                    opSubA(ComposeRegister(Registers.B));
                    break;
                case 145:  //SUB C
                    opSubA(ComposeRegister(Registers.C));
                    break;
                case 146:  //SUB D
                    opSubA(ComposeRegister(Registers.D));
                    break;
                case 147:  //SUB E
                    opSubA(ComposeRegister(Registers.E));
                    break;
                case 148:  //SUB H
                    opSubA(ComposeRegister(Registers.H));
                    break;
                case 149:  //SUB L
                    opSubA(ComposeRegister(Registers.L));
                    break;
                case 150:  //SUB (HL)
                    opSubA(ComposeRegisterIndirect(Registers.HL));
                    break;
                case 151:  //SUB A
                    opSubA(ComposeRegister(Registers.A));
                    break;
                case 152:  //SBC A,B
                    opSbcA(ComposeRegister(Registers.B));
                    break;
                case 153:  //SBC A,C
                    opSbcA(ComposeRegister(Registers.C));
                    break;
                case 154:  //SBC A,D
                    opSbcA(ComposeRegister(Registers.D));
                    break;
                case 155:  //SBC A,E
                    opSbcA(ComposeRegister(Registers.E));
                    break;
                case 156:  //SBC A,H
                    opSbcA(ComposeRegister(Registers.H));
                    break;
                case 157:  //SBC A,L
                    opSbcA(ComposeRegister(Registers.L));
                    break;
                case 158:  //SBC A,(HL)
                    opSbcA(ComposeRegisterIndirect(Registers.HL));
                    break;
                case 159:  //SBC A,A
                    opSbcA(ComposeRegister(Registers.A));
                    break;
                case 160:  //AND B
                    opAndA(ComposeRegister(Registers.B));
                    break;
                case 161:  //AND C
                    opAndA(ComposeRegister(Registers.C));
                    break;
                case 162:  //AND D
                    opAndA(ComposeRegister(Registers.D));
                    break;
                case 163:  //AND E
                    opAndA(ComposeRegister(Registers.E));
                    break;
                case 164:  //AND H
                    opAndA(ComposeRegister(Registers.H));
                    break;
                case 165:  //AND L
                    opAndA(ComposeRegister(Registers.L));
                    break;
                case 166:  //AND (HL)
                    opAndA(ComposeRegisterIndirect(Registers.HL));
                    break;
                case 167:  //AND A
                    opAndA(ComposeRegister(Registers.A));
                    break;
                case 168:  //XOR B
                    opXorA(ComposeRegister(Registers.B));
                    break;
                case 169:  //XOR C
                    opXorA(ComposeRegister(Registers.C));
                    break;
                case 170:  //XOR D
                    opXorA(ComposeRegister(Registers.D));
                    break;
                case 171:  //XOR E
                    opXorA(ComposeRegister(Registers.E));
                    break;
                case 172:  //XOR H
                    opXorA(ComposeRegister(Registers.H));
                    break;
                case 173:  //XOR L
                    opXorA(ComposeRegister(Registers.L));
                    break;
                case 174:  //XOR (HL)
                    opXorA(ComposeRegisterIndirect(Registers.HL));
                    break;
                case 175:  //XOR A
                    opXorA(ComposeRegister(Registers.A));
                    break;
                case 176:  //OR B
                    opOrA(ComposeRegister(Registers.B));
                    break;
                case 177:  //OR C
                    opOrA(ComposeRegister(Registers.C));
                    break;
                case 178:  //OR D
                    opOrA(ComposeRegister(Registers.D));
                    break;
                case 179:  //OR E
                    opOrA(ComposeRegister(Registers.E));
                    break;
                case 180:  //OR H
                    opOrA(ComposeRegister(Registers.H));
                    break;
                case 181:  //OR L
                    opOrA(ComposeRegister(Registers.L));
                    break;
                case 182:  //OR (HL)
                    opOrA(ComposeRegisterIndirect(Registers.HL));
                    break;
                case 183:  //OR A
                    opOrA(ComposeRegister(Registers.A));
                    break;
                case 184:  //CP B
                    opCpA(ComposeRegister(Registers.B));
                    break;
                case 185:  //CP C
                    opCpA(ComposeRegister(Registers.C));
                    break;
                case 186:  //CP D
                    opCpA(ComposeRegister(Registers.D));
                    break;
                case 187:  //CP E
                    opCpA(ComposeRegister(Registers.E));
                    break;
                case 188:  //CP H
                    opCpA(ComposeRegister(Registers.H));
                    break;
                case 189:  //CP L
                    opCpA(ComposeRegister(Registers.L));
                    break;
                case 190:  //CP (HL)
                    opCpA(ComposeRegisterIndirect(Registers.HL));
                    break;
                case 191:  //CP A
                    opCpA(ComposeRegister(Registers.A));
                    break;
                case 192:  //RET NZ
                    opRetnz();
                    break;
                case 200:  //RET Z
                    opRetz();
                    break;
                case 208:  //RET NC
                    opRetnc();
                    break;
                case 216:  //RET C
                    opRetc();
                    break;
                case 224:  //RET PO
                    opRetpo();
                    break;
                case 232:  //RET PE
                    opRetpe();
                    break;
                case 240:  //RET P
                    opRetp();
                    break;
                case 248:  //RET M
                    opRetm();
                    break;
                case 193:  //POP BC
                    opPop16(ComposeRegister(Registers.BC));
                    break;
                case 201:  //RET
                    opRet();
                    break;
                case 209:  //POP DE
                    opPop16(ComposeRegister(Registers.DE));
                    break;
                case 217:  //EXX
                    opExx();
                    break;
                case 225:  //POP HL
                    opPop16(ComposeRegister(Registers.HL));
                    break;
                case 233:  //JP HL
                    opJp(ComposeRegister(Registers.HL));
                    break;
                case 241:  //POP AF
                    opPop16(ComposeRegister(Registers.AF));
                    break;
                case 249:  //LD SP,HL
                    opLd16(ComposeRegister(Registers.SP), ComposeRegister(Registers.HL));
                    break;
                case 194:  //JP NZ,nn
                    opJpnz(FetchImmediateWord());
                    break;
                case 202:  //JP Z,nn
                    opJpz(FetchImmediateWord());
                    break;
                case 210:  //JP NC,nn
                    opJpnc(FetchImmediateWord());
                    break;
                case 218:  //JP C,nn
                    opJpc(FetchImmediateWord());
                    break;
                case 226:  //JP PO,nn
                    opJpo(FetchImmediateWord());
                    break;
                case 234:  //JP PE,nn
                    opJpe(FetchImmediateWord());
                    break;
                case 242:  //JP P,nn
                    opJpp(FetchImmediateWord());
                    break;
                case 250:  //JP M,nn
                    opJpm(FetchImmediateWord());
                    break;
                case 195:  //JP nn
                    opJp(FetchImmediateWord());
                    break;
                case 203:  //prefix CB
                    ExecuteCb();
                    break;
                case 211:  //OUT (n),A
                    opOutbA(FetchImmediateByte());
                    break;
                case 219:  //IN A,(n)
                    opInbA(FetchImmediateByte());
                    break;
                case 227:  //EX (SP),HL
                    opEx(ComposeRegisterIndirect(Registers.SP), ComposeRegister(Registers.HL));
                    break;
                case 235:  //EX DE,HL
                    opEx(ComposeRegister(Registers.DE), ComposeRegister(Registers.HL));
                    break;
                case 243:  //DI
                    opDi();
                    break;
                case 251:  //EI
                    opEi();
                    break;
                case 196:  //CALL NZ,nn
                    opCallnz(FetchImmediateWord());
                    break;
                case 204:  //CALL Z,nn
                    opCallz(FetchImmediateWord());
                    break;
                case 212:  //CALL NC,nn
                    opCallnc(FetchImmediateWord());
                    break;
                case 220:  //CALL C,nn
                    opCallc(FetchImmediateWord());
                    break;
                case 228:  //CALL PO,nn
                    opCallpo(FetchImmediateWord());
                    break;
                case 236:  //CALL PE,nn
                    opCallpe(FetchImmediateWord());
                    break;
                case 244:  //CALL P,nn
                    opCallp(FetchImmediateWord());
                    break;
                case 252:  //CALL M,nn
                    opCallm(FetchImmediateWord());
                    break;
                case 197:  //PUSH BC
                    opPush16(ComposeRegister(Registers.BC));
                    break;
                case 205:  //CALL nn
                    opCall(FetchImmediateWord());
                    break;
                case 213:  //PUSH DE
                    opPush16(ComposeRegister(Registers.DE));
                    break;
                case 221:  //prefix IX
                    ExecuteId(Registers.IX);
                    break;
                case 229:  //PUSH HL
                    opPush16(ComposeRegister(Registers.HL));
                    break;
                case 237:  //prefix ED
                    ExecuteEd();
                    break;
                case 245:  //PUSH AF
                    opPush16(ComposeRegister(Registers.AF));
                    break;
                case 253:  //prefix IY
                    ExecuteId(Registers.IY);
                    break;
                case 198:  //ADD A,n
                    opAddA(FetchImmediateByte());
                    break;
                case 206:  //ADC A,n
                    opAdcA(FetchImmediateByte());
                    break;
                case 214:  //SUB n
                    opSubA(FetchImmediateByte());
                    break;
                case 222:  //SBC n
                    opSbcA(FetchImmediateByte());
                    break;
                case 230:  //AND n
                    opAndA(FetchImmediateByte());
                    break;
                case 238:  //XOR n
                    opXorA(FetchImmediateByte());
                    break;
                case 246:  //OR n
                    opOrA(FetchImmediateByte());
                    break;
                case 254:  //CP n
                    opCpA(FetchImmediateByte());
                    break;
                case 199:  //RST 0
                    opRst(0);
                    break;
                case 207:  //RST 8
                    opRst(8);
                    break;
                case 215:  //RST 16
                    opRst(16);
                    break;
                case 223:  //RST 24
                    opRst(24);
                    break;
                case 231:  //RST 32
                    opRst(32);
                    break;
                case 239:  //RST 40
                    opRst(40);
                    break;
                case 247:  //RST 48
                    opRst(48);
                    break;
                case 255:  //RST 56
                    opRst(56);
                    break;
                default:
                    throw new InvalidOpcodeException("Execute", opcode);
            }
        }

    }
}
