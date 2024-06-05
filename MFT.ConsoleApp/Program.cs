// See https://aka.ms/new-console-template for more information


using MFT.Abstractions;
using MFT.Logic;
using System.Diagnostics;

IFileSystem fileSystem = new FileSystem();

var stopWatch = Stopwatch.StartNew();

var files = fileSystem.GetFiles("D:\\photo\\2023");

stopWatch.Stop();

Console.WriteLine($"Found {files.Count}. Time elapsed {stopWatch.Elapsed}");
