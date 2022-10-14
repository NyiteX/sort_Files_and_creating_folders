string directory = "D:\\Test";
string? subdirectory;
foreach (var fi in new DirectoryInfo(directory).EnumerateFiles("*.*", SearchOption.AllDirectories))
{  
    string ext = fi.Name.Substring(fi.Name.LastIndexOf('.'));
    if (ext == ".jpg" || ext == ".png" || ext == ".jpeg")    subdirectory = "Pictures";
    else if (ext == ".mp3" || ext == ".flac" || ext == ".wave")    subdirectory = "Music";
    else if (ext == ".mp4" || ext == ".mkv" || ext == ".avi")     subdirectory = "Video";
    else      subdirectory = "Documents";
    string newPath = directory + "\\" + subdirectory;

    if (!Directory.Exists(newPath))
    {
        Directory.CreateDirectory(newPath);
        Console.WriteLine("Была создана папка: " + newPath);
    }
    newPath += "\\" + fi.Name;
    File.Move(fi.FullName, newPath);
    Console.WriteLine("\nФайл "+ fi.FullName + " был перемещен в папку" + newPath);
}