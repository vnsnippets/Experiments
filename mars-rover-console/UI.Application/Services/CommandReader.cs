using System;
using Domain.Entities;

namespace UI.Application.Services
{
    public class CommandReader
    {
        public static Platform ParsePlatformParameters(string command)
        {
            try
            {
                string[] Parameters = command.Split(" ");
                if (Parameters.Length != 2)
                    throw new Exception("ERROR: Inavlid platform limits.");

                var Result = new Platform();
                Result.LimitX = int.Parse(Parameters[0]);
                Result.LimitY = int.Parse(Parameters[1]);

                return Result;
            }
            catch (Exception)
            {
                throw new Exception("ERROR: Platform limits must be integers.");
            }
        }

        public static Rover ParseRoverParameters(string command)
        {
            string[] Parameters = command.Split(" ");
            if (Parameters.Length != 3)
                throw new Exception("ERROR: Invalid rover landing position.");

            if (Parameters[2].ToUpper() != "N" &&
                Parameters[2].ToUpper() != "S" &&
                Parameters[2].ToUpper() != "E" &&
                Parameters[2].ToUpper() != "W")
                throw new Exception("ERROR: Invalid rover heading.");

            var Result = new Rover();
            try
            {
                Result.Position.X = int.Parse(Parameters[0]);
                Result.Position.Y = int.Parse(Parameters[1]);
            }
            catch
            {
                throw new Exception("ERROR: Rover landing coordinates must be integers.");
            }

            Result.Heading = char.Parse(Parameters[2].ToUpper());

            return Result;
        }
    }
}
