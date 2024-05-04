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

    // TODO
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
                NativeMethods.video_TrackerVit_create2(&parameters, out var p));
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

    }
}
