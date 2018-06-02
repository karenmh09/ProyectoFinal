using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.Modelo
{
	public class Categories
	{
		public List<Category> categories { get; set; }
	}

	public class Category
	{
		public String idCategory { get; set; }
		public String strCategory { get; set; }
		public String strCategoryThumb { get; set; }
		public String strCategoryDescription { get; set; }
	}
}
