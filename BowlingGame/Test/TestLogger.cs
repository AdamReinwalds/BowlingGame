﻿using BowlingGame.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGame.Test
{
    public class TestLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message + "test");
        }
    }
}
