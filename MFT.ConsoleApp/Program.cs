// See https://aka.ms/new-console-template for more information
using MFT.Abstractions;
using MFT.Logic.Extensions;
using MFT.Logic.Services;

IFileSystem fileSystem = new FileSystem();

var replicaDirectory = "C:\\GPhoto_2021";
var originalDirectory = "D:\\photo\\2021";
var resultDirectory = "C:\\Photo_Result";

var modifiedFiles = fileSystem.GetFiles(replicaDirectory);
Console.WriteLine($"{replicaDirectory} found {modifiedFiles.Count} files");

var originalFiles = fileSystem.GetFiles(originalDirectory, modifiedFiles.GetUniqueFileExtenssions());
Console.WriteLine($"{originalDirectory} found {originalFiles.Count} files");

// var sFiles = modifiedFiles.Except(originalFiles, new FileInfoSizeComparer()).ToList();

var result = modifiedFiles.GetBiggerFiles(originalFiles);

int count = fileSystem.CopyFiles(result, resultDirectory, "_bigger");
Console.WriteLine($"{resultDirectory} copied {count} files");


Console.ReadKey();
