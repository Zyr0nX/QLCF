﻿using PhanMemQLCafe.DTOModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhanMemQLCafe.DAOModel
{
    public class FoodDAO
    {
        private static FoodDAO instance;

        public static FoodDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FoodDAO();
                }
                return instance;
            }

            private set
            {
                instance = value;
            }
        }

        private FoodDAO() { }

        public List<Food> GetFoodByCategoryID(int id)
        {
            List<Food> list = new List<Food>();

            string query = "SELECT * FROM Food WHERE CategoryID = "+id+"";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Food food = new Food(item);

                list.Add(food);
            }

            return list;
        }
    }
}
