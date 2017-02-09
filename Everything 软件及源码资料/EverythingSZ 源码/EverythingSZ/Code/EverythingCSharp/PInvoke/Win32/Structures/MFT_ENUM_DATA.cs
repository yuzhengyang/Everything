using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace PInvoke.Win32.Structures
{
    /// <summary>
    /// MFT Enum Data structure, contains Start File Reference Number(64bits), Low USN(64bits),
    /// High USN(64bits).
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct MFT_ENUM_DATA
    {
        public UInt64 StartFileReferenceNumber;
        public Int64 LowUsn;
        public Int64 HighUsn;
    }
}
