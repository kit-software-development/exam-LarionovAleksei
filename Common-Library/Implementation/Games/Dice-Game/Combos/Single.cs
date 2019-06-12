﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CommonLibrary.Model.Games.Dice;

namespace CommonLibrary.Implementation.Games.Dice.Combos
{
    public class Single : Combo
    {
        public override ComboMaxResult GetMaxCombo(List<IDie> dice, bool is_sorted)
        {
            List<IDie> dice_copy = dice;
            byte[] found_combo_sides = new byte[6];
            ComboMaxResult result = new ComboMaxResult();
            for (int i = 0; i < dice_copy.Count; ++i)
            {
                IDie die = dice_copy[i];
                if (die.Side == DieSide.JOKER)
                {
                    continue;
                }
                ++found_combo_sides[(int)die.Side];
            }

            int search_count = 1;
            DieSide search_for = DieSide.ONE;
            bool combo_exists = true;
            if (found_combo_sides[0] >= 2)
            {
                result.Score = 20;
                result.Name = "1+1";
                search_count = 2;
            }
            else if (found_combo_sides[0] == 1)
            {
                result.Score = 10;
                result.Name = "1";
            }
            else
            {
                search_for = DieSide.FIVE;
                if (found_combo_sides[4] >= 2)
                {
                    result.Score = 10;
                    result.Name = "5+5";
                    search_count = 2;
                }
                else if (found_combo_sides[4] == 1)
                {
                    result.Score = 5;
                    result.Name = "5";
                }
                else
                {
                    combo_exists = false;
                }
            }
            if (!combo_exists)
            {
                return null;
            }
            for (int i = 0; i < dice_copy.Count && search_count > 0; ++i)
            {
                IDie die = dice_copy[i];
                if (die.Side == search_for)
                {
                    result.DiceInCombo.Add(die);
                    --search_count;
                }
            }
            return result;
        }
    }
}