﻿using System;

namespace GuardiansOfTheCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //PrimaryPlayer player = PrimaryPlayer.Instance;
            //Console.WriteLine($"{player.Name} - lvl {player.Level}");

            Gameboard board = new Gameboard();
            board.PlayArea(1);
        }
    }
}
