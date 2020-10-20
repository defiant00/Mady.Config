using System.Collections.Generic;

namespace Mady.Config
{
	public class Config
	{
		private Dictionary<string, string> Flags = new Dictionary<string, string>();
		private List<string> Files = new List<string>();

		public bool IsSet(string flag) => Flags.ContainsKey(flag);

		public string this[string flag]
		{
			get => Flags[flag];
			set => Flags[flag] = value;
		}

		public Config(string[] args)
		{
			foreach (string arg in args)
			{
				if (arg[0] == '/')
				{
					int ind = arg.IndexOf(':');
					string key = arg;
					string val = null;
					if (ind > -1)
					{
						key = arg.Substring(0, ind);
						val = arg.Substring(ind + 1);
					}
					Flags[key.Substring(1)] = val;
				}
				else { Files.Add(arg); }
			}
		}
	}
}
