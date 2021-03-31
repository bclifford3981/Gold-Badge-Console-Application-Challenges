using CafeRepo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CafeRepoTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddMenuItem()
        {
            MenuItem cafe = new MenuItem();
            Cafe_Repo cafeRepo = new Cafe_Repo();

            bool added = cafeRepo.AddMenuItem(cafe);

            Assert.IsTrue(added);

            Console.WriteLine(added);
        }
        [TestMethod]
        public void ReadMenuItem()
        {
            MenuItem cafe = new MenuItem();
            Cafe_Repo cafeRepo = new Cafe_Repo();

            cafeRepo.AddMenuItem(cafe);

            List<MenuItem> menuitems = cafeRepo.ReadMenu();

            bool menuHasItems = menuitems.Contains(cafe);

            Assert.IsTrue(menuHasItems);

            Console.WriteLine(menuHasItems);
        }
        [TestMethod]
        public void DeleteMenuItems()
        {
            MenuItem cafe;
            MenuItem menuItem = new MenuItem(111, "asl;dkf", "asdf", "asdf", 22.22);

            Cafe_Repo cafe_Repo = new Cafe_Repo();
            cafe_Repo.AddMenuItem(menuItem);
            cafe = cafe_Repo.ReadMenuByItemNumber(111);
            bool delete = cafe_Repo.DeleteMenuItem(cafe);
            Assert.IsTrue(delete);
            Console.WriteLine(delete);
        }
    }
}
