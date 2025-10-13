using FileHandlingTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace FileHandlingTest.Controllers
{
    public class FileController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(new PearsonViewModel());
        }

        public IActionResult CreateFile(PearsonViewModel personViewModel)
        {
            string directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "Files");
            string fileName = $"Name_{DateTime.Now.ToString("MMddyyyyHHmmss")}.txt";

            FileInfo fileInfo = new FileInfo(directoryPath + "\\" + fileName);
            fileInfo.Create().Close();

            using (StreamWriter writer = fileInfo.AppendText())
            {
                writer.WriteLine($"Name: {Reverse(personViewModel.Name ?? string.Empty)}");
                writer.WriteLine($"Age: {Reverse(personViewModel.Age?.ToString() ?? string.Empty)}");
                writer.WriteLine($"Gender: {Reverse(personViewModel.Gender ?? string.Empty)}");
            }

            return View(personViewModel);
        }

        [HttpGet]
        public IActionResult Read()
        {
            string directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "Files");
            string[] filePaths = Directory.GetFiles(directoryPath, "*.txt");

            // Map the file paths to a list of FileListViewModel objects
            List<FileListViewModel> fileList = filePaths
                .Select(filePath => new FileListViewModel { FileName = Path.GetFileName(filePath), FilePath = filePath })
                .ToList();

            return View(fileList);
        }

        public IActionResult View(string path)
        {
            FileInfo fileInfo = new FileInfo(path);

            List<string> lines = new List<string>();
            using (StreamReader reader = new StreamReader(fileInfo.FullName))
            {
                string? line; // Allow line to be nullable
                while ((line = reader.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }

            PearsonViewModel persons = new PearsonViewModel();

            foreach (var line in lines)
            {
                if (line.StartsWith("Name:"))
                {
                    persons.Name = Reverse(line.Substring(5).Trim());
                }
                else if (line.StartsWith("Age:"))
                {
                    if (int.TryParse(Reverse(line.Substring(4).Trim()), out int age))
                    {
                        persons.Age = age;
                    }
                }
                else{
                    persons.Gender = Reverse(line.Substring(7).Trim());
                }               
            }
              
            return View(persons);
        }

        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
