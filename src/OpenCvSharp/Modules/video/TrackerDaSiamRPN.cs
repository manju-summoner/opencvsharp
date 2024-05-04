using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using OpenCvSharp.Internal;

namespace OpenCvSharp;

/// <inheritdoc />
/// <summary>
/// DaSiamRPN
/// </summary>
/// <remarks>
/// 
/// </remarks>
// ReSharper disable once InconsistentNaming
public class TrackerDaSiamRPN : Tracker
{
    /// <summary>
    /// 
    /// </summary>
    protected TrackerDaSiamRPN(IntPtr p)
        : base(new Ptr(p))
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <returns></returns>
    public static TrackerDaSiamRPN Create()
    {
        NativeMethods.HandleException(
            NativeMethods.video_TrackerDaSiamRPN_create1(out var p));
        return new TrackerDaSiamRPN(p);
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="parameters">DaSiamRPN parameters</param>
    /// <returns></returns>
    public static TrackerDaSiamRPN Create(Params parameters)
    {
        unsafe
        {
            NativeMethods.HandleException(
                NativeMethods.video_TrackerDaSiamRPN_create2(ref parameters, out var p));
            return new TrackerDaSiamRPN(p);
        }
    }
        
    internal class Ptr : OpenCvSharp.Ptr
    {
        public Ptr(IntPtr ptr) : base(ptr)
        {
        }

        public override IntPtr Get()
        {
            NativeMethods.HandleException(
                NativeMethods.video_Ptr_TrackerDaSiamRPN_get(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }

        protected override void DisposeUnmanaged()
        {
            NativeMethods.HandleException(
                NativeMethods.video_Ptr_TrackerDaSiamRPN_delete(ptr));
            base.DisposeUnmanaged();
        }
    }

#pragma warning disable CA1034
    /// <summary>
    /// 
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Params
    {
#pragma warning disable 1591
        [MarshalAs(UnmanagedType.LPStr)]
        public string Model = "dasiamrpn_model.onnx";
        [MarshalAs(UnmanagedType.LPStr)]
        public string KernelCls1 = "dasiamrpn_kernel_cls1.onnx";
        [MarshalAs(UnmanagedType.LPStr)]
        public string KernelR1 = "dasiamrpn_kernel_r1.onnx";
        public int Backend = 0;
        public int Target = 0;

        public Params()
        {

        }
    }
}
