﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4Gewinnt
{
    public interface ITreeElement<T>
    {
        T[] GetAllPossibilities();
        int GetHeuristik();

       void  SetHeuristik(int Heuristik);
    }
}
