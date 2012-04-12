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

        public void ExecuteCb()
        {
            byte opcode = Fetch();
            switch (opcode)
            {
                case 0:  //RLC B
                    opRlc(ComposeRegister(Registers.B));
                    break;
                case 1:  //RLC C
                    opRlc(ComposeRegister(Registers.C));
                    break;
                case 2:  //RLC D
                    opRlc(ComposeRegister(Registers.D));
                    break;
                case 3:  //RLC E
                    opRlc(ComposeRegister(Registers.E));
                    break;
                case 4:  //RLC H
                    opRlc(ComposeRegister(Registers.H));
                    break;
                case 5:  //RLC L
                    opRlc(ComposeRegister(Registers.L));
                    break;
                case 6:  //RLC (HL)
                    opRlc(ComposeRegisterIndirect(Registers.HL));
                    break;
                case 7:  //RLC A
                    opRlc(ComposeRegister(Registers.A));
                    break;
                case 8:  //RRC B
                    opRrc(ComposeRegister(Registers.B));
                    break;
                case 9:  //RRC C
                    opRrc(ComposeRegister(Registers.C));
                    break;
                case 10: //RRC D
                    opRrc(ComposeRegister(Registers.D));
                    break;
                case 11: //RRC E
                    opRrc(ComposeRegister(Registers.E));
                    break;
                case 12: //RRC H
                    opRrc(ComposeRegister(Registers.H));
                    break;
                case 13: //RRC L
                    opRrc(ComposeRegister(Registers.L));
                    break;
                case 14: //RRC (HL)
                    opRrc(ComposeRegisterIndirect(Registers.HL));
                    break;
                case 15: //RRC A
                    opRrc(ComposeRegister(Registers.A));
                    break;
                case 16: //RL B
                    opRl(ComposeRegister(Registers.B));
                    break;
                case 17: //RL C
                    opRl(ComposeRegister(Registers.C));
                    break;
                case 18: //RL D
                    opRl(ComposeRegister(Registers.D));
                    break;
                case 19: //RL E
                    opRl(ComposeRegister(Registers.E));
                    break;
                case 20: //RL H
                    opRl(ComposeRegister(Registers.H));
                    break;
                case 21: //RL L
                    opRl(ComposeRegister(Registers.L));
                    break;
                case 22: //RL (HL)
                    opRl(ComposeRegisterIndirect(Registers.HL));
                    break;
                case 23: //RL A
                    opRl(ComposeRegister(Registers.A));
                    break;
                case 24: //RR B
                    opRr(ComposeRegister(Registers.B));
                    break;
                case 25: //RR C
                    opRr(ComposeRegister(Registers.C));
                    break;
                case 26: //RR D
                    opRr(ComposeRegister(Registers.D));
                    break;
                case 27: //RR E
                    opRr(ComposeRegister(Registers.E));
                    break;
                case 28: //RR H
                    opRr(ComposeRegister(Registers.H));
                    break;
                case 29: //RR L
                    opRr(ComposeRegister(Registers.L));
                    break;
                case 30: //RR (HL)
                    opRr(ComposeRegisterIndirect(Registers.HL));
                    break;
                case 31: //RR A
                    opRr(ComposeRegister(Registers.A));
                    break;
                case 32: //SLA B
                    opSla(ComposeRegister(Registers.B));
                    break;
                case 33: //SLA C
                    opSla(ComposeRegister(Registers.C));
                    break;
                case 34: //SLA D
                    opSla(ComposeRegister(Registers.D));
                    break;
                case 35: //SLA E
                    opSla(ComposeRegister(Registers.E));
                    break;
                case 36: //SLA H
                    opSla(ComposeRegister(Registers.H));
                    break;
                case 37: //SLA L
                    opSla(ComposeRegister(Registers.L));
                    break;
                case 38: //SLA (HL)
                    opSla(ComposeRegisterIndirect(Registers.HL));
                    break;
                case 39: //SLA A
                    opSla(ComposeRegister(Registers.A));
                    break;
                case 40: //SRA B
                    opSra(ComposeRegister(Registers.B));
                    break;
                case 41: //SRA C
                    opSra(ComposeRegister(Registers.C));
                    break;
                case 42: //SRA D
                    opSra(ComposeRegister(Registers.D));
                    break;
                case 43: //SRA E
                    opSra(ComposeRegister(Registers.E));
                    break;
                case 44: //SRA H
                    opSra(ComposeRegister(Registers.H));
                    break;
                case 45: //SRA L
                    opSra(ComposeRegister(Registers.L));
                    break;
                case 46: //SRA (HL)
                    opSra(ComposeRegisterIndirect(Registers.HL));
                    break;
                case 47: //SRA A
                    opSra(ComposeRegister(Registers.A));
                    break;
                case 48: //SLS B
                    opSls(ComposeRegister(Registers.B));
                    break;
                case 49: //SLS C
                    opSls(ComposeRegister(Registers.C));
                    break;
                case 50: //SLS D
                    opSls(ComposeRegister(Registers.D));
                    break;
                case 51: //SLS E
                    opSls(ComposeRegister(Registers.E));
                    break;
                case 52: //SLS H
                    opSls(ComposeRegister(Registers.H));
                    break;
                case 53: //SLS L
                    opSls(ComposeRegister(Registers.L));
                    break;
                case 54: //SLS (HL)
                    opSls(ComposeRegisterIndirect(Registers.HL));
                    break;
                case 55: //SLS A
                    opSls(ComposeRegister(Registers.A));
                    break;
                case 56: //SRL B
                    opSrl(ComposeRegister(Registers.B));
                    break;
                case 57: //SRL C
                    opSrl(ComposeRegister(Registers.C));
                    break;
                case 58: //SRL D
                    opSrl(ComposeRegister(Registers.D));
                    break;
                case 59: //SRL E
                    opSrl(ComposeRegister(Registers.E));
                    break;
                case 60: //SRL H
                    opSrl(ComposeRegister(Registers.H));
                    break;
                case 61: //SRL L
                    opSrl(ComposeRegister(Registers.L));
                    break;
                case 62: //SRL (HL)
                    opSrl(ComposeRegisterIndirect(Registers.HL));
                    break;
                case 63: //SRL A
                    opSrl(ComposeRegister(Registers.A));
                    break;
                case 64: //BIT 0,B
                    opBit(0, ComposeRegister(Registers.B));
                    break;
                case 65: //BIT 0,C
                    opBit(0, ComposeRegister(Registers.C));
                    break;
                case 66: //BIT 0,D
                    opBit(0, ComposeRegister(Registers.D));
                    break;
                case 67: //BIT 0,E
                    opBit(0, ComposeRegister(Registers.E));
                    break;
                case 68: //BIT 0,H
                    opBit(0, ComposeRegister(Registers.H));
                    break;
                case 69: //BIT 0,L
                    opBit(0, ComposeRegister(Registers.L));
                    break;
                case 70: //BIT 0,(HL)
                    opBit(0, ComposeRegisterIndirect(Registers.HL));
                    break;
                case 71: //BIT 0,A
                    opBit(0, ComposeRegister(Registers.A));
                    break;
                case 72: //BIT 1,B
                    opBit(1, ComposeRegister(Registers.B));
                    break;
                case 73: //BIT 1,C
                    opBit(1, ComposeRegister(Registers.C));
                    break;
                case 74: //BIT 1,D
                    opBit(1, ComposeRegister(Registers.D));
                    break;
                case 75: //BIT 1,E
                    opBit(1, ComposeRegister(Registers.E));
                    break;
                case 76: //BIT 1,H
                    opBit(1, ComposeRegister(Registers.H));
                    break;
                case 77: //BIT 1,L
                    opBit(1, ComposeRegister(Registers.L));
                    break;
                case 78: //BIT 1,(HL)
                    opBit(1, ComposeRegisterIndirect(Registers.HL));
                    break;
                case 79: //BIT 1,A
                    opBit(1, ComposeRegister(Registers.A));
                    break;
                case 80: //BIT 2,B
                    opBit(2, ComposeRegister(Registers.B));
                    break;
                case 81: //BIT 2,C
                    opBit(2, ComposeRegister(Registers.C));
                    break;
                case 82: //BIT 2,D
                    opBit(2, ComposeRegister(Registers.D));
                    break;
                case 83: //BIT 2,E
                    opBit(2, ComposeRegister(Registers.E));
                    break;
                case 84: //BIT 2,H
                    opBit(2, ComposeRegister(Registers.H));
                    break;
                case 85: //BIT 2,L
                    opBit(2, ComposeRegister(Registers.L));
                    break;
                case 86: //BIT 2,(HL)
                    opBit(2, ComposeRegisterIndirect(Registers.HL));
                    break;
                case 87: //BIT 2,A
                    opBit(2, ComposeRegister(Registers.A));
                    break;
                case 88: //BIT 3,B
                    opBit(3, ComposeRegister(Registers.B));
                    break;
                case 89: //BIT 3,C
                    opBit(3, ComposeRegister(Registers.C));
                    break;
                case 90: //BIT 3,D
                    opBit(3, ComposeRegister(Registers.D));
                    break;
                case 91: //BIT 3,E
                    opBit(3, ComposeRegister(Registers.E));
                    break;
                case 92: //BIT 3,H
                    opBit(3, ComposeRegister(Registers.H));
                    break;
                case 93: //BIT 3,L
                    opBit(3, ComposeRegister(Registers.L));
                    break;
                case 94: //BIT 3,(HL)
                    opBit(3, ComposeRegisterIndirect(Registers.HL));
                    break;
                case 95: //BIT 3,A
                    opBit(3, ComposeRegister(Registers.A));
                    break;
                case 96: //BIT 4,B
                    opBit(4, ComposeRegister(Registers.B));
                    break;
                case 97: //BIT 4,C
                    opBit(4, ComposeRegister(Registers.C));
                    break;
                case 98: //BIT 4,D
                    opBit(4, ComposeRegister(Registers.D));
                    break;
                case 99: //BIT 4,E
                    opBit(4, ComposeRegister(Registers.E));
                    break;
                case 100: //BIT 4,H
                    opBit(4, ComposeRegister(Registers.H));
                    break;
                case 101: //BIT 4,L
                    opBit(4, ComposeRegister(Registers.L));
                    break;
                case 102: //BIT 4,(HL)
                    opBit(4, ComposeRegisterIndirect(Registers.HL));
                    break;
                case 103: //BIT 4,A
                    opBit(4, ComposeRegister(Registers.A));
                    break;
                case 104: //BIT 5,B
                    opBit(5, ComposeRegister(Registers.B));
                    break;
                case 105: //BIT 5,C
                    opBit(5, ComposeRegister(Registers.C));
                    break;
                case 106: //BIT 5,D
                    opBit(5, ComposeRegister(Registers.D));
                    break;
                case 107: //BIT 5,E
                    opBit(5, ComposeRegister(Registers.E));
                    break;
                case 108: //BIT 5,H
                    opBit(5, ComposeRegister(Registers.H));
                    break;
                case 109: //BIT 5,L
                    opBit(5, ComposeRegister(Registers.L));
                    break;
                case 110: //BIT 5,(HL)
                    opBit(5, ComposeRegisterIndirect(Registers.HL));
                    break;
                case 111: //BIT 5,A
                    opBit(5, ComposeRegister(Registers.A));
                    break;
                case 112: //BIT 6,B
                    opBit(6, ComposeRegister(Registers.B));
                    break;
                case 113: //BIT 6,C
                    opBit(6, ComposeRegister(Registers.C));
                    break;
                case 114: //BIT 6,D
                    opBit(6, ComposeRegister(Registers.D));
                    break;
                case 115: //BIT 6,E
                    opBit(6, ComposeRegister(Registers.E));
                    break;
                case 116: //BIT 6,H
                    opBit(6, ComposeRegister(Registers.H));
                    break;
                case 117: //BIT 6,L
                    opBit(6, ComposeRegister(Registers.L));
                    break;
                case 118: //BIT 6,(HL)
                    opBit(6, ComposeRegisterIndirect(Registers.HL));
                    break;
                case 119: //BIT 6,A
                    opBit(6, ComposeRegister(Registers.A));
                    break;
                case 120: //BIT 7,B
                    opBit(7, ComposeRegister(Registers.B));
                    break;
                case 121: //BIT 7,C
                    opBit(7, ComposeRegister(Registers.C));
                    break;
                case 122: //BIT 7,D
                    opBit(7, ComposeRegister(Registers.D));
                    break;
                case 123: //BIT 7,E
                    opBit(7, ComposeRegister(Registers.E));
                    break;
                case 124: //BIT 7,H
                    opBit(7, ComposeRegister(Registers.H));
                    break;
                case 125: //BIT 7,L
                    opBit(7, ComposeRegister(Registers.L));
                    break;
                case 126: //BIT 7,(HL)
                    opBit(7, ComposeRegisterIndirect(Registers.HL));
                    break;
                case 127: //BIT 7,A
                    opBit(7, ComposeRegister(Registers.A));
                    break;
                case 128: //RES 0,B
                    opRes(0, ComposeRegister(Registers.B));
                    break;
                case 129: //RES 0,C
                    opRes(0, ComposeRegister(Registers.C));
                    break;
                case 130: //RES 0,D
                    opRes(0, ComposeRegister(Registers.D));
                    break;
                case 131: //RES 0,E
                    opRes(0, ComposeRegister(Registers.E));
                    break;
                case 132: //RES 0,H
                    opRes(0, ComposeRegister(Registers.H));
                    break;
                case 133: //RES 0,L
                    opRes(0, ComposeRegister(Registers.L));
                    break;
                case 134: //RES 0,(HL)
                    opRes(0, ComposeRegisterIndirect(Registers.HL));
                    break;
                case 135: //RES 0,A
                    opRes(0, ComposeRegister(Registers.A));
                    break;
                case 136: //RES 1,B
                    opRes(1, ComposeRegister(Registers.B));
                    break;
                case 137: //RES 1,C
                    opRes(1, ComposeRegister(Registers.C));
                    break;
                case 138: //RES 1,D
                    opRes(1, ComposeRegister(Registers.D));
                    break;
                case 139: //RES 1,E
                    opRes(1, ComposeRegister(Registers.E));
                    break;
                case 140: //RES 1,H
                    opRes(1, ComposeRegister(Registers.H));
                    break;
                case 141: //RES 1,L
                    opRes(1, ComposeRegister(Registers.L));
                    break;
                case 142: //RES 1,(HL)
                    opRes(1, ComposeRegisterIndirect(Registers.HL));
                    break;
                case 143: //RES 1,A
                    opRes(1, ComposeRegister(Registers.A));
                    break;
                case 144: //RES 2,B
                    opRes(2, ComposeRegister(Registers.B));
                    break;
                case 145: //RES 2,C
                    opRes(2, ComposeRegister(Registers.C));
                    break;
                case 146: //RES 2,D
                    opRes(2, ComposeRegister(Registers.D));
                    break;
                case 147: //RES 2,E
                    opRes(2, ComposeRegister(Registers.E));
                    break;
                case 148: //RES 2,H
                    opRes(2, ComposeRegister(Registers.H));
                    break;
                case 149: //RES 2,L
                    opRes(2, ComposeRegister(Registers.L));
                    break;
                case 150: //RES 2,(HL)
                    opRes(2, ComposeRegisterIndirect(Registers.HL));
                    break;
                case 151: //RES 2,A
                    opRes(2, ComposeRegister(Registers.A));
                    break;
                case 152: //RES 3,B
                    opRes(3, ComposeRegister(Registers.B));
                    break;
                case 153: //RES 3,C
                    opRes(3, ComposeRegister(Registers.C));
                    break;
                case 154: //RES 3,D
                    opRes(3, ComposeRegister(Registers.D));
                    break;
                case 155: //RES 3,E
                    opRes(3, ComposeRegister(Registers.E));
                    break;
                case 156: //RES 3,H
                    opRes(3, ComposeRegister(Registers.H));
                    break;
                case 157: //RES 3,L
                    opRes(3, ComposeRegister(Registers.L));
                    break;
                case 158: //RES 3,(HL)
                    opRes(3, ComposeRegisterIndirect(Registers.HL));
                    break;
                case 159: //RES 3,A
                    opRes(3, ComposeRegister(Registers.A));
                    break;
                case 160: //RES 4,B
                    opRes(4, ComposeRegister(Registers.B));
                    break;
                case 161: //RES 4,C
                    opRes(4, ComposeRegister(Registers.C));
                    break;
                case 162: //RES 4,D
                    opRes(4, ComposeRegister(Registers.D));
                    break;
                case 163: //RES 4,E
                    opRes(4, ComposeRegister(Registers.E));
                    break;
                case 164: //RES 4,H
                    opRes(4, ComposeRegister(Registers.H));
                    break;
                case 165: //RES 4,L
                    opRes(4, ComposeRegister(Registers.L));
                    break;
                case 166: //RES 4,(HL)
                    opRes(4, ComposeRegisterIndirect(Registers.HL));
                    break;
                case 167: //RES 4,A
                    opRes(4, ComposeRegister(Registers.A));
                    break;
                case 168: //RES 5,B
                    opRes(5, ComposeRegister(Registers.B));
                    break;
                case 169: //RES 5,C
                    opRes(5, ComposeRegister(Registers.C));
                    break;
                case 170: //RES 5,D
                    opRes(5, ComposeRegister(Registers.D));
                    break;
                case 171: //RES 5,E
                    opRes(5, ComposeRegister(Registers.E));
                    break;
                case 172: //RES 5,H
                    opRes(5, ComposeRegister(Registers.H));
                    break;
                case 173: //RES 5,L
                    opRes(5, ComposeRegister(Registers.L));
                    break;
                case 174: //RES 5,(HL)
                    opRes(5, ComposeRegisterIndirect(Registers.HL));
                    break;
                case 175: //RES 5,A
                    opRes(5, ComposeRegister(Registers.A));
                    break;
                case 176: //RES 6,B
                    opRes(6, ComposeRegister(Registers.B));
                    break;
                case 177: //RES 6,C
                    opRes(6, ComposeRegister(Registers.C));
                    break;
                case 178: //RES 6,D
                    opRes(6, ComposeRegister(Registers.D));
                    break;
                case 179: //RES 6,E
                    opRes(6, ComposeRegister(Registers.E));
                    break;
                case 180: //RES 6,H
                    opRes(6, ComposeRegister(Registers.H));
                    break;
                case 181: //RES 6,L
                    opRes(6, ComposeRegister(Registers.L));
                    break;
                case 182: //RES 6,(HL)
                    opRes(6, ComposeRegisterIndirect(Registers.HL));
                    break;
                case 183: //RES 6,A
                    opRes(6, ComposeRegister(Registers.A));
                    break;
                case 184: //RES 7,B
                    opRes(7, ComposeRegister(Registers.B));
                    break;
                case 185: //RES 7,C
                    opRes(7, ComposeRegister(Registers.C));
                    break;
                case 186: //RES 7,D
                    opRes(7, ComposeRegister(Registers.D));
                    break;
                case 187: //RES 7,E
                    opRes(7, ComposeRegister(Registers.E));
                    break;
                case 188: //RES 7,H
                    opRes(7, ComposeRegister(Registers.H));
                    break;
                case 189: //RES 7,L
                    opRes(7, ComposeRegister(Registers.L));
                    break;
                case 190: //RES 7,(HL)
                    opRes(7, ComposeRegisterIndirect(Registers.HL));
                    break;
                case 191: //RES 7,A
                    opRes(7, ComposeRegister(Registers.A));
                    break;
                case 192: //SET 0,B
                    opSet(0, ComposeRegister(Registers.B));
                    break;
                case 193: //SET 0,C
                    opSet(0, ComposeRegister(Registers.C));
                    break;
                case 194: //SET 0,D
                    opSet(0, ComposeRegister(Registers.D));
                    break;
                case 195: //SET 0,E
                    opSet(0, ComposeRegister(Registers.E));
                    break;
                case 196: //SET 0,H
                    opSet(0, ComposeRegister(Registers.H));
                    break;
                case 197: //SET 0,L
                    opSet(0, ComposeRegister(Registers.L));
                    break;
                case 198: //SET 0,(HL)
                    opSet(0, ComposeRegisterIndirect(Registers.HL));
                    break;
                case 199: //SET 0,A
                    opSet(0, ComposeRegister(Registers.A));
                    break;
                case 200: //SET 1,B
                    opSet(1, ComposeRegister(Registers.B));
                    break;
                case 201: //SET 1,C
                    opSet(1, ComposeRegister(Registers.C));
                    break;
                case 202: //SET 1,D
                    opSet(1, ComposeRegister(Registers.D));
                    break;
                case 203: //SET 1,E
                    opSet(1, ComposeRegister(Registers.E));
                    break;
                case 204: //SET 1,H
                    opSet(1, ComposeRegister(Registers.H));
                    break;
                case 205: //SET 1,L
                    opSet(1, ComposeRegister(Registers.L));
                    break;
                case 206: //SET 1,(HL)
                    opSet(1, ComposeRegisterIndirect(Registers.HL));
                    break;
                case 207: //SET 1,A
                    opSet(1, ComposeRegister(Registers.A));
                    break;
                case 208: //SET 2,B
                    opSet(2, ComposeRegister(Registers.B));
                    break;
                case 209: //SET 2,C
                    opSet(2, ComposeRegister(Registers.C));
                    break;
                case 210: //SET 2,D
                    opSet(2, ComposeRegister(Registers.D));
                    break;
                case 211: //SET 2,E
                    opSet(2, ComposeRegister(Registers.E));
                    break;
                case 212: //SET 2,H
                    opSet(2, ComposeRegister(Registers.H));
                    break;
                case 213: //SET 2,L
                    opSet(2, ComposeRegister(Registers.L));
                    break;
                case 214: //SET 2,(HL)
                    opSet(2, ComposeRegisterIndirect(Registers.HL));
                    break;
                case 215: //SET 2,A
                    opSet(2, ComposeRegister(Registers.A));
                    break;
                case 216: //SET 3,B
                    opSet(3, ComposeRegister(Registers.B));
                    break;
                case 217: //SET 3,C
                    opSet(3, ComposeRegister(Registers.C));
                    break;
                case 218: //SET 3,D
                    opSet(3, ComposeRegister(Registers.D));
                    break;
                case 219: //SET 3,E
                    opSet(3, ComposeRegister(Registers.E));
                    break;
                case 220: //SET 3,H
                    opSet(3, ComposeRegister(Registers.H));
                    break;
                case 221: //SET 3,L
                    opSet(3, ComposeRegister(Registers.L));
                    break;
                case 222: //SET 3,(HL)
                    opSet(3, ComposeRegisterIndirect(Registers.HL));
                    break;
                case 223: //SET 3,A
                    opSet(3, ComposeRegister(Registers.A));
                    break;
                case 224: //SET 4,B
                    opSet(4, ComposeRegister(Registers.B));
                    break;
                case 225: //SET 4,C
                    opSet(4, ComposeRegister(Registers.C));
                    break;
                case 226: //SET 4,D
                    opSet(4, ComposeRegister(Registers.D));
                    break;
                case 227: //SET 4,E
                    opSet(4, ComposeRegister(Registers.E));
                    break;
                case 228: //SET 4,H
                    opSet(4, ComposeRegister(Registers.H));
                    break;
                case 229: //SET 4,L
                    opSet(4, ComposeRegister(Registers.L));
                    break;
                case 230: //SET 4,(HL)
                    opSet(4, ComposeRegisterIndirect(Registers.HL));
                    break;
                case 231: //SET 4,A
                    opSet(4, ComposeRegister(Registers.A));
                    break;
                case 232: //SET 5,B
                    opSet(5, ComposeRegister(Registers.B));
                    break;
                case 233: //SET 5,C
                    opSet(5, ComposeRegister(Registers.C));
                    break;
                case 234: //SET 5,D
                    opSet(5, ComposeRegister(Registers.D));
                    break;
                case 235: //SET 5,E
                    opSet(5, ComposeRegister(Registers.E));
                    break;
                case 236: //SET 5,H
                    opSet(5, ComposeRegister(Registers.H));
                    break;
                case 237: //SET 5,L
                    opSet(5, ComposeRegister(Registers.L));
                    break;
                case 238: //SET 5,(HL)
                    opSet(5, ComposeRegisterIndirect(Registers.HL));
                    break;
                case 239: //SET 5,A
                    opSet(5, ComposeRegister(Registers.A));
                    break;
                case 240: //SET 6,B
                    opSet(6, ComposeRegister(Registers.B));
                    break;
                case 241: //SET 6,C
                    opSet(6, ComposeRegister(Registers.C));
                    break;
                case 242: //SET 6,D
                    opSet(6, ComposeRegister(Registers.D));
                    break;
                case 243: //SET 6,E
                    opSet(6, ComposeRegister(Registers.E));
                    break;
                case 244: //SET 6,H
                    opSet(6, ComposeRegister(Registers.H));
                    break;
                case 245: //SET 6,L
                    opSet(6, ComposeRegister(Registers.L));
                    break;
                case 246: //SET 6,(HL)
                    opSet(6, ComposeRegisterIndirect(Registers.HL));
                    break;
                case 247: //SET 6,A
                    opSet(6, ComposeRegister(Registers.A));
                    break;
                case 248: //SET 7,B
                    opSet(7, ComposeRegister(Registers.B));
                    break;
                case 249: //SET 7,C
                    opSet(7, ComposeRegister(Registers.C));
                    break;
                case 250: //SET 7,D
                    opSet(7, ComposeRegister(Registers.D));
                    break;
                case 251: //SET 7,E
                    opSet(7, ComposeRegister(Registers.E));
                    break;
                case 252: //SET 7,H
                    opSet(7, ComposeRegister(Registers.H));
                    break;
                case 253: //SET 7,L
                    opSet(7, ComposeRegister(Registers.L));
                    break;
                case 254: //SET 7,(HL)
                    opSet(7, ComposeRegisterIndirect(Registers.HL));
                    break;
                case 255: //SET 7,A
                    opSet(7, ComposeRegister(Registers.A));
                    break;
                default:
                    throw new InvalidOpcodeException("Execute CB", opcode);
            }
        }
    }
}
