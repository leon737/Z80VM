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
    public class Z80Model
    {
        public IMemoryManager memoryManager;
        IPortManager portManager;
        IVideoRenderer videoRenderer;

        public Z80Model(System.Windows.Forms.Form d, int size)
        {
            if (size == 128)
                memoryManager = new Z80MemoryManager128K();
            else
                memoryManager = new Z80MemoryManager48KFlat();
            portManager = new Z80PortManager();
            videoRenderer = new VideoRenderer(d);
        }

        public IMemoryManager MemoryManager
        {
            get { return memoryManager; }
        }

        public IPortManager PortManager
        {
            get { return portManager; }
        }

        public IVideoRenderer VideoRenderer
        {
            get { return videoRenderer; }
        }

    }



    public interface IMemoryManager
    {
        byte ReadByte(ushort addr);
        ushort ReadWord(ushort addr);
        void Write(ushort addr, byte value);
        void Write(ushort addr, ushort value);
        byte ReadByteScreen(ushort addr);
    }

    public interface IPortManager
    {
        byte ReadByte(ushort addr);
        void Write(ushort addr, byte value);
    }

    public interface IVideoRenderer
    {
        void Draw();
        void Plot(ushort addr);
    }
}
