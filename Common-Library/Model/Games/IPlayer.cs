﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonLibrary.Model
{
    public interface IPlayer
    {
        string Name { get; }
        int Score { get; }
    }
}