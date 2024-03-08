using Domain.Entities;
using Services.Implementation;
using System;
using System.IO;
using UI.Application.Services;

namespace UI.Application
{
    public class Program
    {
        static void Main(string[] args)
        {
            string FileURI;
            string[] Instructions;

            while (true)
            {
                try
                {
                    Console.WriteLine("\nWELCOME TO ROVER CONTROL 1.0.\nPlease enter link to your instructions file: ");
                    FileURI = Console.ReadLine();

                    if (!FileURI.Trim().EndsWith(".txt"))
                        throw new Exception("ERROR: File is not in the .txt format.");

                    Instructions = File.ReadAllLines(@FileURI);

                    // READING PLATFORM DATA
                    int Index = 0;
                    while (Instructions[Index].Trim() == string.Empty) Index++;

                    Platform PlatformData = CommandReader.ParsePlatformParameters(Instructions[Index++].Trim());

                    var Controller = new RoverController(PlatformData);

                    // READING ROVER DATA
                    for (int i = Index; i < Instructions.Length; i++)
                    {
                        while (Instructions[i].Trim() == string.Empty) i++;

                        try
                        {
                            var rover = CommandReader.ParseRoverParameters(Instructions[i].Trim());
                            Controller.InitializeRover(rover);

                            do { ++i; } while (Instructions[i].Trim() == string.Empty);

                            string command = Instructions[i].Trim().ToUpper();

                            for (int j = 0; j < command.Length; j++)
                            {
                                char c = command[j];
                                switch (c)
                                {
                                    case 'L':
                                        Controller.TurnRoverLeft();
                                        break;

                                    case 'R':
                                        Controller.TurnRoverRight();
                                        break;

                                    case 'M':
                                        Controller.MoveRover();
                                        break;

                                    default:
                                        throw new Exception("ERROR: Invalid rover command.");
                                }
                            }

                            Console.WriteLine(string.Format("{0} {1} {2}", Controller.MarsRover.Position.X, Controller.MarsRover.Position.Y, rover.Heading));
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
                catch (IndexOutOfRangeException ex)
                {
                    Console.WriteLine("Reached end of instruction file.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Try again.\n\n");
                }
            }
        }
    }
}
