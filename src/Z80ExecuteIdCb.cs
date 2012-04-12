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
        public void ExecuteIdCb(byte opcode, Operand op)
        {
            switch (opcode)
            {
                case 0: //RLC B
                    opRlcId(ComposeRegister(Registers.B), op);
                    break;
                case 1: //RLC C
                    opRlcId(ComposeRegister(Registers.C), op);
                    break;
                case 2: //RLC D
                    opRlcId(ComposeRegister(Registers.D), op);
                    break;
                case 3: //RLC E
                    opRlcId(ComposeRegister(Registers.E), op);
                    break;
                case 4: //RLC H
                    opRlcId(ComposeRegister(Registers.H), op);
                    break;
                case 5: //RLC L
                    opRlcId(ComposeRegister(Registers.L), op);
                    break;
                case 6: //RLC (HL)
                    opRlcId(ComposeIndexIndirect(Registers.HL), op);
                    break;
                case 7: //RLC A
                    opRlcId(ComposeRegister(Registers.A), op);
                    break;
                case 8: //RRC B
                    opRrcId(ComposeRegister(Registers.B), op);
                    break;
                case 9: //RRC C
                    opRrcId(ComposeRegister(Registers.C), op);
                    break;
                case 10: //RRC D
                    opRrcId(ComposeRegister(Registers.D), op);
                    break;
                case 11: //RRC E
                    opRrcId(ComposeRegister(Registers.E), op);
                    break;
                case 12: //RRC H
                    opRrcId(ComposeRegister(Registers.H), op);
                    break;
                case 13: //RRC L
                    opRrcId(ComposeRegister(Registers.L), op);
                    break;
                case 14: //RRC (HL)
                    opRrcId(ComposeIndexIndirect(Registers.HL), op);
                    break;
                case 15: //RRC A
                    opRrcId(ComposeRegister(Registers.A), op);
                    break;
                case 16: //RL B
                    opRlId(ComposeRegister(Registers.B), op);
                    break;
                case 17: //RL C
                    opRlId(ComposeRegister(Registers.C), op);
                    break;
                case 18: //RL D
                    opRlId(ComposeRegister(Registers.D), op);
                    break;
                case 19: //RL E
                    opRlId(ComposeRegister(Registers.E), op);
                    break;
                case 20: //RL H
                    opRlId(ComposeRegister(Registers.H), op);
                    break;
                case 21: //RL L
                    opRlId(ComposeRegister(Registers.L), op);
                    break;
                case 22: //RL (HL)
                    opRlId(ComposeIndexIndirect(Registers.HL), op);
                    break;
                case 23: //RL A
                    opRlId(ComposeRegister(Registers.A), op);
                    break;
                case 24: //RR B
                    opRrId(ComposeRegister(Registers.B), op);
                    break;
                case 25: //RR C
                    opRrId(ComposeRegister(Registers.C), op);
                    break;
                case 26: //RR D
                    opRrId(ComposeRegister(Registers.D), op);
                    break;
                case 27: //RR E
                    opRrId(ComposeRegister(Registers.E), op);
                    break;
                case 28: //RR H
                    opRrId(ComposeRegister(Registers.H), op);
                    break;
                case 29: //RR L
                    opRrId(ComposeRegister(Registers.L), op);
                    break;
                case 30: //RR (HL)
                    opRrId(ComposeIndexIndirect(Registers.HL), op);
                    break;
                case 31: //RR A
                    opRrId(ComposeRegister(Registers.A), op);
                    break;
                case 32: //SLA B
                    opSlaId(ComposeRegister(Registers.B), op);
                    break;
                case 33: //SLA C
                    opSlaId(ComposeRegister(Registers.C), op);
                    break;
                case 34: //SLA D
                    opSlaId(ComposeRegister(Registers.D), op);
                    break;
                case 35: //SLA E
                    opSlaId(ComposeRegister(Registers.E), op);
                    break;
                case 36: //SLA H
                    opSlaId(ComposeRegister(Registers.H), op);
                    break;
                case 37: //SLA L
                    opSlaId(ComposeRegister(Registers.L), op);
                    break;
                case 38: //SLA (HL)
                    opSlaId(ComposeIndexIndirect(Registers.HL), op);
                    break;
                case 39: //SLA A
                    opSlaId(ComposeRegister(Registers.A), op);
                    break;
                case 40: //SRA B
                    opSraId(ComposeRegister(Registers.B), op);
                    break;
                case 41: //SRA C
                    opSraId(ComposeRegister(Registers.C), op);
                    break;
                case 42: //SRA D
                    opSraId(ComposeRegister(Registers.D), op);
                    break;
                case 43: //SRA E
                    opSraId(ComposeRegister(Registers.E), op);
                    break;
                case 44: //SRA H
                    opSraId(ComposeRegister(Registers.H), op);
                    break;
                case 45: //SRA L
                    opSraId(ComposeRegister(Registers.L), op);
                    break;
                case 46: //SRA (HL)
                    opSraId(ComposeIndexIndirect(Registers.HL), op);
                    break;
                case 47: //SRA A
                    opSraId(ComposeRegister(Registers.A), op);
                    break;
                case 48: //SLS B
                    opSlsId(ComposeRegister(Registers.B), op);
                    break;
                case 49: //SLS C
                    opSlsId(ComposeRegister(Registers.C), op);
                    break;
                case 50: //SLS D
                    opSlsId(ComposeRegister(Registers.D), op);
                    break;
                case 51: //SLS E
                    opSlsId(ComposeRegister(Registers.E), op);
                    break;
                case 52: //SLS H
                    opSlsId(ComposeRegister(Registers.H), op);
                    break;
                case 53: //SLS L
                    opSlsId(ComposeRegister(Registers.L), op);
                    break;
                case 54: //SKS (HL)
                    opSlsId(ComposeIndexIndirect(Registers.HL), op);
                    break;
                case 55: //SLS A
                    opSlsId(ComposeRegister(Registers.A), op);
                    break;
                case 56: //SRL B
                    opSrlId(ComposeRegister(Registers.B), op);
                    break;
                case 57: //SRL C
                    opSrlId(ComposeRegister(Registers.C), op);
                    break;
                case 58: //SRL D
                    opSrlId(ComposeRegister(Registers.D), op);
                    break;
                case 59: //SRL E
                    opSrlId(ComposeRegister(Registers.E), op);
                    break;
                case 60: //SRL H
                    opSrlId(ComposeRegister(Registers.H), op);
                    break;
                case 61: //SRL L
                    opSrlId(ComposeRegister(Registers.L), op);
                    break;
                case 62: //SRL (HL)
                    opSrlId(ComposeIndexIndirect(Registers.HL), op);
                    break;
                case 63: //SRL A
                    opSrlId(ComposeRegister(Registers.A), op);
                    break;
                case 64:
                case 65:
                case 66:
                case 67:
                case 68:
                case 69:
                case 70:
                case 71:
                    opBit(0, op);
                    break;
                case 72:
                case 73:
                case 74:
                case 75:
                case 76:
                case 77:
                case 78:
                case 79:
                    opBit(1, op);
                    break;
                case 80:
                case 81:
                case 82:
                case 83:
                case 84:
                case 85:
                case 86:
                case 87:
                    opBit(2, op);
                    break;
                case 88:
                case 89:
                case 90:
                case 91:
                case 92:
                case 93:
                case 94:
                case 95:
                    opBit(3, op);
                    break;
                case 96:
                case 97:
                case 98:
                case 99:
                case 100:
                case 101:
                case 102:
                case 103:
                    opBit(4, op);
                    break;
                case 104:
                case 105:
                case 106:
                case 107:
                case 108:
                case 109:
                case 110:
                case 111:
                    opBit(5, op);
                    break;
                case 112:
                case 113:
                case 114:
                case 115:
                case 116:
                case 117:
                case 118:
                case 119:
                    opBit(6, op);
                    break;
                case 120:
                case 121:
                case 122:
                case 123:
                case 124:
                case 125:
                case 126:
                case 127:
                    opBit(7, op);
                    break;
                case 128: //RES 0, (ID+y)->B
                    opResId(0, ComposeRegister(Registers.B), op);
                    break;
                case 129: //RES 0, (ID+y)->C
                    opResId(0, ComposeRegister(Registers.C), op);
                    break;
                case 130: //RES 0, (ID+y)->D
                    opResId(0, ComposeRegister(Registers.D), op);
                    break;
                case 131: //RES 0, (ID+y)->E
                    opResId(0, ComposeRegister(Registers.E), op);
                    break;
                case 132: //RES 0, (ID+y)->H
                    opResId(0, ComposeRegister(Registers.H), op);
                    break;
                case 133: //RES 0, (ID+y)->L
                    opResId(0, ComposeRegister(Registers.L), op);
                    break;
                case 134: //RES 0, (HL)
                    opResId(0, ComposeRegisterIndirect(Registers.HL), op);
                    break;
                case 135: //RES 0, (ID+y)->A
                    opResId(0, ComposeRegister(Registers.A), op);
                    break;
                case 136: //RES 1, (ID+y)->B
                    opResId(1, ComposeRegister(Registers.B), op);
                    break;
                case 137: //RES 1, (ID+y)->C
                    opResId(1, ComposeRegister(Registers.C), op);
                    break;
                case 138: //RES 1, (ID+y)->D
                    opResId(1, ComposeRegister(Registers.D), op);
                    break;
                case 139: //RES 1, (ID+y)->E
                    opResId(1, ComposeRegister(Registers.E), op);
                    break;
                case 140: //RES 1, (ID+y)->H
                    opResId(1, ComposeRegister(Registers.H), op);
                    break;
                case 141: //RES 1, (ID+y)->L
                    opResId(1, ComposeRegister(Registers.L), op);
                    break;
                case 142: //RES 1, (HL)
                    opResId(1, ComposeRegisterIndirect(Registers.HL), op);
                    break;
                case 143: //RES 1, (ID+y)->A
                    opResId(1, ComposeRegister(Registers.A), op);
                    break;
                case 144: //RES 2, (ID+y)->B
                    opResId(2, ComposeRegister(Registers.B), op);
                    break;
                case 145: //RES 2, (ID+y)->C
                    opResId(2, ComposeRegister(Registers.C), op);
                    break;
                case 146: //RES 2, (ID+y)->D
                    opResId(2, ComposeRegister(Registers.D), op);
                    break;
                case 147: //RES 2, (ID+y)->E
                    opResId(2, ComposeRegister(Registers.E), op);
                    break;
                case 148: //RES 2, (ID+y)->H
                    opResId(2, ComposeRegister(Registers.H), op);
                    break;
                case 149: //RES 2, (ID+y)->L
                    opResId(2, ComposeRegister(Registers.L), op);
                    break;
                case 150: //RES 2, (HL)
                    opResId(2, ComposeRegisterIndirect(Registers.HL), op);
                    break;
                case 151: //RES 2, (ID+y)->A
                    opResId(2, ComposeRegister(Registers.A), op);
                    break;
                case 152: //RES 3, (ID+y)->B
                    opResId(3, ComposeRegister(Registers.B), op);
                    break;
                case 153: //RES 3, (ID+y)->C
                    opResId(3, ComposeRegister(Registers.C), op);
                    break;
                case 154: //RES 3, (ID+y)->D
                    opResId(3, ComposeRegister(Registers.D), op);
                    break;
                case 155: //RES 3, (ID+y)->E
                    opResId(3, ComposeRegister(Registers.E), op);
                    break;
                case 156: //RES 3, (ID+y)->H
                    opResId(3, ComposeRegister(Registers.H), op);
                    break;
                case 157: //RES 3, (ID+y)->L
                    opResId(3, ComposeRegister(Registers.L), op);
                    break;
                case 158: //RES 3, (HL)
                    opResId(3, ComposeRegisterIndirect(Registers.HL), op);
                    break;
                case 159: //RES 3, (ID+y)->A
                    opResId(3, ComposeRegister(Registers.A), op);
                    break;
                case 160: //RES 4, (ID+y)->B
                    opResId(4, ComposeRegister(Registers.B), op);
                    break;
                case 161: //RES 4, (ID+y)->C
                    opResId(4, ComposeRegister(Registers.C), op);
                    break;
                case 162: //RES 4, (ID+y)->D
                    opResId(4, ComposeRegister(Registers.D), op);
                    break;
                case 163: //RES 4, (ID+y)->E
                    opResId(4, ComposeRegister(Registers.E), op);
                    break;
                case 164: //RES 4, (ID+y)->H
                    opResId(4, ComposeRegister(Registers.H), op);
                    break;
                case 165: //RES 4, (ID+y)->L
                    opResId(4, ComposeRegister(Registers.L), op);
                    break;
                case 166: //RES 4, (HL)
                    opResId(4, ComposeRegisterIndirect(Registers.HL), op);
                    break;
                case 167: //RES 4, (ID+y)->A
                    opResId(4, ComposeRegister(Registers.A), op);
                    break;
                case 168: //RES 5, (ID+y)->B
                    opResId(5, ComposeRegister(Registers.B), op);
                    break;
                case 169: //RES 5, (ID+y)->C
                    opResId(5, ComposeRegister(Registers.C), op);
                    break;
                case 170: //RES 5, (ID+y)->D
                    opResId(5, ComposeRegister(Registers.D), op);
                    break;
                case 171: //RES 5, (ID+y)->E
                    opResId(5, ComposeRegister(Registers.E), op);
                    break;
                case 172: //RES 5, (ID+y)->H
                    opResId(5, ComposeRegister(Registers.H), op);
                    break;
                case 173: //RES 5, (ID+y)->L
                    opResId(5, ComposeRegister(Registers.L), op);
                    break;
                case 174: //RES 5, (HL)
                    opResId(5, ComposeRegisterIndirect(Registers.HL), op);
                    break;
                case 175: //RES 5, (ID+y)->A
                    opResId(5, ComposeRegister(Registers.A), op);
                    break;
                case 176: //RES 6, (ID+y)->B
                    opResId(6, ComposeRegister(Registers.B), op);
                    break;
                case 177: //RES 6, (ID+y)->C
                    opResId(6, ComposeRegister(Registers.C), op);
                    break;
                case 178: //RES 6, (ID+y)->D
                    opResId(6, ComposeRegister(Registers.D), op);
                    break;
                case 179: //RES 6, (ID+y)->E
                    opResId(6, ComposeRegister(Registers.E), op);
                    break;
                case 180: //RES 6, (ID+y)->H
                    opResId(6, ComposeRegister(Registers.H), op);
                    break;
                case 181: //RES 6, (ID+y)->L
                    opResId(6, ComposeRegister(Registers.L), op);
                    break;
                case 182: //RES 6, (HL)
                    opResId(6, ComposeRegisterIndirect(Registers.HL), op);
                    break;
                case 183: //RES 6, (ID+y)->A
                    opResId(6, ComposeRegister(Registers.A), op);
                    break;
                case 184: //RES 7, (ID+y)->B
                    opResId(7, ComposeRegister(Registers.B), op);
                    break;
                case 185: //RES 7, (ID+y)->C
                    opResId(7, ComposeRegister(Registers.C), op);
                    break;
                case 186: //RES 7, (ID+y)->D
                    opResId(7, ComposeRegister(Registers.D), op);
                    break;
                case 187: //RES 7, (ID+y)->E
                    opResId(7, ComposeRegister(Registers.E), op);
                    break;
                case 188: //RES 7, (ID+y)->H
                    opResId(7, ComposeRegister(Registers.H), op);
                    break;
                case 189: //RES 7, (ID+y)->L
                    opResId(7, ComposeRegister(Registers.L), op);
                    break;
                case 190: //RES 7, (HL)
                    opResId(7, ComposeRegisterIndirect(Registers.HL), op);
                    break;
                case 191: //RES 7, (ID+y)->A
                    opResId(7, ComposeRegister(Registers.A), op);
                    break;
                case 192: //SET 0, (ID+y)->B
                    opSetId(0, ComposeRegister(Registers.B), op);
                    break;
                case 193: //SET 0, (ID+y)->C
                    opSetId(0, ComposeRegister(Registers.C), op);
                    break;
                case 194: //SET 0, (ID+y)->D
                    opSetId(0, ComposeRegister(Registers.D), op);
                    break;
                case 195: //SET 0, (ID+y)->E
                    opSetId(0, ComposeRegister(Registers.E), op);
                    break;
                case 196: //SET 0, (ID+y)->H
                    opSetId(0, ComposeRegister(Registers.H), op);
                    break;
                case 197: //SET 0, (ID+y)->L
                    opSetId(0, ComposeRegister(Registers.L), op);
                    break;
                case 198: //SET 0, (HL)
                    opSetId(0, ComposeRegisterIndirect(Registers.HL), op);
                    break;
                case 199: //SET 0, (ID+y)->A
                    opSetId(0, ComposeRegister(Registers.A), op);
                    break;
                case 200: //SET 1, (ID+y)->B
                    opSetId(1, ComposeRegister(Registers.B), op);
                    break;
                case 201: //SET 1, (ID+y)->C
                    opSetId(1, ComposeRegister(Registers.C), op);
                    break;
                case 202: //SET 1, (ID+y)->D
                    opSetId(1, ComposeRegister(Registers.D), op);
                    break;
                case 203: //SET 1, (ID+y)->E
                    opSetId(1, ComposeRegister(Registers.E), op);
                    break;
                case 204: //SET 1, (ID+y)->H
                    opSetId(1, ComposeRegister(Registers.H), op);
                    break;
                case 205: //SET 1, (ID+y)->L
                    opSetId(1, ComposeRegister(Registers.L), op);
                    break;
                case 206: //SET 1, (HL)
                    opSetId(1, ComposeRegisterIndirect(Registers.HL), op);
                    break;
                case 207: //SET 1, (ID+y)->A
                    opSetId(1, ComposeRegister(Registers.A), op);
                    break;
                case 208: //SET 2, (ID+y)->B
                    opSetId(2, ComposeRegister(Registers.B), op);
                    break;
                case 209: //SET 2, (ID+y)->C
                    opSetId(2, ComposeRegister(Registers.C), op);
                    break;
                case 210: //SET 2, (ID+y)->D
                    opSetId(2, ComposeRegister(Registers.D), op);
                    break;
                case 211: //SET 2, (ID+y)->E
                    opSetId(2, ComposeRegister(Registers.E), op);
                    break;
                case 212: //SET 2, (ID+y)->H
                    opSetId(2, ComposeRegister(Registers.H), op);
                    break;
                case 213: //SET 2, (ID+y)->L
                    opSetId(2, ComposeRegister(Registers.L), op);
                    break;
                case 214: //SET 2, (HL)
                    opSetId(2, ComposeRegisterIndirect(Registers.HL), op);
                    break;
                case 215: //SET 2, (ID+y)->A
                    opSetId(2, ComposeRegister(Registers.A), op);
                    break;
                case 216: //SET 3, (ID+y)->B
                    opSetId(3, ComposeRegister(Registers.B), op);
                    break;
                case 217: //SET 3, (ID+y)->C
                    opSetId(3, ComposeRegister(Registers.C), op);
                    break;
                case 218: //SET 3, (ID+y)->D
                    opSetId(3, ComposeRegister(Registers.D), op);
                    break;
                case 219: //SET 3, (ID+y)->E
                    opSetId(3, ComposeRegister(Registers.E), op);
                    break;
                case 220: //SET 3, (ID+y)->H
                    opSetId(3, ComposeRegister(Registers.H), op);
                    break;
                case 221: //SET 3, (ID+y)->L
                    opSetId(3, ComposeRegister(Registers.L), op);
                    break;
                case 222: //SET 3, (HL)
                    opSetId(3, ComposeRegisterIndirect(Registers.HL), op);
                    break;
                case 223: //SET 3, (ID+y)->A
                    opSetId(3, ComposeRegister(Registers.A), op);
                    break;
                case 224: //SET 4, (ID+y)->B
                    opSetId(4, ComposeRegister(Registers.B), op);
                    break;
                case 225: //SET 4, (ID+y)->C
                    opSetId(4, ComposeRegister(Registers.C), op);
                    break;
                case 226: //SET 4, (ID+y)->D
                    opSetId(4, ComposeRegister(Registers.D), op);
                    break;
                case 227: //SET 4, (ID+y)->E
                    opSetId(4, ComposeRegister(Registers.E), op);
                    break;
                case 228: //SET 4, (ID+y)->H
                    opSetId(4, ComposeRegister(Registers.H), op);
                    break;
                case 229: //SET 4, (ID+y)->L
                    opSetId(4, ComposeRegister(Registers.L), op);
                    break;
                case 230: //SET 4, (HL)
                    opSetId(4, ComposeRegisterIndirect(Registers.HL), op);
                    break;
                case 231: //SET 4, (ID+y)->A
                    opSetId(4, ComposeRegister(Registers.A), op);
                    break;
                case 232: //SET 5, (ID+y)->B
                    opSetId(5, ComposeRegister(Registers.B), op);
                    break;
                case 233: //SET 5, (ID+y)->C
                    opSetId(5, ComposeRegister(Registers.C), op);
                    break;
                case 234: //SET 5, (ID+y)->D
                    opSetId(5, ComposeRegister(Registers.D), op);
                    break;
                case 235: //SET 5, (ID+y)->E
                    opSetId(5, ComposeRegister(Registers.E), op);
                    break;
                case 236: //SET 5, (ID+y)->H
                    opSetId(5, ComposeRegister(Registers.H), op);
                    break;
                case 237: //SET 5, (ID+y)->L
                    opSetId(5, ComposeRegister(Registers.L), op);
                    break;
                case 238: //SET 5, (HL)
                    opSetId(5, ComposeRegisterIndirect(Registers.HL), op);
                    break;
                case 239: //SET 5, (ID+y)->A
                    opSetId(5, ComposeRegister(Registers.A), op);
                    break;
                case 240: //SET 6, (ID+y)->B
                    opSetId(6, ComposeRegister(Registers.B), op);
                    break;
                case 241: //SET 6, (ID+y)->C
                    opSetId(6, ComposeRegister(Registers.C), op);
                    break;
                case 242: //SET 6, (ID+y)->D
                    opSetId(6, ComposeRegister(Registers.D), op);
                    break;
                case 243: //SET 6, (ID+y)->E
                    opSetId(6, ComposeRegister(Registers.E), op);
                    break;
                case 244: //SET 6, (ID+y)->H
                    opSetId(6, ComposeRegister(Registers.H), op);
                    break;
                case 245: //SET 6, (ID+y)->L
                    opSetId(6, ComposeRegister(Registers.L), op);
                    break;
                case 246: //SET 6, (HL)
                    opSetId(6, ComposeRegisterIndirect(Registers.HL), op);
                    break;
                case 247: //SET 6, (ID+y)->A
                    opSetId(6, ComposeRegister(Registers.A), op);
                    break;
                case 248: //SET 7, (ID+y)->B
                    opSetId(7, ComposeRegister(Registers.B), op);
                    break;
                case 249: //SET 7, (ID+y)->C
                    opSetId(7, ComposeRegister(Registers.C), op);
                    break;
                case 250: //SET 7, (ID+y)->D
                    opSetId(7, ComposeRegister(Registers.D), op);
                    break;
                case 251: //SET 7, (ID+y)->E
                    opSetId(7, ComposeRegister(Registers.E), op);
                    break;
                case 252: //SET 7, (ID+y)->H
                    opSetId(7, ComposeRegister(Registers.H), op);
                    break;
                case 253: //SET 7, (ID+y)->L
                    opSetId(7, ComposeRegister(Registers.L), op);
                    break;
                case 254: //SET 7, (HL)
                    opSetId(7, ComposeRegisterIndirect(Registers.HL), op);
                    break;
                case 255: //SET 7, (ID+y)->A
                    opSetId(7, ComposeRegister(Registers.A), op);
                    break;
                default:
                    throw new InvalidOpcodeException("Execute ID CB", opcode);
            }
        }
    }
}
