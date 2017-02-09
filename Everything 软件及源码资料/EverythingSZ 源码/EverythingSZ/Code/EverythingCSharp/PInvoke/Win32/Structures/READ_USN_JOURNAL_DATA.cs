using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace PInvoke.Win32.Structures
{
    /// <summary>
    /// Contains the Start USN(64bits), Reason Mask(32bits), Return Only on Close flag(32bits),
    /// Time Out(64bits), Bytes To Wait For(64bits), and USN Journal ID(64bits).
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct READ_USN_JOURNAL_DATA
    {
        public Int64 StartUsn;
        public UInt32 ReasonMask;
        public UInt32 ReturnOnlyOnClose;
        public UInt64 Timeout;
        public UInt64 bytesToWaitFor;
        public UInt64 UsnJournalId;
    }
}
