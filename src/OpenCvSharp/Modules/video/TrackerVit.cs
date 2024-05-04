using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using OpenCvSharp.Internal;

namespace OpenCvSharp;

/// <inheritdoc />
/// <summary>
/// Vit
/// </summary>
/// <remarks>
/// 
/// </remarks>
// ReSharper disable once InconsistentNaming
public class TrackerVit : Tracker
{
    /// <summary>
    /// 
    /// </summary>
    protected TrackerVit(IntPtr p)
        : base(new Ptr(p))
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <returns></returns>
    public static TrackerVit Create()
    {
        NativeMethods.HandleException(
            NativeMethods.video_TrackerVit_create1(out var p));
        return new TrackerVit(p);
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="parameters">Vit parameters</param>
    /// <returns></returns>
    public static TrackerVit Create(Params parameters)
    {
        unsafe
        {
            NativeMethods.HandleException(
                NativeMethods.video_TrackerVit_create2(ref parameters, out var p));
            return new TrackerVit(p);
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
                NativeMethods.video_Ptr_TrackerVit_get(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }

        protected override void DisposeUnmanaged()
        {
            NativeMethods.HandleException(
                NativeMethods.video_Ptr_TrackerVit_delete(ptr));
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
        public string Net = "vitTracker.onnx";
        public int Backend = 0;
        public int Target = 0;
        public Scalar MeanValue = new Scalar(0.485, 0.456, 0.406);
        public Scalar StdValue = new Scalar(0.229, 0.224, 0.225);

        public Params()
        {

        }
    }
}
