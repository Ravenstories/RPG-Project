﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Models;

namespace Engine.Factories
{
    internal static class QuestFactory
    {
        private static readonly List<Quests> _quests = new List<Quests>();

        static QuestFactory() 
        {
            //Declare the items need to complete the quest and its reward items
            List<ItemQuantity> itemsToComplete = new List<ItemQuantity>();
            List<ItemQuantity> rewardItems = new List<ItemQuantity>();

            itemsToComplete.Add(new ItemQuantity(9001, 5));
            rewardItems.Add(new ItemQuantity(1002, 1));
            rewardItems.Add(new ItemQuantity(4001, 1));

            // Create Quest. Parameters ID, Name, Description, Items to complete, EXP reward, Gold reward, Items reward.
            //Quest 1: Dræb Slanger
            _quests.Add(new Quests(
                1,
                "Clear the herb garden",
                "'Oh please help me! My garden is crawling with snakes! Kill them and bring me proof and I will give you my old sword.'",
                itemsToComplete, 25, 10, rewardItems));

            //Quest 2: Dræb Rotter Pest Control

            List<ItemQuantity> itemsToComplete2 = new List<ItemQuantity>();
            List<ItemQuantity> rewardItems2 = new List<ItemQuantity>();

            itemsToComplete2.Add(new ItemQuantity(9003, 6));
            rewardItems2.Add(new ItemQuantity(1003, 1));

            _quests.Add(new Quests(
               2,
               "Pest control",
               @"'Damit!! Rat's have infested my fields. Without the crops the town will starve..You will help? Good!' The farmer looks out into the field 'But be careful of the scarecrow, my son said that it have become haunted",      
               
               itemsToComplete2, 40, 10, rewardItems2 ));
                
            //Quest 3: Tore's Bug Quest

            List<ItemQuantity> itemsToComplete3 = new List<ItemQuantity>();
            List<ItemQuantity> rewardItems3 = new List<ItemQuantity>();

            itemsToComplete3.Add(new ItemQuantity(9005, 2));
            rewardItems3.Add(new ItemQuantity(2002, 2));

            _quests.Add(new Quests(
                3,
                "Tore's Quest",
                @"'Bugs! To the East! Get rid of them before it's to late!\n'",
                itemsToComplete3, 50, 50,rewardItems3 ));
            
        }
        internal static Quests GetQuestByID(int id) 
        {
            return _quests.FirstOrDefault(quests => quests.ID == id);
        }
    }
}
