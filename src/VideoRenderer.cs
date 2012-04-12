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
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace Z80VM
{
    public class VideoRenderer : IVideoRenderer
    {
        public Form1 Form;
        readonly bool[,] scrnLines = new bool[192, 33];
        readonly int[,] glScreenMem = new int[192, 32];
        public int[] GlRowIndex = new int[191];
        public int[] GlColIndex = new int[191];
        public TBitTable[,] GtBitTable = new TBitTable[256, 256];
        public int[] GlBufferBits = new int[256 * 192];

        public struct TBitTable
        {
            public int dw0;
            public int dw1;
        }





        public VideoRenderer(Form form)
        {
            Form = (Form1)form;
            InitScreenMemTable();
        }

        public void RefreshFlashChars()
        {
            Program.bFlashInverse = !Program.bFlashInverse;
            for (int addr = 6144; addr < 6911; addr++)
            {
                bool b;
                if (Program.size == 128)
                {
                    b = (Program.memory128.mem[Program.screenPage][addr] & 128) != 0;                    
                }
                else
                {
                    b = (Program.memory.mem[addr + 0x4000] & 128) != 0;
                }
                if (b)
                {
                    int lne = (addr - 6144) >> 5;
                    lne <<= 3;
                    for (int i = lne; i < lne + 8; i++)
                    {
                        scrnLines[i, 32] = true;
                        scrnLines[i, addr & 31] = true;
                    }
                }
            }
            
        }

        public void InitScreenMemTable()
        {
            for (int y = 0; y < 192; y++)
                for (int x = 0; x < 32; x++)
                {
                    glScreenMem[y, x] = ((((y / 8) * 32) + (y % 8) * 256) + ((y / 64) * 2048) - (y / 64) * 256) + x;
                }
        }

        public void Draw()
        {
            if (!Program.ScrnNeedRepaint) return;
            BitmapData bd = Form.bmp.LockBits(new Rectangle(0, 0, 256, 192), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
            IntPtr ptr = bd.Scan0;
            Marshal.Copy(GlBufferBits, 0, ptr, 256 * 192);
            Form.bmp.UnlockBits(bd);
            Form.SetImage();
            //form.Refresh();
            Program.ScrnNeedRepaint = false;
        }

#pragma warning disable 0675

        public int MakeColor(int color)
        {
            Color c;
            switch (color)
            {
                case 0: c = Color.Black; break;
                case 1: c = Color.FromArgb(255, 0, 0, 192); break;
                case 2: c = Color.FromArgb(255, 192, 0, 0); break;
                case 3: c = Color.FromArgb(255, 192, 0, 192); break;
                case 4: c = Color.FromArgb(255, 0, 192, 0); break;
                case 5: c = Color.FromArgb(255, 0, 192, 192); break;
                case 6: c = Color.FromArgb(255, 192, 192, 0); break;
                case 7: c = Color.FromArgb(255, 192, 192, 192); break;
                case 8: c = Color.FromArgb(255, 0, 0, 0); break;
                case 9: c = Color.FromArgb(255, 0, 0, 255); break;
                case 10: c = Color.FromArgb(255, 255, 0, 0); break;
                case 11: c = Color.FromArgb(255, 255, 0, 255); break;
                case 12: c = Color.FromArgb(255, 0, 255, 0); break;
                case 13: c = Color.FromArgb(255, 0, 255, 255); break;
                case 14: c = Color.FromArgb(255, 255, 255, 0); break;
                case 15: c = Color.FromArgb(255, 255, 255, 255); break;
                default:
                    c = Color.Black; break;
            }
            return c.ToArgb();
        }

        public Color MakeColor2(int color)
        {
            Color c;
            switch (color)
            {
                case 0: c = Color.Black; break;
                case 1: c = Color.FromArgb(255, 0, 0, 192); break;
                case 2: c = Color.FromArgb(255, 192, 0, 0); break;
                case 3: c = Color.FromArgb(255, 192, 0, 192); break;
                case 4: c = Color.FromArgb(255, 0, 192, 0); break;
                case 5: c = Color.FromArgb(255, 0, 192, 192); break;
                case 6: c = Color.FromArgb(255, 192, 192, 0); break;
                case 7: c = Color.FromArgb(255, 192, 192, 192); break;
                case 8: c = Color.FromArgb(255, 0, 0, 0); break;
                case 9: c = Color.FromArgb(255, 0, 0, 255); break;
                case 10: c = Color.FromArgb(255, 255, 0, 0); break;
                case 11: c = Color.FromArgb(255, 255, 0, 255); break;
                case 12: c = Color.FromArgb(255, 0, 255, 0); break;
                case 13: c = Color.FromArgb(255, 0, 255, 255); break;
                case 14: c = Color.FromArgb(255, 255, 255, 0); break;
                case 15: c = Color.FromArgb(255, 255, 255, 255); break;
                default:
                    c = Color.Black; break;
            }
            return c;

        }

        public void InitScreenIndexs()
        {
            int n;

            for (n = 0; n < 192; n++)
            {
                GlRowIndex[n] = 6144 + (n / 8) * 32;
                GlColIndex[n] = (n * 256) / 4;
            }

        }

        public void ScanLinePaint(int lne)
        {

            
            int fcolor, bcolor;


            if (scrnLines[lne, 32])
            {
                for (int x = 0; x < 32; x++)
                {
                    int sByte;
                    int aByte;
                    if (Program.size == 128)
                    {
                        sByte = Program.memory128.ReadByteScreen((ushort)(glScreenMem[lne, x]));
                        aByte = Program.memory128.ReadByteScreen((ushort)(6144 + ((lne >> 3) << 5) + x));
                    }
                    else
                    {
                        sByte = Program.memory.ReadByteScreen((ushort)(glScreenMem[lne, x]));
                        aByte = Program.memory.ReadByteScreen((ushort)(6144 + ((lne >> 3) << 5) + x));
                    }


                    int charStart = x << 3;
                    if ((aByte & 64) == 64)
                    {
                        fcolor = (aByte & 7) + 8;
                        bcolor = ((aByte & 56) >> 3) + 8;
                    }
                    else
                    {
                        fcolor = (aByte & 7);
                        bcolor = ((aByte & 56) >> 3);
                    }
                    if (((aByte & 128) == 128) && Program.bFlashInverse)
                    {
                        int xColor = fcolor;
                        fcolor = bcolor;
                        bcolor = xColor;
                    }

                    int xBit = 128;
                    int offset = 0;
                    do
                    {
                        if ((sByte & xBit) == xBit)
                            GlBufferBits[lne * 256 + charStart + offset] = MakeColor(fcolor);
                        else
                            GlBufferBits[lne * 256 + charStart + offset] = MakeColor(bcolor);
                        xBit >>= 1;
                        offset++;
                    } while (xBit != 0);
                }
                scrnLines[lne, 32] = false;
                Program.ScrnNeedRepaint = true;
            }            
        }




        public void Plot(ushort addr)
        {
            int i, lne, x;
            if (addr < 22528)
            {
                // alter a pixel
                lne = ((addr >> 8) & 0x7) | ((addr >> 2) & 0x38) | ((addr >> 5) & 0xc0);
                scrnLines[lne, 32] = true;
                scrnLines[lne, addr & 31] = true;
            }
            else
            {
                // alter an attribute
                lne = (addr - 22528) >> 5;
                x = addr % 32;
                for (i = lne * 8; i < lne * 8 + 8; i++)
                {
                    scrnLines[i, 32] = true;
                    scrnLines[i, x] = true;
                }
            }
            //Program.ScrnNeedRepaint = true;
        }
    }
}
