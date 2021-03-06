// ==++==
// 
//   Copyright (c) Microsoft Corporation.  All rights reserved.
// 
// ==--==
/*=============================================================================
**
** Class: DispatchWrapper.
**
**
** Purpose: Wrapper that is converted to a variant with VT_DISPATCH.
**
**
=============================================================================*/
#if !FULL_AOT_RUNTIME
namespace System.Runtime.InteropServices {
   
    using System;
    using System.Security;
    using System.Security.Permissions;

    [Serializable]
[System.Runtime.InteropServices.ComVisible(true)]
    public sealed class DispatchWrapper
    {
        [System.Security.SecuritySafeCritical]  // auto-generated
#pragma warning disable 618
        [SecurityPermissionAttribute(SecurityAction.Demand,Flags=SecurityPermissionFlag.UnmanagedCode)]
#pragma warning restore 618
        public DispatchWrapper(Object obj)
        {
            if (obj != null)
            {
                // Make sure this guy has an IDispatch
                IntPtr pdisp = Marshal.GetIDispatchForObject(obj);

                // If we got here without throwing an exception, the QI for IDispatch succeeded.
                Marshal.Release(pdisp);
            }
            m_WrappedObject = obj;
        }

        public Object WrappedObject 
        {
            get 
            {
                return m_WrappedObject;
            }
        }

        private Object m_WrappedObject;
    }
}
#endif