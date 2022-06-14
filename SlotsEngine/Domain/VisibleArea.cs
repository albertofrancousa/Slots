namespace SlotsEngine.Domain
{
	public class VisibleArea : IVisibleArea
	{
		public int Rows { get; set; }

		public int Columns { get; set; }

		public VisibleArea(int rows, int columns)
		{
			Rows = rows;
			Columns = columns;
		}
	}
}
