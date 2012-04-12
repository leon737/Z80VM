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

using System.Diagnostics;

namespace Z80VM
{
    public class Z80PortManager : IPortManager
    {
        public byte ReadByte(ushort addr)
        {
            int res;

            res = 0xBF;

            if ((addr & 0xFE) != 0 && Program.video.Form.fs != null && !Program.video.Form.IsWriting)
            {
                byte r = (byte)Program.video.Form.fs.ReadByte();
                res |= (r & 0x40);
            }


             if ((addr & 0xFF) == 254) 
            {
                
                if ((addr & 0x8000) == 0)
                    res &= Program.keyB_SPC;
                if ((addr & 0x4000) == 0)
                    res &= Program.keyH_ENT;
                if ((addr & 0x2000) == 0)
                    res &= Program.keyY_P;
                if ((addr & 0x1000) == 0)
                    res &= Program.key6_0;
                if ((addr & 0x800) == 0)
                    res &= Program.key1_5;
                if ((addr & 0x400) == 0)
                    res &= Program.keyQ_T;
                if ((addr & 0x200) == 0)
                    res &= Program.keyA_G;
                if ((addr & 0x100) == 0)
                    res &= Program.keyCAPS_V;

                //res |= 0xFF;
                //res = 0;
            }

            return (byte)res;
        }

        public void Write(ushort addr, byte value)
        {

            Debug.WriteLine(addr.ToString("X") + " : " + value.ToString("X"));

            if ((addr & 0xFE) != 0 && Program.video.Form.fs != null && Program.video.Form.IsWriting)
            {
                byte r = (byte)(((value & 0x8) != 0) ? 0xFF : 0x00);
                Program.video.Form.fs.WriteByte(r);
            }
            if ((addr & 1) == 0)
            {
                Program.video.Form.BackColor = Program.video.MakeColor2(value & 7);
            }
            else
            {
                if ((addr & 32770) == 0)
                {
                    Program.paging[3] = value & 7;
                    if ((value & 8) != 0)
                        if (Program.screenPage == 5)
                            Program.screenPage = 7;
                        else
                            Program.screenPage = 5;
                    else
                        if ((value & 16) != 0)
                        {
                            Program.paging[0] = 9;
                            Program.paging[4] = 9;
                        }
                        else
                        {
                            Program.paging[0] = 8;
                            Program.paging[4] = 8;
                        }
                }

            }
        }
    }
}
