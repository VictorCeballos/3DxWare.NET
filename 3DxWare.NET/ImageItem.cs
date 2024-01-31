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

using System.Drawing;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;

public abstract class ImageItem : IDisposable
{
    #region member variables

    protected SiApp.SiImage_s m_siImage;
    private readonly UTF8String m_Id = new();

    #endregion member variables

    public string? Id
    {
        get
        {
            return m_Id.Value;
        }
        set
        {
            if (value?.Length == 0)
            {
                throw new ArgumentException("Invalid Item Id");
            }
            m_Id.Value = value;
        }
    }

    protected ImageItem(string id = "")
    {
        m_siImage.size = Marshal.SizeOf(typeof(SiApp.SiImage_s));
        m_siImage.type = SiApp.SiImageType_t.e_none;
        if (id.Length == 0)
        {
            Id = @"id_" + Guid.NewGuid().ToString();
        }
        else
        {
            Id = id;
        }
    }

    public static ImageItem FromFile(string filename, int index = 0, string id = "")
    {
        return new ImageFile(filename, index, id);
    }

    public static ImageItem FromResource(string resourceDllPath, string resourceId, string resourceType, int index = 0, string id = "")
    {
        return new ImageResource(resourceDllPath, resourceId, resourceType, index, id);
    }

    public static ImageItem FromImage(Image image, int index = 0, string id = "")
    {
        return new ImageData(image, index, id);
    }

    public virtual SiApp.SiImage_s PinObject()
    {
        m_siImage.id = m_Id.PinObject();
        return m_siImage;
    }

    public virtual IntPtr UnpinObject()
    {
        m_siImage.id = m_Id.UnpinObject();
        return IntPtr.Zero;
    }

    #region IDisposable Support

    private bool disposedValue = false; // To detect redundant calls

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                // dispose managed state (managed objects).
            }

            // free unmanaged resources (unmanaged objects) and override a finalizer below.
            // set large fields to null.
            UnpinObject();

            disposedValue = true;
        }
    }

    // override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
    ~ImageItem()
    {
        // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        Dispose(false);
    }

    // This code added to correctly implement the disposable pattern.
    public void Dispose()
    {
        // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        Dispose(true);
        //  SuppressFinalize if the finalizer is overridden above.
        GC.SuppressFinalize(this);
    }

    #endregion IDisposable Support
}

/// <summary>
/// class to handle image items referring to resource items in dll files
/// </summary>
public class ImageResource : ImageItem
{
    private class Resource
    {
        public UTF8String id = new();
        public UTF8String type = new();
    }

    private readonly Resource m_resource = new();
    private readonly UTF8String m_filename = new();

    public ImageResource(string resourceDllPath, string resourceId, string resourceType, int index = 0, string id = "") : base(id)
    {
        m_siImage.u.resource.index = index;

        m_filename.Value = resourceDllPath;
        m_resource.id.Value = resourceId;
        m_resource.type.Value = resourceType;
    }

    public override SiApp.SiImage_s PinObject()
    {
        m_siImage.u.resource.file_name = m_filename.PinObject();
        m_siImage.u.resource.id = m_resource.id.PinObject();
        m_siImage.u.resource.type = m_resource.type.PinObject();

        m_siImage.type = SiApp.SiImageType_t.e_resource_file;

        return base.PinObject();
    }

    public override IntPtr UnpinObject()
    {
        m_siImage.type = SiApp.SiImageType_t.e_none;

        m_filename.UnpinObject();
        m_resource.id.UnpinObject();
        m_resource.type.UnpinObject();

        return base.UnpinObject();
    }
}

/// <summary>
/// class to handle image items referring to System.Drawing.Image objects
/// </summary>
public class ImageData : ImageItem
{
    private class Data
    {
        public PinnedObject<byte[]> data = new();
    }

    private readonly Data m_imageData = new();

    public ImageData(Image image, int index = 0, string id = "") : base(id)
    {
        m_imageData.data.Value = ImageToByte(image);
        m_siImage.u.image.index = index;
        if (m_imageData.data.Value != null)
        {
            m_siImage.u.image.size = (uint)m_imageData.data.Value.Length;
        }
    }

    public override SiApp.SiImage_s PinObject()
    {
        m_siImage.u.image.data = m_imageData.data.PinObject();
        m_siImage.type = SiApp.SiImageType_t.e_image;

        return base.PinObject();
    }

    public override IntPtr UnpinObject()
    {
        m_siImage.type = SiApp.SiImageType_t.e_none;
        m_imageData.data.UnpinObject();

        return base.UnpinObject();
    }

    private static byte[]? ImageToByte(Image img)
    {
        if (OperatingSystem.IsWindows())
        {
            ImageConverter converter = new();
            return (byte[]?)converter.ConvertTo(img, typeof(byte[]));
        }
        else
        {
            throw new NotImplementedException();
        }
    }
}

/// <summary>
/// class to handle image items referring to bitmap files
/// </summary>
public class ImageFile : ImageItem
{
    private readonly UTF8String m_filename = new();

    public ImageFile(string filename, int index = 0, string id = "") : base(id)
    {
        m_filename.Value = filename;
        m_siImage.u.file.index = index;
    }

    public override SiApp.SiImage_s PinObject()
    {
        m_siImage.u.file.file_name = m_filename.PinObject();
        m_siImage.type = SiApp.SiImageType_t.e_image_file;

        return base.PinObject();
    }

    public override IntPtr UnpinObject()
    {
        m_siImage.type = SiApp.SiImageType_t.e_none;
        m_filename.UnpinObject();

        return base.UnpinObject();
    }
}
