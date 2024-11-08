using SharpMetal.Foundation;
using SharpMetal.QuartzCore;
using SharpMetal.ObjectiveCCore;
using System.Runtime.InteropServices;
using System;

namespace SharpMetal.Metal
{
    public enum MTLCommandBufferStatus : ulong
    {
        NotEnqueued = 0,
        Enqueued = 1,
        Committed = 2,
        Scheduled = 3,
        Completed = 4,
        Error = 5,
    }

    public enum MTLCommandBufferError : ulong
    {
        None = 0,
        Internal = 1,
        Timeout = 2,
        PageFault = 3,
        Blacklisted = 4,
        AccessRevoked = 4,
        NotPermitted = 7,
        OutOfMemory = 8,
        InvalidResource = 9,
        Memoryless = 10,
        DeviceRemoved = 11,
        StackOverflow = 12,
    }

    public enum MTLCommandBufferErrorOption : ulong
    {
        None = 0,
        EncoderExecutionStatus = 1,
    }

    public enum MTLCommandEncoderErrorState : long
    {
        Unknown = 0,
        Completed = 1,
        Affected = 2,
        Pending = 3,
        Faulted = 4,
    }

    public enum MTLDispatchType : ulong
    {
        Serial = 0,
        Concurrent = 1,
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void MTLCommandBufferHandler(IntPtr block, MTLCommandBuffer buffer);

    public partial struct MTLCommandBufferDescriptor
    {
        public IntPtr NativePtr;

        public MTLCommandBufferDescriptor(in IntPtr ptr) => NativePtr = ptr;

        public static MTLCommandBufferDescriptor New() => s_class.AllocInit<MTLCommandBufferDescriptor>();

        public bool RetainedReferences
        {
            get => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_retainedReferences);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setRetainedReferences, value);
        }
        
