using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using OpenCvSharp.Internal;

namespace OpenCvSharp;

/// <inheritdoc />
/// <summary>
/// Nano
/// </summary>
/// <remarks>
/// 
/// </remarks>
// ReSharper disable once InconsistentNaming
public class TrackerNano : Tracker
{
    /// <summary>
    /// 
    /// </summary>
    protected TrackerNano(IntPtr p)
        : base(new Ptr(p))
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <returns></returns>
    public static TrackerNano Create()
    {
        NativeMethods.HandleException(
            NativeMethods.video_TrackerNano_create1(out var p));
        return new TrackerNano(p);
    }

    // TODO
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="parameters">Nano parameters</param>
    /// <returns></returns>
    public static TrackerNano Create(Params parameters)
    {
        unsafe
        {
            NativeMethods.HandleException(
                NativeMethods.video_TrackerNano_create2(&parameters, out var p));
            return new TrackerNano(p);
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
                NativeMethods.video_Ptr_TrackerNano_get(ptr, out var ret));
            GC.KeepAlive(this);
            return ret;
        }

        protected override void DisposeUnmanaged()
        {
            NativeMethods.HandleException(
                NativeMethods.video_Ptr_TrackerNano_delete(ptr));
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
