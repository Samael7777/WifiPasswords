using System.Runtime.InteropServices;
using Windows.Win32;
using Windows.Win32.Foundation;

namespace WlanApi.PInvoke;

internal class SafeWlanHandle : SafeHandle
{
    public SafeWlanHandle(HANDLE unsafeHandle) : base(IntPtr.Zero, true)
    {
        handle = unsafeHandle.Value;
    }

    protected override bool ReleaseHandle()
    {
        unsafe
        {
            return IsInvalid || WinApi.WlanCloseHandle((HANDLE)handle) == 0;
        }
    }

    public override bool IsInvalid => handle == IntPtr.Zero;
}