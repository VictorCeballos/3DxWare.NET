///////////////////////////////////////////////////////////////////////////////////
// Copyright notice:
//   Copyright (c) 2016 3Dconnexion. All rights reserved.
//
// This file and source code are an integral part of the "3Dconnexion
// Software Development Kit", including all accompanying documentation,
// and is protected by intellectual property laws. All use of the
// 3Dconnexion Software Development Kit is subject to the License
// Agreement found in the "LicenseAgreementSDK.txt" file.
// All rights not expressly granted by 3Dconnexion are reserved.
//
namespace _3Dconnexion;

using System.Runtime.InteropServices;


public class SiApp
{
    private const string SI_DLL = "siappdll";

    #region Enums

    public enum SpwRetVal
    {
        SPW_NO_ERROR,
        SPW_ERROR,
        SI_BAD_HANDLE,
        SI_BAD_ID,
        SI_BAD_VALUE,
        SI_IS_EVENT,
        SI_SKIP_EVENT,
        SI_NOT_EVENT,
        SI_NO_DRIVER,
        SI_NO_RESPONSE,
        SI_UNSUPPORTED,
        SI_UNINITIALIZED,
        SI_WRONG_DRIVER,
        SI_INTERNAL_ERROR,
        SI_BAD_PROTOCOL,
        SI_OUT_OF_MEMORY,
        SPW_DLL_LOAD_ERROR,
        SI_NOT_OPEN,
        SI_ITEM_NOT_FOUND,
        SI_UNSUPPORTED_DEVICE
    }

    public enum SiEventType : int
    {
        SI_BUTTON_EVENT = 1,
        SI_MOTION_EVENT,
        SI_COMBO_EVENT,
        SI_ZERO_EVENT,
        SI_EXCEPTION_EVENT,
        SI_OUT_OF_BAND,
        SI_ORIENTATION_EVENT,
        SI_KEYBOARD_EVENT,
        SI_LPFK_EVENT,
        SI_APP_EVENT,
        SI_SYNC_EVENT,
        SI_BUTTON_PRESS_EVENT,
        SI_BUTTON_RELEASE_EVENT,
        SI_DEVICE_CHANGE_EVENT,
        SI_MOUSE_EVENT,
        SI_JOYSTICK_EVENT,
        SI_CMD_EVENT,
        SI_MOTION_HID_EVENT,
        SI_SETTING_CHANGED_EVENT,
        SI_RECONNECT_EVENT
    }

    public enum SiDeviceChangeType
    {
        SI_DEVICE_CHANGE_CONNECT = 0,
        SI_DEVICE_CHANGE_DISCONNECT = 1
    }

