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
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace Z80VM
{
    public partial class Form1 : Form
    {

       public Bitmap bmp = new Bitmap(256, 192);
        
        public Form1()
        {
            InitializeComponent();
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(256 * 2 + 80, 192 * 2 + 80);
            pictureBox1.Size = new Size(256 * 2, 192 * 2);
            resize();
            if (Program.size == 48)
            {
                k48ToolStripMenuItem.Checked = true;
                k128ToolStripMenuItem.Checked = false;
            }
            else
            {
                k48ToolStripMenuItem.Checked = false;
                k128ToolStripMenuItem.Checked = true;
            }
            pictureBox1.BackgroundImage = bmp;
        }

        public void SetImage()
        {
           // this.pictureBox1.BackgroundImage = this.bmp;
            pictureBox1.Refresh();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OnClose(object sender, FormClosingEventArgs e)
        {
            Program.go = false;
        }

        private void OnKeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            int keyCode = (int)e.KeyCode;
            int shift = (int)e.KeyData / 0x10000;
            if ((shift & 4) != 0) return;
            doKey(true, keyCode, (short)shift);
        }

        public bool doKey(bool down, int ascii, short mods)
        {
		
            bool CAPS, SYMB;
		
		    CAPS = (mods & 1) != 0;
		    SYMB = (mods & 2) != 0;
    		
		    // Change control versions of keys to lower case
		    if ((ascii >= 1) & (ascii <= 0x27) & SYMB)
			    ascii = ascii + 97 - 1;
    		
    		
		    if (CAPS) Program.keyCAPS_V = (Program.keyCAPS_V & (~1)); else Program.keyCAPS_V = (Program.keyCAPS_V | 1);
		    if (SYMB) Program.keyB_SPC = (Program.keyB_SPC & (~2)); else Program.keyB_SPC = (Program.keyB_SPC | 2);
    		
		    switch(ascii) {
			    case 8: // Backspace
				    if (down) {
					    Program.key6_0 = (Program.key6_0 & (~ 1));
					    Program.keyCAPS_V = (Program.keyCAPS_V & (~ 1));
				    }else {
					    Program.key6_0 = (Program.key6_0 | 1);
					    if (!CAPS)
						    Program.keyCAPS_V = (Program.keyCAPS_V | 1);					
				    }
                    break;
			    case 65: // A
				    if (down) Program.keyA_G = (Program.keyA_G & (~ 1)); else Program.keyA_G = (Program.keyA_G | 1);
                    break;
			    case 66: // B
				    if (down )  Program.keyB_SPC = (Program.keyB_SPC & (~ 16)) ; else Program.keyB_SPC = (Program.keyB_SPC | 16);
                    break;
			    case 67: // C
				    if (down )  Program.keyCAPS_V = (Program.keyCAPS_V & (~ 8)) ; else Program.keyCAPS_V = (Program.keyCAPS_V | 8);
                    break;
			    case 68: // D
				    if (down )  Program.keyA_G = (Program.keyA_G & (~ 4)) ; else Program.keyA_G = (Program.keyA_G | 4);
                    break;
			    case 69: // E
				    if (down )  Program.keyQ_T = (Program.keyQ_T & (~ 4)) ; else Program.keyQ_T = (Program.keyQ_T | 4);
                    break;
			    case 70: // F
				    if (down )  Program.keyA_G = (Program.keyA_G & (~ 8)) ; else Program.keyA_G = (Program.keyA_G | 8);
                    break;
			    case 71: // G
				    if (down )  Program.keyA_G = (Program.keyA_G & (~ 16)) ; else Program.keyA_G = (Program.keyA_G | 16);
                    break;
			    case 72: // H
				    if (down )  Program.keyH_ENT = (Program.keyH_ENT & (~ 16)) ; else Program.keyH_ENT = (Program.keyH_ENT | 16);
                    break;
			    case 73: // I
				    if (down )  Program.keyY_P = (Program.keyY_P & (~ 4)) ; else Program.keyY_P = (Program.keyH_ENT | 4);
                    break;
			    case 74: // J
				    if (down )  Program.keyH_ENT = (Program.keyH_ENT & (~ 8)) ; else Program.keyH_ENT = (Program.keyH_ENT | 8);
                    break;
			    case 75: // K
				    if (down )  Program.keyH_ENT = (Program.keyH_ENT & (~ 4)) ; else Program.keyH_ENT = (Program.keyH_ENT | 4);
                    break;
			    case 76: // L
				    if (down )  Program.keyH_ENT = (Program.keyH_ENT & (~ 2)) ; else Program.keyH_ENT = (Program.keyH_ENT | 2);
                    break;
			    case 77: // M
				    if (down )  Program.keyB_SPC = (Program.keyB_SPC & (~ 4)) ; else Program.keyB_SPC = (Program.keyB_SPC | 4);
                    break;
			    case 78: // N
				    if (down )  Program.keyB_SPC = (Program.keyB_SPC & (~ 8)) ; else Program.keyB_SPC = (Program.keyB_SPC | 8);
                    break;
			    case 79: // O
				    if (down )  Program.keyY_P = (Program.keyY_P & (~ 2)) ; else Program.keyY_P = (Program.keyY_P | 2);
                    break;
			    case 80: // P
				    if (down )  Program.keyY_P = (Program.keyY_P & (~ 1)) ; else Program.keyY_P = (Program.keyY_P | 1);
                    break;
			    case 81: // Q
				    if (down )  Program.keyQ_T = (Program.keyQ_T & (~ 1)) ; else Program.keyQ_T = (Program.keyQ_T | 1);
                    break;
			    case 82: // R
				    if (down )  Program.keyQ_T = (Program.keyQ_T & (~ 8)) ; else Program.keyQ_T = (Program.keyQ_T | 8);
                    break;
			    case 83: // S
				    if (down )  Program.keyA_G = (Program.keyA_G & (~ 2)) ; else Program.keyA_G = (Program.keyA_G | 2);
                    break;
			    case 84: // T
				    if (down )  Program.keyQ_T = (Program.keyQ_T & (~ 16)) ; else Program.keyQ_T = (Program.keyQ_T | 16);
                    break;
			    case 85: // U
				    if (down )  Program.keyY_P = (Program.keyY_P & (~ 8)) ; else Program.keyY_P = (Program.keyY_P | 8);
                    break;
			    case 86: // V
				    if (down )  Program.keyCAPS_V = (Program.keyCAPS_V & (~ 16)) ; else Program.keyCAPS_V = (Program.keyCAPS_V | 16);
                    break;
			    case 87: // W
				    if (down )  Program.keyQ_T = (Program.keyQ_T & (~ 2)) ; else Program.keyQ_T = (Program.keyQ_T | 2);
                    break;
			    case 88: // X
				    if (down )  Program.keyCAPS_V = (Program.keyCAPS_V & (~ 4)) ; else Program.keyCAPS_V = (Program.keyCAPS_V | 4);
                    break;
			    case 90: // Y
				    if (down )  Program.keyCAPS_V = (Program.keyCAPS_V & (~ 2)) ; else Program.keyCAPS_V = (Program.keyCAPS_V | 2);
                    break;
			    case 89: // Z
				    if (down )  Program.keyY_P = (Program.keyY_P & (~ 16)) ; else Program.keyY_P = (Program.keyY_P | 16);
                    break;
			    case 48: // 0
				    if (down )  Program.key6_0 = (Program.key6_0 & (~ 1)) ; else Program.key6_0 = (Program.key6_0 | 1);
                    break;
			    case 49: // 1
				    if (down )  Program.key1_5 = (Program.key1_5 & (~ 1)) ; else Program.key1_5 = (Program.key1_5 | 1);
                    break;
			    case 50: // 2
				    if (down )  Program.key1_5 = (Program.key1_5 & (~ 2)) ; else Program.key1_5 = (Program.key1_5 | 2);
                    break;
			    case 51: // 3
				    if (down )  Program.key1_5 = (Program.key1_5 & (~ 4)) ; else Program.key1_5 = (Program.key1_5 | 4);
                    break;
			    case 52: // 4
				    if (down )  Program.key1_5 = (Program.key1_5 & (~ 8)) ; else Program.key1_5 = (Program.key1_5 | 8);
                    break;
			    case 53: // 5
				    if (down )  Program.key1_5 = (Program.key1_5 & (~ 16)) ; else Program.key1_5 = (Program.key1_5 | 16);
                    break;
			    case 54: // 6
				    if (down )  Program.key6_0 = (Program.key6_0 & (~ 16)) ; else Program.key6_0 = (Program.key6_0 | 16);
                    break;
			    case 55: // 7
				    if (down )  Program.key6_0 = (Program.key6_0 & (~ 8)) ; else Program.key6_0 = (Program.key6_0 | 8);
                    break;
			    case 56: // 8
				    if (down )  Program.key6_0 = (Program.key6_0 & (~ 4)) ; else Program.key6_0 = (Program.key6_0 | 4);
                    break;
			    case 57: // 9
				    if (down )  Program.key6_0 = (Program.key6_0 & (~ 2)) ; else Program.key6_0 = (Program.key6_0 | 2);
                    break;
			    case 96: // Keypad 0
				    if (down )  Program.key6_0 = (Program.key6_0 & (~ 1)) ; else Program.key6_0 = (Program.key6_0 | 1);
                    break;
			    case 97: // Keypad 1
				    if (down )  Program.key1_5 = (Program.key1_5 & (~ 1)) ; else Program.key1_5 = (Program.key1_5 | 1);
                    break;
			    case 98: // Keypad 2
				    if (down )  Program.key1_5 = (Program.key1_5 & (~ 2)) ; else Program.key1_5 = (Program.key1_5 | 2);
                    break;
			    case 99: // Keypad 3
				    if (down )  Program.key1_5 = (Program.key1_5 & (~ 4)) ; else Program.key1_5 = (Program.key1_5 | 4);
                    break;
			    case 100: // Keypad 4
				    if (down )  Program.key1_5 = (Program.key1_5 & (~ 8)) ; else Program.key1_5 = (Program.key1_5 | 8);
                    break;
			    case 101: // Keypad 5
				    if (down )  Program.key1_5 = (Program.key1_5 & (~ 16)) ; else Program.key1_5 = (Program.key1_5 | 16);
                    break;
			    case 102: // Keypad 6
				    if (down )  Program.key6_0 = (Program.key6_0 & (~ 16)) ; else Program.key6_0 = (Program.key6_0 | 16);
                    break;
			    case 103: // Keypad 7
				    if (down )  Program.key6_0 = (Program.key6_0 & (~ 8)) ; else Program.key6_0 = (Program.key6_0 | 8);
                    break;
			    case 104: // Keypad 8
				    if (down )  Program.key6_0 = (Program.key6_0 & (~ 4)) ; else Program.key6_0 = (Program.key6_0 | 4);
                    break;
			    case 105: // Keypad 9
				    if (down )  Program.key6_0 = (Program.key6_0 & (~ 2)) ; else Program.key6_0 = (Program.key6_0 | 2);
                    break;
			    case 106: // Keypad *
				    if (down ) 
					    Program.keyB_SPC = (Program.keyB_SPC & ~(18));
				    else
					    if (SYMB ) 
						    Program.keyB_SPC = (Program.keyB_SPC | 16);
					    else
						    Program.keyB_SPC = (Program.keyB_SPC | 18);
                    break;
			    case 107: // Keypad +
                    if (down)
                    {
                        Program.keyH_ENT = (Program.keyH_ENT & (~4));
                        Program.keyB_SPC = (Program.keyB_SPC & (~2));
                    }
                    else
                    {
                        Program.keyH_ENT = (Program.keyH_ENT | 4);
                        if (!SYMB)
                            Program.keyB_SPC = (Program.keyB_SPC | 2);
                    }
                        break;
			    case 109: // Keypad -
                    if (down)
                    {
                        Program.keyH_ENT = (Program.keyH_ENT & (~8));
                        Program.keyB_SPC = (Program.keyB_SPC & (~2));
                    }
                    else
                    {
                        Program.keyH_ENT = (Program.keyH_ENT | 8);
                        if (!SYMB)
                            Program.keyB_SPC = (Program.keyB_SPC | 2);
                    }
                        break;
			    case 110: // Keypad .
				    if (down ) 
					    Program.keyB_SPC = (Program.keyB_SPC & (~ 6));
				    else
					    if (SYMB ) 
						    Program.keyB_SPC = (Program.keyB_SPC | 4);
					     else
						    Program.keyB_SPC = (Program.keyB_SPC | 6);
                    break;
			    case 111: // Keypad /
                    if (down)
                    {
                        Program.keyCAPS_V = (Program.keyCAPS_V & (~16));
                        Program.keyB_SPC = (Program.keyB_SPC & (~2));
                    }
                    else
                    {
                        Program.keyCAPS_V = (Program.keyCAPS_V | 16);
                        if (!SYMB)
                            Program.keyB_SPC = (Program.keyB_SPC | 2);
                    }
                    break;
			    case 37: // Left
                    if (down)
                    {
                        Program.key1_5 = (Program.key1_5 & (~16));
                        Program.keyCAPS_V = (Program.keyCAPS_V & (~1));
                    }
                    else
                    {
                        Program.key1_5 = (Program.key1_5 | 16);
                        if (!SYMB)
                            Program.keyB_SPC = (Program.keyB_SPC | 2);
                    }
                    break;
			    case 38: // Up
                    if (down)
                    {
                        Program.key6_0 = (Program.key6_0 & (~8));
                        Program.keyCAPS_V = (Program.keyCAPS_V & (~1));
                    }
                    else
                    {
                        Program.key6_0 = (Program.key6_0 | 8);
                        if (!CAPS)
                            Program.keyCAPS_V = (Program.keyCAPS_V | 1);
                    }
                    break;
			    case 39: // Right
                    if (down)
                    {
                        Program.key6_0 = (Program.key6_0 & (~4));
                        Program.keyCAPS_V = (Program.keyCAPS_V & (~1));
                    }
                    else
                    {
                        Program.key6_0 = (Program.key6_0 | 4);
                        if (!CAPS)
                            Program.keyCAPS_V = (Program.keyCAPS_V | 1);
                    }
                    break;
			    case 40: // Down
                    if (down)
                    {
                        Program.key6_0 = (Program.key6_0 & (~16));
                        Program.keyCAPS_V = (Program.keyCAPS_V & (~1));
                    }
                    else
                    {
                        Program.key6_0 = (Program.key6_0 | 16);
                        if (!CAPS)
                            Program.keyCAPS_V = (Program.keyCAPS_V | 1);
                    }
                    break;
			    case 13: // RETURN
				    if (down )  Program.keyH_ENT = (Program.keyH_ENT & (~ 1)) ; else Program.keyH_ENT = (Program.keyH_ENT | 1);
                    break;
			    case 32: // SPACE BAR
				    if (down )  Program.keyB_SPC = (Program.keyB_SPC & (~ 1)) ; else Program.keyB_SPC = (Program.keyB_SPC | 1);
                    break;
			    case 187: // =/+ key
				    if (down ) {
                        if (CAPS)
                            Program.keyH_ENT = (Program.keyH_ENT & (~4));
                        else
                        {
                            Program.keyH_ENT = (Program.keyH_ENT & (~2));
                            Program.keyB_SPC = (Program.keyB_SPC & (~2));
                            Program.keyCAPS_V = (Program.keyCAPS_V | 1);
                        }
                    }
				    else {
					    Program.keyH_ENT = (Program.keyH_ENT | 4);
					    Program.keyH_ENT = (Program.keyH_ENT | 2);
					    Program.keyB_SPC = (Program.keyB_SPC | 2);
				    }
                    break;
			    case 189: // -/_ key
				    if (down ) {
                        if (CAPS)
                            Program.key6_0 = (Program.key6_0 & (~1));
                        else
                        {
                            Program.keyH_ENT = (Program.keyH_ENT & (~8));
                            Program.keyB_SPC = (Program.keyB_SPC & (~2));
                            Program.keyCAPS_V = (Program.keyCAPS_V | 1);
                        }
                    }
				    else {
					    Program.key6_0 = (Program.key6_0 | 1); // // Release the Spectrum//s //0// key
					    Program.keyH_ENT = (Program.keyH_ENT | 8); // // Release the Spectrum//s //J// key
					    Program.keyB_SPC = (Program.keyB_SPC | 2); // // Release the Symbol Shift key
				    }
                    break;
			    case 186: // ;/: keys
				    if (down ) {
                        if (CAPS)
                            Program.keyCAPS_V = (Program.keyCAPS_V & (~2));
                        else
                        {
                            Program.keyY_P = (Program.keyY_P & (~2));
                            Program.keyB_SPC = (Program.keyB_SPC & (~2));
                            Program.keyCAPS_V = (Program.keyCAPS_V | 1);
                        }
                    }
				    else {
					    Program.keyCAPS_V = (Program.keyCAPS_V | 2);
					    Program.keyY_P = (Program.keyY_P | 2);
					    Program.keyB_SPC = (Program.keyB_SPC | 2);
				    }
                    break;
			    default:
				    return false;
            }		
		    return true;
        }

        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            int keyCode = (int)e.KeyCode;
            int shift = (int)e.KeyData / 0x10000;
            doKey(false, keyCode, (short)shift);
        }

        private void OnResize(object sender, EventArgs e)
        {
            resize();
        }

        public void resize()
        {
            pictureBox1.Left = (this.ClientSize.Width - pictureBox1.Width) / 2;
            pictureBox1.Top = (this.ClientSize.Height - pictureBox1.Height) / 2;
            pictureBox1.Top += (this.Height - this.ClientSize.Height) / 2;

        }

        private void resetMachineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.ResetMachine();
        }

        private void k48ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.size != 48)
            {
                Program.z80.Halt();
                Program.size = 48;
                Program.memory = new Z80MemoryManager48KFlat();
                Program.z80.model.memoryManager = Program.memory;
                Program.LoadFlatROM(@"e:\Data\2007-04-23\zzzz\vbspec-src\spectrum.rom", Program.memory);
                Program.ResetMachine();
                this.k48ToolStripMenuItem.Checked = true;
                this.k128ToolStripMenuItem.Checked = false;
            }
            
        }

        private void k128ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Program.size != 128)
            {
                Program.z80.Halt();
                Program.size = 128;
                Program.memory128 = new Z80MemoryManager128K();
                Program.z80.model.memoryManager = Program.memory128;
                Program.LoadPagedROM(@"e:\Data\2007-04-23\zzzz\vbspec-src\ZX128_0.ROM", Program.memory128, 8);
                Program.LoadPagedROM(@"e:\Data\2007-04-23\zzzz\vbspec-src\ZX128_1.ROM", Program.memory128, 9);
                Program.ResetMachine();
                this.k48ToolStripMenuItem.Checked = false;
                this.k128ToolStripMenuItem.Checked = true;
            }

        }

        private void OnHalt(object sender, EventArgs e)
        {
            Program.z80.Halt();
        }

        private void OnResume(object sender, EventArgs e)
        {
            Program.z80.Resume();
        }

        public System.IO.FileStream fs;
        public bool IsWriting = false;

        private void OnStartRecording(object sender, EventArgs e)
        {
            fs = System.IO.File.Create(@"d:\temp.tap");
            IsWriting = true;
        }

        private void OnStopRecording(object sender, EventArgs e)
        {
            fs.Dispose();
            fs = null;
        }

        private void OnStartPlayback(object sender, EventArgs e)
        {
            fs = System.IO.File.Open(@"d:\temp.tap", FileMode.Open);
            IsWriting = false;
        }

        private void OnStopPlayback(object sender, EventArgs e)
        {
            fs.Dispose();
            fs = null;
        }
    }

}