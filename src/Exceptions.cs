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
    class InvalidOperandSizeException:ApplicationException 
    {
        public InvalidOperandSizeException()  { }

        public InvalidOperandSizeException(string message) : base (message) {}

        public InvalidOperandSizeException(string message, Exception innerException) : base(message, innerException) { }                       
    }

    class InvalidAddressingModeException : ApplicationException
    {
        public InvalidAddressingModeException() { }

        public InvalidAddressingModeException(string message) : base(message) { }

        public InvalidAddressingModeException(string message, Exception innerException) : base(message, innerException) { }
    }

    class InvalidOpcodeException : ApplicationException
    {
        readonly byte opcode;

        public InvalidOpcodeException() { }

        public InvalidOpcodeException(string message) : base(message) { }

        public InvalidOpcodeException(string message, byte opCode) : base(message) 
        {
            opcode = opCode;
        }

        public InvalidOpcodeException(string message, Exception innerException) : base(message, innerException) { }

        public override string ToString()
        {
            return base.ToString() + "\nOpcode: [0x" + opcode.ToString("x") + "," + opcode.ToString("d") + "]";
        }
    }
}
