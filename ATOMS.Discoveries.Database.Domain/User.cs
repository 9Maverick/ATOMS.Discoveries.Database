namespace Atoms.Discoveries.Database.Domain;

public class User
{
	public ulong Id { get; set; }
	public string NickName { get; set; }
	public List<Discovery> Discoveries { get; set; }

	public User(string nickName)
	{
		NickName = nickName;
		Discoveries = new List<Discovery>();
	}

	public User(ulong id, string nickName)
	{
		Id = id;
		NickName = nickName;
		Discoveries = new List<Discovery>();
	}
	private User() : this(null!) { }
}