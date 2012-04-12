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
        public void ExecuteEd()
        {
            byte opcode = Fetch();
            if ((opcode >= 0 && opcode <= 63) || (opcode >= 127 && opcode <= 159) ||
                (opcode >= 164 && opcode <= 167) || (opcode >= 172 && opcode <= 175) ||
                (opcode >= 180 && opcode <= 183))
            {
                // NOP
                return;
            }

            switch (opcode)
            {
                case 64: //IN B,(c)
                    opInb(ComposeRegister(Registers.BC), ComposeRegister(Registers.B));
                    break;
                case 72: //IN C,(c)
                    opInb(ComposeRegister(Registers.BC), ComposeRegister(Registers.C));
                    break;
                case 80: //IN D,(c)
                    opInb(ComposeRegister(Registers.BC), ComposeRegister(Registers.D));
                    break;
                case 88: //IN E,(c)
                    opInb(ComposeRegister(Registers.BC), ComposeRegister(Registers.E));
                    break;
                case 96: //IN H,(c)
                    opInb(ComposeRegister(Registers.BC), ComposeRegister(Registers.H));
                    break;
                case 104:  //IN L,(c)
                    opInb(ComposeRegister(Registers.BC), ComposeRegister(Registers.L));
                    break;
                case 112:  //IN (c)
                    opInb(ComposeRegister(Registers.BC));
                    break;
                case 120:  //IN A,(c)
                    opInb(ComposeRegister(Registers.BC), ComposeRegister(Registers.A));
                    break;
                case 65: //OUT (c),B
                    opOutb(ComposeRegister(Registers.BC), ComposeRegister(Registers.B));
                    break;
                case 73: //OUT (c),C
                    opOutb(ComposeRegister(Registers.BC), ComposeRegister(Registers.C));
                    break;
                case 81: //OUT (c),D
                    opOutb(ComposeRegister(Registers.BC), ComposeRegister(Registers.D));
                    break;
                case 89: //OUT (c),E
                    opOutb(ComposeRegister(Registers.BC), ComposeRegister(Registers.E));
                    break;
                case 97: //OUT (c),H
                    opOutb(ComposeRegister(Registers.BC), ComposeRegister(Registers.H));
                    break;
                case 105:  //OUT (c),L
                    opOutb(ComposeRegister(Registers.BC), ComposeRegister(Registers.L));
                    break;
                case 113:  //OUT (c),0
                    opOutb(ComposeRegister(Registers.BC));
                    break;
                case 121:  //OUT (c),A
                    opOutb(ComposeRegister(Registers.BC), ComposeRegister(Registers.A));
                    break;
                case 66:   //SBC HL,BC
                    opSbc16(ComposeRegister(Registers.HL), ComposeRegister(Registers.BC));
                    break;
                case 74:   //ADC HL,BC
                    opAdc16(ComposeRegister(Registers.HL), ComposeRegister(Registers.BC));
                    break;
                case 82:   //SBC HL,DE
                    opSbc16(ComposeRegister(Registers.HL), ComposeRegister(Registers.DE));
                    break;
                case 90: //ADC HL,DE
                    opAdc16(ComposeRegister(Registers.HL), ComposeRegister(Registers.DE));
                    break;
                case 98: //SBC HL,HL
                    opSbc16(ComposeRegister(Registers.HL), ComposeRegister(Registers.HL));
                    break;
                case 106:  //ADC HL,HL
                    opAdc16(ComposeRegister(Registers.HL), ComposeRegister(Registers.HL));
                    break;
                case 114:  //SBC HL,SP
                    opSbc16(ComposeRegister(Registers.HL), ComposeRegister(Registers.SP));
                    break;
                case 122:  //ADC HL,SP
                    opAdc16(ComposeRegister(Registers.HL), ComposeRegister(Registers.SP));
                    break;
                case 67:   //LD (nn),BC
                    opLd16(ComposeImmediateIndirectWord(), ComposeRegister(Registers.BC));
                    break;
                case 75:   //LD BC,(nn)
                    opLd16(ComposeRegister(Registers.BC), ComposeImmediateIndirectWord());
                    break;
                case 83:   //LD (nn),DE
                    opLd16(ComposeImmediateIndirectWord(), ComposeRegister(Registers.DE));
                    break;
                case 91:   //LD DE,(nn)
                    opLd16(ComposeRegister(Registers.DE), ComposeImmediateIndirectWord());
                    break;
                case 99:   //LD (nn),HL
                    opLd16(ComposeImmediateIndirectWord(), ComposeRegister(Registers.HL));
                    break;
                case 107:  //LD HL,(nn)
                    opLd16(ComposeRegister(Registers.HL), ComposeImmediateIndirectWord());
                    break;
                case 115:  //LD (nn),SP
                    opLd16(ComposeImmediateIndirectWord(), ComposeRegister(Registers.SP));
                    break;
                case 123:  //LD SP,(nn)
                    opLd16(ComposeRegister(Registers.SP), ComposeImmediateIndirectWord());
                    break;
                case 68:
                case 76:
                case 84:
                case 92:
                case 100:
                case 108:
                case 116:
                case 124: //NEG
                    opNegA();
                    break;
                case 69:
                case 85:
                case 101:
                case 117: // RETn
                    opRetn();
                    break;
                case 77:
                case 93:
                case 109:
                case 125: //RETI
                    opReti();
                    break;
                case 70:
                case 78:
                case 102:
                case 110: //IM 0
                    opIm0();
                    break;
                case 86:
                case 118:  //IM 1
                    opIm1();
                    break;
                case 94:
                case 126:  //IM 2
                    opIm2();
                    break;
                case 71: //LD I,A
                    opLd8(ComposeRegister(Registers.I), ComposeRegister(Registers.A));
                    break;
                case 79: //LD R,A
                    opLd8(ComposeRegister(Registers.R), ComposeRegister(Registers.A));
                    break;
                case 87: //LD A,I
                    opLdAI();
                    break;
                case 95: //LD A,R
                    opLDAR();
                    break;
                case 103:  //RRD
                    opRrd();
                    break;
                case 111:  //RLD
                    opRld();
                    break;
                case 160:  //LDI
                    opLdi();
                    break;
                case 161:  //CPI
                    opCpi();
                    break;
                case 162:  //INI
                    opIni();
                    break;
                case 163:  //OUTI
                    opOuti();
                    break;
                case 168:  //LDD
                    opLdd();
                    break;
                case 169:  //CPD
                    opCpd();
                    break;
                case 170:  //IND
                    opInd();
                    break;
                case 171:  //OUTD
                    opOutd();
                    break;
                case 176:  //LDIR
                    opLdir();
                    break;
                case 177:  //CPIR
                    opCpir();
                    break;
                case 178:  //INIR
                    opInir();
                    break;
                case 179:  //OTIR
                    opOtir();
                    break;
                case 184:  //LDDR
                    opLddr();
                    break;
                case 185:  //CPDR
                    opCpdr();
                    break;
                case 186:  //INDR
                    opIndr();
                    break;
                case 187:  //OTDR
                    opOtdr();
                    break;
                default:
                    throw new InvalidOpcodeException("Execute ED", opcode);
            }

        }
    }
}