    public enum V3DCMD : int
    {
        V3DCMD_NOOP = 0,
        V3DCMD_MENU_OPTIONS = 1,
        V3DCMD_VIEW_FIT = 2,
        V3DCMD_VIEW_TOP = 3,
        V3DCMD_VIEW_LEFT = 4,
        V3DCMD_VIEW_RIGHT = 5,
        V3DCMD_VIEW_FRONT = 6,
        V3DCMD_VIEW_BOTTOM = 7,
        V3DCMD_VIEW_BACK = 8,
        V3DCMD_VIEW_ROLLCW = 9,
        V3DCMD_VIEW_ROLLCCW = 10,
        V3DCMD_VIEW_ISO1 = 11,
        V3DCMD_VIEW_ISO2 = 12,
        V3DCMD_KEY_F1 = 13,
        V3DCMD_KEY_F2 = 14,
        V3DCMD_KEY_F3 = 15,
        V3DCMD_KEY_F4 = 16,
        V3DCMD_KEY_F5 = 17,
        V3DCMD_KEY_F6 = 18,
        V3DCMD_KEY_F7 = 19,
        V3DCMD_KEY_F8 = 20,
        V3DCMD_KEY_F9 = 21,
        V3DCMD_KEY_F10 = 22,
        V3DCMD_KEY_F11 = 23,
        V3DCMD_KEY_F12 = 24,
        V3DCMD_KEY_ESC = 25,
        V3DCMD_KEY_ALT = 26,
        V3DCMD_KEY_SHIFT = 27,
        V3DCMD_KEY_CTRL = 28,
        V3DCMD_FILTER_ROTATE = 29,
        V3DCMD_FILTER_PANZOOM = 30,
        V3DCMD_FILTER_DOMINANT = 31,
        V3DCMD_SCALE_PLUS = 32,
        V3DCMD_SCALE_MINUS = 33,
        V3DCMD_VIEW_SPINCW = 34,
        V3DCMD_VIEW_SPINCCW = 35,
        V3DCMD_VIEW_TILTCW = 36,
        V3DCMD_VIEW_TILTCCW = 37,
        V3DCMD_MENU_POPUP = 38,
        V3DCMD_MENU_BUTTONMAPPINGEDITOR = 39,
        V3DCMD_MENU_ADVANCEDSETTINGSEDITOR = 40,
        V3DCMD_MOTIONMACRO_ZOOM = 41,
        V3DCMD_MOTIONMACRO_ZOOMOUT_CURSORTOCENTER = 42,
        V3DCMD_MOTIONMACRO_ZOOMIN_CURSORTOCENTER = 43,
        V3DCMD_MOTIONMACRO_ZOOMOUT_CENTERTOCENTER = 44,
        V3DCMD_MOTIONMACRO_ZOOMIN_CENTERTOCENTER = 45,
        V3DCMD_MOTIONMACRO_ZOOMOUT_CURSORTOCURSOR = 46,
        V3DCMD_MOTIONMACRO_ZOOMIN_CURSORTOCURSOR = 47,
        V3DCMD_VIEW_QZ_IN = 48,
        V3DCMD_VIEW_QZ_OUT = 49,
        V3DCMD_KEY_ENTER = 50,
        V3DCMD_KEY_DELETE = 51,
        V3DCMD_KEY_F13 = 52,
        V3DCMD_KEY_F14 = 53,
        V3DCMD_KEY_F15 = 54,
        V3DCMD_KEY_F16 = 55,
        V3DCMD_KEY_F17 = 56,
        V3DCMD_KEY_F18 = 57,
        V3DCMD_KEY_F19 = 58,
        V3DCMD_KEY_F20 = 59,
        V3DCMD_KEY_F21 = 60,
        V3DCMD_KEY_F22 = 61,
        V3DCMD_KEY_F23 = 62,
        V3DCMD_KEY_F24 = 63,
        V3DCMD_KEY_F25 = 64,
        V3DCMD_KEY_F26 = 65,
        V3DCMD_KEY_F27 = 66,
        V3DCMD_KEY_F28 = 67,
        V3DCMD_KEY_F29 = 68,
        V3DCMD_KEY_F30 = 69,
        V3DCMD_KEY_F31 = 70,
        V3DCMD_KEY_F32 = 71,
        V3DCMD_KEY_F33 = 72,
        V3DCMD_KEY_F34 = 73,
        V3DCMD_KEY_F35 = 74,
        V3DCMD_KEY_F36 = 75,
        V3DCMD_VIEW_1 = 76,
        V3DCMD_VIEW_2 = 77,
        V3DCMD_VIEW_3 = 78,
        V3DCMD_VIEW_4 = 79,
        V3DCMD_VIEW_5 = 80,
        V3DCMD_VIEW_6 = 81,
        V3DCMD_VIEW_7 = 82,
        V3DCMD_VIEW_8 = 83,
        V3DCMD_VIEW_9 = 84,
        V3DCMD_VIEW_10 = 85,
        V3DCMD_VIEW_11 = 86,
        V3DCMD_VIEW_12 = 87,
        V3DCMD_VIEW_13 = 88,
        V3DCMD_VIEW_14 = 89,
        V3DCMD_VIEW_15 = 90,
        V3DCMD_VIEW_16 = 91,
        V3DCMD_VIEW_17 = 92,
        V3DCMD_VIEW_18 = 93,
        V3DCMD_VIEW_19 = 94,
        V3DCMD_VIEW_20 = 95,
        V3DCMD_VIEW_21 = 96,
        V3DCMD_VIEW_22 = 97,
        V3DCMD_VIEW_23 = 98,
        V3DCMD_VIEW_24 = 99,
        V3DCMD_VIEW_25 = 100,
        V3DCMD_VIEW_26 = 101,
        V3DCMD_VIEW_27 = 102,
        V3DCMD_VIEW_28 = 103,
        V3DCMD_VIEW_29 = 104,
        V3DCMD_VIEW_30 = 105,
        V3DCMD_VIEW_31 = 106,
        V3DCMD_VIEW_32 = 107,
        V3DCMD_VIEW_33 = 108,
        V3DCMD_VIEW_34 = 109,
        V3DCMD_VIEW_35 = 110,
        V3DCMD_VIEW_36 = 111,
        V3DCMD_SAVE_VIEW_1 = 112,
        V3DCMD_SAVE_VIEW_2 = 113,
        V3DCMD_SAVE_VIEW_3 = 114,
        V3DCMD_SAVE_VIEW_4 = 115,
        V3DCMD_SAVE_VIEW_5 = 116,
        V3DCMD_SAVE_VIEW_6 = 117,
        V3DCMD_SAVE_VIEW_7 = 118,
        V3DCMD_SAVE_VIEW_8 = 119,
        V3DCMD_SAVE_VIEW_9 = 120,
        V3DCMD_SAVE_VIEW_10 = 121,
        V3DCMD_SAVE_VIEW_11 = 122,
        V3DCMD_SAVE_VIEW_12 = 123,
        V3DCMD_SAVE_VIEW_13 = 124,
        V3DCMD_SAVE_VIEW_14 = 125,
        V3DCMD_SAVE_VIEW_15 = 126,
        V3DCMD_SAVE_VIEW_16 = 127,
        V3DCMD_SAVE_VIEW_17 = 128,
        V3DCMD_SAVE_VIEW_18 = 129,
        V3DCMD_SAVE_VIEW_19 = 130,
        V3DCMD_SAVE_VIEW_20 = 131,
        V3DCMD_SAVE_VIEW_21 = 132,
        V3DCMD_SAVE_VIEW_22 = 133,
        V3DCMD_SAVE_VIEW_23 = 134,
        V3DCMD_SAVE_VIEW_24 = 135,
        V3DCMD_SAVE_VIEW_25 = 136,
        V3DCMD_SAVE_VIEW_26 = 137,
        V3DCMD_SAVE_VIEW_27 = 138,
        V3DCMD_SAVE_VIEW_28 = 139,
        V3DCMD_SAVE_VIEW_29 = 140,
        V3DCMD_SAVE_VIEW_30 = 141,
        V3DCMD_SAVE_VIEW_31 = 142,
        V3DCMD_SAVE_VIEW_32 = 143,
        V3DCMD_SAVE_VIEW_33 = 144,
        V3DCMD_SAVE_VIEW_34 = 145,
        V3DCMD_SAVE_VIEW_35 = 146,
        V3DCMD_SAVE_VIEW_36 = 147,
        V3DCMD_KEY_TAB = 148,
        V3DCMD_KEY_SPACE = 149,
        V3DCMD_MENU_1 = 150,
        V3DCMD_MENU_2 = 151,
        V3DCMD_MENU_3 = 152,
        V3DCMD_MENU_4 = 153,
        V3DCMD_MENU_5 = 154,
        V3DCMD_MENU_6 = 155,
        V3DCMD_MENU_7 = 156,
        V3DCMD_MENU_8 = 157,
        V3DCMD_MENU_9 = 158,
        V3DCMD_MENU_10 = 159,
        V3DCMD_MENU_11 = 160,
        V3DCMD_MENU_12 = 161,
        V3DCMD_MENU_13 = 162,
        V3DCMD_MENU_14 = 163,
        V3DCMD_MENU_15 = 164,
        V3DCMD_MENU_16 = 165,
    }

