using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using SharpMetal.ObjectiveCCore;
using SharpMetal.Foundation;

namespace SharpMetal.Metal
{
    public enum MTLSparseTextureMappingMode : ulong
    {
        Map = 0,
        Unmap = 1,
    }

    
    [StructLayout(LayoutKind.Sequential)]
    public struct MTLMapIndirectArguments
    {
        public uint regionOriginX;
        public uint regionOriginY;
        public uint regionOriginZ;
        public uint regionSizeWidth;
        public uint regionSizeHeight;
        public uint regionSizeDepth;
        public uint mipMapLevel;
        public uint sliceId;
    }

    
    public partial class MTLResourceStateCommandEncoder : MTLCommandEncoder
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(MTLResourceStateCommandEncoder obj) => obj.NativePtr;
        public MTLResourceStateCommandEncoder(IntPtr ptr) : base(ptr) => NativePtr = ptr;

        protected MTLResourceStateCommandEncoder()
        {
            throw new NotImplementedException();
        }

        public void UpdateTextureMappings(MTLTexture texture, MTLSparseTextureMappingMode mode, MTLRegion regions, ulong mipLevels, ulong slices, ulong numRegions)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_updateTextureMappingsmoderegionsmipLevelsslicesnumRegions, texture, (ulong)mode, regions, mipLevels, slices, numRegions);
        }

        public void UpdateTextureMapping(MTLTexture texture, MTLSparseTextureMappingMode mode, MTLRegion region, ulong mipLevel, ulong slice)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_updateTextureMappingmoderegionmipLevelslice, texture, (ulong)mode, region, mipLevel, slice);
        }

        public void UpdateTextureMapping(MTLTexture texture, MTLSparseTextureMappingMode mode, MTLBuffer indirectBuffer, ulong indirectBufferOffset)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_updateTextureMappingmodeindirectBufferindirectBufferOffset, texture, (ulong)mode, indirectBuffer, indirectBufferOffset);
        }

        public void UpdateFence(MTLFence fence)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_updateFence, fence);
        }

        public void WaitForFence(MTLFence fence)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_waitForFence, fence);
        }

        public void MoveTextureMappingsFromTexture(MTLTexture sourceTexture, ulong sourceSlice, ulong sourceLevel, MTLOrigin sourceOrigin, MTLSize sourceSize, MTLTexture destinationTexture, ulong destinationSlice, ulong destinationLevel, MTLOrigin destinationOrigin)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_moveTextureMappingsFromTexturesourceSlicesourceLevelsourceOriginsourceSizetoTexturedestinationSlicedestinationLeveldestinationOrigin, sourceTexture, sourceSlice, sourceLevel, sourceOrigin, sourceSize, destinationTexture, destinationSlice, destinationLevel, destinationOrigin);
        }

        private static readonly Selector sel_updateTextureMappingsmoderegionsmipLevelsslicesnumRegions = "updateTextureMappings:mode:regions:mipLevels:slices:numRegions:";
        private static readonly Selector sel_updateTextureMappingmoderegionmipLevelslice = "updateTextureMapping:mode:region:mipLevel:slice:";
        private static readonly Selector sel_updateTextureMappingmodeindirectBufferindirectBufferOffset = "updateTextureMapping:mode:indirectBuffer:indirectBufferOffset:";
        private static readonly Selector sel_updateFence = "updateFence:";
        private static readonly Selector sel_waitForFence = "waitForFence:";
        private static readonly Selector sel_moveTextureMappingsFromTexturesourceSlicesourceLevelsourceOriginsourceSizetoTexturedestinationSlicedestinationLeveldestinationOrigin = "moveTextureMappingsFromTexture:sourceSlice:sourceLevel:sourceOrigin:sourceSize:toTexture:destinationSlice:destinationLevel:destinationOrigin:";
    }
}