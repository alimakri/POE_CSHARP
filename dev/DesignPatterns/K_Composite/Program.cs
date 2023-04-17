using K_Composite;
var root = new DirectoryElement("root");
var folder1 = new DirectoryElement("folder1");
var folder2 = new DirectoryElement("folder2");
var folder3 = new DirectoryElement("folder3");

var file1 = new FileElement("file1_folder1");
var file2 = new FileElement("file2_folder1");
var file3 = new FileElement("file3_folder2");
var file4 = new FileElement("file4_folder2");
var file5 = new FileElement("file5_folder2");
var file6 = new FileElement("file6_folder2");

root.Add(folder1);
folder1.Add(folder2);
folder2.Add(file6);
root.Add(folder3);
folder1.Add(file1);
folder1.Add(file2);
folder2.Add(file3);
folder2.Add(file4);
folder2.Add(file5);

var n = folder1.Count;

Console.WriteLine(n);