using SharpMetal.Foundation;
using SharpMetal.ObjectiveCCore;

namespace SharpMetal.Metal
{
    public partial struct MTLComputePipelineReflection
    {
        public IntPtr NativePtr;

        public MTLComputePipelineReflection(in IntPtr ptr) => NativePtr = ptr;

        public static MTLComputePipelineReflection New() => s_class.AllocInit<MTLComputePipelineReflection>();

        public NSArray Bindings => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_bindings));
        
        public NSArray Arguments => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_arguments));

        public static implicit operator IntPtr(in MTLComputePipelineReflection obj) => obj.NativePtr;

        private static readonly ObjectiveCClass s_class = new ObjectiveCClass(nameof(MTLComputePipelineReflection));
        private static readonly Selector sel_bindings = "bindings";
        private static readonly Selector sel_arguments = "arguments";
    }

    public partial struct MTLComputePipelineDescriptor
    {
        public IntPtr NativePtr;

        public MTLComputePipelineDescriptor(in IntPtr ptr) => NativePtr = ptr;

        public static MTLComputePipelineDescriptor New() => s_class.AllocInit<MTLComputePipelineDescriptor>();

        public NSString Label
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_label));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLabel, value);
        }
        
        public MTLFunction ComputeFunction
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_computeFunction));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setComputeFunction, value);
        }
        
        public bool ThreadGroupSizeIsMultipleOfThreadExecutionWidth
        {
            get => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_threadGroupSizeIsMultipleOfThreadExecutionWidth);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setThreadGroupSizeIsMultipleOfThreadExecutionWidth, value);
        }
        
        public ulong MaxTotalThreadsPerThreadgroup
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_maxTotalThreadsPerThreadgroup);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setMaxTotalThreadsPerThreadgroup, value);
        }
        
        public MTLStageInputOutputDescriptor StageInputDescriptor
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_stageInputDescriptor));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setStageInputDescriptor, value);
        }
        
        public MTLPipelineBufferDescriptorArray Buffers => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_buffers));
        
        public bool SupportIndirectCommandBuffers
        {
            get => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_supportIndirectCommandBuffers);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setSupportIndirectCommandBuffers, value);
        }
        
        public NSArray InsertLibraries
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_insertLibraries));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setInsertLibraries, value);
        }
        
        public NSArray PreloadedLibraries
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_preloadedLibraries));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setPreloadedLibraries, value);
        }
        
        public NSArray BinaryArchives
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_binaryArchives));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setBinaryArchives, value);
        }
        
        public MTLLinkedFunctions LinkedFunctions
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_linkedFunctions));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLinkedFunctions, value);
        }
        
        public bool SupportAddingBinaryFunctions
        {
            get => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_supportAddingBinaryFunctions);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setSupportAddingBinaryFunctions, value);
        }
        
        public ulong MaxCallStackDepth
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_maxCallStackDepth);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setMaxCallStackDepth, value);
        }

        public MTLShaderValidation ShaderValidation
        {
            get => (MTLShaderValidation)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_shaderValidation);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setShaderValidation, (ulong)value);
        }

        public void Reset()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_reset);
        }

        public static implicit operator IntPtr(in MTLComputePipelineDescriptor obj) => obj.NativePtr;

        private static readonly ObjectiveCClass s_class = new ObjectiveCClass(nameof(MTLComputePipelineDescriptor));
        private static readonly Selector sel_label = "label";
        private static readonly Selector sel_setLabel = "setLabel:";
        private static readonly Selector sel_computeFunction = "computeFunction";
        private static readonly Selector sel_setComputeFunction = "setComputeFunction:";
        private static readonly Selector sel_threadGroupSizeIsMultipleOfThreadExecutionWidth = "threadGroupSizeIsMultipleOfThreadExecutionWidth";
        private static readonly Selector sel_setThreadGroupSizeIsMultipleOfThreadExecutionWidth = "setThreadGroupSizeIsMultipleOfThreadExecutionWidth:";
        private static readonly Selector sel_maxTotalThreadsPerThreadgroup = "maxTotalThreadsPerThreadgroup";
        private static readonly Selector sel_setMaxTotalThreadsPerThreadgroup = "setMaxTotalThreadsPerThreadgroup:";
        private static readonly Selector sel_stageInputDescriptor = "stageInputDescriptor";
        private static readonly Selector sel_setStageInputDescriptor = "setStageInputDescriptor:";
        private static readonly Selector sel_buffers = "buffers";
        private static readonly Selector sel_supportIndirectCommandBuffers = "supportIndirectCommandBuffers";
        private static readonly Selector sel_setSupportIndirectCommandBuffers = "setSupportIndirectCommandBuffers:";
        private static readonly Selector sel_insertLibraries = "insertLibraries";
        private static readonly Selector sel_setInsertLibraries = "setInsertLibraries:";
        private static readonly Selector sel_preloadedLibraries = "preloadedLibraries";
        private static readonly Selector sel_setPreloadedLibraries = "setPreloadedLibraries:";
        private static readonly Selector sel_binaryArchives = "binaryArchives";
        private static readonly Selector sel_setBinaryArchives = "setBinaryArchives:";
        private static readonly Selector sel_reset = "reset";
        private static readonly Selector sel_linkedFunctions = "linkedFunctions";
        private static readonly Selector sel_setLinkedFunctions = "setLinkedFunctions:";
        private static readonly Selector sel_supportAddingBinaryFunctions = "supportAddingBinaryFunctions";
        private static readonly Selector sel_setSupportAddingBinaryFunctions = "setSupportAddingBinaryFunctions:";
        private static readonly Selector sel_maxCallStackDepth = "maxCallStackDepth";
        private static readonly Selector sel_setMaxCallStackDepth = "setMaxCallStackDepth:";
        private static readonly Selector sel_shaderValidation = "shaderValidation";
        private static readonly Selector sel_setShaderValidation = "setShaderValidation:";
    }

    public partial struct MTLComputePipelineState
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(in MTLComputePipelineState obj) => obj.NativePtr;
        public MTLComputePipelineState(in IntPtr ptr) => NativePtr = ptr;

        public NSString Label => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_label));

        public MTLDevice Device => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_device));

        public ulong MaxTotalThreadsPerThreadgroup => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_maxTotalThreadsPerThreadgroup);

        public ulong ThreadExecutionWidth => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_threadExecutionWidth);

        public ulong StaticThreadgroupMemoryLength => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_staticThreadgroupMemoryLength);

        public bool SupportIndirectCommandBuffers => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_supportIndirectCommandBuffers);

        public MTLResourceID GpuResourceID => ObjectiveCRuntime.MTLResourceID_objc_msgSend(NativePtr, sel_gpuResourceID);

        public ulong ShaderValidation
        {
            get => ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_shaderValidation);
        }

        public ulong ImageblockMemoryLength(in MTLSize imageblockDimensions)
        {
            return ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_imageblockMemoryLengthForDimensions, imageblockDimensions);
        }

        public MTLFunctionHandle FunctionHandle(in MTLFunction function)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_functionHandleWithFunction, function));
        }

        public MTLComputePipelineState NewComputePipelineState(in NSArray functions, ref NSError error)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_newComputePipelineStateWithAdditionalBinaryFunctionserror, functions, ref error.NativePtr));
        }

        public MTLVisibleFunctionTable NewVisibleFunctionTable(in MTLVisibleFunctionTableDescriptor descriptor)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_newVisibleFunctionTableWithDescriptor, descriptor));
        }

        public MTLIntersectionFunctionTable NewIntersectionFunctionTable(in MTLIntersectionFunctionTableDescriptor descriptor)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_newIntersectionFunctionTableWithDescriptor, descriptor));
        }

        private static readonly Selector sel_label = "label";
        private static readonly Selector sel_device = "device";
        private static readonly Selector sel_maxTotalThreadsPerThreadgroup = "maxTotalThreadsPerThreadgroup";
        private static readonly Selector sel_threadExecutionWidth = "threadExecutionWidth";
        private static readonly Selector sel_staticThreadgroupMemoryLength = "staticThreadgroupMemoryLength";
        private static readonly Selector sel_imageblockMemoryLengthForDimensions = "imageblockMemoryLengthForDimensions:";
        private static readonly Selector sel_supportIndirectCommandBuffers = "supportIndirectCommandBuffers";
        private static readonly Selector sel_gpuResourceID = "gpuResourceID";
        private static readonly Selector sel_shaderValidation = "shaderValidation";
        private static readonly Selector sel_functionHandleWithFunction = "functionHandleWithFunction:";
        private static readonly Selector sel_newComputePipelineStateWithAdditionalBinaryFunctionserror = "newComputePipelineStateWithAdditionalBinaryFunctions:error:";
        private static readonly Selector sel_newVisibleFunctionTableWithDescriptor = "newVisibleFunctionTableWithDescriptor:";
        private static readonly Selector sel_newIntersectionFunctionTableWithDescriptor = "newIntersectionFunctionTableWithDescriptor:";
    }
}
