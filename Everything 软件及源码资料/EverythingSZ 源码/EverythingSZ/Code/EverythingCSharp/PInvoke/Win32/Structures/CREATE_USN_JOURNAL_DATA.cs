using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace PInvoke.Win32.Structures
{
    /// <summary>
    /// Create USN Journal Data structure, contains Maximum Size(64bits) and Allocation Delta(64(bits).
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct CREATE_USN_JOURNAL_DATA
    {
        public UInt64 MaximumSize;
        public UInt64 AllocationDelta;
    }
}
