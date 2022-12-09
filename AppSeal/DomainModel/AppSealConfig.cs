using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSeal.DomainModel
{
	public class AppSealConfig
	{
		public string SignTool { get; set; }
		public List<SealProfile> SealProfiles { get; set; }
	}
}