        public MTLCommandBufferErrorOption ErrorOptions
        {
            get => (MTLCommandBufferErrorOption)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_errorOptions);
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setErrorOptions, (ulong)value);
        }

        public MTLLogState LogState
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_logState));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLogState, value);
        }


        public static implicit operator IntPtr(in MTLCommandBufferDescriptor obj) => obj.NativePtr;

        private static readonly ObjectiveCClass s_class = new ObjectiveCClass(nameof(MTLCommandBufferDescriptor));
        private static readonly Selector sel_retainedReferences = "retainedReferences";
        private static readonly Selector sel_setRetainedReferences = "setRetainedReferences:";
        private static readonly Selector sel_errorOptions = "errorOptions";
        private static readonly Selector sel_setErrorOptions = "setErrorOptions:";
        private static readonly Selector sel_logState = "logState";
        private static readonly Selector sel_setLogState = "setLogState:";
    }

    
    public partial struct MTLCommandBufferEncoderInfo
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(in MTLCommandBufferEncoderInfo obj) => obj.NativePtr;
        public MTLCommandBufferEncoderInfo(in IntPtr ptr) => NativePtr = ptr;

        public NSString Label => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_label));

        public NSArray DebugSignposts => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_debugSignposts));

        public MTLCommandEncoderErrorState ErrorState => (MTLCommandEncoderErrorState)ObjectiveCRuntime.long_objc_msgSend(NativePtr, sel_errorState);

        private static readonly Selector sel_label = "label";
        private static readonly Selector sel_debugSignposts = "debugSignposts";
        private static readonly Selector sel_errorState = "errorState";
    }

    
    public partial struct MTLCommandBuffer
    {
        public IntPtr NativePtr;
        public static implicit operator IntPtr(in MTLCommandBuffer obj) => obj.NativePtr;
        public MTLCommandBuffer(in IntPtr ptr) => NativePtr = ptr;

        public MTLDevice Device => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_device));

        public MTLCommandQueue CommandQueue => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_commandQueue));

        public bool RetainedReferences => ObjectiveCRuntime.bool_objc_msgSend(NativePtr, sel_retainedReferences);

        public MTLCommandBufferErrorOption ErrorOptions => (MTLCommandBufferErrorOption)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_errorOptions);

        public NSString Label
        {
            get => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_label));
            set => ObjectiveCRuntime.objc_msgSend(NativePtr, sel_setLabel, value);
        }

        public IntPtr KernelStartTime => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_kernelStartTime));

        public IntPtr KernelEndTime => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_kernelEndTime));

        public MTLLogContainer Logs => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_logs));

        public IntPtr GPUStartTime => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_GPUStartTime));

        public IntPtr GPUEndTime => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_GPUEndTime));

        public MTLCommandBufferStatus Status => (MTLCommandBufferStatus)ObjectiveCRuntime.ulong_objc_msgSend(NativePtr, sel_status);

        public NSError Error => new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_error));

        public void Enqueue()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_enqueue);
        }

        public void Commit()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_commit);
        }

        public void PresentDrawable(in MTLDrawable drawable)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_presentDrawable, drawable);
        }

        public void PresentDrawableAtTime(in MTLDrawable drawable, in IntPtr presentationTime)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_presentDrawableatTime, drawable, presentationTime);
        }

        public void PresentDrawableAfterMinimumDuration(in MTLDrawable drawable, in IntPtr duration)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_presentDrawableafterMinimumDuration, drawable, duration);
        }

        public void WaitUntilScheduled()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_waitUntilScheduled);
        }

        public void WaitUntilCompleted()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_waitUntilCompleted);
        }

        public void AddScheduledHandler(MTLCommandBufferHandler block)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_addScheduledHandler, block);
        }

        public void AddCompletedHandler(MTLCommandBufferHandler block)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_addCompletedHandler, block);
        }

        public MTLRenderCommandEncoder RenderCommandEncoder(in MTLRenderPassDescriptor renderPassDescriptor)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_renderCommandEncoderWithDescriptor, renderPassDescriptor));
        }

        public MTLComputeCommandEncoder ComputeCommandEncoder(in MTLComputePassDescriptor computePassDescriptor)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_computeCommandEncoderWithDescriptor, computePassDescriptor));
        }

        public MTLBlitCommandEncoder BlitCommandEncoder(in MTLBlitPassDescriptor blitPassDescriptor)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_blitCommandEncoderWithDescriptor, blitPassDescriptor));
        }

        public MTLBlitCommandEncoder BlitCommandEncoder()
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_blitCommandEncoder));
        }

        public MTLComputeCommandEncoder ComputeCommandEncoder()
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_computeCommandEncoder));
        }

        public MTLComputeCommandEncoder ComputeCommandEncoder(in MTLDispatchType dispatchType)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_computeCommandEncoderWithDispatchType, (ulong)dispatchType));
        }

        public void useResidencySet(in MTLResidencySet residencySet)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_useResidencySet, residencySet);
        }

        public void useResidencySets(in IntPtr residencySets, in ulong count)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_useResidencySetscount, residencySets, count);
        }

        public void EncodeWait(in MTLEvent mltEvent, in ulong value)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_encodeWaitForEventvalue, mltEvent, value);
        }

        public void EncodeSignalEvent(in MTLEvent mltEvent, in ulong value)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_encodeSignalEventvalue, mltEvent, value);
        }

        public MTLParallelRenderCommandEncoder ParallelRenderCommandEncoder(in MTLRenderPassDescriptor renderPassDescriptor)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_parallelRenderCommandEncoderWithDescriptor, renderPassDescriptor));
        }

        public MTLResourceStateCommandEncoder ResourceStateCommandEncoder(in MTLResourceStatePassDescriptor resourceStatePassDescriptor)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_resourceStateCommandEncoderWithDescriptor, resourceStatePassDescriptor));
        }

        public MTLResourceStateCommandEncoder ResourceStateCommandEncoder()
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_resourceStateCommandEncoder));
        }

        public MTLAccelerationStructureCommandEncoder AccelerationStructureCommandEncoder(in MTLAccelerationStructurePassDescriptor descriptor)
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_accelerationStructureCommandEncoderWithDescriptor, descriptor));
        }

        public MTLAccelerationStructureCommandEncoder AccelerationStructureCommandEncoder()
        {
            return new(ObjectiveCRuntime.IntPtr_objc_msgSend(NativePtr, sel_accelerationStructureCommandEncoder));
        }

        public void PushDebugGroup(in NSString nsString)
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_pushDebugGroup, nsString);
        }

        public void PopDebugGroup()
        {
            ObjectiveCRuntime.objc_msgSend(NativePtr, sel_popDebugGroup);
        }

        private static readonly Selector sel_device = "device";
        private static readonly Selector sel_commandQueue = "commandQueue";
        private static readonly Selector sel_retainedReferences = "retainedReferences";
        private static readonly Selector sel_errorOptions = "errorOptions";
        private static readonly Selector sel_label = "label";
        private static readonly Selector sel_setLabel = "setLabel:";
        private static readonly Selector sel_kernelStartTime = "kernelStartTime";
        private static readonly Selector sel_kernelEndTime = "kernelEndTime";
        private static readonly Selector sel_logs = "logs";
        private static readonly Selector sel_GPUStartTime = "GPUStartTime";
        private static readonly Selector sel_GPUEndTime = "GPUEndTime";
        private static readonly Selector sel_enqueue = "enqueue";
        private static readonly Selector sel_commit = "commit";
        private static readonly Selector sel_presentDrawable = "presentDrawable:";
        private static readonly Selector sel_presentDrawableatTime = "presentDrawable:atTime:";
        private static readonly Selector sel_presentDrawableafterMinimumDuration = "presentDrawable:afterMinimumDuration:";
        private static readonly Selector sel_waitUntilScheduled = "waitUntilScheduled";
        private static readonly Selector sel_waitUntilCompleted = "waitUntilCompleted";
        private static readonly Selector sel_addScheduledHandler = "addScheduledHandler:";
        private static readonly Selector sel_addCompletedHandler = "addCompletedHandler:";
        private static readonly Selector sel_status = "status";
        private static readonly Selector sel_error = "error";
        private static readonly Selector sel_blitCommandEncoder = "blitCommandEncoder";
        private static readonly Selector sel_renderCommandEncoderWithDescriptor = "renderCommandEncoderWithDescriptor:";
        private static readonly Selector sel_computeCommandEncoderWithDescriptor = "computeCommandEncoderWithDescriptor:";
        private static readonly Selector sel_blitCommandEncoderWithDescriptor = "blitCommandEncoderWithDescriptor:";
        private static readonly Selector sel_computeCommandEncoder = "computeCommandEncoder";
        private static readonly Selector sel_computeCommandEncoderWithDispatchType = "computeCommandEncoderWithDispatchType:";
        private static readonly Selector sel_useResidencySet = "useResidencySet";
        private static readonly Selector sel_useResidencySetscount = "useResidencySets:count:";
        private static readonly Selector sel_encodeWaitForEventvalue = "encodeWaitForEvent:value:";
        private static readonly Selector sel_encodeSignalEventvalue = "encodeSignalEvent:value:";
        private static readonly Selector sel_parallelRenderCommandEncoderWithDescriptor = "parallelRenderCommandEncoderWithDescriptor:";
        private static readonly Selector sel_resourceStateCommandEncoder = "resourceStateCommandEncoder";
        private static readonly Selector sel_resourceStateCommandEncoderWithDescriptor = "resourceStateCommandEncoderWithDescriptor:";
        private static readonly Selector sel_accelerationStructureCommandEncoder = "accelerationStructureCommandEncoder";
        private static readonly Selector sel_accelerationStructureCommandEncoderWithDescriptor = "accelerationStructureCommandEncoderWithDescriptor:";
        private static readonly Selector sel_pushDebugGroup = "pushDebugGroup:";
        private static readonly Selector sel_popDebugGroup = "popDebugGroup";
    }
}
