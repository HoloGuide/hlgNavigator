using System;
using System.IO;
using System.Collections.Generic;

#if !UNITY_EDITOR && UNITY_WSA
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Streams;
#endif

public static class OpenFileHelper
{
    /// <summary>
    /// Opens the specified file for writing.
    /// </summary>
    /// <param name="folderName">The name of the folder containing the file.</param>
    /// <param name="fileName">The name of the file, including extension.</param>
    /// <returns>Stream used for writing the file's data.</returns>
    /// <remarks>If the specified file already exists, it will be overwritten.</remarks>
    public static Stream OpenFileForWrite(string folderName, string fileName)
    {
        Stream stream = null;

#if !UNITY_EDITOR && UNITY_WSA
            Task<Task> task = Task<Task>.Factory.StartNew(
                            async () =>
                            {
                                StorageFolder folder = await StorageFolder.GetFolderFromPathAsync(folderName);
                                StorageFile file = await folder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
                                IRandomAccessStream randomAccessStream = await file.OpenAsync(FileAccessMode.ReadWrite);
                                stream = randomAccessStream.AsStreamForWrite();
                            });
            task.Wait();
            task.Result.Wait();
#else
        stream = new FileStream(Path.Combine(folderName, fileName), FileMode.Create, FileAccess.Write);
#endif
        return stream;
    }

    /// <summary>
    /// Opens the specified file for reading.
    /// </summary>
    /// <param name="folderName">The name of the folder containing the file.</param>
    /// <param name="fileName">The name of the file, including extension. </param>
    /// <returns>Stream used for reading the file's data.</returns>
    public static Stream OpenFileForRead(string folderName, string fileName)
    {
        Stream stream = null;

#if !UNITY_EDITOR && UNITY_WSA
            Task<Task> task = Task<Task>.Factory.StartNew(
                            async () =>
                            {
                                StorageFolder folder = await StorageFolder.GetFolderFromPathAsync(folderName);
                                StorageFile file = await folder.GetFileAsync(fileName);
                                IRandomAccessStreamWithContentType randomAccessStream = await file.OpenReadAsync();
                                stream = randomAccessStream.AsStreamForRead();
                            });
            task.Wait();
            task.Result.Wait();
#else
        stream = new FileStream(Path.Combine(folderName, fileName), FileMode.Open, FileAccess.Read);
#endif
        return stream;
    }

}
