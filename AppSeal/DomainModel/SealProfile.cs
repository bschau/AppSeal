namespace AppSeal.DomainModel
{
	public class SealProfile
	{
		public string Name { get; set; }
		public string Thumbprint { get; set; }
		public string TimeStampUrl { get; set; }
		public string TimeStampHash { get; set; }
		public string Description { get; set; }
		public string DescriptionUrl { get; set; }

		public override string ToString()
		{
			return Name;
		}
	}
}
