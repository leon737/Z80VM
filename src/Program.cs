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
using System.IO;

namespace Z80VM
{
    public static class Program
    {


        public static bool ScrnNeedRepaint = true;
        public static bool go = true;
        public static Z80MemoryManager48KFlat memory;
        public static Z80MemoryManager128K memory128;
        public static VideoRenderer video;
        public static int t = 70000;
        public static int ti = 2000;
        public static bool bFlashInverse = false;

        public static int size = 48;
        public static Z80 z80;
        public static int keyCAPS_V;
        public static int keyB_SPC;
        public static int key6_0;
        public static int keyA_G;
        public static int keyQ_T;
        public static int keyH_ENT;
        public static int keyY_P;
        public static int key1_5;


        public static int[] paging = new int[6];
        public static int screenPage = 5;


        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var f = new Form1();
            f.Show();
            MainRun(f);
        }

        public static void ResetMachine()
        {
            z80.Reset();
            if (size == 128)
                memory128.ResetPaging();
            ResetKeyboard();
        }

        
        public static void MainRun (Form f)
        {          
            var model = new Z80Model(f, size);
            if (size == 48)
                memory = (Z80MemoryManager48KFlat)model.MemoryManager;
            else
                memory128 = (Z80MemoryManager128K)model.MemoryManager;
            if (size == 48)
					LoadFlatROM(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"d:\ZXS48.ROM"), memory);
            else
            {
                LoadPagedROM(@"e:\Data\2007-04-23\zzzz\vbspec-src\ZX128_0.ROM", memory128, 8);
                LoadPagedROM(@"e:\Data\2007-04-23\zzzz\vbspec-src\ZX128_1.ROM", memory128, 9);
            }
            video = (VideoRenderer)model.VideoRenderer;
            z80 = new Z80(model);
            ResetMachine();
            go = true;
            while (go)
            {
                z80.Execute();
                t--;
                ti--;
                if (t == 0)
                {
                    video.Draw();
                    Application.DoEvents();
                    t = 70000;
                }
                if (ti == 0)
                {
                    z80.Interrupt();
                    System.Threading.Thread.Sleep(20);
                    Application.DoEvents();
                    ti = 5000;
                }
            }
        }

        public static void LoadFlatROM(string file, Z80MemoryManager48KFlat mem)
        {
            var rom = new byte[0x3FFF];
            rom = File.ReadAllBytes(file);
            for (int i = 0; i < 0x4000; i++)
                mem.mem[i] = rom[i];
        }

        public static void LoadPagedROM(string file, Z80MemoryManager128K mem, int page)
        {
            var rom = new byte[0x3FFF];
            rom = File.ReadAllBytes(file);
            for (int i = 0; i < 0x4000; i++)
                mem.mem[page][i] = rom[i];
        }

        public static void ResetKeyboard()
        {
            keyB_SPC = 0xFF;
            keyH_ENT = 0xFF;
            keyY_P = 0xFF;
            key6_0 = 0xFF;
            key1_5 = 0xFF;
            keyQ_T = 0xFF;
            keyA_G = 0xFF;
            keyCAPS_V = 0xFF;
        }
    }
}