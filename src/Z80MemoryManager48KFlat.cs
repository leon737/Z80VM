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
    public class Z80MemoryManager48KFlat : IMemoryManager
    {
        // memory (64K => 0x0000 ... 0x3FFFF - ROM, 0x4000 ... 0xFFFF - RAM)
        public byte[] mem;

        public Z80MemoryManager48KFlat()
        {
            mem = new byte[0x10000];
        }
        
        public byte ReadByte(ushort addr)
        {
            return mem[addr];
        }

        public byte ReadByteScreen(ushort addr)
        {
            return mem[addr + 0x4000];
        }

        public ushort ReadWord(ushort addr)
        {
            if (addr == 0xFFFF)
                throw new AccessViolationException("Memory read fault. Addr:0xFFFF, Size:2 bytes");
            return (ushort)(((int)mem[addr + 1]) << 8 | (int)mem[addr]);
        }

        public void Write(ushort addr, byte value)
        {
            if (addr < 0x4000)
                //throw new AccessViolationException("Memory write fault. Cannot write to ROM");
                return;
            if (addr < 23296)
            {
                Program.video.Plot(addr);
            }
            mem[addr] = value;
        }

        public void Write(ushort addr, ushort value)
        {
            if (addr < 0x4000)
                //throw new AccessViolationException("Memory write fault. Cannot write to ROM");
                return;
            if (addr == 0xFFFF)
                throw new AccessViolationException("Memory write fault. Addr:0xFFFF, Size:2 bytes");

            if (addr < 23296)
            {
                Program.video.Plot(addr);
            }
            mem[addr] = (byte)(((int)value) & 0xFF);
            mem[addr + 1] = (byte)(((int)value >> 8) & 0xFF);
        }

    }


    public class Z80MemoryManager128K : IMemoryManager
    {
        public byte[][] mem;

         public Z80MemoryManager128K()
        {
            mem = new byte[12][]; // (pages 0 to 7 are RAM, and pages 8 to 11 are ROM)
            for (int i = 0; i < mem.Length; i++)
                mem[i] = new byte [0x4000];
            ResetPaging();
           
        }

        public byte ReadByte(ushort addr)
        {
            int page = Program.paging[addr >> 14];
            return mem[page][addr & 0x3FFF];
        }

        public byte ReadByteScreen(ushort addr)
        {
            return mem[Program.screenPage][addr & 0x3FFF];
        }

        public ushort ReadWord(ushort addr)
        {
            if (addr == 0xFFFF)
                throw new AccessViolationException("Memory read fault. Addr:0xFFFF, Size:2 bytes");
            int page = Program.paging[addr >> 14];
            return (ushort)(((int)mem[page][(addr & 0x3FFF) + 1]) << 8 | (int)mem[page][addr & 0x3FFF]);
        }

        public void Write(ushort addr, byte value)
        {
            if (addr < 0x4000)
                //throw new AccessViolationException("Memory write fault. Cannot write to ROM");
                return;
            int page = Program.paging[addr >> 14];
            if (Program.screenPage == 5 && addr < 23296)
            {
                Program.video.Plot(addr);
            }
            else if (Program.screenPage == 7)
            {
                if ((addr > 49151) && (addr < 56064))
                    Program.video.Plot((ushort)(addr & 32767));
            }
            mem[page][addr & 0x3FFF] = value;
        }

        public void Write(ushort addr, ushort value)
        {
            if (addr < 0x4000)
                //throw new AccessViolationException("Memory write fault. Cannot write to ROM");
                return;
            if (addr == 0xFFFF)
                throw new AccessViolationException("Memory write fault. Addr:0xFFFF, Size:2 bytes");

            int page = Program.paging[addr >> 14];
            if (Program.screenPage == 5 && addr < 23296)
            {
                Program.video.Plot(addr);
            }
            else if (Program.screenPage == 7)
            {
                if ((addr > 49151) && (addr < 56064))
                    Program.video.Plot((ushort)(addr & 32767));
            }
            mem[page][addr & 0x3FFF] = (byte)(((int)value) & 0xFF);
            mem[page][(addr & 0x3FFF) + 1] = (byte)(((int)value >> 8) & 0xFF);
        }

        public void ResetPaging()
        {
            Program.paging[0] = 8;
            Program.paging[1] = 5;
            Program.paging[2] = 2;
            Program.paging[3] = 0;
            Program.paging[4] = 8;
        }

    }
}
