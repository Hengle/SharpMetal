using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    
    [StructLayout(LayoutKind.Sequential)]
    public struct MTLOrigin
    {
        public ulong x;
        public ulong y;
        public ulong z;
    }

    
    [StructLayout(LayoutKind.Sequential)]
    public struct MTLSize
    {
        public ulong width;
        public ulong height;
        public ulong depth;
    }

    
    [StructLayout(LayoutKind.Sequential)]
    public struct MTLRegion
    {
        public MTLOrigin origin;
        public MTLSize size;
    }

    
    [StructLayout(LayoutKind.Sequential)]
    public struct MTLSamplePosition
    {
        public float x;
        public float y;
    }

    
    [StructLayout(LayoutKind.Sequential)]
    public struct MTLResourceID
    {
        public ulong _impl;
    }
}