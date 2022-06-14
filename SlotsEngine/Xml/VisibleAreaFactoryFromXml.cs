using SlotsEngine.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SlotsEngine.Xml
{
	public class VisibleAreaFactoryFromXml : IVisibleAreaFactory
	{
		public IVisibleArea CreateVisibleArea(XElement element)
		{
			var rows = GetRows(element);
			var columns = GetColumns(element);
			var visibleArea = new VisibleArea(rows, columns);
			return visibleArea;
		}

		private int GetRows(XElement element)
		{
			var rowsValue = element.Attribute("Rows").Value;
			var rows = int.Parse(rowsValue);
			return rows;
		}

		private int GetColumns(XElement element)
		{
			var columnsValue = element.Attribute("Columns").Value;
			var columns = int.Parse(columnsValue);
			return columns;
		}
	}
}
