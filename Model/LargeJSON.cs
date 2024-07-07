namespace Lazy_Loading_API.Model
{
	public class LargeJSON
	{

		public class Rootobject
		{
			public string id { get; set; }
			public string type { get; set; }
			public Actor actor { get; set; }
			public Repo repo { get; set; }
			public Payload payload { get; set; }
			public bool _public { get; set; }
			public DateTime created_at { get; set; }
		}

		public class Actor
		{
			public int id { get; set; }
			public string login { get; set; }
			public string gravatar_id { get; set; }
			public string url { get; set; }
			public string avatar_url { get; set; }
		}

		public class Repo
		{
			public int id { get; set; }
			public string name { get; set; }
			public string url { get; set; }
		}

		public class Payload
		{
			public string _ref { get; set; }
			public string ref_type { get; set; }
			public string master_branch { get; set; }
			public string description { get; set; }
			public string pusher_type { get; set; }
		}

	}
}
