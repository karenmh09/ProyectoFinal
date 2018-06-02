using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.Modelo
{
	public class Meals
	{
		public List<Recipe> meals { get; set; }
	}

	public class Recipe
	{
		public int idMeal { get; set; }
		public String strMeal { get; set; }
		public String strCategory { get; set; }
		public String strInstructions { get; set; }
		public String strMealThumb { get; set; }
		public String strYoutube { get; set; }
		public String strIngredient1 { get; set; }
		public String strIngredient2 { get; set; }
		public String strIngredient3 { get; set; }
		public String strIngredient4 { get; set; }
		public String strIngredient5 { get; set; }
		public String strIngredient6 { get; set; }
		public String strIngredient7 { get; set; }
		public String strIngredient8 { get; set; }
		public String strIngredient9 { get; set; }
		public String strIngredient10 { get; set; }
		public String strIngredient11 { get; set; }
		public String strIngredient12 { get; set; }
		public String strIngredient13 { get; set; }
		public String strIngredient14 { get; set; }
		public String strIngredient15 { get; set; }
		public String strIngredient16 { get; set; }
		public String strIngredient17 { get; set; }
		public String strIngredient18 { get; set; }
		public String strIngredient19 { get; set; }
		public String strIngredient20 { get; set; }
		public String strMeasure1 { get; set; }
		public String strMeasure2 { get; set; }
		public String strMeasure3 { get; set; }
		public String strMeasure4 { get; set; }
		public String strMeasure5 { get; set; }
		public String strMeasure6 { get; set; }
		public String strMeasure7 { get; set; }
		public String strMeasure8 { get; set; }
		public String strMeasure9 { get; set; }
		public String strMeasure10 { get; set; }
		public String strMeasure11 { get; set; }
		public String strMeasure12 { get; set; }
		public String strMeasure13 { get; set; }
		public String strMeasure14 { get; set; }
		public String strMeasure15 { get; set; }
		public String strMeasure16 { get; set; }
		public String strMeasure17 { get; set; }
		public String strMeasure18 { get; set; }
		public String strMeasure19 { get; set; }
		public String strMeasure20 { get; set; }

		public String getIngredientes()
		{
			String ingredients =
				strMeasure1 + " of " + strIngredient1;

			if (strMeasure2 != null && strMeasure2.Length > 0)
				ingredients += "\n" + strMeasure2 + " of " + strIngredient2;

			if (strMeasure3 != null && strMeasure3.Length > 0)
				ingredients += "\n" + strMeasure3 + " of " + strIngredient3;

			if (strMeasure4 != null && strMeasure4.Length > 0)
				ingredients += "\n" + strMeasure4 + " of " + strIngredient4;

			if (strMeasure5 != null && strMeasure5.Length > 0)
				ingredients += "\n" + strMeasure5 + " of " + strIngredient5;

			if (strMeasure6 != null && strMeasure6.Length > 0)
				ingredients += "\n" + strMeasure6 + " of " + strIngredient6;

			if (strMeasure7 != null && strMeasure7.Length > 0)
				ingredients += "\n" + strMeasure7 + " of " + strIngredient7;

			if (strMeasure8 != null && strMeasure8.Length > 0)
				ingredients += "\n" + strMeasure8 + " of " + strIngredient8;

			if (strMeasure9 != null && strMeasure9.Length > 0)
				ingredients += "\n" + strMeasure9 + " of " + strIngredient9;

			if (strMeasure10 != null && strMeasure10.Length > 0)
				ingredients += "\n" + strMeasure10 + " of " + strIngredient10;

			if (strMeasure11 != null && strMeasure11.Length > 0)
				ingredients += "\n" + strMeasure11 + " of " + strIngredient11;

			if (strMeasure12 != null && strMeasure12.Length > 0)
				ingredients += "\n" + strMeasure12 + " of " + strIngredient12;

			if (strMeasure13 != null && strMeasure13.Length > 0)
				ingredients += "\n" + strMeasure13 + " of " + strIngredient13;

			if (strMeasure14 != null && strMeasure14.Length > 0)
				ingredients += "\n" + strMeasure14 + " of " + strIngredient14;

			if (strMeasure15 != null && strMeasure15.Length > 0)
				ingredients += "\n" + strMeasure15 + " of " + strIngredient15;

			if (strMeasure16 != null && strMeasure16.Length > 0)
				ingredients += "\n" + strMeasure16 + " of " + strIngredient16;

			if (strMeasure17 != null && strMeasure17.Length > 0)
				ingredients += "\n" + strMeasure17 + " of " + strIngredient17;

			if (strMeasure18 != null && strMeasure18.Length > 0)
				ingredients += "\n" + strMeasure18 + " of " + strIngredient18;

			if (strMeasure19 != null && strMeasure19.Length > 0)
				ingredients += "\n" + strMeasure19 + " of " + strIngredient19;

			if (strMeasure20 != null && strMeasure20.Length > 0)
				ingredients += "\n" + strMeasure20 + " of " + strIngredient20;

			return ingredients;
		}
	}
}