    public enum SiActionNodeType_t : int
    {
        SI_ACTIONSET_NODE = 0,
        SI_CATEGORY_NODE,
        SI_ACTION_NODE
    }

    public enum SiImageType_t : int
    {
        e_none = 0,
        e_image_file,
        e_resource_file,
        e_image
    }

    #endregion Enums

    #region Const Variables

    private const int MAX_PATH = 260;

    private const int SI_STRSIZE = 128;
    private const int SI_MAXBUF = 128;
    private const int SI_MAXPORTNAME = 260;
    private const int SI_MAXPATH = 512;
    private const int SI_MAXAPPCMDID = 500;
    private const int SI_KEY_MAXBUF = 5120;

    public const int SI_ANY_DEVICE = -1;
    public const int SI_NO_BUTTON = -1;
    public const int SI_EVENT = 0x0001;
    public const int SI_AVERAGE_EVENTS = 1;

    //private const int SPW_FALSE = 0;
    private static readonly uint SpaceWareMessage00 = RegisterWindowMessage(@"SpaceWareMessage00");

    #endregion Const Variables

    #region Classes and structs

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class SiDevInfo
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = SI_STRSIZE)]
        public string? firmware;

        public int devType;
        public int numButtons;
        public int numDegrees;
        public int canBeep;
        public int majorVersion;
        public int minorVersion;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class SiDevPort
    {
        public int devID;
        public int devType;
        public int devClass;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = SI_STRSIZE)]
        public string? devName;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = SI_MAXPORTNAME)]
        public string? portName;
    }

    [StructLayout(LayoutKind.Sequential)]
    public class SiDeviceName
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = SI_STRSIZE)]
        public string? name;
    }

    [StructLayout(LayoutKind.Sequential)]
    public class SiButtonName
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = SI_STRSIZE)]
        public string? name;
    }

    [StructLayout(LayoutKind.Sequential)]
    public class SiPortName
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = SI_MAXPATH)]
        public string? name;
    }

    [StructLayout(LayoutKind.Sequential)]
    public class SiAppCmdID
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = SI_MAXAPPCMDID)]
        public string? appCmdID;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class SiOpenData
    {
        public IntPtr hWnd;
        public IntPtr transCtl;
        public int processID;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH)]
        public string? exeFile;

        public int libFlag;
    }

    [StructLayout(LayoutKind.Sequential)]
    public class SiTypeMask
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[]? mask;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class SiGetEventData
    {
        public uint msg;
        public IntPtr wParam;
        public IntPtr lParam;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class SiButtonData
    {
        public uint last;
        public uint current;
        public uint pressed;
        public uint released;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class SiHWButtonData : SiEventData
    {
        // The V3DKey that went down/up in a SI_BUTTON_PRESS/RELEASE_EVENT event
        public int buttonNumber;      
    }

    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class SiSpwOOB : SiEventData
    {
        public byte code;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = SI_MAXBUF - 1)]
        public byte[]? message;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class SiOrientation
    {
        public int orientation;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class SiKeyboardData : SiEventData
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = SI_KEY_MAXBUF)]
        public byte[]? kstring;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class SiCmdEventData : SiEventData
    {
        public int pressed;

        [MarshalAs(UnmanagedType.I4)]
        public V3DCMD functionNumber;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public int[]? iArgs;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16, ArraySubType = UnmanagedType.R4)]
        public float[]? fArgs;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class SiDeviceChangeEventData : SiEventData
    {
        public int type;
        public int devID;
        public SiPortName? portName;
    }

    public class SiSpwEvent
    {
        public SiEventType? Type => EventData?.EventType;

        public SiAppCommandData? AppCommandData => EventData as SiAppCommandData;

        public SiSpwData? SpwData => (EventData as SiSpwEventData)?.Data;

        public SiCmdEventData? CmdEventData => EventData as SiCmdEventData;
        
        public SiEventData? EventData { get; set; }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class SiEventData
    {
        public SiEventType EventType { get; set; }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class SiSpwEventData : SiEventData
    {
        public SiSpwData? Data { get; set; }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class SiSpwData
    {
        public SiButtonData? ButtonData => _bData;

        public int[]? Data => _mData;

        public int Period => _period;

        private readonly SiButtonData? _bData;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
        private readonly int[]? _mData;

        private readonly int _period;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class SiAppCommandData : SiEventData
    {
        public int Pressed { get; set; }
        public SiAppCmdID? ID { get; set; }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SiActionNodeEx_t
    {
        public uint size;
        public SiActionNodeType_t type;

        public IntPtr next;       // SiActionNodeEx_t*
        public IntPtr children;   // SiActionNodeEx_t*

        public IntPtr id;         // string utf8
        public IntPtr label;      // string utf8
        public IntPtr description;// string utf8
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SiResource_s
    {
        public IntPtr file_name;  //  string utf8
        public IntPtr id;         //  string utf8
        public IntPtr type;       //  string utf8
        public int index;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SiImageFile_s
    {
        public IntPtr file_name;  //  string utf8
        public int index;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SiImageData_s
    {
        public IntPtr data;       // byte[]
        public uint size;
        public int index;
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct SiImage_union_s
    {
        [FieldOffset(0)]
        public SiImageData_s image;

        [FieldOffset(0)]
        public SiResource_s resource;

        [FieldOffset(0)]
        public SiImageFile_s file;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SiImage_s
    {
        public int size;
        public SiImageType_t type;

        public IntPtr id;       // string utf8

        public SiImage_union_s u;
    }

    #endregion Classes and structs

    #region DLL Imports

    [DllImport(SI_DLL)]
    public static extern SpwRetVal SiGetButtonName([In] IntPtr hdl, [In] uint buttonNumber, [In, Out] SiButtonName name);

    [DllImport(SI_DLL)]
    public static extern SpwRetVal SiGetDeviceName([In] IntPtr hdl, [In, Out] SiDeviceName name);

    [DllImport(SI_DLL, EntryPoint = "SiInitialize")]
    public static extern SpwRetVal SiInitializeImport();

    [DllImport(SI_DLL)]
    public static extern int SiTerminate();

    [DllImport(SI_DLL)]
    public static extern SpwRetVal SiClose([In] IntPtr hdl);

    [DllImport(SI_DLL)]
    public static extern int SiOpenWinInit([In, Out] SiOpenData o, [In] IntPtr hwnd);

    [DllImport(SI_DLL)]
    public static extern IntPtr SiOpen([In, MarshalAs(UnmanagedType.LPStr)] string pAppName, int devID, [In] IntPtr pTMask, int mode, [In, Out] SiOpenData pData);

    [DllImport(SI_DLL)]
    public static extern IntPtr SiOpenPort([In, MarshalAs(UnmanagedType.LPStr)] string pAppName, [In, Out] SiDevPort pPort, int mode, [In, Out] SiOpenData pData);

    [DllImport(SI_DLL)]
    public static extern SpwRetVal SiGetDeviceInfo([In] IntPtr hdl, [In, Out] SiDevInfo pInfo);

    [DllImport(SI_DLL)]
    public static extern SpwRetVal SiGetDevicePort([In] IntPtr hdl, [In, Out] SiDevPort pPort);

    [DllImport(SI_DLL)]
    public static extern void SiGetEventWinInit([In, Out] SiGetEventData pData, int msg, [In] IntPtr wParam, [In] IntPtr lParam);

    [DllImport(SI_DLL)]
    public static extern SpwRetVal SiGetEvent([In] IntPtr hdl, int flags, [In] SiGetEventData pData, [In, Out][MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SiSpwEventMarshaler))] SiSpwEvent spwEvent);

    [DllImport(SI_DLL)]
    public static extern int SiButtonPressed([In, Out] SiSpwData pEvent);

    [DllImport(SI_DLL)]
    public static extern SpwRetVal SiRezero([In] IntPtr hdl);

    [DllImport(SI_DLL)]
    public static extern SpwRetVal SiSetLEDs([In] IntPtr hdl, [In] long mask);

    [DllImport(SI_DLL)]
    public static extern int SiGetNumDevices();

    [DllImport(SI_DLL)]
    public static extern SpwRetVal SiGrabDevice([In] IntPtr hdl, [In] int flag);

    [DllImport(SI_DLL)]
    public static extern SpwRetVal SiReleaseDevice([In] IntPtr hdl);

    [DllImport(SI_DLL)]
    public static extern SpwRetVal SiAppCmdWriteActions([In] IntPtr hdl, [In] ref SiActionNodeEx_t action_tree);

    [DllImport(SI_DLL)]
    public static extern SpwRetVal SiAppCmdWriteActions([In] IntPtr hdl, [In] IntPtr action_tree);

    [DllImport(SI_DLL)]
    public static extern SpwRetVal SiAppCmdActivateActionSet([In] IntPtr hdl, [In, MarshalAs(UnmanagedType.LPStr)] string action_set_id);

    [DllImport(SI_DLL)]
    public static extern SpwRetVal SiAppCmdWriteActionImages([In] IntPtr hdl, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] SiImage_s[] images, [In] int image_count);

    [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
    private static extern uint RegisterWindowMessage(string lpString);

    #endregion DLL Imports

    #region Custom marshalers

    public class SiSpwEventMarshaler : ICustomMarshaler
    {
        private IntPtr nativeData = IntPtr.Zero;
        private SiSpwEvent? siSpwEvent = null;

        public IntPtr MarshalManagedToNative(object managedObj)
        {
            nativeData = Marshal.AllocHGlobal(GetNativeDataSize());
            if (managedObj != null)
            {
                siSpwEvent = (SiSpwEvent)managedObj;
                if (siSpwEvent != null)
                {
                    if (siSpwEvent.Type != null)
                    {
                        Marshal.WriteInt32(nativeData, (int)siSpwEvent.Type);
                    }
                }
            }
            return nativeData;
        }

        public object MarshalNativeToManaged(IntPtr pNativeData)
        {
            if (siSpwEvent == null)
            {
                throw new MarshalDirectiveException("Marshaling error");
            }

            if (pNativeData == IntPtr.Zero)
            {
                siSpwEvent.EventData = null;
            }

            if (nativeData != pNativeData)
            {
                throw new MarshalDirectiveException("Marshaling different structure back to managed data");
            }

            SiEventType type = (SiEventType)Marshal.ReadInt32(pNativeData);
            siSpwEvent.EventData = type switch
            {
                SiEventType.SI_APP_EVENT => (SiEventData?)Marshal.PtrToStructure(pNativeData, typeof(SiAppCommandData)),
                SiEventType.SI_BUTTON_EVENT or SiEventType.SI_MOTION_EVENT or SiEventType.SI_ZERO_EVENT => (SiEventData?)Marshal.PtrToStructure(pNativeData, typeof(SiSpwEventData)),
                SiEventType.SI_BUTTON_PRESS_EVENT or SiEventType.SI_BUTTON_RELEASE_EVENT => (SiEventData?)Marshal.PtrToStructure(pNativeData, typeof(SiHWButtonData)),
                SiEventType.SI_CMD_EVENT => (SiEventData?)Marshal.PtrToStructure(pNativeData, typeof(SiCmdEventData)),
                SiEventType.SI_DEVICE_CHANGE_EVENT => (SiEventData?)Marshal.PtrToStructure(pNativeData, typeof(SiDeviceChangeEventData)),
                _ => null,
            };

            return siSpwEvent;
        }

        public void CleanUpNativeData(IntPtr pNativeData)
        {
            Marshal.FreeHGlobal(pNativeData);
        }

        public void CleanUpManagedData(object managedObj)
        {

        }

        public int GetNativeDataSize()
        {
            return 4 + SI_KEY_MAXBUF;
        }

        public static ICustomMarshaler GetInstance(string cookie)
        {
            return new SiSpwEventMarshaler();
        }
    }

    #endregion Custom marshalers

    #region Helper functions

    public static SpwRetVal SiInitialize()
    {
        SpwRetVal ret;

        try
        {
            ret = SiInitializeImport();
        }
        catch (DllNotFoundException)
        {
            // If the driver is not loaded, the DLL will be missing
            // and the "import" functions cannot be called.
            ret = SpwRetVal.SPW_DLL_LOAD_ERROR;
        }
        catch (Exception)
        {
            ret = SpwRetVal.SPW_ERROR;
        }

        return ret;
    }

    public static bool IsSpaceMouseMessage(int msg)
    {
        return msg == (uint)SpaceWareMessage00;
    }

    #endregion Helper functions
}
