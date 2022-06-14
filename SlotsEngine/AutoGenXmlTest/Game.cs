namespace SlotsEngine.AutoGenXmlTest
{


	// NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
	public partial class Game
	{

		private GameBetInfo betInfoField;

		private GameVisibleArea visibleAreaField;

		private GamePaylines paylinesField;

		private GameSymbols symbolsField;

		private GameReels reelsField;

		private GamePayTable payTableField;

		private string nameField;

		/// <remarks/>
		public GameBetInfo BetInfo
		{
			get
			{
				return this.betInfoField;
			}
			set
			{
				this.betInfoField = value;
			}
		}

		/// <remarks/>
		public GameVisibleArea VisibleArea
		{
			get
			{
				return this.visibleAreaField;
			}
			set
			{
				this.visibleAreaField = value;
			}
		}

		/// <remarks/>
		public GamePaylines Paylines
		{
			get
			{
				return this.paylinesField;
			}
			set
			{
				this.paylinesField = value;
			}
		}

		/// <remarks/>
		public GameSymbols Symbols
		{
			get
			{
				return this.symbolsField;
			}
			set
			{
				this.symbolsField = value;
			}
		}

		/// <remarks/>
		public GameReels Reels
		{
			get
			{
				return this.reelsField;
			}
			set
			{
				this.reelsField = value;
			}
		}

		/// <remarks/>
		public GamePayTable PayTable
		{
			get
			{
				return this.payTableField;
			}
			set
			{
				this.payTableField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string name
		{
			get
			{
				return this.nameField;
			}
			set
			{
				this.nameField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GameBetInfo
	{

		private byte amountField;

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public byte Amount
		{
			get
			{
				return this.amountField;
			}
			set
			{
				this.amountField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GameVisibleArea
	{

		private byte rowsField;

		private byte columnsField;

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public byte Rows
		{
			get
			{
				return this.rowsField;
			}
			set
			{
				this.rowsField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public byte Columns
		{
			get
			{
				return this.columnsField;
			}
			set
			{
				this.columnsField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GamePaylines
	{

		private GamePaylinesPayline[] paylineField;

		private string nameField;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("Payline")]
		public GamePaylinesPayline[] Payline
		{
			get
			{
				return this.paylineField;
			}
			set
			{
				this.paylineField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string name
		{
			get
			{
				return this.nameField;
			}
			set
			{
				this.nameField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GamePaylinesPayline
	{

		private string nameField;

		private string verticalOffsetsField;

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string name
		{
			get
			{
				return this.nameField;
			}
			set
			{
				this.nameField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string VerticalOffsets
		{
			get
			{
				return this.verticalOffsetsField;
			}
			set
			{
				this.verticalOffsetsField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GameSymbols
	{

		private GameSymbolsSymbol[] symbolField;

		private string nameField;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("Symbol")]
		public GameSymbolsSymbol[] Symbol
		{
			get
			{
				return this.symbolField;
			}
			set
			{
				this.symbolField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string name
		{
			get
			{
				return this.nameField;
			}
			set
			{
				this.nameField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GameSymbolsSymbol
	{

		private string nameField;

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string name
		{
			get
			{
				return this.nameField;
			}
			set
			{
				this.nameField = value;
			}
		}

		public override string ToString()
		{
			return this.nameField;
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GameReels
	{

		private GameReelsReel[] reelField;

		private string nameField;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("Reel")]
		public GameReelsReel[] Reel
		{
			get
			{
				return this.reelField;
			}
			set
			{
				this.reelField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string name
		{
			get
			{
				return this.nameField;
			}
			set
			{
				this.nameField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GameReelsReel
	{

		private string nameField;

		private string symbolsField;

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string name
		{
			get
			{
				return this.nameField;
			}
			set
			{
				this.nameField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Symbols
		{
			get
			{
				return this.symbolsField;
			}
			set
			{
				this.symbolsField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GamePayTable
	{

		private GamePayTablePay[] payField;

		private string nameField;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("Pay")]
		public GamePayTablePay[] Pay
		{
			get
			{
				return this.payField;
			}
			set
			{
				this.payField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string name
		{
			get
			{
				return this.nameField;
			}
			set
			{
				this.nameField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class GamePayTablePay
	{

		private string exactMatchField;

		private ushort amountField;

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string ExactMatch
		{
			get
			{
				return this.exactMatchField;
			}
			set
			{
				this.exactMatchField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public ushort Amount
		{
			get
			{
				return this.amountField;
			}
			set
			{
				this.amountField = value;
			}
		}
	}
}
